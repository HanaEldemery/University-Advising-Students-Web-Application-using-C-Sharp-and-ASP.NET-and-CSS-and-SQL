﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class Admin_View_Student_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Session["LoggedIn"]))
            {
                Response.Redirect("AdminLogin.aspx");
            }

            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM view_Students", connection);

                    connection.Open();

                    viewStudents.DataSource = command.ExecuteReader();
                    viewStudents.DataBind();
                }
            }
        }
        protected void backHomeFn(object sender, EventArgs e)
        {
            Response.Redirect("AdminHomePage.aspx");
        }
    }
}