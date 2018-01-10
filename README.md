# Serverless Microservice Bootstrap

[![serverless](https://dl.dropboxusercontent.com/s/d6opqwym91k0roz/serverless_badge_v3.svg)](http://www.serverless.com) 
[![Build Status](https://travis-ci.org/PageUpPeopleOrg/serverless-microservice-template.svg?branch=master)](https://travis-ci.org/PageUpPeopleOrg/serverless-microservice-template)

This is a serverless framework template project for creating microservices using microsoft dotnet core.

## Getting Started

Make sure you have the [Serverless Framework](http://www.serverless.com) installed.
```
npm install serverless -g
```

Install dotnet core on your machine. Instructions can be found at (dotnet website)[https://www.microsoft.com/net/download]


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

### Continous deployment with Travis
The repository is configured for continous deployment with Travis. Refer to the include `.travis.yml` file.
For the purpose of templating, deployment section has been commented out. Please uncomment the following lines in `.travis.yml`.

```
deploy:
- provider: script
  skip_cleanup: true
  script: "./deploy.sh"
  on:
    branch: master
```

### To deploy from the command line
```
serverless deploy
```
