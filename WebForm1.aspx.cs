using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // string connection_string = "server=.;database=MYDATABASE;integrated security=SSPI";
            string connection_string=ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            #region SQL command class
            
            using (SqlConnection connection = new SqlConnection(connection_string))
            { 


                SqlCommand command2 = new SqlCommand("SELECT COUNT(NAME) FROM EMPLOYEE", connection);
                connection.Open();
                int TOTAL_ROWS=(int)command2.ExecuteScalar();
                Response.Write("Total Rows=" + TOTAL_ROWS.ToString());


            }

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command3 = new SqlCommand("INSERT INTO EMPLOYEE VALUES(null,'ANISH','JAIPUR','MALE',123456789,'NOT ALLOWED')",connection);
                connection.Open();
                int TOTAL_ROWS_AFFACTED=command3.ExecuteNonQuery();
                Response.Write("\nTotal Rows Affacted=" + TOTAL_ROWS_AFFACTED);
            }

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command4 = new SqlCommand("UPDATE EMPLOYEE SET ID=4 WHERE NAME='ANISH'",connection);
                connection.Open();
                command4.ExecuteNonQuery();
                Response.Write("\nUpdated");
            }

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command5 = new SqlCommand("DELETE EMPLOYEE WHERE NAME='ANISH'", connection);
                connection.Open();
                command5.ExecuteNonQuery();
                Response.Write("\nDeleted");
            }

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                SqlCommand command = new SqlCommand("SELECT *FROM Employee", connection);
                connection.Open();
                //SqlDataReader reader = command.ExecuteReader();
                //GridView1.DataSource = reader;
                GridView1.DataSource = command.ExecuteReader();
                GridView1.DataBind();
            }
            
            #endregion




        }

           




    }

}