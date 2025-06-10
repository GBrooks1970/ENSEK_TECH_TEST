# API_BDD_Test_Project

This project contains BDD-style automated API tests for ENSEK's backend endpoints using SpecFlow and .NET.

## Features

- Written in Gherkin syntax for clear, business-readable scenarios
- Uses SpecFlow for BDD and test orchestration
- Validates key API endpoints for the Buy Energy feature
- Includes positive, negative, and edge case tests

## Prerequisites

- .NET SDK 6.0 or later
- [SpecFlow](https://specflow.org/) and required NuGet packages
- Access to the ENSEK API (test or staging environment)

## Running the Tests

From the root of the repository or this folder, run:

```
dotnet test API_BDD_Test_Project.csproj
```

Or use the provided batch file for timestamped results:

```
..\RUN_TESTS_API.BAT
```

## Structure

- `Features/` – Gherkin feature files describing test scenarios
- `Steps/` – Step definitions mapping Gherkin steps to code
- `Hooks/` – Test setup and teardown logic

## Reporting

Test results are output to the console and, if using the batch file, to a timestamped text file.

## Troubleshooting

- Ensure the API endpoint URLs and credentials are configured correctly in the test settings.
- Check the output file for detailed error messages if a test fails.

---
For more details, see the main [README.md](../README.md).