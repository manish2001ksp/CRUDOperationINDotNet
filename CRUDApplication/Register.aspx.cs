using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDApplication
{
    public partial class Register : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCountries();
                LoadData();
            }

        }

        private void LoadData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                DataSet dsEmployee = new DataSet();
                SqlCommand objSqlCommand = new SqlCommand("Select * from RegistrationPage", con);
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSqlCommand);
                try
                {
                    objSqlDataAdapter.Fill(dsEmployee);
                    //dsEmployee.Tables[0].TableName = "Employees";
                    GridView1.DataSource = dsEmployee;
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void LoadCountries()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                DataSet dsEmployee = new DataSet();
                SqlCommand objSqlCommand = new SqlCommand("Select * from Country", con);
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSqlCommand);
                try
                {
                    objSqlDataAdapter.Fill(dsEmployee);
                    //dsEmployee.Tables[0].TableName = "Employees";
                    drpCountry.DataSource = dsEmployee;
                    drpCountry.DataBind();
                }
                catch (Exception ex)
                {
                   
                }
            }
        }

        protected void drpCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dropDownList = (DropDownList)sender;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                DataSet dsEmployee = new DataSet();
                SqlCommand objSqlCommand = new SqlCommand("Select * from State where CountryID=" + dropDownList.SelectedValue + "", con);
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSqlCommand);
                try
                {
                    objSqlDataAdapter.Fill(dsEmployee);
                    //dsEmployee.Tables[0].TableName = "Employees";
                    drpCountry.DataSource = dsEmployee;
                    drpCountry.DataBind();
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void drpState_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dropDownList = (DropDownList)sender;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                DataSet dsEmployee = new DataSet();
                SqlCommand objSqlCommand = new SqlCommand("Select * from City where StateID=" + dropDownList.SelectedValue + "", con);
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSqlCommand);
                try
                {
                    objSqlDataAdapter.Fill(dsEmployee);
                    //dsEmployee.Tables[0].TableName = "Employees";
                    drpCountry.DataSource = dsEmployee;
                    drpCountry.DataBind();
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}