USE [DBConnection (WebApplication2)]
GO

ALTER PROCEDURE TestAge
AS BEGIN

DECLARE @id int;
SET @id = 0;
SELECT @id = MAX(ID_Спортсмена) FROM Спортсмен

DECLARE @age datetime, @year int;
SELECT @age = Спортсмен.Дата_рождения FROM Спортсмен WHERE ID_Спортсмена = @id

SET @year = YEAR(@age)
PRINT(@year)
SET @year = 2019 - @year
PRINT(@year)
IF (@year >= 18)

BEGIN
UPDATE Спортсмен SET Группа =  'Старшая' WHERE ID_Спортсмена = @id;
GOTO BrancheOne;
END;

ELSE
UPDATE Спортсмен SET Группа = 'Младшая' WHERE ID_Спортсмена = @id;
GOTO BrancheTwo;


BrancheOne:
BEGIN
PRINT ('Добавлен в старшую группу');
SELECT * FROM Спортсмен WHERE ID_Спортсмена = @id;
GOTO Branche3
END;


Branche3:
BEGIN
RETURN
END;


BrancheTwo:
BEGIN
PRINT ('Добавлен в младшую группу');
SELECT * FROM Спортсмен WHERE ID_Спортсмена = @id;
GOTO Branche3
END;

END;