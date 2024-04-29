SELECT co.Continent, FLOOR(AVG(c.Population))
FROM City c
INNER JOIN Country co ON c.CountryCode = co.Code
GROUP BY co.Continent;
