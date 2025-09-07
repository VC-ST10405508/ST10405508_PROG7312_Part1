# South African Municipality platform

## A simple ASP.NET Core MVC web application built with:

~ Visual Studio (latest version)

~ ASP.NET Core MVC

~ Entity Framework Core with SQLite (serverless so its easy to run on any machine :D)

~ Dependency Injection using the Repository + Interface pattern

## Features:

-> User can create and login to their account
-> Report issues - users can report issues in the municipality area
-> Feedback user engagement strategy - users can provide feedback on thier experience using the platform
-> more features coming soon (stay tuned)

## Considerations:

- Repository pattern for clean separation of concerns

- Entity Framework Core for data persistence (SQLite .db file, no external server required)

- Auto-create database on startup with EnsureCreated()

- MVC pattern (Models, Views, Controllers)

- Dependency Injection configured in Program.cs



## Technologies: 

- .NET 8 / ASP.NET Core MVC
- Entity Framework Core (SQLite)
- Dependency Injection
- C# 12

## Getting Started to run program on your side: 
Prerequisites:

- .NET 8 SDK
- Visual Studio (latest version)
- SQLite (no setup required, database auto-generates)

## Setup
- Close repository
open visual studio and click clone repository then copy past the following:
https://github.com/VC-ST10405508/ST10405508_PROG7312_Part1.git 

- open the project
open the project in visual code if it didnt open already

- Run the app
Once project is open run it using IIS Express

- Enjoy
hope this guide helps and that you are able to user the platform as intended

## Database

- SQLite database file is stored in Data/app.db
- EF Core DbContext defines tables for User, Document, and ReportIssue
- On first run, database and tables are created automatically

# License

This project is licensed under the MIT License - entity framework uses MIT licenses

