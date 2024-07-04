# Removing Images and Containers

```shell
docker rm container
```

```shell
docker rmi image
```

> [!INFO] You cannot delete a image if that particular image is referenced by containers

```shell
docker rmi image -f
```

- When used the arguement `-f`, the container only will get untagged, not deleted

# Pruning

```shell
docker system prune -a
```

> [!DANGER] All images and containers are wiped out
