declare @sid int
select top 1 @sid = surveyId from Survey order by SurveyId desc

declare @responseid int

declare @count int = 1

while @count <= 10
begin
	insert into response
	select @sid, GETDATE()

	set @responseid = @@IDENTITY

	if @count <= 6
	begin
		insert into ResponseAnswer
		select @responseid, 1000 --C#

		insert into ResponseAnswer
		select @responseid, 1011 --10

		insert into ResponseAnswer
		select @responseid, 1021 --10
	end
	else
	begin
		insert into ResponseAnswer
		select @responseid, 1001 --VB.NET

		insert into ResponseAnswer
		select @responseid, 1009 --8

		insert into ResponseAnswer
		select @responseid, 1019 --8
	end
	set @count = @count + 1
end


select * from Response
select * from ResponseAnswer