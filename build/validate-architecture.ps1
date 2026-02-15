param(
    [string]$SolutionPath = "src\Tool.sln",
    [string]$RulesPath = "build\architecture-rules.json"
)

$ErrorActionPreference = "Stop"

Write-Host "Loading architecture rules from $RulesPath ..."
$rules = Get-Content $RulesPath -Raw | ConvertFrom-Json
$allowed = $rules.allowedDependencies

Write-Host "Scanning .csproj files under src/ and tests/ ..."
$csprojs = Get-ChildItem -Path "." -Recurse -Filter "*.csproj" |
  Where-Object { $_.FullName -notmatch "\\obj\\|\\bin\\" } |
  ForEach-Object { $_.FullName }

$violations = New-Object System.Collections.Generic.List[string]

foreach ($projPath in $csprojs) {
    $projName = [System.IO.Path]::GetFileNameWithoutExtension($projPath)

    if (-not ($allowed.PSObject.Properties.Name -contains $projName)) {
        continue
    }

    Write-Host "Checking $projName ..."

    $xml = [xml](Get-Content $projPath -Raw)
    $refNodes = @()
    foreach ($ig in $xml.Project.ItemGroup) {
        foreach ($pr in $ig.ProjectReference) {
            $refNodes += $pr
        }
    }

    foreach ($refNode in $refNodes) {
        $ref = $refNode.Include
        $refName = [System.IO.Path]::GetFileNameWithoutExtension($ref)
        $allowedTargets = $allowed.$projName

        if ($allowedTargets -notcontains $refName) {
            $violations.Add("$projName -> $refName is NOT allowed")
        }
    }
}

if ($violations.Count -gt 0) {
    Write-Host ""
    Write-Host "ARCHITECTURE VIOLATIONS DETECTED:"
    $violations | ForEach-Object { Write-Host "  - $_" }
    exit 1
}

Write-Host "Architecture validation passed."
