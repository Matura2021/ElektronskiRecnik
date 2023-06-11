using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace ElektronskiRecnik
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                TextBox2.Enabled = false;
                TextBox3.Enabled = true;
            }
            else if (DropDownList1.SelectedIndex == 1)
            {
                TextBox2.Enabled = true;
                TextBox3.Enabled = false;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                TextBox2.Enabled = false;
                TextBox3.Enabled = true;
                TextBox4.Enabled = false;
            }
            else if(DropDownList1.SelectedIndex == 1)
            {
                TextBox2.Enabled = true;
                TextBox3.Enabled = false;
                TextBox4.Enabled = false;
            }
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnPrevedi_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(konekcija.conString))
            {
                try
                {
                    conn.Open();
                    if(DropDownList1.SelectedIndex == 0)
                    {
                        string cmdSelect1 = "Select Engleski,Opis from Prevod where Srpski = @srpski";
                        using (SqlCommand cmd = new SqlCommand(cmdSelect1,conn))
                        {
                            cmd.Parameters.AddWithValue("@srpski", TextBox3.Text);
                            SqlDataReader reader = cmd.ExecuteReader();
                            reader.Read();
                            TextBox2.Text = reader["Engleski"].ToString();
                            TextBox4.Text = reader["Opis"].ToString();
                            reader.Close();
                        }
                    }
                    else if(DropDownList1.SelectedIndex == 1)
                    {
                        string cmdSelect1 = "Select Srpski,Opis from Prevod where Engleski = @engleski";
                        using (SqlCommand cmd = new SqlCommand(cmdSelect1, conn))
                        {
                            cmd.Parameters.AddWithValue("@engleski", TextBox2.Text);
                            SqlDataReader reader = cmd.ExecuteReader();
                            reader.Read();
                            TextBox3.Text = reader["Srpski"].ToString();
                            TextBox4.Text = reader["Opis"].ToString();
                            reader.Close();
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