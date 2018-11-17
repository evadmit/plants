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
    public partial class About : Page
    {
        String MyConString = "SERVER=localhost;" +
        "DATABASE=plantcatalogue;" +
        "UID=root;" +
        "PASSWORD=evadmit;" +
        "SSLMODE=none;";
        
        List<string> order = new List<string>();

        int Quantity=3;


        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGridview();
            if (DropDownList1.HasAttributes)
            {

            }
            else
            {
                Populateddl1();
                Populateddl2();
                Populateddl3();
                Populateddl4();
            }


        }



        protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        public void PopulateGridview()
        {

            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT plant.id_plant, plant.plant_quantity, plant.plant_price, plant.plant_name, ground.ground_type, country.country_name, planttype.type_name, watering.watering_type" +
                        " FROM plant INNER JOIN" +
                     " ground ON plant.ground_fk = ground.id_ground INNER JOIN" +
                     " country ON plant.country_fk = country.id_country INNER JOIN" +
                     " planttype ON plant.planttype_fk = planttype.id_type INNER JOIN" +
                     " watering ON plant.watering_fk = watering.id_watering ORDER BY plant.id_plant ASC", conn);
            conn.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);
            GridView.DataSource = dataTable;
            GridView.DataBind();

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

        protected void Button2_Click(object sender, EventArgs e)
        {
            UpdateGridView();
        }
        public void UpdateGridView()
        {

            string newcommand = "SELECT plant.id_plant, plant.plant_quantity, plant.plant_price, plant.plant_name, ground.ground_type, country.country_name, planttype.type_name, watering.watering_type " +
                         "FROM country INNER JOIN " +
                         "plant ON country.id_country = plant.country_fk INNER JOIN " +
                         "ground ON plant.ground_fk = ground.id_ground INNER JOIN " +
                         "planttype ON plant.planttype_fk = planttype.id_type INNER JOIN " +
                         "watering ON plant.watering_fk = watering.id_watering " +
                         "WHERE (plant.ground_fk= " + DropDownList1.SelectedValue + ")AND " +
                         " (plant.country_fk= " + DropDownList2.SelectedValue + ")AND " +
                         " (plant.planttype_fk= " + DropDownList3.SelectedValue + ")AND " +
                         " (plant.watering_fk= " + DropDownList4.SelectedValue + ") "+
                         "ORDER BY plant.id_plant ASC";
            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand(newcommand, conn);
            conn.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);
            GridView.DataSource = dataTable;
            GridView.DataBind();
            
        }

        protected void ButtonBuy_Click(object sender, EventArgs e)
        {    int k = GridView.SelectedIndex;
             order.Add(Convert.ToString(GridView.DataKeys[k].Value) + "," + 1);
             if (order.Count>0)
            {
                ButtonBuy.Visible = false;
                Label1.Visible = true;
                Label2.Visible = true;
                Label3.Visible = true;
                Label4.Visible = true;
                Label5.Visible = true;
                TextBoxName.Visible = true;
                TextBoxSname.Visible = true;
                TextBoxPhone.Visible = true;
                DropDownListCity.Visible = true;
                TextBoxComment.Visible = true;
                ButtonOk.Visible = true;

            }
            else
            {
                lblerror.Text = "выберете товар";
            }
         
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = order.Count;
            int k = GridView.SelectedIndex;
            TextBox TextBoxQuantity =(TextBox) GridView.Rows[k].FindControl("TextBoxQuantity");
            Quantity = Convert.ToInt16( TextBoxQuantity.Text);
            order.Add(Convert.ToString(GridView.DataKeys[k].Value) + "," + 1);
            Label6.Text = Convert.ToString(Quantity);
       
            for (int y = 0; y < order.Count; y++)
            {
                lblerror.Text += (order[y] + " ");
            }
            lblsuccess.Text = "выбрано: " + k  +" id: "+ GridView.DataKeys[k].Value+" записей в листе: "+ order.Count.ToString()+" в массиве: "+ order[0];


        }
             
        protected void ButtonOk_Click(object sender, EventArgs e)
        {
            int lastorder;
            MySqlConnection sqlCon1 = new MySqlConnection(MyConString);
            sqlCon1.Open();
            string query = "INSERT INTO `order` "+
                         "(client_name, client_surname, client_phone, client_city, client_notes) "+
                         "VALUES('"+ TextBoxName.Text +"','"+TextBoxSname.Text +"','"+ TextBoxPhone.Text +"','"+ DropDownListCity.SelectedValue+"','"+TextBoxComment.Text +"')";
            MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon1);
            sqlCmd.ExecuteNonQuery();
            sqlCon1.Close();

            MySqlConnection sqlCon2 = new MySqlConnection(MyConString);
            sqlCon2.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT MAX(id_order) FROM `order`", sqlCon2);
            lastorder= Convert.ToInt16(cmd.ExecuteScalar());
            sqlCon2.Close();

            int k = GridView.SelectedIndex;
            try { 
            MySqlConnection sqlCon3 = new MySqlConnection(MyConString);
            sqlCon3.Open();
           string query3 = "INSERT INTO `order_details` " +
                      "(plant_id_fk, order_id_fk, quantity, amount) " +
                  "VALUES('" +Convert.ToInt16( GridView.DataKeys[k].Value) + "','" +lastorder + "',1,1)";
            MySqlCommand sqlCmd3 = new MySqlCommand(query3, sqlCon3);
            sqlCmd3.ExecuteNonQuery();
            sqlCon3.Close();
            lblsuccess.Text = "заказ сформирован";}
            catch(Exception ex)
            {
                lblerror.Text = ex.Message;
            }
        }

        protected void TextBoxQuantity_TextChanged(object sender, EventArgs e)
        {
                
        }
    }

        }

            

    
    