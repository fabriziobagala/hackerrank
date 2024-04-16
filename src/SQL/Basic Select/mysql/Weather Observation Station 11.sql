SELECT DISTINCT City
FROM Station
WHERE City NOT RLIKE '^[aeiou].*[aeiou]$';
