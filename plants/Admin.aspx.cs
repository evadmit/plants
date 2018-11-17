using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Web.Configuration;
using System.Text;
using System.Data;
using MySql.Data.Common;
using MySql.Data.MySqlClient;

namespace plants
{
    public partial class Admin : System.Web.UI.Page
    {
        String MyConString = "SERVER=localhost;" +
       "DATABASE=plantcatalogue;" +
       "UID=root;" +
       "PASSWORD=evadmit;" +
       "SSLMODE=none;";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT id_admin, login, password" +
                        " FROM admins WHERE (login='"+ TextBoxLogin.Text.Trim()+ "') AND (password='"+
                        TextBoxPassword.Text.Trim()+"')" , conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                dr.Read();
                Session["id_admin"] = dr["id_admin"];
                Session["login"] = dr["login"].ToString();
                Session["password"] = dr["password"].ToString();
                Label3.Text = "Вы вошли в систему";
                
                if ((int)Session["id_admin"] > 0)
                {
                    Button1.Visible = false;
                    TextBoxLogin.Visible = false;
                    TextBoxPassword.Visible = false;
                    Label1.Visible = false;
                    Label2.Visible = false;
                    ButtonEdit.Visible = true;
                   ButtonOrder.Visible = true;
                    Button4.Visible = true;
                }
                dr.Close();
                conn.Close();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session["id_admin"] = 0;
            Button1.Visible = true;
            TextBoxLogin.Visible = true;
            TextBoxPassword.Visible = true;
            Label1.Visible = true;
            Label2.Visible = true;
            ButtonOrder.Visible = false;
            ButtonEdit.Visible = false;
            Button4.Visible = false;
            Label3.Text = "";

        }

        protected void ButtonOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("Orders.aspx");
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit.aspx");
        }
    }
}