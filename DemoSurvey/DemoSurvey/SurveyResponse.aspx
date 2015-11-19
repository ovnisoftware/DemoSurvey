<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SurveyResponse.aspx.cs" Inherits="DemoSurvey.SurveyResponse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Survey Response</title>
    <style>
        .question {
            background-color: lightgreen;
        }
    </style>
</head>
<body>
    <h3>Thank you for participating, you have completed the survey!</h3>
    <div runat="server" id="SurveyResults">
    </div>
</body>
</html>