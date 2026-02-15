# Pull Request – Architecture Gate

## Summary
Describe what this PR changes.

## Type
- [ ] Feature
- [ ] Bug Fix
- [ ] Refactor
- [ ] Security
- [ ] Docs

## Architecture Gate
Dependency direction must remain:
UI → Application → Core; Infrastructure → Core; Host → (UI + Application + Infrastructure)

- [ ] No backward dependencies introduced
- [ ] No circular project references
- [ ] No business logic in UI

## Layer Impact
- [ ] Core
- [ ] Application
- [ ] Infrastructure
- [ ] UI
- [ ] Host.Desktop
- [ ] Host.RestServer

## Tests
- [ ] Added/updated tests
- [ ] CI passes
