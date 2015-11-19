declare @sid as int
declare @iid as int

select @sid = 1

INSERT INTO Item
select @sid, 'How likely are you to recommend Visual Studio 2015 to a friend or associate?'

select @iid = @@IDENTITY

insert into ItemAnswer
select @iid, '1', 1

insert into ItemAnswer
select @iid, '2', 2

insert into ItemAnswer
select @iid, '3', 3

insert into ItemAnswer
select @iid, '4', 4

insert into ItemAnswer
select @iid, '5', 5

insert into ItemAnswer
select @iid, '6', 6

insert into ItemAnswer
select @iid, '7', 7

insert into ItemAnswer
select @iid, '8', 8

insert into ItemAnswer
select @iid, '9', 9

insert into ItemAnswer
select @iid, '10', 10

select * from survey
select * from item
select * from ItemAnswer