SELECT TOP 1 MAX(Salary * Months) AS TotalEarning, COUNT(1)
FROM Employee
GROUP BY Salary * Months
ORDER BY TotalEarning DESC;
