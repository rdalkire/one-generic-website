# one-generic-website

Mainly for basic blogging.

## To Do
Things I still want to do with this:

  - [x] Ensure that the project is using a supported version of dotnet
  - [ ] Port it to an API/React architecture
  - [ ] Separate the parts into a clean (or "onion") architecture.  Or at least
        put models and data-access functionality into separate projects.
  - [ ] Make the deployment generic and more automated, and test the automation
  -     using another simple feature update.  Maybe a green page
  - [ ] Add markdown parsing
  - [ ] Add image support
  - [ ] Add blog records to CRUD
  - [ ] Add a way to make selected entries public
  - Add support for multiple DB back-ends:
      - [ ] SQL Server
      - [ ] Oracle
      - [ ] Postgres
      - [ ] MySQL
  - [ ] Add a way for user to switch to a dark theme


## Done already

  - [x] Rename the "starter-app" project to "StarterApp"  
        (And update all the namespaces from starter_app to StarterApp)
  - [x] Add identity framework, customize it just enough to let me log in, and 
        add just enough authorization so that I'm the only one who can edit
        things
  - [x] Deploy
  - [x] Add a simple "red page" feature, and document the manual deployment 
        process. (This documentation is not part of the source code because
        it's specific to the author's own environment)

## Tooling notes
  - Primarily using Visual Studio Code, with extensions:
    + C# Dev Kit
  - Use the following to install EF tools (using powershell):  
    `dotnet tool install --global dotnet-ef`
  - Then, to create the sqlLite database artifacts for development/debugging purposes:
    ```
    dotnet ef database update --project StarterApp --context SomeDbContext
    dotnet ef database update --project StarterApp --context SomeIdDbContext
    ```
