# Ensek.UITests

This project contains automated UI tests for ENSEK's Buy Energy feature, using SpecFlow, Selenium WebDriver, and the Screenplay pattern.

## Features

- End-to-end UI automation for the Buy Energy workflow
- Scenarios written in Gherkin (SpecFlow) for clarity and traceability
- Uses the Screenplay pattern for maintainable, reusable test code
- Cross-browser support (Chrome by default, extensible to others)
- Data-driven tests using external JSON files

## Prerequisites

- .NET SDK 6.0 or later
- Chrome browser (for ChromeDriver)
- [SpecFlow](https://specflow.org/) and required NuGet packages (see `.csproj`)
- [Selenium WebDriver](https://www.selenium.dev/)
- Test data and selectors in `Env\TestData.json` and `Env\BuyEnergy_CombinedSelectors.json`

## Running the Tests

From this folder, run:

```
dotnet test Ensek.UITests.csproj
```

Or use the provided batch file for timestamped results:

```
..\RUN_TESTS_UI.BAT
```

## Structure

- `Features/` – Gherkin feature files describing UI scenarios
- `Steps/` – Step definitions mapping Gherkin steps to automation code
- `Screenplay/` – Tasks, Questions, and Interactions for the Screenplay pattern
- `Env/` – Test data and selector configuration files

## Reporting

Test results are output to the console and, if using the batch file, to a timestamped text file.

## Troubleshooting

- Ensure Chrome is installed and matches the ChromeDriver version.
- Update selectors in `Env\BuyEnergy_CombinedSelectors.json` if the UI changes.
- Check the output file for detailed error messages if a test fails.

---
For more details, see the main [README.md](../README.md).
