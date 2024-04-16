WITH CTE AS (
    SELECT City, LEN(City) AS Length,
    ROW_NUMBER() OVER (ORDER BY LEN(City), City) AS rn_asc,
    ROW_NUMBER() OVER (ORDER BY LEN(City) DESC, City) AS rn_desc
    FROM Station
)
SELECT City, Length FROM CTE WHERE rn_asc = 1
UNION
SELECT City, Length FROM CTE WHERE rn_desc = 1;
