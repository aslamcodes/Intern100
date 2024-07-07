```shell
docker pull postgre

docker run --name some-postgres -e POSTGRES_PASSWORD=mysecretpassword -d postgre

docker exec -it some-postgres bash
```

```sql
create database mydb;

\c mydb

create table Employee (id serial primary key, name varchar(100), age int);

insert into Employee (name, age) values ('John', 30);
insert into Employee (name, age) values ('Jane', 25);
insert into Employee (name, age) values ('Jim', 40);

select * from Employee;
```

Data wasn't there bro, I need some volume
