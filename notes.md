## Docker and docker-compose presentation

If we want to do this as a workshop, important thing is to prepare all memebers before starting a workshop or some of presentation time will be lost on preparing docker environment.

Create git repo for this: store presentation and source there

### Talk
- What is docker?
- Why you need docker and why not?
- History of docker
- Docker vs LXC vs VM
- What is docker-compose?
- Example of running some docker container from public image with docker CLI
- Example of creating custom image from Dockerfile
	- run for example some azbooky service (dotnet) inside
	- create some new service
- Running same image inside docker-compose and orchestrate it with some dependency container
	- explain how volumes are working
	- explain how networks are working
	- show load balancing round-robin example?
- Explain how images and repositories for images are working

### Extra for talk
- docker swarm ????
- scaling with docker-compose ????
- docker-machine? this loooks obsolete but needs checking
- some words about kubernetes ????
- Kubernetes, Mesos, and Docker Swarm 

### Example presentations

https://www.slideshare.net/mario21ic/docker-compose-to-production-with-docker-swarm
http://linhmtran168.github.io/docker-compose-slides

###  Presentation
https://github.com/hakimel/reveal.js/
https://github.com/fsprojects/FsReveal