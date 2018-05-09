#!/bin/bash

docker-compose up

docker container run --network=private-example-network --rm appropriate/curl -fsSL http://static-file-server/

docker-compose scale static-file-server-one=3 static-file-server-two=2