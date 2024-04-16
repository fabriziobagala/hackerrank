SELECT DISTINCT City 
FROM Station 
WHERE City NOT LIKE '[aeiou]%' AND 
      City NOT LIKE '%[aeiou]';
