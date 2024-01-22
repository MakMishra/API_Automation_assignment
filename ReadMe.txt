# API Automation Framework

This project is an API automation framework developed in C# using SpecFlow, RestSharp, and NUnit. The framework is designed to test basic functionalities of a banking system.

## Project Structure

The project follows a modular structure for better organization and maintainability:

- **Models**: Contains classes representing request and response models.
- **Utils**: Holds utility classes for API interactions and verification.
- **SpecFlow**: Contains feature files and step definition files for behavior-driven development.
  
## Features

### Scenario 1: Create Account
- A user can create a new account with specified details.
- Endpoint: `POST https://www.localhost:8080/api/account/create`

### Scenario 2: Delete Account
- A user can delete an existing account.
- Endpoint: `DELETE https://www.localhost:8080/api/account/delete/{accountID}`

### Scenario 3: Deposit to Account
- A user can deposit a specified amount to an account.
- Endpoint: `PUT https://www.localhost:8080/api/account/deposit`

### Scenario 4: Withdraw from Account
- A user can withdraw a specified amount from an account.
- Endpoint: `PUT https://www.localhost:8080/api/account/withdraw`

## Dependencies

- **RestSharp**: Used for making HTTP requests to the API.
- **SpecFlow**: Enables behavior-driven development with Gherkin syntax.
- **NUnit**: Framework for writing and executing NUnit tests.

## Getting Started

1. Clone the repository from GitHub.
2. Install the required NuGet packages (`RestSharp`, `SpecFlow`, `NUnit`).
3. Open the solution in Visual Studio.
4. Run the SpecFlow tests.
