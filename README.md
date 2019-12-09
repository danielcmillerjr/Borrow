# BorrowWorks
Borrow Works - Sample Joke Api

How to Run the application:
      
   Download the code.

   Using Command Line
      Open a command line 
      Navigate to the directory/folder location of the source code
      type the following command
             docker build -t aspnetapp .
      Once everyting is pulls and downloads are complete
   Using Visual Studio
      Open the solutions with visual studio 2019
      if not already installed, install docker desktop

      ensure you using the Docker launch settings.

      Once the application is fired up, Swagger documentation can be found at /Swagger



The applications design leverages the follwing:
1. InMemory Database
   a. prepopulated with some simple jokes
2. .NET Core 3.0
   a. implements Api versioning.
3. gzip Compression
4. Async/Await for vertical scaling
5. Swagger for api documentation
6. Dependency Injection for testability
7. Logging
8. model validation
9. Error handling
10. added an endpoint to care for filtering/searching jokes
11. Dockerized the application.



Vertical Scaling of an application Reference:
https://medium.com/@frederikbanke/improving-scalability-in-c-using-async-and-await-f97af1466922
