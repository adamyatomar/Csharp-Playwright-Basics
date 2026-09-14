# 🚀 Scalable B2C E-Commerce Test Automation Suite

An enterprise-grade test automation framework built from scratch using **C#**, **Playwright**, and **NUnit**. This project implements strict industry-standard architecture for testing end-to-end user journeys on e-commerce platforms.

## 🏛️ Project Architecture

The framework strictly follows the **Page Object Model (POM)** pattern to maximize reusability and maintainability:

- 📁 **Pages/**: Contains structural page element classes. Features **strict encapsulation** where all locators are kept `private` and only safe action/getter methods are exposed.
- 📁 **Tests/**: Independent test execution engines mapping the complete multi-page user lifecycle.
- 📁 **Utils/**: Reusable helper infrastructure (e.g., custom instant dynamic timestamp generator).

## 🛠️ Core Engineering Implementations

- **Airtight Locator Strategy**: Optimized backend element bindings using unique HTML IDs (`#`) and classes (`.`) to eradicate timeouts and strict-mode violations.
- **Asynchronous Pipeline**: Line-by-line task execution orchestration utilizing C# `async` and `await` structures.
- **Robust Sync Support**: Integrated dynamic fallback capsules (`?? string.Empty`) within string getters to achieve a **0-warning compilation zone**.

## 🏃‍♂️ How To Run Locally

1. Clone this repository to your local system.
2. Ensure you have the `.NET SDK` installed.
3. Open the terminal inside the root project directory and execute:
   ```bash
   dotnet test --logger:"console;verbosity=detailed"
   ```
