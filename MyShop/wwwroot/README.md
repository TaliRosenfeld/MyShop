# MyShop API

## Overview
MyShop is a Web API project built with .NET 8, adhering to REST architectural principles. This API provides endpoints for managing categories, products, orders, and users in an e-commerce application.

## Features
- **Layered Architecture**: The project is divided into multiple layers to promote separation of concerns. Each layer has a specific responsibility:
  - **Controllers**: Handle HTTP requests and responses.
  - **Services**: Contain business logic.
  - **Repositories**: Handle data access.
  - **DTOs (Data Transfer Objects)**: Define the data structures for communication between layers.
- **AutoMapper**: Used for mapping between different layers' objects, ensuring clean and maintainable code.
- **Dependency Injection (DI)**: Facilitates the communication between layers and promotes scalability.
- **Asynchronous Operations**: Utilizes `async` and `await` for non-blocking operations, enhancing scalability and performance.
- **SQL Database**: Implements a code-first approach for database management. Commands are provided for creating and updating the database schema.
- **Configuration Files**: Uses configuration files for managing application settings.
- **Error Handling**: All errors are managed by a centralized middleware. Errors are logged, and fatal errors are sent via email notifications.
- **Request Logging**: Every request is logged for analysis and rating purposes.
- **Clean Code**: Emphasis on writing clean, readable, and maintainable code.

## API Documentation
The API documentation is available via Swagger. You can access it [here](link-to-swagger).

## Endpoints
### Category
- **GET /api/Category**: Retrieves a list of categories.

### Order
- **GET /api/Order/{id}**: Retrieves an order by its ID.
- **POST /api/Order**: Creates a new order.

### Product
- **GET /api/Product**: Retrieves a list of products with optional filters.
- **GET /api/Product/{id}**: Retrieves a product by its ID.

### Users
- **GET /api/Users/{id}**: Retrieves a user by their ID.
- **PUT /api/Users/{id}**: Updates a user by their ID.
- **POST /api/Users/login**: Logs in a user.
- **POST /api/Users**: Registers a new user.
- **POST /api/Users/password**: Updates a user's password.

## Database
The project uses a SQL database with a code-first approach. To create the database, use the following commands:

```sh
# Add the necessary commands here
```

## Error Handling
All errors are handled by a centralized error middleware. Errors are logged, and fatal errors are sent via email notifications. 

## Request Logging
Every request to the API is logged for rating and analysis purposes.

## Clean Code
The project follows clean code principles to ensure the codebase is maintainable and readable.

## Technologies Used
- **.NET 8**
- **C#**
- **SQL**
- **AutoMapper**
- **Swagger**

## Contributing
We welcome contributions to the project. Please fork the repository and submit pull requests.

## License
This project is licensed under the MIT License.

## Contact
For any questions or inquiries, please contact [Tali Rosenfeld](email:38326774742@mby.co.il,phone:0533106831).

