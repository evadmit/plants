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
    public partial class Orders : System.Web.UI.Page
    {
        String MyConString = "SERVER=localhost;" +
        "DATABASE=plantcatalogue;" +
        "UID=root;" +
        "PASSWORD=evadmit;" +
        "SSLMODE=none;";


        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGridview();

        }
        public void PopulateGridview()
        {

            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT `order`.id_order, `order`.client_name, `order`.client_surname, `order`.client_phone, `order`.client_city, `order`.client_notes, plant.plant_name "+
            "FROM            `order` INNER JOIN"+
                         " order_details ON `order`.id_order = order_details.order_id_fk INNER JOIN "+
                         "plant ON order_details.plant_id_fk = plant.id_plant", conn);
            conn.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);
            GridView.DataSource = dataTable;
            GridView.DataBind();

        }

        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(MyConString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `order` WHERE(`order`.id_order = "+GridView.DataKeys[e.RowIndex].Value.ToString() + " )", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MySqlConnection conn2 = new MySqlConnection(MyConString);
            conn2.Open();
            MySqlCommand cmd2 = new MySqlCommand("DELETE FROM `order_details` WHERE(order_details.order_id_fk= " + GridView.DataKeys[e.RowIndex].Value.ToString() + " )", conn2);
            cmd2.ExecuteNonQuery();
            conn2.Close();


        }
    }
}