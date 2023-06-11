using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ElektronskiRecnik
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(konekcija.conString))
            {
                try
                {
                    conn.Open();
                    string cmdInsert = "Insert into Prevod (Engleski,Srpski,Opis) VALUES (@Engleski,@Srpski,@Opis)";
                    using (SqlCommand cmd = new SqlCommand(cmdInsert, conn))
                    {
                        cmd.Parameters.AddWithValue("@Engleski", TextBox1.Text);
                        cmd.Parameters.AddWithValue("@Srpski", TextBox2.Text);
                        cmd.Parameters.AddWithValue("@Opis", TextBox3.Text);

                        int dodat = cmd.ExecuteNonQuery();
                        if (dodat == 1)
                        {
                            lblMessage.Text = "Uspesno dodato";
                        }
                    }
                }
                catch(System.Data.SqlClient.SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}