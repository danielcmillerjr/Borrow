BorrowWorks Joke Web API

Using .NET Core 3.0
	InMemory Database
	With a Service/Repository design

How To run the application?
Visual Studio on Windows: 
	Prerequesits:
		Visual studio (2019) 16.4 or higher
		.Net Core 3.0 
		Docker for Windows

	1. Create a pull request.
	2. once downloaded unzip the contents to a working directory
	3. Open with Visual studio
		a. A docker profile should be available for you in the launchSettings.json.
		b. Change to the docker launch profile and hit F5.


Docker for Windows Command Line:
	1. Before you add your .NET Core app to the Docker image, publish it.
		a. dotnet publish -c Release

			E.G. C:\Users\websi\Source\Repos\Jokes\Jokes.WebApi>dotnet publish -c Release
					Microsoft (R) Build Engine version 16.4.0+e901037fe for .NET Core
					Copyright (C) Microsoft Corporation. All rights reserved.

					  Restore completed in 145.28 ms for C:\Users\websi\Source\Repos\Jokes\Jokes.WebApi\Jokes.WebApi.csproj.
					  Jokes.WebApi -> C:\Users\websi\Source\Repos\Jokes\Jokes.WebApi\bin\Release\netcoreapp3.0\Jokes.WebApi.dll
					  Jokes.WebApi -> C:\Users\websi\Source\Repos\Jokes\Jokes.WebApi\bin\Release\netcoreapp3.0\publish\

		b. This command compiles your app to the publish folder. The path to the publish folder from the working folder should be .\app\bin\Release\netcoreapp[Version]\publish\
	2. The Dockerfile in the project is used by the docker build command to create a container image. 
		a. docker build -t jokesimage -f Dockerfile .
		b. To list the available containers
			docker ps -a 
	3. Create a container
		a.  docker create jokesimage --name jokes
	4. Manage the container
		a. docker start jokes
	5. Other interesting commands
		docker build
		docker run
		docker ps
		docker stop
		docker rm
		docker rmi
		docker image
	6. Reference: https://docs.microsoft.com/en-us/dotnet/core/docker/build-container