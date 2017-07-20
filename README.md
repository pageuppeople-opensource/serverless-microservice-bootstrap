# Serverless.DotnetCore.Template
[![serverless](https://dl.dropboxusercontent.com/s/d6opqwym91k0roz/serverless_badge_v3.svg)](http://www.serverless.com) 

This is a serverless framework template project created for VS2017.

## Installation

Make sure you have the [Serverless Framework](http://www.serverless.com) installed.
```
npm install serverless -g
```

Install dotnetcore on your machine. If you encounter issues with VS2015, visit the following url to install the appropriate version of dotnetcore sdk.
https://github.com/aspnet/Tooling/blob/master/known-issues-vs2015.md


## Setup

Setup your AWS Credentials in your local environment
```
aws configure
```

## Build

Run the following command in powershell to build the project.
```
build.ps1
```

Use the following command for bash.
```
./build.sh
```

## Test
To run unit tests
```
dotnet test .\src\Tests
```

## Deploy
```
serverless deploy
```



