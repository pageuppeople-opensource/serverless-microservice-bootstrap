# Serverless Microservice Bootstrap

[![serverless](https://dl.dropboxusercontent.com/s/d6opqwym91k0roz/serverless_badge_v3.svg)](http://www.serverless.com)
[![Build Status](https://travis-ci.org/PageUpPeopleOrg/serverless-microservice-bootstrap.svg?branch=making-it-relevant)](https://travis-ci.org/PageUpPeopleOrg/serverless-microservice-bootstrap)

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
Use the following command to deploy from the command line tool
```
serverless deploy
```

#### Expected serverless output
```
λ  serverless deploy                                                                  
Serverless: Packaging service...                                                      
Serverless: Uploading CloudFormation file to S3...                                    
Serverless: Uploading artifacts...                                                    
Serverless: Validating template...                                                    
Serverless: Updating Stack...                                                         
Serverless: Checking Stack update progress...                                         
....................                                                                  
Serverless: Stack update finished...                                                  
Service Information                                                                   
service: serverless-microservice-bootstrap                                            
stage: v1                                                                             
region: ap-southeast-2                                                                
stack: serverless-microservice-bootstrap-v1                                           
api keys:                                                                             
  None                                                                                
endpoints:                                                                            
  GET - https://xxxxxxxx.execute-api.ap-southeast-2.amazonaws.com/v1/healthcheck    
functions:                                                                            
  hello: serverless-microservice-bootstrap-v1-hello                                   
  healthcheck: serverless-microservice-bootstrap-v1-healthcheck      
```

#### Test the deployment

Bootstrap includes a healthcheck endpoint for which the get endpoint will be written console, refer to the deploy output above. A simple curl command like below should verify the deployment.

``curl -i https://xxxxxxxx.execute-api.ap-southeast-2.amazonaws.com/v1/healthcheck``

*Output should be similar to*

```
HTTP/2 200
content-type: application/json
content-length: 2
date: Wed, 10 Jan 2018 15:19:02 GMT
x-amzn-requestid: 95b5bc4a-f619-11e7-8866-43a29ca1cc05
context-type: text/html
x-amzn-trace-id: sampled=0;root=1-5a562ee4-4453904d7fcc88f425547103
x-cache: Miss from cloudfront
via: 1.1 9edc66051886b13f4d282ea125622e34.cloudfront.net (CloudFront)
x-amz-cf-id: eXe9WCo_Kf3futXvyNcHlGGtZ0Yz1X3OxXfxf8XhNweeC-NsDvBomQ==

OK

```


#### Removing after testing
If you are playing around, remember to remove the serverless stack after testing using the following command.

``serverless remove``
