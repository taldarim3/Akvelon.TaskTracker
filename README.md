# Task Tracker

**Test task for a candidate on .NET intern position**

This is a WEB-API for Task Tracker application that will allow you to track your projects and tasks. Projects have a name, start and end dates, status and priority. Tasks have a name, description, status and priority. You can create, view, edit, and delete projects and tasks. You can also sort and filter projects by different values.

The project contains a three-level architecture:
 - Data access level
 - Busises logic level
 - Presentation level

## Stack
-   Core: ASP .NET Core 6
-   ORM: Entity Framework
-   Database: PostgreSQL
##

## Instruction
1.  Firstly, you must change connection string in  _appsettings.json_  file stored in  _Akvelon.TaskTracker.PresentationLayer_  project.

Example:

```
"ConnectionStrings": {
    "ConnectionString": "Enter your connection string here"
    }
```

2.  Secondly, run with  _dotnet-cli_  in project directory:

```
dotnet ef database update -s .\Akvelon.TaskTracker.PresentationLayer\ -p .\Akvelon.TaskTracker.DataAccessLayer\
```

3.  Run  the  project.


