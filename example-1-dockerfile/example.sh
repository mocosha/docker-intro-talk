#!/bin/bash
docker login
docker image build --tag brndusic/static-html:latest --tag brndusic/static-html:1.0 .
docker image ls

docker container run --detach --name static-1.0 -p 8580:80 brndusic/static-html:1.0

# Change some content

docker image build --tag brndusic/static-html:latest --tag brndusic/static-html:1.1 .

# Image history
docker image history brndusic/static-html:1.1

docker container run --detach --name static-1.1 -p 8680:80 brndusic/static-html:1.1

# clean images

docker container rm --force static-1.0 static-1.1
docker image rm brndusic/static-html:latest brndusic/static-html:1.0 brndusic/static-html:1.1