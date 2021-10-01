# Readme
asasd

References

1 - [Paris Xavier Pinkney](
https://medium.com/@pxpgraphics/clean-architecture-3fe6907e7441)

2 - [Microsoft article](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#:~:text=Clean%20architecture%20puts%20the%20business,the%20center%20of%20the%20application.&text=This%20functionality%20is%20achieved%20by,defined%20in%20the%20Infrastructure%20layer.)

 
#### Library(other)
 - [FluentAssertion](https://fluentassertions.com/) is used for the assertion
 - [Nunit](https://nunit.org/) as testing framework
 
 
 # Setup
Restore nuget package
- From terminal


 For windows
 - .Net 5 is required
 - From visual studio 2019+ you can select Api.Http and click on run button
 ![image](https://user-images.githubusercontent.com/21263939/133583039-ce53d2f5-bee2-46c6-8c0f-77f7570903ba.png)
 - From terminal, go inside 
    src/Api.Http path and run `dotnet run`

For linux
 - .Net 5 is required
 - From terminal, go inside 
    src/Api.Http path and run `dotnet run`
 
 For Mac
 - .Net 5 is required
  - From visual studio 2019+ you can select Api.Http and click on run button
 - From terminal, go inside 
    src/Api.Http path and run `dotnet run`

# Tests
For test cases there are two projects 
 - Integration Test(Using in memory db)
 - Unit Test (using mocked db)

Run tests
- From visual studio 2019+ you can select test proect, right click and select option to 'Run Tests'
 - From terminal, go inside test project
    src/Api.Http path and run `dotnet test`
