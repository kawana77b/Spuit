---
name: maintain-dotnet-stack
description: Update this solution's .NET runtime and SDK, NuGet dependencies, release CI, and related documentation while preserving application behavior. Use for .NET maintenance or LTS migrations, dependency refreshes, and release-workflow compatibility reviews.
---

# Maintain the .NET Stack

Keep the solution supported and its release pipeline working without changing application features, output formats, or UI behavior. Honor a narrower request, such as reviewing CI alone. Commit-message drafting is outside this workflow.

## Repository context

Confirm these paths and settings against the current checkout before editing:

- `Spuit.sln`: the solution.
- `src/Spuit.Core/Spuit.Core.csproj`: Windows library using WPF and Windows Forms; declares x86 and x64 runtime identifiers.
- `src/Spuit.WPF/Spuit.WPF.csproj`: WPF executable; publishes for Windows x64 as a self-contained, single-file application. Native DLLs can remain beside the executable and must be packaged too.
- `global.json`: SDK selection policy, when present.
- `.github/workflows/release.yml`: version-tag workflow that packages the application with README and LICENSE, then creates a draft GitHub release with generated notes.
- `README.md`: installation, platform, and build requirements.

## Inspect and establish a baseline

Read applicable repository instructions and inspect the working tree before making changes. Preserve existing user edits. Inspect all project files, shared MSBuild/package configuration, package sources, SDK selection, and relevant workflows rather than assuming the repository still matches this map.

Record installed SDKs and runtimes, current target frameworks, direct and transitive dependencies, and existing build warnings. Run a baseline Release build when practical. Determine whether actual test projects exist; a successful `dotnet test` invocation with no tests is not test coverage.

## Verify supported versions

Use current primary sources rather than remembered version numbers:

- [.NET support policy](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core): LTS status and support dates.
- [NuGet](https://www.nuget.org/): stable package versions, compatibility, deprecations, and vulnerability information. Check package owners' release notes for relevant changes.
- [.NET compatibility documentation](https://learn.microsoft.com/en-us/dotnet/core/compatibility/): breaking changes across every skipped major version, especially WPF, Windows Forms, drawing, globalization, and JSON behavior used here.
- The referenced Actions' official repositories and versioned `action.yml` files: maintained releases, inputs, outputs, and runner requirements.

Choose a supported stable target consistent with the user's request, normally the current LTS. Do not adopt previews unless requested. Distinguish the target framework, selected SDK, and runtime patch bundled in a self-contained release; updating one does not prove the others changed.

## Apply focused updates

Update related target frameworks together and keep SDK selection, CI setup, and documented requirements consistent. If SDK selection needs a constraint, use a policy that stays within the chosen stable major/minor while allowing its serviced SDKs, such as `latestFeature` with `allowPrerelease: false`. Installing an SDK with `setup-dotnet` alone does not guarantee that SDK wins selection on a runner with newer SDKs.

Use NuGet's outdated, vulnerable, and deprecated package reports, including transitive dependencies. Keep packages already at a suitable current stable version. Review major upgrades for breaking changes and update only the references needed. Avoid overriding transitive packages or adding runtime/tooling version pins without understanding their effect on SDK-managed dependencies and publishing.

Preserve runtime identifiers, self-contained deployment, single-file settings, localization, and existing behavior unless a compatibility fix is necessary. Keep any such fix small and explain why it is needed. Update documentation only where requirements, commands, or links changed. Do not alter dependency-update schedules or unrelated configuration as part of routine maintenance.

## Review the release workflow

Check the workflow from tag trigger through asset upload:

- Verify the tag-to-version conversion. Remove only the leading `v`; replacing every `v` corrupts suffixes such as `preview`. Pass tag data through environment variables rather than interpolating it into PowerShell source.
- Confirm the shell, command options, configuration, target project/solution, and restore/build/publish ordering. Use `--no-restore` or `--no-build` only when the required matching outputs already exist. Check native command exit codes when several commands share a step.
- Quote paths and property arguments using the actual shell's syntax. Inspect raw file contents and reproduce argument passing before diagnosing an escaping issue; tool-result JSON may display escaped quotes that are absent from the file.
- Check Actions' supported runtime and runner versions before changing their major versions. Confirm release-token permissions, step-output references, tag association, and asset paths against the chosen Action's manifest.
- Preserve the existing draft-release intent, generated notes, ZIP naming convention, and archive layout unless the user asks to change them. Detect a missing executable before packaging and configure missing upload files to fail the release step.

## Validate the result

Run an appropriate Release build and publish the WPF project using the workflow's actual options. Check the emitted runtime configuration to identify the bundled runtime patch. If verifying a newer patch via a command-line override, report that separately from the committed defaults.

Re-run dependency reports and distinguish known NuGet findings from broader security guarantees. Use existing tests where available. For runtime changes affecting observable output, a temporary comparison of baseline and updated binaries can check color strings and Pixel JSON serialization/round trips under English and Japanese cultures. Keep temporary harnesses and generated output out of tracked source.

For CI edits, use `actionlint` when available and reproduce the workflow's actual PowerShell commands in a clean workspace, preferably including a path with spaces. Verify version-tag handling, executable version metadata, ZIP filename, and archive contents: README, LICENSE, the executable, and all published native dependencies. Do not reuse stale build or publish output as proof of a clean release.

Run `git diff --check` and review the final diff for unintended behavior or scope changes. Local validation does not authorize creating tags, pushing commits, creating GitHub releases, or uploading assets; perform those actions only when separately requested.

Report the versions and files changed, why each change was needed, checks performed, and material verification limits. Clearly distinguish local publish/package validation from an actual hosted workflow run and state whether GUI behavior was exercised.
