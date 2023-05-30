# **Meselal Onboarding**

## Backend

### IDK

* [.NET 6.0](https://dotnet.microsoft.com/en-us/download "Download .NET For Windows")
* [Visual Studio 2022](https://visualstudio.microsoft.com/downloads "Download Visual Studio")
* [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/ "")

### Code Organization

### SCREENSHOT

1. Contexts
    > DB
2. Controllers
    > Endpoints
3. DTOs
    > [Data Transfer Object](https://learn.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-5 "Microsoft Docs on DTOs") - is an object that carries data between processes.
4. Migrations
    > DO NOT TOUCH!
5. Models
    > Object to be mapped to a SQL database table
6. Services
    > Where the magic happens.
7. Utils
    > Where we store our utility files like Constants, Mapper Profile (more on that later)

## Frontend

1. Open the file.
2. Find the following code block on line 21:

        <html>
          <head>
            <title>Test</title>
          </head>

3. Update the title to match the name of your website.
