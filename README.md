# C# Playwright NUnit Automation Project

A web automation testing project built for the SauceDemo website using **C#**, **Playwright**, and **NUnit**. This project demonstrates how to structure automation scripts using the Page Object Model (POM) and manage test data dynamically.

## 🚀 Key Features

- **Page Object Model (POM):** Organized the code by separating UI elements and actions into dedicated page classes, making the scripts easy to read and maintain.

- **Data-Driven Testing:** Removed all hardcoded usernames and passwords. The project reads test data dynamically from an external **JSON file** at runtime using C# objects.

- **Clean Test Layout (No If-Else):** Avoided complex conditional logic inside tests. The workflows are split into two separate, clean test files: one for the successful end-to-end checkout flow (`ValidUserTests`) and one for the locked-out user error validation (`LockedUserTests`).

- **Playwright Tracing & Setup Hooks:** Integrated NUnit `[SetUp]` and `[TearDown]` hooks to open a fresh browser context and page for every test. It automatically records execution logs and saves them as `.zip` traces with unique timestamps inside a `Traces/` folder whenever tests run.

## 📁 Project Directory Structure

```text
PlaywrightFramework/
│
├── Data/
│   ├── LoginData.json          # Test data credentials in JSON format
│   └── LoginDataModel.cs       # C# class mapping for JSON data structure
│
├── Pages/
│   ├── LoginPage.cs            # Login page elements and methods
│   ├── InventoryPage.cs        # Product catalog elements and methods
│   ├── InfoCheckoutDetails.cs  # Customer checkout form elements and methods
│   └── CheckoutCompletePage.cs # Order completion success page verification
│
├── Tests/
│   ├── ValidUserTests.cs       # End-to-End successful user journey test
│   └── LockedUserTests.cs      # Negative locked-out user error message test
│
├── Utils/
│   ├── FrameworkUtils.cs       # Custom timestamp generator tool
│   └── JsonReader.cs           # JSON file reading utility
│
└── Traces/                     # Folder where execution zip traces are saved automatically
```

## 🛠️ How to Setup and Run

1. **Clone the Project Repository:**
   ```bash
   git clone https://github.com
   cd csharp-playwright-nunit-framework
   ```

2. **Restore Dependencies:**
   ```bash
   dotnet restore
   ```

3. **Run the Automated Tests:**
   Execute the following command in your terminal to clear past cache and trigger the execution suite:
   ```bash
   dotnet clean
   ```
   ```bash
   dotnet test --logger:"console;verbosity=detailed"
   ```
