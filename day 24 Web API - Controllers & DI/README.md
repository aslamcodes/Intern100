# Task 1 - Doctor Clinic WEB Api

[Task folder](https://github.com/aslamcodes/Intern100/tree/main/day%2024%20Web%20API%20-%20Controllers%20%26%20DI/DoctorClinicSLN)

## Description

Implement the following features in the ClinicAPI:

1. List all doctors
2. Update doctor information
3. List doctors based on their experience
4. List doctors based on their speciality

## Steps

1. Implement an API endpoint to retrieve a list of all doctors.
2. Implement an API endpoint to update a doctor's information.
3. Implement an API endpoint to retrieve a list of doctors based on their experience.
4. Implement an API endpoint to retrieve a list of doctors based on their speciality.

## Expected Output

The expected output of completing this task is a fully functional ClinicAPI with the above-mentioned features implemented.

## Additional Notes

- Make sure to handle any necessary validations and error handling.
- Use appropriate HTTP methods and status codes for each API endpoint.


# Task 2 - Daily SQL
1) [More than 75 marks](https://www.hackerrank.com/challenges/more-than-75-marks/problem?isFullScreen=true) 
```sql
SELECT NAME FROM STUDENTS WHERE MARKS > 75 ORDER BY RIGHT(NAME,3), ID ASC
```
2) [Contest Leaderboard](https://www.hackerrank.com/challenges/contest-leaderboard/problem?isFullScreen=true)
```sql
SELECT M.hacker_id, H.name, SUM(M.score) from (select hacker_id ,max(score) 'score' from Submissions group by hacker_id, challenge_id) as M 
join hackers H on H.hacker_id = M.hacker_id
group by M.hacker_id, H.name
having SUM(M.score) > 0
order by SUM(M.score) desc, hacker_id;
```
