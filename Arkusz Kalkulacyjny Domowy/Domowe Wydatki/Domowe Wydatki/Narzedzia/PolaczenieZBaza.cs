using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domowe_Wydatki
{
    public class PolaczenieZBaza
    {
        public List<List<string>> PobierzDane (string polecenieSQL)
        {
            string connetionString = @"Data Source=PKIZA\SQLEXPRESS01; Initial catalog=Arkusz_Wydatki; Integrated security=SSPI;";
            SqlConnection connection = new SqlConnection(connetionString);

            SqlCommand command;

            SqlDataReader dataReader;

            List<List<string>> wynik = new List<List<string>>();
            try
            {
                connection.Open(); // otwieramy połączenie z bazą danych
                command = new SqlCommand(polecenieSQL, connection);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())// czytaj jeden wiersz (pierwszy) rezultatu
                {
                    List<string> wiersz = new List<string>();
                    wynik.Add(wiersz);
                    for (int i = 0; i < dataReader.FieldCount; i++)
                        wiersz.Add(dataReader.GetValue(i).ToString());
                }

                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error like: " + ex);
            }

            return wynik;
        }
    }
}
