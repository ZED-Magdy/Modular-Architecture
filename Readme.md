# I have created this project for a client we didnt close the deal with him so we abandoned it
### I've open sourced this project for educational purposes feel free to use it on ur work or education
#### this is a modular architecture with DDD where u can create a new module with its application/domain/infra and add it to program.cs with IServiceCollection
every module has its dbcontext with a seperated scheme by default so u can easily add a program.cs to it or Http Layer and seperate it to a microservice without changing anything
you just will check for the modules that uses the application services of this module and use the interfaces to create implementation using HttpClient
![system](https://github.com/ZED-Magdy/Modular-Architecture/assets/43310796/b0c4f357-1b7b-415a-84f5-96d34bba202f)
