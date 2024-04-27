SELECT SUM(c.Population)
FROM City c
LEFT JOIN Country co ON c.CountryCode = co.Code
WHERE co.Continent = 'Asia';
