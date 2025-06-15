# 🏁 Training Task Scenario – SampleStore API

Welcome to the **SampleStore** onboarding project!  
This task will introduce you to the powerful `.NET CLI` tool 
[**DEFC.Util.RepoGen**](https://www.nuget.org/packages/DEFC.Util.RepoGen), 
which automates repository and Unit of Work generation using **SQL Server stored procedures** [See RepoGen tool documentation](https://github.com/AminaElsheikh/DEFC.Util.RepoGen/wiki).

# 📑 Table of Contents

1. [🧩 Scenario Title](#-scenario-title)
2. [📘 Scenario](#-scenario)
3. [🛠️ Prerequisites](#️-prerequisites)
4. [🚀 Steps to Complete the Task](#-steps-to-complete-the-task)
   - [✅ Step 1: Create the Database](#-step-1-create-the-database)
   - [✅ Step 2: Open the API Project](#-step-2-open-the-api-project)
   - [✅ Step 3: Packages to be installed](#-step-3-packages-to-be-installed)
   - [✅ Step 4: Initialize the RepoGen tool](#-step-4-initialize-the-repogen-tool)
   - [✅ Step 5: Review the Configuration](#-step-5-review-the-configuration)
   - [✅ Step 6: Set-up app folder structure](#-step-6-set-up-app-folder-structure)
   - [✅ Step 7: Use CRUD option for ProductCategories](#-step-7-for-productcategories-table-will-use-crud-option)
   - [✅ Step 8: Use Map option for Products, Orders, Customers](#-step-8-for-products-orders-customers-tables-will-use-map-option)
   - [✅ Step 9: Use Batch option for OrderItems](#-step-9-for-orderitems-table-will-use-batch-option)
   - [✅ Step 10: Explore the Generated Code](#-step-10-explore-the-generated-code--add-required-logics-and-validations)
   - [✅ Step 11: Configure your application](#-step-11-configure-your-application)
   - [✅ Step 12: Final result](#-step-12-final-result)
5. [📚 For More Tool Training](#-for-more-tool-training)
6. [🧱 Challenges](#-challenge-1-remap-stored-procedure)
   - [Challenge 1: Remap Stored Procedure](#-challenge-1-remap-stored-procedure)
   - [Challenge 2: Remove Stored Procedure Mapping](#-challenge-2-remove-stored-procedure-mapping)
   - [Challenge 3: Force Overwrite Using --force or -f](#-challenge-3-force-overwrite-using---force-or--f)
   - [Challenge 4: Change Structure Model](#-challenge-4-change-structure-model)
   - [Challenge 5: Change Structure Model to MODEL_CUSTOM](https://github.com/AminaElsheikh/DEFC.Util.RepoGen/wiki/Step-by-step-practice-sample-with-MODEL_CUSTOM-guide)
7. [🎯 Learning Objectives](#-learning-objectives)
8. [📩 Questions?](#-questions)
9. [🎯 Learning Outcome](#-learning-outcome)
10. [❓ FAQ](https://github.com/AminaElsheikh/DEFC.Util.RepoGen/wiki/FAQ)

---

## 🧩 Scenario Title
`Kickstart the Store API with DEFC.Util.RepoGen`

## 📘 Scenario
You've joined the backend team of an online platform called **SampleStore**.  
Your goal is to set up the data access layer using `DEFC.Util.RepoGen`, based on:

- A sample SQL Server database ([`SampleStore.sql`](https://github.com/AminaElsheikh/DEFC.Util.RepoGen-SampleStore/tree/main/DB)) that creates the store database with tables like 
  `Products`, `ProductCategories`, `Orders`, `Customers`,`OrderItems` and stored procedures.
- A .NET Core API skeleton project ([`SampleStore`](https://github.com/AminaElsheikh/DEFC.Util.RepoGen-SampleStore/tree/main/SampleStore))
You'll generate the necessary code structure without writing boilerplate repositories or services manually!

---

## 🛠️ Prerequisites

Make sure the following are installed:

- SQL Server
- [.NET 6 SDK or newer](https://dotnet.microsoft.com/download)   

---

## 🚀 Steps to Complete the Task

### ✅ Step 1: Create the Database
- Open SQL Server Management Studio (SSMS) or any SQL client.
- [Run the script](https://github.com/AminaElsheikh/DEFC.Util.RepoGen-SampleStore/tree/main/DB)
- This creates tables `Products`, `ProductCategories`, `Orders`, `Customers`, `OrderItems` and a few stored procedures.
### ✅ Step 2: Open the API Project
- Frok and open the [`SampleStore`](https://github.com/AminaElsheikh/DEFC.Util.RepoGen-SampleStore/tree/main/SampleStore) solution in Visual Studio.
- Review the structure — **do not manually add repositories or services**.

### ✅ Step 3: Packages to be installed
 - `Microsoft.Data.SqlClient`
- `Microsoft.EntityFrameworkCore.SqlServer`
- `Microsoft.EntityFrameworkCore`
- `DEFC.Util.RepoGen`
  ```bash
  dotnet add package DEFC.Util.RepoGen --version 1.0.0-beta
  ```

### ✅ Step 4: Initialize the RepoGen tool
- Open **Developer PowerShell for Visual Studio** *(`recommended`)* — provides better visualization and output formatting.
    - (OR) **.NET CLI** from terminal or command prompt *(`recommended`)* — provides better visualization and output formatting.		
    - (OR) **Package Manager Console** in Visual Studio.
- Write the initialization command below
```bash
dotnet tool run RepoGen initial
```
> 💡 **Important:** For best experience and readability, use **Developer PowerShell** or **.NET CLI**.
![PS](https://github.com/AminaElsheikh/DEFC.Util.RepoGen/blob/main/Img/CLI.png)


### ✅ Step 5: Review the Configuration

[See RepoGen Configuration](https://github.com/AminaElsheikh/DEFC.Util.RepoGen/wiki/Configuration)

#### 🔧 RepoGen Configuration Checklist

Verify and update the following in the `RepoGen.json` file:

**Path:** `SampleStore/RepoGenTool/RepoGen.json`

#### 🔧 Required Configuration Fields

| Field                    | Status     | Description                                                                                   | Example Value            |
|-------------------------|------------|-----------------------------------------------------------------------------------------------|--------------------------|
| `ConnectionString`      | ❌ Pending | Valid connection string to the SampleStore database                                           | `Server=localhost;Database=SampleStore;User Id=admin;Password=secret;TrustServerCertificate=True` |
| `DBContextName`         | ❌ Pending | Base name for the `DbContext` (suffix `DBContext` will be added automatically)               | `Store`                  |
| `Namespace`             | ❌ Pending | Root namespace to be used for generated code                                                  | `SampleStore`            |
| `FoldersStructureModel` | ✅ Set      | Structure model used for organizing the generated codebase                                   | `MODEL_1`                |
| `Model` | ✅ Set      | Suffix for domain or entity classes                                   | `Model`                |
| `DTO` | ✅ Set      | Suffix for data transfer objects                                  | `DTO`                |


> ℹ️ **Note:** Other folder models include [`MODEL_2`](#-step-10-explore-the-generated-code--add-required-logics-and-validations), [`MODEL_3`](#-step-10-explore-the-generated-code--add-required-logics-and-validations), and [`MODEL_CUSTOM`](https://github.com/AminaElsheikh/DEFC.Util.RepoGen/wiki/Step-by-step-practice-sample-with-MODEL_CUSTOM-guide).

#### 📁 Example `RepoGen.json`

```json
{
  "Config": {
    "DBConfig": {
      "SchemaID": "1",
      "DBContextName": "Store",
          // TO DO: Apply your connection data
      "ConnectionString": "Server=localhost;Database=SampleStore;User Id=admin;Password=secret;TrustServerCertificate=True"
    },
    "AppConfig": {
      "Namespace": "SampleStore",
      "FoldersStructureModel": "MODEL_1",
      "LoggerCode": "101",
      "Suffixes": {
        "Model": "Model", // Suffix for domain or entity classes
        "DTO": "DTO" // Suffix for data transfer objects 
 
      }
    }
  }
}
```
### ✅ Step 6: Set-up app folder structure

```bash
dotnet tool run RepoGen structure set
```
#### ⚠️ Important Notes
- Make sure no extra spaces in the commands.

- To confirm if the connection string in `RepoGen.json` is working:
```bash
dotnet tool run RepoGen test db-connection
```

### ✅ Step 7: For ProductCategories table will use CRUD option

- **Option 1:** *(Recommended)* use `crud` command with table `ProductCategories` with endpoint generator:  
```bash
dotnet tool run RepoGen crud --tbl ProductCategories --service ProductCategory --controller ProductCategory
```
- **Option 2:** use `crud` command with table `ProductCategories`:  
```bash
dotnet tool run RepoGen crud --tbl ProductCategories --service ProductCategory
```
### ✅ Step 8: For `Products`, `Orders`, `Customers` tables will use Map option
- use	`add` for creating `Products`,`Customers` and `Orders` Repository:

```bash
dotnet tool run RepoGen add --repo Products
dotnet tool run RepoGen add --repo Customers
dotnet tool run RepoGen add --repo Orders
```
- use `map` command with `sp_CreateProduct`,`sp_GetAllProducts`,`sp_GetProductById`,`sp_UpdateProduct` and `sp_DeleteProduct` stored procedures: 
  - Map using full command
    ```bash
    dotnet tool run RepoGen map --sp sp_CreateProduct --repo Products --controller Products --endpoint CreateProduct --post
    ```
  - Using command shorthads [see shorthands table](https://github.com/AminaElsheikh/DEFC.Util.RepoGen/wiki/RepoGen-CLI-Shorthands-Table)
    ```bash
    dotnet tool run RepoGen map -sp sp_GetAllProducts -r Products -c Products -ep GetAllProducts -g 
    ```
  - Mix between full commands and shorthands
    ```bash
    dotnet tool run RepoGen map --sp sp_GetProductById --repo Products -c Products --endpoint GetProductById --get
    ```
  - By defult will take Products as controller name and sp_UpdateProduct as endpoint name
    ```bash
    dotnet tool run RepoGen map --sp sp_UpdateProduct --repo Products --put
    ```
  - By defult will take Products as controller name
    ```bash
    dotnet tool run RepoGen map -sp sp_DeleteProduct -r Products -ep DeleteProduct --delete
    ```

> **Note:** To map without creating controller endpoint, use the `map` command as shown below:
```bash
dotnet tool run RepoGen map --sp sp_CreateProduct --repo Products
```
> **Note:** To remap, use the `remap` command as shown below:
```bash
dotnet tool run RepoGen re-map --sp sp_CreateProduct --repo Products --controller Products --endpoint CreateProduct --post
```
```bash
dotnet tool run RepoGen re-map --sp sp_CreateProduct --repo Products
```
> **Note:** To remove, use the `remove` command as shown below:
```bash
dotnet tool run RepoGen remove --sp sp_CreateProduct --repo Products
```

- use `map` command with `sp_CreateCustomer`,`sp_GetAllCustomers`,`sp_GetCustomerById`,`sp_UpdateCustomer` and `sp_DeleteCustomer` stored procedures: 
```bash
dotnet tool run RepoGen map --sp sp_CreateCustomer --repo Customers --controller Customers --endpoint CreateCustomer --post
dotnet tool run RepoGen map -sp sp_GetAllCustomers -r Customers -c Customers -ep GetAllCustomers -g 
dotnet tool run RepoGen map --sp sp_GetCustomerById --repo Customers -c Customers --endpoint GetCustomerById --get
dotnet tool run RepoGen map --sp sp_UpdateCustomer --repo Customers --put
dotnet tool run RepoGen map -sp sp_DeleteCustomer -r Customers -ep DeleteCustomer --delete
```
- use `map` command with `sp_CreateOrder`,`sp_GetAllOrders`,`sp_GetOrderById`,`sp_UpdateOrder` and `sp_DeleteOrder` stored procedures: 
```bash
dotnet tool run RepoGen map --sp sp_CreateOrder --repo Orders --controller Orders --endpoint CreateOrder --post
dotnet tool run RepoGen map -sp sp_GetAllOrders -r Orders -c Orders -ep GetAllOrders -g 
dotnet tool run RepoGen map --sp sp_GetOrderById --repo Orders -c Orders --endpoint GetOrderById --get
dotnet tool run RepoGen map --sp sp_UpdateOrder --repo Orders -u
dotnet tool run RepoGen map -sp sp_DeleteOrder -r Orders -ep DeleteOrder -d
```
### ✅ Step 9: For `OrderItems` table will use batch option
- Add batch file called `batch-orderitems`.
```bash
dotnet tool run RepoGen add --batch batch-orderitems
```
- Generated file location **Path:** `SampleStore/RepoGenTool/Batches/batch-orderitems.json`.
- The generated file will include **sample nodes** like below:

```json
{
  "Commands": [
    {
      "ID": "add-repo",
      "Command": "add --repo <YourRepoName>"
    },
    {
      "ID": "map-insert-endpoint",
      "Command": "map --sp <YourStoredProcedureName> --repo <YourRepoName> --controller <ControllerName> --endpoint <EndpointName> --<Method>"
    },
    {
      "ID": "map-insert",
      "Command": "map --sp <YourStoredProcedureName> --repo <YourRepoName>"
    },
    {
      "ID": "re-map-update",
      "Command": "re-map --sp <YourStoredProcedureName> --repo <YourRepoName>"
    },
    {
      "ID": "remove-delete",
      "Command": "remove --sp <YourStoredProcedureName> --repo <YourRepoName>"
    } 
    ,
    {
      "ID": "curd-table",
      "Command": "crud --tbl <YourTableName> --service <YourServiceName>"
    } 

  ]
}
```
- Change in this file to be like below:
```json
{
  "Commands": [
    {
      "ID": "add-OrderItems-repo",
      "Command": "add --repo OrderItems"
    },
    {
      "ID": "map-insert-OrderItems",
      "Command": "map --sp sp_CreateOrderItem --repo OrderItems --controller OrderItems --endpoint CreateOrderItem -p"
    },
    {
      "ID": "map-update-OrderItems",
      "Command": "map --sp sp_UpdateOrderItem --repo OrderItems --endpoint UpdateOrderItem -u"
    },
    {
      "ID": "map-delete-OrderItems",
      "Command": "map --sp sp_DeleteOrderItem --repo OrderItems --controller OrderItems --endpoint DeleteOrderItem --delete"
    },
    {
      "ID": "map-get-OrderItems",
      "Command": "map --sp sp_GetOrderItemById --repo OrderItems -g"
    },
    {
      "ID": "map-get-all-OrderItems",
      "Command": "map --sp sp_GetAllOrderItems --repo OrderItems -c OrderItems -ep GetAllOrderItems --get"
    }

  ]
}
```
- Run batch of commands from a JSON file:
```bash
dotnet tool run RepoGen batch --file batch-orderitems
``` 
- This will: 
    - Create OrderItems reposatory.
    - Map stored procedures for OrderItems written in `batch-orderitems.json`.
## ✅ Step 10: Explore the Generated Code & Add required logics and validations
Look inside the following folders:

- Repositories
- Interfaces (IRepositories)
- Services
- DTOs
- Find the auto-generated ProductsRepository, UnitOfWork, etc.


| MODEL_1                 | MODEL_2            | MODEL_3            |
|-------------------------|--------------------|--------------------|
|![MODEL_1](https://github.com/AminaElsheikh/DEFC.Util.RepoGen-SampleStore/blob/main/Img/MODEL_1_Store.png)|![MODEL_2](https://github.com/AminaElsheikh/DEFC.Util.RepoGen-SampleStore/blob/main/Img/MODEL_2_Store.png)|![MODEL_3](https://github.com/AminaElsheikh/DEFC.Util.RepoGen-SampleStore/blob/main/Img/MODEL_3_Store.png)|

 
##  ✅ Step 11: Configure your application
This based on your application requirements.
- Confuger database connection string in `appsettings.json` file.
```json
...............
  "AllowedHosts": "*",
  "ConnectionStrings": {
      // TO DO: Apply your connection data
    "ConnectionString": "Server=SERVER_NAME;Database=DATABASE_NAME;User Id=USER_NAME;Password=PASSWORD;TrustServerCertificate=True"

  }
}
```
- Confuger database connection string in `Program.cs` file.
- Add any other configurations needed.

```c#
.....................
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StoreDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
}
);
......................
```

##  ✅ Step 12: Final result

![PS](https://github.com/AminaElsheikh/DEFC.Util.RepoGen-SampleStore/blob/main/Img/Final_Result.png)

---

## 📚 For More Tool Training

Once you complete the main task, try redoing it using a different folder structure model.  
This helps you better understand clean architecture strategies and how `DEFC.Util.RepoGen` adapts to different setups.

---
### 🧱 Challenge 1: Remap Stored Procedure
1. **Add new field `PhoneNumber` with datatype `nvarchar(150)` to `Customers` table.**
```sql
ALTER TABLE Customers ADD PhoneNumber nvarchar(150) null;
```
2. **Alter `sp_CreateCustomer` stored procedure to accept the new `PhoneNumber` field.**
```sql 
ALTER PROCEDURE [dbo].[sp_CreateCustomer]
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email NVARCHAR(150),
    @PhoneNumber NVARCHAR(150)
AS
BEGIN
    INSERT INTO Customers (FirstName, LastName, Email,PhoneNumber)
    VALUES (@FirstName, @LastName, @Email,@PhoneNumber);
    
    SELECT SCOPE_IDENTITY() AS NewCustomerId;
END
```
3. **use `re-map` command to apply the changes**
```bash
dotnet tool run RepoGen re-map --sp sp_CreateCustomer --repo Customers
```
4. **Verify updates**
- Open `sp_CreateCustomerDto` class and confirm the `PhoneNumber` field is included.
- Open `Customers` repository and ensure the changes have been correctly applied.

### 🧱 Challenge 2: Remove Stored Procedure Mapping
1. **Assumption:**  
   We want to remove the `sp_DeleteOrder` stored procedure mapping.
2. **Use `remove` command to remove the mapped stored procedure**
```bash
dotnet tool run RepoGen remove --sp sp_DeleteOrder --repo Orders
```
### 🧱 Challenge 3: Force Overwrite Using --force or -f
- Try regenerating a CRUD layer for an existing table with the force option:
```bash
dotnet tool run RepoGen crud --tbl ProductCategories --service ProductCategory --force
```
Or shorthand:
```bash
dotnet tool run RepoGen crud --tbl ProductCategories --service ProductCategory -f
```
> ⚠️ This overwrites existing files. Useful when structure or schema has changed.

### 🧱 Challenge 4: Change Structure Model
- Try using `MODEL_2` (Layered), (Hexagonal) `MODEL_3` (Hexagonal) or [`MODEL_CUSTOM`](https://github.com/AminaElsheikh/DEFC.Util.RepoGen/wiki/Step-by-step-practice-sample-with-MODEL_CUSTOM-guide) and observe code layout changes.
> ⚠️ This Challenge is the most critical
1. Manually delete(or keep aside) previously generated folders (to avoid conflicts):
```bash
# Delete folders like Services, Repositories, etc.
```
2. Open `RepoGen.json` and update the structure model:
```json
{
  "FoldersStructureModel": "MODEL_2"
}
```
3. Re-run the folder setup:
```bash
dotnet tool run RepoGen structure set
```
4. Re-run the batch setup:
```bash
dotnet tool run RepoGen batch --file batch-orderitems
```
5. Observe how the folder layout and organization differ from `MODEL_1`.

> 🔁 You can also try `MODEL_3` (Hexagonal) or define your own using [`MODEL_CUSTOM`](https://github.com/AminaElsheikh/DEFC.Util.RepoGen/wiki/Step-by-step-practice-sample-with-MODEL_CUSTOM-guide).

---
## 🎯 Learning Objectives
By completing this task, you will:

- Understand the Repository & Unit of Work patterns.
- Learn to use a CLI-based code generator in real projects.
- Follow clean architecture principles in a .NET Core application.
- Map, Re-map and Remove stored procedures to strongly typed repository methods.
- CRUD tables to strongly typed services methods.

---

## 📩 Questions?
If you're stuck or want feedback on your solution: Open a [GitHub Issue](https://github.com/AminaElsheikh/DEFC.Util.RepoGen-SampleStore/issues) with your question
> It’s helpful if you can also attach an image or screenshot of the issue to provide more context.

---

### 🎯 Learning Outcome
- Understand how layered architecture separates **application**, **domain**, and **infrastructure** logic.
- Learn to switch architectural styles without changing your business logic.
- Practice adapting tools to enterprise-grade coding standards.
 

Your support is greatly appreciated and helps keep this project active and maintained! 🙏

