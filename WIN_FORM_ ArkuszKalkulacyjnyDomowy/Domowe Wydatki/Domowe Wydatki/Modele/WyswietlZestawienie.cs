using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domowe_Wydatki;

namespace Domowe_Wydatki.Modele
{
    public class WyswietlZestawienie : Form1
    {
        public BindingSource Wyswietl()
        {
            string connetionString = @"Data Source=PKIZA\SQLEXPRESS01; Initial catalog=Arkusz_Wydatki; Integrated security=SSPI;";
            SqlConnection connection = new SqlConnection(connetionString);
            SqlCommand command;
            string query = @"Select 
                                z.Data, a.Imie, k.Kategoria, p.Podkategoria, z.Kwota
                                from Zestawienie as z 
                                inner join Autorzy as a on a.ID = z.IdAutora 
                                inner join Kategorie as k on k.ID = z.IdKategorii 
                                inner join Podkategorie as p on p.ID = z.IdPodkategorii
                                order by z.ID desc";
            BindingSource bSource= new BindingSource(); ;
            try
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = command;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                bSource.DataSource = dbdataset;
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error with displaying data " +ex);
            }
            return bSource;

        }
    }
}
