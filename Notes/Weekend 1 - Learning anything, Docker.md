# How to learn anything?
## The 10,000 Hours Rule
- If you wanna be good at something, It takes 10k hours
- But I dont have 10k hours, 
- for 10k you'll become expert level
## But?
- Its not 10k hours to learn something
- ![[Pasted image 20240419104031.png]]
-![[Pasted image 20240419104149.png]]
## The 20Hours
- If you put 20 hours of focus, you'll be a standard,
- 45min a day for a couple of month
## The Steps
- Deconstruct - Decide what you'll be able to do after learning, break them down into smaller skills
- Learn enough to self correct
- Remove practice barriers (Distractions, Internet)
- Practice for atleast 20 hours;
## 
# Docker
## Background Knowledge
### What is Container?
- A Isolated environment to the code
- Container has everything that code needs to run, down to OS.
### What is a Virtual Machine?
- Digital Computer that behaves like a physical machine.
- It also have to have separate resources unlike containers?
- Virtualization is the process of creating a **virtual version or representation** of computing resources like servers, storage devices, operating systems (OS), or networks that are abstracted from the physical computing hardware.
### Simple Diff?
- Containers has virtualized OS
- VMs has entire physical computer virtualized
### Are VMs obsolete?
. VMs are still necessary for running heavy-duty workloads or legacy applications that need a complete operating system environment, and migrating monolith application to cloud environment

> https://www.youtube.com/watch?v=cjXI-yxqGTI


## How to use Docker?
### What is an Image?
- More like a Class(image, blueprint) that produces objects (Containers)
- It is from where the docker container gets all the files from
- Images are immutable
### How to get things up and running?
- You set the instructions in dockerfile
- and you build an image with the instruction
- and you build containers using that image