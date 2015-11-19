declare @sid as int
declare @iid as int

INSERT INTO Survey
select 'Demo Microsoft Customer Survey', NEWID()

select @sid = @@IDENTITY

INSERT INTO Item
select @sid, 'What is your preferred .NET language in Visual Studio?'

select @iid = @@IDENTITY

insert into ItemAnswer
select @iid, 'C#', 1

insert into ItemAnswer
select @iid, 'VB.NET', 2

select * from survey
select * from item
select * from ItemAnswer