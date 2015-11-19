<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Survey.aspx.cs" Inherits="DemoSurvey.Survey" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Demo Survey</title>
    <link href="css/survey.css" rel="stylesheet" />
    <link href="css/jquery-ui.css" rel="stylesheet" />
    <script src="js/jquery-2.1.4.min.js"></script>
    <script src="js/jquery-ui.js"></script>
    <script src="js/survey.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="startup" class="startup">
            <br />
            <input id="ButtonStart" type="button" value="Start Survey" />
        </div>
        <br />
        <div id="survey" runat="server">
            <div class="surveyHead">Demo Survey</div>
            <div class="surveyBody">
                <div id="question1">
                    <br />
                    <asp:Panel ID="PanelQuestion1" runat="server">
                        <asp:Label ID="LabelQuestion1" runat="server"></asp:Label>
                    </asp:Panel>
                    <input id="buttonQ1" type="button" value="Next" />
                </div>

                <div id="question2">
                    <br />
                    <asp:Panel ID="PanelQuestion2" runat="server">
                        <asp:Label ID="LabelQuestion2" runat="server"></asp:Label>
                    </asp:Panel>
                    <input id="buttonQ2" type="button" value="Next" />
                </div>

                <div id="question3">
                    <asp:Button ID="Button3" runat="server" Text="Next" Visible="false" />
                    <br />
                    <asp:Panel ID="PanelQuestion3" runat="server">
                        <asp:Label ID="LabelQuestion3" runat="server"></asp:Label>
                    </asp:Panel>
                    <input id="buttonQ3" type="button" value="Next" />
                </div>

                <div id="endOfSurvey">
                    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="Button4_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
