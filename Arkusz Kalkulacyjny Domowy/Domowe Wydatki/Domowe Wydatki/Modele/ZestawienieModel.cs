using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domowe_Wydatki.Modele
{
    public class ZestawienieModel
    {
        public void Wstaw(DateTime data, int idAutora, int idKategorii, int idPodkategorii, string  kwota)
        {
            string connetionString = @"Data Source=PKIZA\SQLEXPRESS01; Initial catalog=Arkusz_Wydatki; Integrated security=SSPI;";
            SqlConnection connection = new SqlConnection(connetionString);
            SqlCommand command;
            string query = string.Format(@"Insert into Zestawienie(Data, IdAutora,IdKategorii,IdPodkategorii,Kwota) values ('{0}',{1},{2},{3},'{4}')", data.ToShortDateString(), idAutora, idKategorii, idPodkategorii, kwota);
            connection.Open(); 
            command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
        }
    }
}
