-- Retrieve everything from a table
select * from cd.facilities;

-- Retrieve specific columns from a table
select name, membercost from cd.facilities

-- Control which rows are retrieved
select * from cd.facilities where membercost != 0;

-- Control which rows are retrieved - part 2.
select facid, name, membercost,monthlymaintenance from cd.facilities 
where membercost != NULL or membercost > 0 and membercost < monthlymaintenance/50;

-- Basic string searches
select * from cd.facilities where name like '%Tennis%'

-- Matching against multiple possible values
select * from cd.facilities where facid in (1,5);

-- Classify results into buckets
select name, 
		case 
			when monthlymaintenance > 100 then 'expensive'
			else 'cheap' 
		end as cost  
		
from cd.facilities;

-- Removing duplicates, and ordering results
select distinct surname from cd.members order by surname limit 10;


-- Working with dates
select memid, surname, firstname, joindate from cd.members where joindate > '2012-09-01';

-- Simple aggregation
select joindate as latest from cd.members order by joindate desc limit 1;

-- More aggregation
select firstname, surname, joindate from cd.members order by joindate desc limit 1;

-- Combining results from multiple queries
SELECT surname FROM cd.members
UNION 
SELECT name FROM cd.facilities;