using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// import all sql librabries
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
//------------------------------


namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["My_Database_String_in_AppConfig_file"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //only when page o-eneing 1st time
            {
                GridView();
            }
            if (IsPostBack) // after upload is clicked
            {
                GridView();
            }
           
        }

        void GridView() // put gridview in web page and put id as GridView1
        {
            SqlConnection con = new SqlConnection(cs);
            string querry = "select * from img";

            SqlDataAdapter sda = new SqlDataAdapter(querry, con);

            DataTable data = new DataTable();

            sda.Fill(data);

            GridView1.DataSource = data;
            GridView1.DataBind();


        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);

            string path = Server.MapPath("images/"); //stores  images inside images folder

            if ( FileUpload1.HasFile )
            {
                string fileName = Path.GetFileName( FileUpload1.FileName ); //gets path of the stored image

                string extension = Path.GetExtension( fileName );

                HttpPostedFile postedFile = FileUpload1.PostedFile; // stores file controls

                int length = postedFile.ContentLength; //gets size of images in bytes


                if(extension.ToLower() == ".jfif" || extension.ToLower() == " .jpg " || extension.ToLower() == ".png" || extension.ToLower() == ".jpeg")
                {

                    if (length <= 1000000000)
                    {
                        FileUpload1.SaveAs(path + fileName);

                        string name = "images/" + fileName;

                        //store in database
                        string query = "insert into img values(@path) ";
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@path", name);

                        con.Open();

                        int a = cmd.ExecuteNonQuery();

                        if (a > 0)
                        {
                            Label1.Text = "image uploaded sucessfully";
                            Label1.ForeColor = System.Drawing.Color.Green;
                            Label1.Visible = true;
                            GridView();
                        }
                        else
                        {
                            Label1.Text = "image not uploaded";
                            Label1.ForeColor = System.Drawing.Color.Red;
                            Label1.Visible = true;
                        }

                        con.Close();

                    }
                    else
                    {
                        Label1.Text = "image size too big";
                        Label1.ForeColor = System.Drawing.Color.Red;
                        Label1.Visible = true;
                    }


                }
                else
                {
                    Label1.Text = "image format not supported";
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Visible = true;
                }


            }
            else
            {
                Label1.Text = "select image";
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Visible = true;
            }

        }
    }
}