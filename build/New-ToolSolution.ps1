<#
.SYNOPSIS
  Creates a new repository by copying this template repo into a target directory.

.EXAMPLE
  pwsh ./build/New-ToolSolution.ps1 -TargetDir ..\MyNewTool
#>
param(
  [string]$TargetDir = "..\MyNewTool"
)

$ErrorActionPreference = "Stop"
$templateRoot = Split-Path $PSScriptRoot -Parent

if (Test-Path $TargetDir) {
  throw "TargetDir already exists: $TargetDir"
}

Write-Host "Creating new repo at: $TargetDir"
New-Item -ItemType Directory -Path $TargetDir -Force | Out-Null

$items = @(
  ".github",
  "build",
  "docs",
  "samples",
  "src",
  "tests",
  "tools",
  ".editorconfig",
  "global.json",
  "README.md"
)

foreach ($i in $items) {
  $src = Join-Path $templateRoot $i
  $dst = Join-Path $TargetDir $i
  Write-Host "Copying $i ..."
  Copy-Item $src $dst -Recurse -Force
}

Write-Host "Done."
Write-Host "Open: $TargetDir\src\Tool.sln"
