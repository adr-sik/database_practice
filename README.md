# mock_database

Simple datase project utulizing EntityFramework and .NET utilities to communicate with an SQL databse programically using C#. This project demonstrates core database handling concepts and is intended solely for educational purposes, with limited practical use.
Additional details, including class diagrams and other visuals, are available in the accompanying PDF documentation provided as part of the course assignment.

## Demo Overview

The application launches with a login form. To access all demo features, use the following credentials:  
**Username:** 'owner'
**Password:** 'owner'

### GUI Functionality

- The application uses a WinForms GUI with two main tabs:
  - **Devices tab**: Shows devices by type via a combo box; clicking a row opens a form displaying:
    - Associated materials
    - Images of the device (stored as file paths, not hosted)
  - **Playgrounds tab**: Displays playgrounds and allows filtering by completion date; also shows assigned employees.

### Database Design Highlights

- **Entity Framework** is used for database interaction via LINQ.
- **Images** are stored as file paths (no external hosting/server).
- **Device-Material Relationship**: 
  - Many-to-many via a junction table.
  - Devices require at least one material.
- **Device Inheritance**:
  - Implemented using **Table Per Hierarchy (TPH)**.
  - Chosen for efficiency and simplicity in filtering devices by type.
- **Clients**:
  - Two types: *Individual* and *Institution*.
  - Implemented with **Table Per Type (TPT)** strategy.
  - Chosen for clean schema separation with minimal duplication.

### Device Creation Workflow

- "Add" button opens a form where user fills in all required fields.
- After submission:
  - A device object is created and inserted into the database.
  - Related materials are linked via the junction table.
  - The process uses a transaction that only commits on full success.

### Employee–Playground Assignment

- Each playground is implemented by 2–6 employees.
- Assignments are stored in a junction table with:
  - A unique assignment ID.
  - An expiry date.

### Inheritance: Designer and Employee

- Designers can be employees (overlapping inheritance).
- Implemented by giving the `Designer` model a nullable `Employee` field.
- All person-related entities implement the `IPerson` interface.
