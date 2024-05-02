select * from Employee;

UPDATE Employee set BossNo = case 
when BossNo = 1 then 1
when BossNo = 3 then 1
else 2 end
where Emp_no = 10;

Delete from Employee where Emp_name = 'Gita';

Delete from Employee;