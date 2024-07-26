# SozlukClone Backend

SozlukClone is a backend project that replicates the functionalities of the popular Turkish social media site "Ekşi Sözlük". This project is built using modern technologies to ensure robustness and scalability.

## Disclaimer

**This project is not completed and is currently under development.**

## Technologies Used

- **ASP.Net Core**: A cross-platform, high-performance framework for building modern, cloud-based, Internet-connected applications.
- **PostgreSQL**: A powerful, open source object-relational database system with a strong reputation for reliability, feature robustness, and performance.
- **NArchitecture.Core**: A comprehensive framework for building applications with a focus on maintainability and modularity.

## Project Structure

The project is organized to follow best practices and ensure a clean architecture:

- **Domain**: Contains the core business logic and entities.
- **Infrastructure**: Handles data access, external services, and other infrastructure concerns.
- **Persistence**: Manages database context and migrations.
- **Application/Services**: Includes application services, use cases, and business rules.
- **WebAPI**: Exposes the application's functionalities through a RESTful API.

## Features

- User authentication and authorization
- Topic creation and management
- Entry posting and management
- Dynamic search function for Titles and Users
- Voting and commenting on entries
- User profiles and settings
- Users can follow each other

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)

### Installation

1. **Clone the repository:**
   ```sh
   git clone https://github.com/yourusername/SozlukClone.git
   cd SozlukClone
   ```
2. **Set up the database:**

   Create a PostgreSQL database.
   Update the connection string in appsettings.json with your database credentials.
   Run the migrations:
   
   ```sh
   dotnet ef database update
   ```

3. **Run the application:**

   ```sh
   dotnet run
   ```

### Running Tests
   To run the tests, use the following command:

   ```sh
   dotnet test
   ```

### Contributing
   Contributions are welcome! Please open an issue or submit a pull request.

### License
   This project is licensed under the MIT License - see the LICENSE file for details.

Feel free to copy and paste this into your README file!
