#!/bin/bash

export AWS_ACCESS_KEY_ID=$AWS_SECRET_ID && export AWS_SECRET_ACCESS_KEY=$AWS_SECRET_KEY
serverless deploy --stage v1 --region ap-southeast-2

