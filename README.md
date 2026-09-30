# 🎓 Student Management System (Console Application)

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/Language-C%23%2013-239120?logo=csharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Platform](https://img.shields.io/badge/Platform-Cross--Platform-lightgrey.svg)]()
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

A clean, modular, and menu-driven **Student Management System** built with **C#** and **.NET**. Designed following layered architecture and object-oriented programming (OOP) principles, this application allows educators and administrators to perform complete CRUD (Create, Read, Update, Delete) operations on student records directly from the terminal.

---

## 📑 Table of Contents

- [Features](#-features)
- [Architecture & Design](#-architecture--design)
- [Project Structure](#-project-structure)
- [Validation & Business Rules](#-validation--business-rules)
- [Prerequisites](#-prerequisites)
- [Installation & Getting Started](#-installation--getting-started)
- [Sample Usage Walkthrough](#-sample-usage-walkthrough)
- [Roadmap & Future Improvements](#-roadmap--future-improvements)
- [Contributing](#-contributing)
- [License](#-license)
- [Author](#-author)

---

## ✨ Features

- ➕ **Add Student**: Enrolls new students with auto-incrementing unique IDs and robust validation.
- 📋 **View Students**: Displays all stored students in a clean, tabular format.
- 🔍 **Search Student**: Look up any student instantly by their unique ID.
- ✏️ **Update Student**: Modify a student's name, age, or grade with flexible in-place editing (skip unchanged fields).
- 🗑️ **Delete Student**: Safely remove student records by ID.
- 🛡️ **Defensive Validation**: Re-prompts on invalid inputs (empty names, invalid ages, non-standard grades) to prevent runtime crashes.
- 🔄 **Continuous Menu Loop**: Smooth console interface powered by strongly-typed enums.

---

## 🏛️ Architecture & Design

The application emphasizes **Separation of Concerns (SoC)** and adheres to standard **N-tier / Layered Architecture**:

```
┌────────────────────────────────────────┐
│            ConsoleUI (UI)              │  <-- Presentation Layer (User input/output)
└───────────────────┬────────────────────┘
                    │
┌───────────────────▼────────────────────┐
│         StudentService (Services)      │  <-- Business Logic & Validation Layer
└───────────────────┬────────────────────┘
                    │
┌───────────────────▼────────────────────┐
│      StudentRepository (Repositories)  │  <-- Data Access Layer (In-memory storage)
└───────────────────┬────────────────────┘
                    │
┌───────────────────▼────────────────────┐
│          Student (Models)              │  <-- Domain Entity Layer
└────────────────────────────────────────┘
```

- **Models**: Defines the domain entity `Student` using modern C# features (`required`, `init`, nullable reference types).
- **Repositories**: Encapsulates data access and storage operations using generic collections and LINQ.
- **Services**: Enforces business validation rules and acts as an intermediary between the UI and storage layers.
- **UI**: Manages terminal menus, user prompts, input parsing, and output formatting.
- **Enums**: Provides strongly-typed menu options (`MainMenuOptions`) to avoid magic numbers.

---

## 📂 Project Structure

```text
Student-Managerment-Console-/
├── Enums/
│   └── MainMenuOptions.cs          # Enum defining interactive menu actions
├── Models/
│   └── Student.cs                  # Student entity (Id, Name, Age, Grade)
├── Repositories/
│   └── StudentRepository.cs        # In-memory CRUD data access logic
├── Services/
│   └── StudentService.cs           # Business logic & field validation
├── UI/
│   └── ConsoleUI.cs                # Console interaction and menu handler
├── .gitignore                      # Git ignore rules for .NET build artifacts
├── Program.cs                      # Application entry point
├── README.md                       # Project documentation
└── Student Management(Console).csproj # .NET project configuration
```

---

## 📏 Validation & Business Rules

| Field | Rule / Constraint | Description |
|---|---|---|
| **ID** | Auto-incremented (`int`) | Automatically generated starting from `1`. |
| **Name** | Non-empty (`string`) | Cannot be null, empty, or whitespace. |
| **Age** | Positive number (`int > 0`) | Must be a valid positive integer. |
| **Grade** | Allowed values: `A`, `B`, `C`, `D`, `F` | Case-insensitive input; automatically converted to uppercase. |

---

## ⚙️ Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (**.NET 8.0, 9.0, or 10.0+**)
- Any code editor or IDE (Visual Studio, VS Code, JetBrains Rider) or terminal

---

## 🚀 Installation & Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/HevilChaudhari/Student-Managerment-Console-.git
cd Student-Managerment-Console-
```

### 2. Build the Application

```bash
dotnet build
```

### 3. Run the Application

```bash
dotnet run
```

---

## 🖥️ Sample Usage Walkthrough

### Main Menu

```text
======================================
Student Management System
======================================

1. Add Student
2. View Students
3. Search Student
4. Update Student
5. Delete Student
6. Exit

Choose an option : 1
```

### Adding a Student

```text
Enter a name : Alice Johnson
Enter Age : 20
Enter Grade : A

Student Added SucessFully
```

### Viewing All Students

```text
1. Add Student
2. View Students
3. Search Student
4. Update Student
5. Delete Student
6. Exit

Choose an option : 2

1       Alice Johnson   20      A
```

---

## 🗺️ Roadmap & Future Improvements

- [ ] **Persistent Storage**: Integrate SQLite / Entity Framework Core or JSON file serialization.
- [ ] **Search & Filtering**: Search by name or filter by grade.
- [ ] **Data Export**: Export student lists to CSV or JSON formats.
- [ ] **Unit Tests**: Implement test coverage using xUnit or NUnit.
- [ ] **Sorting**: Sort student records by ID, Name, or Grade.

---

## 🤝 Contributing

Contributions are welcome! If you have suggestions or bug fixes, feel free to open an issue or submit a pull request.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## 📄 License

This project is open-source and available under the [MIT License](LICENSE).

---

## 👤 Author

**Hevil Chaudhari**  
- GitHub: [@HevilChaudhari](https://github.com/HevilChaudhari)
