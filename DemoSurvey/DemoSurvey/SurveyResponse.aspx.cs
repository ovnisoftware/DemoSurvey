using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DemoSurvey
{
    public partial class SurveyResponse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connString = "Enter your connection string here";
            string queryTotalResponders = "select count(responseId) from response where surveyId = 1";
            string querySurveyQuestions = "select itemText from item where surveyid=1";
            string queryQuestion1Results = "SELECT ItemAnswer.ItemId, ItemAnswer.AnswerText, COUNT(ResponseAnswer.AnswerId) AS 'NumResponses' FROM ItemAnswer LEFT OUTER JOIN ResponseAnswer ON ItemAnswer.AnswerId = ResponseAnswer.AnswerId WHERE ItemId = 100 GROUP BY ItemAnswer.AnswerId, ItemAnswer.AnswerText, ResponseAnswer.AnswerId, ItemAnswer.ItemId ORDER BY ItemAnswer.AnswerId";
            string queryQuestion2Results = "SELECT ItemAnswer.ItemId, ItemAnswer.AnswerText, COUNT(ResponseAnswer.AnswerId) AS 'NumResponses' FROM ItemAnswer LEFT OUTER JOIN ResponseAnswer ON ItemAnswer.AnswerId = ResponseAnswer.AnswerId WHERE ItemId = 101 GROUP BY ItemAnswer.AnswerId, ItemAnswer.AnswerText, ResponseAnswer.AnswerId, ItemAnswer.ItemId ORDER BY ItemAnswer.AnswerId";
            string queryQuestion3Results = "SELECT ItemAnswer.ItemId, ItemAnswer.AnswerText, COUNT(ResponseAnswer.AnswerId) AS 'NumResponses' FROM ItemAnswer LEFT OUTER JOIN ResponseAnswer ON ItemAnswer.AnswerId = ResponseAnswer.AnswerId WHERE ItemId = 102 GROUP BY ItemAnswer.AnswerId, ItemAnswer.AnswerText, ResponseAnswer.AnswerId, ItemAnswer.ItemId ORDER BY ItemAnswer.AnswerId";

            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand(queryTotalResponders, conn);
                int total = (int)cmd1.ExecuteScalar();

                StringBuilder sb = new StringBuilder();
                sb.Append("Total Number of Responders: " + total + "<br/>");
                sb.Append("<br/>");

                SqlCommand cmd2 = new SqlCommand(querySurveyQuestions, conn);
                SqlDataReader rdr1 = cmd2.ExecuteReader();
                List<string> surveyQuestions = new List<string>();
                while (rdr1.Read())
                    surveyQuestions.Add(rdr1[0].ToString());
                rdr1.Close();
                sb.Append("<div class='question'>" + surveyQuestions[0] + "</div>");

                SqlCommand cmd3 = new SqlCommand(queryQuestion1Results, conn);
                SqlDataReader rdr2 = cmd3.ExecuteReader();
                while (rdr2.Read())
                {
                    sb.Append(rdr2[1].ToString() + ", ");
                    sb.Append(rdr2[2].ToString());
                    sb.Append("<br/>");
                }
                rdr2.Close();
                sb.Append("<div class='question'>" + surveyQuestions[1] + "</div>");

                SqlCommand cmd4 = new SqlCommand(queryQuestion2Results, conn);
                SqlDataReader rdr3 = cmd4.ExecuteReader();
                while (rdr3.Read())
                {
                    sb.Append(rdr3[1].ToString() + ", ");
                    sb.Append(rdr3[2].ToString());
                    sb.Append("<br/>");
                }
                rdr3.Close();
                sb.Append("<div class='question'>" + surveyQuestions[2] + "</div>");

                SqlCommand cmd5 = new SqlCommand(queryQuestion3Results, conn);
                SqlDataReader rdr4 = cmd4.ExecuteReader();
                while (rdr4.Read())
                {
                    sb.Append(rdr4[1].ToString() + ", ");
                    sb.Append(rdr4[2].ToString());
                    sb.Append("<br/>");
                }
                rdr4.Close();
                SurveyResults.InnerHtml = sb.ToString();
            }
            catch
            {
                SurveyResults.InnerHtml = "Database error";
            }
        }
    }
}