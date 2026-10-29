# Tech-Shop — E-Commerce Web Application

An e-commerce web application built with **C#**, **ASP.NET MVC 5**, **Entity Framework 6**, and **SQL Server**. The application combines a responsive electronics-store storefront with database-backed product management and ASP.NET Identity account functionality.


## Overview

Tech-Shop explores the Model–View–Controller (MVC) pattern through a simple online electronics store. It includes pages for browsing a sample storefront and viewing product layouts, alongside a separate set of database-driven pages for managing product records.

The codebase demonstrates:

- Building a web application with ASP.NET MVC and Razor views.
- Performing create, read, update, and delete (CRUD) operations with Entity Framework.
- Connecting an MVC application to SQL Server.
- Using ASP.NET Identity for registration, sign-in, and account management.
- Creating a responsive interface with Bootstrap, HTML, CSS, and JavaScript.

## Technology Stack

| Area | Technology |
| --- | --- |
| Language | C# |
| Backend | ASP.NET MVC 5 on **.NET Framework 4.6.1** |
| Data access | Entity Framework 6 (6.4.4) |
| Database | Microsoft SQL Server / SQL Server LocalDB |
| Authentication | ASP.NET Identity 2, OWIN |
| Views | Razor (`.cshtml`) |
| Frontend | HTML, CSS, Bootstrap, JavaScript, jQuery |

**Note:** This project uses classic **ASP.NET MVC 5 / .NET Framework**, not ASP.NET Core.

## Implemented Features

### Product management

The `ProductsController` provides database-backed CRUD actions:

- **List** products from the database.
- **View** an individual product's details.
- **Create** new product records.
- **Edit** existing product records.
- **Delete** product records.

The create, edit, and delete forms use anti-forgery tokens, and the controller checks model validity before saving changes.

The current `Product` model is intentionally simple:

```csharp
public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
}
```

### User accounts

The project includes ASP.NET Identity account-management code and Razor views for registration, login, logout, and password management. Some email-dependent account flows remain unfinished or commented out.

### Storefront user interface

- Electronics-store landing page with a promotional carousel.
- Responsive product-card layouts with sample prices and placeholder images.
- Shopping page and individual product-layout page.
- Basic navigation and account links.

**Storefront limitation:** The shopping views use hardcoded sample products rather than records fetched from the product database. Visible **Add to cart** buttons are UI placeholders; they do not add items to a working cart.

## Project Structure

```text
ECOMMERCE-DM/
├── ECOMMERCE.sln
└── ECOMMERCE/
    ├── App_Start/              # MVC routing, bundles, Identity configuration
    ├── Controllers/
    │   ├── AccountController.cs
    │   ├── HomeController.cs
    │   ├── ManageController.cs
    │   ├── ProductsController.cs
    │   └── ShoppingController.cs
    ├── Models/
    │   ├── Ecommerce.cs       # Entity Framework product DbContext
    │   ├── Product.cs         # Product entity
    │   ├── ProductInitializer.cs
    │   └── IdentityModels.cs  # Identity user and DbContext
    ├── Views/
    │   ├── Account/
    │   ├── Home/
    │   ├── Manage/
    │   ├── Products/           # CRUD pages
    │   ├── Shopping/           # Sample storefront pages
    │   └── Shared/
    ├── Content/               # CSS and Bootstrap
    ├── Scripts/               # JavaScript and jQuery
    ├── images/
    ├── packages.config
    └── Web.config
```

## Getting Started

### Prerequisites

- **Windows** with **Visual Studio** and ASP.NET/web development support.
- **.NET Framework 4.6.1 targeting pack** (or compatible build tools targeting that framework).
- **SQL Server** or **SQL Server Express LocalDB**.
- NuGet package restore enabled in Visual Studio.

Because this is a .NET Framework application, it is best run in a Windows development environment with IIS Express.

### 1. Clone the repository

```bash
git clone https://github.com/T-King-00/ECOMMERCE-DM.git
cd ECOMMERCE-DM
```

### 2. Open and restore

Open `ECOMMERCE.sln` in Visual Studio. Restore the project's NuGet packages, then build the solution.

### 3. Configure SQL Server connections

Edit `ECOMMERCE/Web.config` to point to your local database instance.

There are **two DbContext classes** in the code:

- `ApplicationDbContext` uses the connection named `DefaultConnection` for ASP.NET Identity.
- `ECommerce` uses the name `Ecommerce` for product data.

For example, you can use separate LocalDB databases:

```xml
<connectionStrings>
  <add name="DefaultConnection"
       connectionString="Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=TechShopIdentity;Integrated Security=True"
       providerName="System.Data.SqlClient" />
  <add name="Ecommerce"
       connectionString="Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=TechShopProducts;Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

These are example local-development settings, not production credentials. The repository defines `DefaultConnection`; add or configure `Ecommerce` if you want to explicitly control the product database connection. Entity Framework may create a development database when first accessed, depending on your configuration.

### 4. Run the application

Start the project from Visual Studio with **IIS Express**. Once running, useful routes include:

| Route | Purpose |
| --- | --- |
| `/` | Homepage |
| `/Products` | Database-backed product list |
| `/Products/Create` | Create a product |
| `/Shopping/ShopNow` | Sample storefront page |
| `/Shopping/ShopItem` | Sample product details layout |
| `/Account/Register` | User registration |
| `/Account/Login` | User login |

> Some navigation links and storefront buttons are placeholders and may not lead to implemented actions. Use the routes above for the corresponding implemented pages.

## Sample Data

`ProductInitializer.cs` defines several example products, including Galaxy A7, Dell G3, Logitech, PS4, and Xbox One. **The initializer is not visibly registered at application startup**, so those records should not be assumed to appear automatically.

The initializer derives from `DropCreateDatabaseIfModelChanges<ECommerce>`: **enabling it can delete and recreate the product database when the model changes**. Use it only with disposable development data.

## Current Limitations and Possible Improvements

The following features are *not* implemented as end-to-end customer workflows:

- A persistent shopping cart, order placement, and checkout.
- Payment processing and order history.
- A storefront populated dynamically from the products database.
- Product images, prices, stock quantities, and categories in the current `Product` entity.
- Role-based authorization protecting product-management actions.
- Automated application tests.

Potential next steps are to expand the product model, connect shopping views to database records, restrict product administration to authorized users, implement cart and order flows, and add validation and automated tests.

## Project Scope

This repository presents a web-based e-commerce application built with ASP.NET MVC, C#, Entity Framework, SQL Server, Razor, and ASP.NET Identity. It currently provides product management, account functionality, and a storefront interface. It is not a production-ready online store.

---

**Repository:** [T-King-00/ECOMMERCE-DM](https://github.com/T-King-00/ECOMMERCE-DM)
