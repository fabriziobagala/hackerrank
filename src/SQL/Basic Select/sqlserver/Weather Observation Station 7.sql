SELECT DISTINCT City
FROM Station
WHERE RIGHT(City, 1) IN ('A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u');
