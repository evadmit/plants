using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;

namespace plants
{
    public partial class Edit : System.Web.UI.Page
    {
        String MyConString = "SERVER=localhost;" +
        "DATABASE=plantcatalogue;" +
        "UID=root;" +
        "PASSWORD=evadmit;" +
        "SSLMODE=none;";
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGridview();
            Populateddl1();
            Populateddl2();
            Populateddl3();
            Populateddl4();
        }
        public void PopulateGridview()
        {

            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT plant.id_plant, plant.plant_quantity, plant.plant_price, plant.plant_name, ground.ground_type, country.country_name, planttype.type_name, watering.watering_type" +
                        " FROM plant INNER JOIN" +
                     " ground ON plant.ground_fk = ground.id_ground INNER JOIN" +
                     " country ON plant.country_fk = country.id_country INNER JOIN" +
                     " planttype ON plant.planttype_fk = planttype.id_type INNER JOIN" +
                     " watering ON plant.watering_fk = watering.id_watering ORDER BY id_plant ASC", conn);
            conn.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);
            GridView.DataSource = dataTable;
            GridView.DataBind();

        }
        protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }
        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                MySqlConnection sqlCon2 = new MySqlConnection(MyConString);
                sqlCon2.Open();
                string query = "DELETE FROM  plant WHERE id_plant=?id_plant";
                MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon2);
                sqlCmd.Parameters.AddWithValue("?id_plant", Convert.ToInt32(GridView.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
                PopulateGridview();
                lblsuccess.Text = "удалено";

            }
            catch (Exception ex) { lblsuccess.Text = ex.Message; }
        }

        protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            try
            {
                MySqlConnection sqlCon2 = new MySqlConnection(MyConString);
                sqlCon2.Open();
                string query = "UPDATE  plant SET plant_name=?plant_name  WHERE  id_plant=?id_plant";
                MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon2);
                sqlCmd.Prepare();
                sqlCmd.Parameters.AddWithValue("?plant_name", Convert.ToString((GridView.Rows[e.RowIndex].FindControl("txtPlant") as TextBox).Text.Trim()));
                sqlCmd.Parameters.AddWithValue("?id_plant", Convert.ToInt32(GridView.DataKeys[e.RowIndex].Value.ToString()));

                sqlCmd.ExecuteNonQuery();
                GridView.EditIndex = -1;
                PopulateGridview();
                lblsuccess.Text = "обновлено";
            }

            catch (Exception ex)
            {
                lblerror.Text = "что-то пошло не так" + ex.Message;
            }

        }

        protected void GridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView.EditIndex = -1;
            PopulateGridview();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            try { 
            MySqlConnection cn = new MySqlConnection(MyConString);
            cn.Open();
            string addquery = "INSERT INTO plant " +
            "(plant_name, plant_quantity, plant_price, watering_fk, planttype_fk, ground_fk, country_fk) " +
            "VALUES('" + TextBox1.Text.Trim() +"', "+Convert.ToInt16(TextBox3.Text.Trim()) +", "+ Convert.ToInt16( TextBox2.Text.Trim())+", "+DropDownList4.SelectedValue +", "+ DropDownList3.SelectedValue +", "+ DropDownList1.SelectedValue +", "+ DropDownList2.SelectedValue +")";
            MySqlCommand cmd = new MySqlCommand(addquery, cn);
                cmd.ExecuteNonQuery();
                TextBox1.Text.Trim();
                TextBox2.Text.Trim();
                TextBox3.Text.Trim();
                PopulateGridview();
                lblsuccess.Text = "добавлено";
                
            }
            catch(Exception ex)
            {
                lblerror.Text = ex.Message;
            }
        }
        public void Populateddl1()
        {
            MySqlConnection cn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT id_ground, ground_type FROM ground", cn);
            cn.Open();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "ground_type";
            DropDownList1.DataValueField = "id_ground";
            DropDownList1.DataBind();

            cn.Close();
        }
        public void Populateddl2()
        {
            MySqlConnection cn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT id_country, country_name FROM country", cn);
            cn.Open();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataTextField = "country_name";
            DropDownList2.DataValueField = "id_country";
            DropDownList2.DataBind();
            cn.Close();
        }
        public void Populateddl3()
        {
            MySqlConnection cn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT id_type, type_name FROM planttype", cn);
            cn.Open();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            DropDownList3.DataSource = dt;
            DropDownList3.DataTextField = "type_name";
            DropDownList3.DataValueField = "id_type";
            DropDownList3.DataBind();
            cn.Close();
        }
        public void Populateddl4()
        {
            MySqlConnection cn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT id_watering, watering_type FROM watering", cn);
            cn.Open();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            DropDownList4.DataSource = dt;
            DropDownList4.DataTextField = "watering_type";
            DropDownList4.DataValueField = "id_watering";
            DropDownList4.DataBind();
            cn.Close();
        }
    }
}