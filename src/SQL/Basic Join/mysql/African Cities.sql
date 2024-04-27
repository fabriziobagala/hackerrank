SELECT c.Name
FROM City c
LEFT JOIN Country co ON c.CountryCode = co.Code
WHERE co.Continent = 'Africa';
