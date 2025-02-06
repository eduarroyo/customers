# 👥 Customer Management API

Welcome to the **Customer Management API** repository, a project developed in **.NET** that allows the creation, listing, editing, and deletion of customers. The data is stored for future reference.

## 🚀 Features

- Customer CRUD operations 👥
- Minimum required data:
  - First Name
  - Last Name
  - Gender
  - Date of Birth
  - Address
  - Country
  - Postal Code
  - Email
- Data persistence 📂

## 🛠️ Technologies Used

- .NET (recommendation: .NET 6 or later)
- Entity Framework Core
- SQL Server
- Blazor (optional)
- Swagger (OpenAPI)
- JWT for authentication (optional)

## 📦 Installation and Setup

1. **Clone the repository:**

   ```sh
   git clone https://github.com/eduarroyo/customers.git
   cd customers
   ```

2. **Configure the database:**

   - Ensure you have a running instance of **SQL Server**.
   - Set up the connection string in `appsettings.json`.

3. **Restore packages and build the project:**

   ```sh
   dotnet restore
   dotnet build
   ```

4. **Run migrations and update the database:**

   ```sh
   dotnet ef database update
   ```

5. **Run the project:**

   ```sh
   dotnet run
   ```

## 📖 Documentation

Once running, access the API documentation in **Swagger**:

- [`https://localhost:7029/swagger`](https://localhost:7029/swagger)

## 📌 Main Endpoints

### 👤 Customers

- `GET /customers` - Retrieve all customers
- `POST /customers` - Add a new customer
- `PUT /customers/{id}` - Update a customer
- `DELETE /customers/{id}` - Delete a customer

## 📄 License

This project is licensed under the **MIT** license. See the [LICENSE](LICENSE) file for more details.

---

📩 *If you have any questions or suggestions, feel free to open an issue or contribute to the project.*

