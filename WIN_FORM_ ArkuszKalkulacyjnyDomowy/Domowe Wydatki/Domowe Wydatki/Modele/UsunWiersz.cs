using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domowe_Wydatki.Modele
{
    class UsunWiersz
    {
        public void Usun(string data,  string kwota)
        {
            string connetionString = @"Data Source=PKIZA\SQLEXPRESS01; Initial catalog=Arkusz_Wydatki; Integrated security=SSPI;";
            SqlConnection connection = new SqlConnection(connetionString);
            SqlCommand command;
            string query = string.Format(@"	Delete from Zestawienie where [Data] = '{0}' 							
								and Kwota = '{1}'", data, kwota.Replace(",","."));
            connection.Open();
            command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
        }
    }
}
