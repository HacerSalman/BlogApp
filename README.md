# BlogApp
Sample Blog using .Net 5, EF, Repository Pattern, UnitofWork, AutoMapper, Ajax, JQuery, MySql, Mvc, Fluent Api

## Getting Started
The solution contains 5 different projects. They are Api,Mvc,Data,Shared and Test.
Api contains web api endpoints.
Mvc is a web application for blog app.
Data contains entities,enums,context and migrations.
Shared contains repositories, unitOfWork, services and utils.
Test contains unit tests for services methods.
To run these projects on your own computer, add the BLOG_APP_DB_CONNECTION variable to the environmet variables 
and add the connection string of the mysql database you set on your computer as the value. After that write  
`dotnet ef database update`
command to Package Manager Console Window for generate database tables.

## Architecture
This repository uses Repository Patterns and UnitOfWork. Also uses Dependency Inversion and Single responsibility SOLID principles.
All services and repository classes are dependent on interfaces instead of being dependent on each other, 
thus becoming compatible with the dependencies inversion principle.Thanks to the Repository Pattern, the Single Responsibility 
principle is followed by using a separate method for each process.

## Used technologies
.Net 5, Entity Framework, Repository Pattern, UnitofWork, AutoMapper, Ajax, JQuery, Nunit, Moq, MySql, Mvc, Fluent Api, Asynchronous Programming

##Note: I haven't finished this project yet, it's under development
