USE [DBConnection (WebApplication2)]
GO

ALTER PROCEDURE TestAge
AS BEGIN

DECLARE @id int;
SET @id = 0;
SELECT @id = MAX(ID_����������) FROM ���������

DECLARE @age datetime, @year int;
SELECT @age = ���������.����_�������� FROM ��������� WHERE ID_���������� = @id

SET @year = YEAR(@age)
PRINT(@year)
SET @year = 2019 - @year
PRINT(@year)
IF (@year >= 18)

BEGIN
UPDATE ��������� SET ������ =  '�������' WHERE ID_���������� = @id;
GOTO BrancheOne;
END;

ELSE
UPDATE ��������� SET ������ = '�������' WHERE ID_���������� = @id;
GOTO BrancheTwo;


BrancheOne:
BEGIN
PRINT ('�������� � ������� ������');
SELECT * FROM ��������� WHERE ID_���������� = @id;
GOTO Branche3
END;


Branche3:
BEGIN
RETURN
END;


BrancheTwo:
BEGIN
PRINT ('�������� � ������� ������');
SELECT * FROM ��������� WHERE ID_���������� = @id;
GOTO Branche3
END;

END;