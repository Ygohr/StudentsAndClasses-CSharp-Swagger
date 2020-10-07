# Technical Challenge - Marlin
A **C# Entity .NETCore API** for Students and Classes, using **Swagger, Authentications and SQLServer**.
Developed by **Ygohr Medeiros** for technical challenge of **Marlin**.

## -> Technologies
This project uses **C# Asp.NET-Core with Swagger**, containing **Authentications/Authorization ** with ** JWT Bearer Token**. For the database: **SQLServer**.

## -> Dependecies:
To run the project you'll need to have installed:

- Microsoft.AspNetCore.Authentication
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Swashbuckle.AspNetCore
- SQL

## -> How to
The API have some methods that can be accessed with **Token Authorization** by Login route. To do so, you'll need to provide a login information that matches in database.
After getting the token, you need to authorize the access to methods by the button **"Authorize"** in the header of **SwaggerUI**, for example:
 **- Bearer TokenKey**
The access **without token authorization is not possible.**
