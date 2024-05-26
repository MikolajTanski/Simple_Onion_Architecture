# Simple Onion Architecture Project

## Overview

The `Simple_Onion_Architecture` project is a .NET application demonstrating the use of a layered (onion) architecture, known for its flexibility and clear separation of concerns. This architecture is geared towards ensuring that business logic is independent of infrastructure and presentation layers, which makes the codebase easier to manage, test, and evolve.

## Key Features

- **Clear Separation of Concerns**: Each layer (Core, Infrastructure, Persistence, Presentation) has clearly defined responsibilities.
- **Flexibility**: Facilitates changes in the business logic without affecting other parts of the system.
- **Testability**: The architecture supports the writing of both unit and integration tests through clear separation of business logic.

## Architecture and Implementation

### Repositories

Repositories in the `Simple_Onion_Architecture` project abstract the data access logic from the business logic. This separation helps manage CRUD operations and isolate the application logic from database implementation details.

- **Generic Repository**: We implement a generic repository `Repository<TEntity, TContext>` capable of handling any entity type, reducing code redundancy.
- **Specialized Repositories**: For more complex business cases requiring specific data access logic, dedicated repositories (e.g., `ProductRepository`) are created that inherit from the generic repository and extend it with additional methods.

### Dependency Injection (DI)

Dependency injection is implemented using the built-in features of .NET Core and is extensively used in the project to manage dependencies between classes. This helps maintain low coupling, ease of testing, and lifecycle management of objects.

- **DI Configuration**: Dependencies are configured in `Startup.cs` or similar files where each service or repository is registered in the DI container. This allows for easy swapping of component implementations without impacting the application code.

### BaseEntity and IEntity

`BaseEntity` and `IEntity` are base classes and interfaces used to define common properties and methods for all entities in the system. Using these abstractions prevents code duplication and facilitates the implementation of common functionalities across all entities.

- **BaseEntity**: Contains basic properties such as `Id`, `CreatedDate`, and `ModifiedDate`, common to all entities. This allows for automatic tracking and management of these properties throughout the application.
- **IEntity**: May include definitions of methods or additional properties that must be implemented by all entities.

## Project Structure

- `Core`: Contains business logic and domain models.
- `Infrastructure`: Provides implementations for data access, external services, and configurations.
- `Persistence`: Handles database configuration and repositories.
- `Presentation`: Presentation layer, where controllers and other UI components reside.

## Running the Project

1. Clone the repository.
2. Ensure you have the required .NET version installed.
3. Navigate to `src/Simple_Onion_Architecture.WebApi` and execute:
4. Open a browser and go to `http://localhost:5000/swagger` to see the available API endpoints.

## License

The project is made available under the [MIT License](LICENSE).
