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
    public partial class Contact : Page
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
            PopulateGridview();
        }
        public void PopulateGridview()
        {
            string newcommand = "SELECT        plant.plant_name, planttype.type_name, country.country_name, ground.ground_type, watering.watering_type, plant.watering_fk, plant.planttype_fk, plant.ground_fk, plant.country_fk " +
                        "FROM country INNER JOIN " +
                        "plant ON country.id_country = plant.country_fk INNER JOIN " +
                        "ground ON plant.ground_fk = ground.id_ground INNER JOIN " +
                        "planttype ON plant.planttype_fk = planttype.id_type INNER JOIN " +
                        "watering ON plant.watering_fk = watering.id_watering " +
                        "WHERE ("+DropDownList1.SelectedValue +"LIKE '%"+ TextBox1.Text + "%')";


            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand(newcommand, conn);
            conn.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);
            GridView.DataSource = dataTable;
            GridView.DataBind();

        }
    }
}