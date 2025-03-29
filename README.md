# BookStore

A Blazor Server application that allows users to browse, purchase, and read books online.  
This project showcases integration with **ASP.NET Core Identity** for authentication and authorization, **Entity Framework Core** with **PostgreSQL** for data storage, and **Stripe** for payment processing.

<div align="center">
  <img src="/webdemo.png" alt="BookStore Screenshot" width="700"/>
</div>

---

## Table of Contents

1. [Features](#features)  
2. [Technologies Used](#technologies-used)  
3. [Getting Started](#getting-started)  
    - [Prerequisites](#prerequisites)  
    - [Installation](#installation)  
    - [Database Setup](#database-setup)  
    - [Stripe Configuration](#stripe-configuration)  
4. [Usage](#usage)
5. [Contributing](#contributing)  
6. [License](#license)

---

## Features

- **User Authentication**: Built on ASP.NET Core Identity. Users can register, log in, and manage their profiles.  
- **Book Catalog**: View a list of books with cover images, authors, and short descriptions.  
- **Search & Filtering**: Search for books by title and filter results.  
- **Shopping Cart**: Add books to a cart and proceed to checkout.  
- **Payment Integration**: Uses Stripe for secure payment processing.  
- **PDF Download**: Once purchased, users can download or read the PDF version of the book.  
- **Purchased Books List**: Displays a list of previously purchased books for easy access.  

---

## Technologies Used

- **.NET 7 / .NET 8 (Blazor Server)**: Core framework for building the application.  
- **ASP.NET Core Identity**: Manages user authentication and authorization.  
- **Entity Framework Core**: Object-relational mapper (ORM) for database operations.  
- **PostgreSQL**: Primary relational database system.  
- **Stripe**: Payment processing integration.  
- **Razor Components**: For interactive UI within Blazor Server.  
- **Bootstrap / CSS**: For styling and layout (if applicable).  

---

## Getting Started

### Prerequisites

1. [.NET 7 SDK or later](https://dotnet.microsoft.com/en-us/download/dotnet)  
2. [PostgreSQL](https://www.postgresql.org/download/)  
3. A [Stripe account](https://stripe.com/) for payment keys (optional if you want to test payments locally)

### Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/your-username/bookstore.git
   cd bookstore
   ```

2. **Open the project** in your preferred IDE (Visual Studio, Rider, or VS Code), or use the CLI.

3. **Restore NuGet packages** (if not automatically done by your IDE):
   ```bash
   dotnet restore
   ```

### Database Setup

1. In `appsettings.json` or `appsettings.Development.json`, locate the `DefaultConnection` under `ConnectionStrings` and update it with your PostgreSQL credentials. For example:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Port=5432;Database=BookStoreDb;Username=postgres;Password=YourPassword"
     }
   }
   ```

2. **Apply Migrations**:  
   From the root of the project (where the `.csproj` is located), run:
   ```bash
   dotnet ef database update
   ```
   This will create or update the database schema using the existing migrations.

### Stripe Configuration

1. In your `appsettings.json` or `appsettings.Development.json`, add or update the `Stripe` section with your API keys:
   ```json
   {
     "Stripe": {
       "PublishableKey": "pk_test_12345",
       "SecretKey": "sk_test_67890"
     }
   }
   ```
2. The application uses `StripeConfiguration.ApiKey` to process payments. If you don’t plan to test payments, you can leave these blank or mock them out.

---

## Usage

1. **Run the application**:
   ```bash
   dotnet run
   ```
2. **Open the browser** at [https://localhost:7071](https://localhost:7071) (or the URL displayed in your terminal/console).

3. **Register a new user** or **log in** with an existing account.

4. **Browse the books**, add them to your cart, and proceed to checkout. Payment is handled by Stripe if configured.

5. After a successful purchase, your **Purchased Books** will be accessible under the “Purchased Books” menu item.

---

## Contributing

Contributions are welcome! If you find a bug or have a feature request, feel free to [open an issue](https://github.com/your-username/bookstore/issues). You can also submit a pull request with your proposed changes.

1. **Fork** the project  
2. **Create** a new feature branch (`git checkout -b feature/awesome-feature`)  
3. **Commit** your changes (`git commit -m 'Add some awesome feature'`)  
4. **Push** to the branch (`git push origin feature/awesome-feature`)  
5. **Open a Pull Request**  

---

## License

This project is licensed under the [MIT License](LICENSE). You are free to use, modify, and distribute this software as per the terms of the license.

---

### Additional Notes

- If you run into issues with HTTPS locally, you may need to trust the local development certificate (`dotnet dev-certs https --trust`).  
- Make sure your PostgreSQL server is running and accessible.  
- The default identity setup requires confirmed accounts (`SignIn.RequireConfirmedAccount = true`). You can adjust this in `Program.cs` if needed.

Enjoy building and expanding your BookStore project!
