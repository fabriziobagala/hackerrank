SELECT DISTINCT City
FROM Station
WHERE MOD(Id, 2) = 0;
