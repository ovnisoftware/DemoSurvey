using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;

namespace DemoSurvey
{
    public partial class Survey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connString = "Enter your connection string here";
            try
            {
                DataContext db = new DataContext(connString);
                Table<SurveyItem> item = db.GetTable<SurveyItem>();
                Table<SurveyItemAnswer> itemAnswer = db.GetTable<SurveyItemAnswer>();

                var questions = from i in item
                                orderby i.ItemId
                                select i;

                var itemAnswers = from answers in itemAnswer
                                  orderby answers.AnswerId
                                  select answers;

                //Question 1
                var questionOneAnswers = itemAnswers.Where(p => p.ItemId == 100);
                questionOneAnswers.ToList();
                LabelQuestion1.Text = questions.First().ItemText;
                LabelQuestion1.Text += "<br/>";

                foreach (var answer in questionOneAnswers)
                {
                    RadioButton rbtn = new RadioButton();
                    rbtn.GroupName = "Q1Answers";
                    rbtn.Text = answer.AnswerText;
                    rbtn.Attributes.Add("value", answer.AnswerText);
                    PanelQuestion1.Controls.Add(rbtn);
                }

                //Question 2
                LabelQuestion2.Text += questions.Skip(1).First().ItemText;
                var questionTwoAnswers = itemAnswers.Where(p => p.ItemId == 101);
                LabelQuestion2.Text += "<br/>";
                foreach (var answer in questionTwoAnswers)
                {
                    RadioButton rbtn = new RadioButton();
                    rbtn.GroupName = "Q2Answers";
                    rbtn.Text = answer.AnswerText;
                    rbtn.Attributes.Add("value", answer.AnswerText);
                    PanelQuestion2.Controls.Add(rbtn);
                }

                //Question 3
                LabelQuestion3.Text += questions.Skip(2).First().ItemText;
                var questionThreeAnswers = itemAnswers.Where(p => p.ItemId == 102);
                LabelQuestion3.Text += "<br/>";
                foreach (var answer in questionThreeAnswers)
                {
                    RadioButton rbtn = new RadioButton();
                    rbtn.GroupName = "Q3Answers";
                    rbtn.Text = answer.AnswerText;
                    rbtn.Attributes.Add("value", answer.AnswerText);
                    PanelQuestion3.Controls.Add(rbtn);
                }
            }
            catch
            {
                LabelQuestion1.Text = "Database Error";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string answer1 = getRadioValue(this.Controls, "Q1Answers");
            string answer2 = getRadioValue(this.Controls, "Q2Answers");
            string answer3 = getRadioValue(this.Controls, "Q3Answers");

            string connString = "Enter your connection string here";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                SqlCommand cmd = new SqlCommand("AddResponses", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@SurveyId";
                parameter1.SqlDbType = SqlDbType.Int;
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = 1;

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@ItemId1";
                parameter2.SqlDbType = SqlDbType.Int;
                parameter2.Direction = ParameterDirection.Input;
                parameter2.Value = 100;

                SqlParameter parameter3 = new SqlParameter();
                parameter3.ParameterName = "@AnswerText1";
                parameter3.SqlDbType = SqlDbType.NVarChar;
                parameter3.Direction = ParameterDirection.Input;
                parameter3.Value = answer1;

                SqlParameter parameter4 = new SqlParameter();
                parameter4.ParameterName = "@ItemId2";
                parameter4.SqlDbType = SqlDbType.Int;
                parameter4.Direction = ParameterDirection.Input;
                parameter4.Value = 101;

                SqlParameter parameter5 = new SqlParameter();
                parameter5.ParameterName = "@AnswerText2";
                parameter5.SqlDbType = SqlDbType.NVarChar;
                parameter5.Direction = ParameterDirection.Input;
                parameter5.Value = answer2;

                SqlParameter parameter6 = new SqlParameter();
                parameter6.ParameterName = "@ItemId3";
                parameter6.SqlDbType = SqlDbType.Int;
                parameter6.Direction = ParameterDirection.Input;
                parameter6.Value = 102;

                SqlParameter parameter7 = new SqlParameter();
                parameter7.ParameterName = "@AnswerText3";
                parameter7.SqlDbType = SqlDbType.NVarChar;
                parameter7.Direction = ParameterDirection.Input;
                parameter7.Value = answer3;

                cmd.Parameters.Add(parameter1);
                cmd.Parameters.Add(parameter2);
                cmd.Parameters.Add(parameter3);
                cmd.Parameters.Add(parameter4);
                cmd.Parameters.Add(parameter5);
                cmd.Parameters.Add(parameter6);
                cmd.Parameters.Add(parameter7);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                LabelQuestion1.Text = "Database Error";
            }
            Response.Redirect("/SurveyResponses.aspx");
        }

        private string getRadioValue(ControlCollection clts, string groupName)
        {
            var ret = "";
            foreach (Control ctl in clts)
            {
                if (ctl.Controls.Count != 0)
                {
                    ret = getRadioValue(ctl.Controls, groupName);
                }
                if (!string.IsNullOrEmpty(ret))
                {
                    return ret;
                }
                var rb = ctl as RadioButton;
                if (rb != null && rb.GroupName == groupName && rb.Checked)
                    return rb.Attributes["Value"];
            }
            return ret;
        }
    }
}