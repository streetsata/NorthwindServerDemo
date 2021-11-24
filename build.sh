#!/bin/bash

docker build -t artem/north:1.2 .

docker stop northwindServer
docker rm northwindServer 

docker run -d -p 5001:5001 --name northwindServer \
    --restart=always \
    artem/north:1.2
