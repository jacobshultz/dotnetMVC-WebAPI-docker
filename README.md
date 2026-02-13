# .NET API + Docker + VS Code Debugging (Dev Container)

This repository is configured so you can run and debug an ASP.NET Core
Web API inside a Docker container using Visual Studio Code.

------------------------------------------------------------------------

## Prerequisites

Install the following on your machine:

-   Docker Desktop (running)
-   Visual Studio Code
-   VS Code Extensions (host):
    -   Dev Containers (Microsoft)
    -   C# / .NET debugger (Microsoft)
    -   (Optional) Docker extension

------------------------------------------------------------------------

## Step 1 -- Start the Debug Container (Host Terminal)

From the repository root directory:

``` bash
docker compose -f docker-compose.debug.yml up -d
docker ps
```

You should see a container like:

    dotnetproj-api-1   Up

To stop the container later:

``` bash
docker compose -f docker-compose.debug.yml down
```

------------------------------------------------------------------------

## Step 2 -- Open the Project in VS Code (Host)

Open VS Code normally and open the repository folder:

File → Open Folder

------------------------------------------------------------------------

## Step 3 -- Reopen in Dev Container

Inside VS Code:

1.  Press Ctrl + Shift + P    (Mac users: CMD Shift P)
2.  Select: Dev Containers: Reopen in Container

VS Code will reload and attach to the running container.

Confirm you are inside the container: - Bottom-left shows: Dev
Container - Open terminal and run:

``` bash
pwd
```

You should see:

    /work

------------------------------------------------------------------------

## Step 4 -- Debug the API

1.  Open `src/Api/Program.cs`
2.  Set a breakpoint inside an endpoint
3.  Press F5
4.  Open in browser:

```{=html}
<!-- -->
```
    http://localhost:8080/weatherforecast

If Swagger is enabled:

    http://localhost:8080/swagger

Your breakpoint should hit when the request executes.

------------------------------------------------------------------------

## Exit Dev Container (Return to Host)

In VS Code:

1.  Press Ctrl + Shift + P
2.  Select: Dev Containers: Reopen Folder Locally

------------------------------------------------------------------------

## Common Fixes

If the container is not running:

``` bash
docker compose -f docker-compose.debug.yml down
docker compose -f docker-compose.debug.yml up -d
```

If debugging behaves strangely, restart VS Code and repeat Step 3.
