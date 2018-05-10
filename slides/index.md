- title : Docker Intro Talk
- description : Introduction to Docker and docker-compose
- author : Mladen Brndušić and Evgeny Grebenyuk
- theme : night
- transition : default

***

## Docker Intro Talk

<br />
<br />

### Introduction to Docker and docker-compose

<br />
<br />
Mladen Brndušić - [@brndusic](https://github.com/brndusic)
<br />
Evgeny Grebenyuk - [@eugene-g](https://github.com/eugene-g)

***

### Docker

* What is docker
    * Docker is a tool designed to make it easier to create, deploy, and run applications by using containers. 
* What are containers?
    * Containers allow a developer to package up an application with all of the parts it needs, such as libraries and other dependencies, and ship it all out as one package.

***

### Benefits of Docker

* Reproducibility
* Isolation
* Security
* Docker Hub
* Environment Management
* Continuous Integration

[// When and why to use docker]: <>  https://www.linode.com/docs/applications/containers/when-and-why-to-use-docker/

---

### When to Use Docker

* Learning new technologies
* Basic use cases
* App isolation
* Developer teams

---

### When Not to Use Docker

* Your app is complicated and you are not/do not have a sysadmin
* Performance is critical to your application
* Security is critical to your application

---

### Should you use Docker Containers?

---


```bash
# Run PostgreSQL container
docker container run -d --name postgresDB postgres
docker container rm postgresDB
```

#### VS

```bash
# Install PostgreSQL
sudo apt-get install postgresql
# setup firewall, users, no isolation
sudo apt-get uninstall postgresql
```

***

### History of Docker and containers

* 1979: Unix V7 - chroot
* 2000: FreeBSD Jails - jails
* 2004: Solaris Containers - snapshots
* 2005: Open VZ (Open Virtuozzo) - OS level virtualization
* 2008: LXC - containers
* 2013: Docker 

[// A brief history of Docker Containers overnight success]: <> https://searchservervirtualization.techtarget.com/feature/A-brief-history-of-Docker-Containers-overnight-success
[// A brief history of containers from 1970s chroot to docker 2016]: <> https://blog.aquasec.com/a-brief-history-of-containers-from-1970s-chroot-to-docker-2016

***

### Docker vs LXC vs VM

* VM - Virtual Machine
    * Entire Virtual Machine setup
* LXC - LinuX Containers
    * No preloaded emulation manager software as in a VM
    * Requires extra learning and expertise
* Windows Containers
    * Windows Server 2016
* Docker
    * Portable
    * Crossplatform
    * Versioning
    * Component reuse
    * Shared libraries like Docker Hub

[//1]: <> https://www.upguard.com/articles/docker-vs-lxc
[//2]: <> https://stackoverflow.com/questions/17989306/what-does-docker-add-to-lxc-tools-the-userspace-lxc-tools

***

### Docker image

* Docker image is an inert, immutable, file that's essentially a snapshot of a container
* Docker image is built up from a series of layers. Each layer represents an instruction in the image's Dockerfile. Each layer except the very last one is read-only.

---

### Docker Container

* An instance of an image is called a container

---

### Creating image from Dockerfile

* Dockerfile example

```bash
FROM microsoft/aspnetcore
WORKDIR /app
COPY . .
EXPOSE 5000
ENTRYPOINT ["dotnet", "SampleService.dll"]
```

<br />

* Creating image from Docker file

```bash
docker image build --tag image_name ./Dockerfile
```


---

### Image tags and layers

* Images can be tagged like on git
* Only differences are using space
* Repository is used for storing and sharing images

***

### Container orchestration

* Docker Compose
* Docker Swarm
* Rancher
* Mesos
* Kubernetes
* Helm


[//3]: <> https://www.slant.co/topics/3929/~docker-orchestration-tools

*** 

# Thank you!
