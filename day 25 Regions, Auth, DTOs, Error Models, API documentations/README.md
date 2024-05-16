# Tasks
1) [Weather Observation Station](https://www.hackerrank.com/challenges/weather-observation-station-5/problem?isFullScreen=true)
```sql
select top 1 city, len(city) from station order by Len(city), city;
select top 1 city, len(city) from station order by Len(city) desc, city;
```

2) [Harry Potter and Wands](https://www.hackerrank.com/challenges/harry-potter-and-wands/problem?isFullScreen=true)
```sql
select id, age, coins_needed, power from
(select w.id, wp.age, w.coins_needed, w.power, Rank() over(partition by w.power, wp.age order by w.coins_needed) as RFGPA
from wands w join wands_property wp on w.code = wp.code
where wp.is_evil = 0) tmp 
where tmp.RFGPA = 1 order by power desc, age desc;

```

4) Create an API that will allow **users** to *_log in_* to an application where **_they can order pizzas_** from sample **pizza chains** like Dominos or Pizza Hut.

    Add an endpoint that **lists the available pizzas in stock**. 
    Design the necessary **models** and **DTOs** as well.

   
