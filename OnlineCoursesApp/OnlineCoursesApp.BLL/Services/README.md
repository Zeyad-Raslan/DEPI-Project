# Service Layer Documentation

This file provides an overview of the **Service Layer** in the project, which simplifies and abstracts the interaction with the database for CRUD operations (Create, Read, Update, Delete) across different entities.

## Purpose of the Service Layer

The **Service Layer** in this project is designed to encapsulate the core business logic and data access logic. It provides a generic interface for managing various entities in the system, promoting code reusability and separation of concerns.

### Key Features:
1. **Abstraction of Database Operations**: Simplifies CRUD operations without directly interacting with the Entity Framework's DbContext.
2. **Generic Implementation**: The use of generics (`Service<T>`) allows for creating a service that can work with any entity type, reducing redundancy.
3. **Centralized Logic**: Ensures that all database operations follow a unified structure, making it easier to manage and maintain.

## Components of the Service Layer

### 1. **IService<T> Interface**
This interface defines the basic operations that any service should implement. These operations are generic and can be applied to any entity.

- **Methods**:
  - `Query()`: Returns an `IQueryable<T>` object for querying data.
  - `GetById(int id)`: Retrieves an entity by its primary key (`id`).
  - `Add(T entity)`: Adds a new entity to the database.
  - `Update(T entity)`: Updates an existing entity in the database.
  - `Delete(int id)`: Deletes an entity by its primary key (`id`).

### 2. **Service<T> Implementation**
The `Service<T>` class implements the `IService<T>` interface and provides the actual logic for each of the CRUD operations. It interacts directly with the Entity Framework's `DbContext` to perform database operations.

- **Constructor**:
  The service requires an instance of `OnlineCoursesDbContext` to access the database and perform operations on the DbSet of the entity type `T`.

- **Methods**:
  - `Query()`: Returns all records for the specified entity type `T` in a queryable format.
  - `GetById(int id)`: Fetches a specific record based on its `id`.
  - `Add(T entity)`: Adds the provided entity to the corresponding table and commits the changes to the database.
  - `Update(T entity)`: Updates the existing record in the database with new values.
  - `Delete(int id)`: Finds the entity by its `id` and deletes it from the database.

## Benefits of the Service Layer

1. **Code Reusability**: Since the service is generic, it can be reused across different entities like `Course`, `Instructor`, `Student`, etc., without duplicating code.
2. **Separation of Concerns**: By isolating the data access logic in the service layer, the controller or other parts of the application can focus on handling user inputs and responses.
3. **Centralized Error Handling**: Centralizing the CRUD operations allows for more consistent error handling and validation mechanisms.
4. **Maintainability**: Any changes in how data is handled can be made in one place (the service), and all dependent components will automatically use the updated logic.

## How to Use the Service Layer

To use the `Service<T>`, it must be injected into the appropriate classes, typically in controllers. Once injected, you can call the CRUD methods provided by the service to interact with the database.

1. **Dependency Injection**: The service should be registered in the `Startup.cs` file or `Program.cs` file (depending on the project setup) to ensure it is available for dependency injection.

2. **Service Registration**:
   You can register the service in the Dependency Injection container as follows:
   
   ```csharp
   services.AddScoped(typeof(IService<>), typeof(Service<>));
   ```

3. **Using the Service in Controllers**:
   Once registered, the service can be injected into a controller or any other class to perform database operations for any entity:

   - Retrieve all records of an entity type
   - Add a new record
   - Update existing records
   - Delete records by ID

## Example Use Case

Suppose you need to manage courses in the application. Instead of writing specific CRUD operations for the `Course` entity, you can utilize the generic service to perform the same operations with less code:

- Fetch all courses: `service.Query()`
- Get a course by ID: `service.GetById(id)`
- Add a new course: `service.Add(course)`
- Update an existing course: `service.Update(course)`
- Delete a course by ID: `service.Delete(id)`

This approach helps maintain a clean and DRY (Don't Repeat Yourself) codebase.

---

This documentation file serves to provide a high-level understanding of how the Service Layer works in the project, its benefits, and how it can be used effectively.

