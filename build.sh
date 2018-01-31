#!/bin/bash

HANDLERS_DIR=Handlers
#build handlers
dotnet publish -c release $HANDLERS_DIR

#install zip
apt-get -qq update
apt-get -qq -y install zip

#create deployment package
pushd $HANDLERS_DIR/bin/release/netstandard2.0/publish
zip -r ./deploy-package.zip ./*
popd
