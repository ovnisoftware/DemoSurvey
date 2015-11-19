CREATE PROCEDURE AddResponses(
@SurveyId INT,
@ItemId1 INT,
@AnswerText1 NVARCHAR(2500),
@ItemId2 INT,
@AnswerText2 NVARCHAR(2500),
@ItemId3 INT,
@AnswerText3 NVARCHAR(2500)
)
AS
DECLARE @Answer1 INT
DECLARE @Answer2 INT
DECLARE @Answer3 INT

BEGIN

SELECT @Answer1 = AnswerId
FROM ItemAnswer
WHERE AnswerText = @AnswerText1 AND ItemId = @ItemId1

SELECT @Answer2 = AnswerId
FROM ItemAnswer
WHERE AnswerText = @AnswerText2 AND ItemId = @ItemId2

SELECT @Answer3 = AnswerId
FROM ItemAnswer
WHERE AnswerText = @AnswerText3 AND ItemId = @ItemId3

INSERT INTO Response
SELECT 1, GETDATE()

DECLARE @ResponseId INT
SET @ResponseId = @@IDENTITY

BEGIN
INSERT INTO ResponseAnswer
SELECT @ResponseId, @Answer1
END

BEGIN
INSERT INTO ResponseAnswer
SELECT @ResponseId, @Answer2
END

BEGIN
INSERT INTO ResponseAnswer
SELECT @ResponseId, @Answer3
END

END