#  Umelle - Test Assessment

## Basic Authentication Project

This is an assessment project.


## Build

You have to install .NET 6 SDK to run this project. You can find it on [official Microsoft site](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).

Pull the repo from your favourite IDE(preferably Rider or Visual Studio), it should automatically restore the installed packages. 
If not, use command below

```
dotnet restore
```

Afterwards, you should be able to build the project from your IDE.


## Run

### User Secrets
To run the project, you need to create some User Secrets which are basically,

* "JwtSettings:Secret" to "super-secret-key"
* "JwtSettings:Issuer" to "test"
* "JwtSettings:ExpiryMinutes" to 60
* "JwtSettings:Audience" to "test"
* "ConnectionStrings:sqlConnection" to your connection string to your database

First go to your terminal and change directory to project file.

```
cd .\Umelle24February2023BurakOzenc\
```

And then initialize a user-secret id for the project with command below.
```
dotnet user-secrets init
```

You can set the user secrets with the command below.
```
dotnet user-secrets set "JwtSettings:Secret" "super-secret-key" 
```

The encryption algorithm 'HS256' requires a key size of at least 128 bits.
So your "JwtSettings:Secret" key should have at least 128 bits(or 16 characters).

### Migrations

For database context, you need to create a first migration using command below.
```
dotnet ef add migrations initialMigration
```

And should update the database using command below.
```
dotnet ef database update
```

Now the project is ready to run.

## Usage

Now you can run your project. A Swagger window will open. 


### User/CreateUser
```
POST 200 OK
```

Limitations for **email** field:
* Should be a legit email.
* Can not exceed 244 characters.

Limitations for **password** field:
* Cannot exceed 40 characters.

This method will return a Bearer token which we will use to reach to authenticated method.

### Math/GetRandomNumbers

```
GET 200 OK
```

This method should be called from Postman or any application that you can send header data within your request.
You should use the token returned from **User/CreateUser** method.
If your authentication succeeded, you will receive 4 random numbers between 0 and 100.


## Project Notes

Database can be 