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
    public partial class _Default : Page
    {   String MyConString = "SERVER=localhost;" +
        "DATABASE=plantcatalogue;" +
        "UID=root;" +
        "PASSWORD=evadmit;" +
        "SSLMODE=none;";
        protected void Page_Load(object sender, EventArgs e)
        {
            Populateddl1();
            Populateddl2();
            Populateddl3();
            Populateddl4();
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
        public void PopulateGridview()
        {
            string newcommand = "SELECT        plant.plant_name, planttype.type_name, country.country_name, ground.ground_type, watering.watering_type, plant.watering_fk, plant.planttype_fk, plant.ground_fk, plant.country_fk "+
                         "FROM country INNER JOIN "+
                         "plant ON country.id_country = plant.country_fk INNER JOIN "+
                         "ground ON plant.ground_fk = ground.id_ground INNER JOIN "+
                         "planttype ON plant.planttype_fk = planttype.id_type INNER JOIN "+
                         "watering ON plant.watering_fk = watering.id_watering "+
                         "WHERE (plant.ground_fk= " + DropDownList1.SelectedValue +")AND " +
                         " (plant.country_fk= " + DropDownList2.SelectedValue + ")AND " +
                         " (plant.planttype_fk= " + DropDownList3.SelectedValue + ")AND " +
                         " (plant.watering_fk= " + DropDownList4.SelectedValue +")";
            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand(newcommand, conn);
            conn.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);
            GridView.DataSource = dataTable;
            GridView.DataBind();
           

            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            PopulateGridview();
          
        }
    }
}