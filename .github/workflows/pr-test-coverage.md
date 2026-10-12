---
description: Rate test coverage and check for xUnit tests on every PR push
on:
  pull_request:
    types: [opened, synchronize, reopened]
    paths: ["**/*.cs", "**/*.csproj"]
permissions:
  contents: read
  pull-requests: read
  copilot-requests: write
engine: copilot
imports:
  - .github/agents/testsAgent.md
network:
  allowed:
    - defaults
    - dotnet
steps:
  - uses: actions/setup-dotnet@v4
    with:
      dotnet-version: "8.0.x"
  - run: dotnet test --collect:"XPlat Code Coverage" --results-directory ./TestResults
  - run: |
      dotnet tool install -g dotnet-reportgenerator-globaltool
      reportgenerator -reports:"TestResults/**/coverage.cobertura.xml" -targetdir:coverage -reporttypes:"MarkdownSummaryGithub"
  - run: |
      git fetch --no-tags --deepen=1 origin
      git diff --name-only HEAD^1 HEAD > changed-files.txt
tools:
  bash: ["cat"]
safe-outputs:
  add-comment:
    max: 1
---

# PR Test Coverage Review

Review pull request #${{ github.event.pull_request.number }}.

1. Read the coverage summary at `coverage/SummaryGithub.md`.
2. Read the list of changed files from `changed-files.txt`.
3. Follow the imported Test Coverage Reviewer instructions and post ONE comment
   on the PR, addressed to the PR author.