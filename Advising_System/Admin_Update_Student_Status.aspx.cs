﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class Admin_Update_Student_Status : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Session["LoggedIn"]))
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }

        protected void backHomeFn(object sender, EventArgs e)
        {
            Response.Redirect("AdminHomePage.aspx");
        }

        protected void updateStudentStatus(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    int id = Convert.ToInt32(studentUpdated.Text);

                    SqlCommand courseDeleteproc = new SqlCommand("Procedure_AdminUpdateStudentStatus", conn);
                    courseDeleteproc.CommandType = System.Data.CommandType.StoredProcedure;
                    courseDeleteproc.Parameters.Add(new SqlParameter("@student_id", id));

                    courseDeleteproc.ExecuteNonQuery();

                    Response.Write("Updated Financial Status of Student With ID: " + id);

                    conn.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }
}