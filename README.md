# DemoSurvey
App For Surveying Customers

You can see how it works here:
www.ovnisoftware.com/Survey.aspx

This is the database diagram it is based on:
![](https://github.com/ovnisoftware/DemoSurvey/blob/master/SQL%20Scripts/DatabaseDiagram.jpg)

It utilizes ASP.NET, SQL, LinqToSQL, JQuery and C#.

Here are the steps to get this project to work:
(All the SQL scripts are located here:

https://github.com/ovnisoftware/DemoSurvey/tree/master/SQL%20Scripts

1. Create a SQL database called survey.
2. Run the Survey_Table_Creation.sql script to create the tables.
3. Run CreatingQuestions1.sql script to create first survey question.
4. Run CreatingQuestions2.sql script to create second survey question.
5. Run CreatingQuestions3.sql script to create third survey question.
6. Run InsertData.sql script to simulate some responses
7. Run SProc_ProcessAnswers.sql script to create the AddResponses Stored Procedure
8. Update the connection strings in the project to connect to your database
