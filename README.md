# one-generic-website

Mainly for basic blogging.

## To Do
Things I still want to do with this:
  - [ ] 0100 Get/make a way to do security admin
  - [ ] 0200 Via a hyperlink, incorporate a separately-created react app that hooks into the same identity model, somehow
  - [ ] 0210 (Move this to other app) Be sure to try out [Tanstack Query](https://tanstack.com/query/latest) for data fetching
  - [ ] 0300 Port the main blog part to an API/React architecture
  - [ ] 0390 Add a way for user to switch to a dark theme
  - [ ] 0400 Separate the parts into a clean (or "onion") architecture.  Or at least put models and data-access functionality into separate projects.
  - [ ] 0500 Make the deployment generic and more automated, and test the automation using another simple feature update.  Maybe a green page
  - [ ] 0600 Add markdown parsing
  - [ ] 0700 Add image support
  - [ ] 0800 Add blog records to CRUD
  - [ ] 0900 Add a way to make selected entries public
  - [ ] 1000 Add support for multiple DB back-ends:
      - [ ] 1050 SQL Server
      - [ ] 1100 Oracle
      - [ ] 1150 Postgres
      - [ ] 1200 MySQL
  
## Done already

  - [x] Updated to .NET 8, which is [good until 11/10/2026](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core)
  - [x] Renames the "starter-app" project to "StarterApp"  
        (And update all the namespaces from starter_app to StarterApp)
  - [x] Added identity framework, customize it just enough to let me log in, and 
        add just enough authorization so that I'm the only one who can edit
        things
  - [x] Deploy
  - [x] Add a simple "red page" feature, and document the manual deployment 
        process. (This documentation is not part of the source code because
        it's specific to the author's own environment)

## Tooling notes
  - Primarily using Visual Studio Code, with extensions:
    + C# Dev Kit
    + Todo Tree
  - Use the following to install EF tools (using powershell):  
    `dotnet tool install --global dotnet-ef`
  - Then, to create the sqlLite database artifacts for development/debugging purposes:
    ```
    dotnet ef database update --project StarterApp --context SomeDbContext
    dotnet ef database update --project StarterApp --context SomeIdDbContext
    ```
