using Microsoft.SqlServer.Server;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;

public partial class UserDefinedFunctions
{
    //XDocument doc = ConversorCsvXml.ConvertCsvToXML(csv, new[] { "," });

    [SqlFunction(DataAccess = DataAccessKind.None, FillRowMethodName = "FillRow ", IsDeterministic = true)]
        public static int uf_LoadDataFromCsvIntoTable(SqlString path, SqlString separator)
	    {
		    try
		    {
            StreamReader sr = new StreamReader(path.ToString());
            string[] headers = sr.ReadLine().Split(separator.ToString().ToCharArray());
            DataTable dt = new DataTable();
            int k = 0;
            string row = "";
            string headr = "Id, ";

            using (SqlConnection connection = new SqlConnection(@"Data Source=830G6\SQLEXPRESS;Initial Catalog=DbExercises;" + "Integrated Security=true;"))
            {
                string drop = "IF OBJECT_ID('[utils].[FromCsv]', 'U') IS NOT NULL DROP TABLE [utils].[FromCsv]; ";
                SqlCommand dropCommand = new SqlCommand(drop, connection);
                dropCommand.Connection.Open();
                dropCommand.ExecuteNonQuery();

                string create = "CREATE TABLE [utils].[FromCsv] (Id [int] NOT NULL)";
                SqlCommand createCommand = new SqlCommand(create, connection);
                createCommand.ExecuteNonQuery();
            }

            foreach (string header in headers)
            {
                dt.Columns.Add(header);
                headr = headr + header + ",";
                using (SqlConnection connection = new SqlConnection(@"Data Source=830G6\SQLEXPRESS;Initial Catalog=DbExercises;" + "Integrated Security=true;"))
                {
                    string alter = $"ALTER TABLE [utils].[FromCsv] ADD {header} varchar(max)";
                    SqlCommand alterCommand = new SqlCommand(alter, connection);
                    alterCommand.Connection.Open();
                    alterCommand.ExecuteNonQuery();
                }
			}
            while (!sr.EndOfStream)
            {
                k = +1;
                row = k + ",";

                string[] rows = sr.ReadLine().Split(separator.ToString().ToCharArray());
                DataRow dr = dt.Rows.Add();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                    row = row + "'" + rows[i] + "'" + ",";
                }
                using (SqlConnection connection = new SqlConnection(@"Data Source=830G6\SQLEXPRESS;Initial Catalog=DbExercises;" + "Integrated Security=true;"))
                {
                    string insert = $"Insert into [utils].[FromCsv] ({headr.Remove(headr.Length - 1)}) values ({row.Remove(row.Length - 1)})";
                    SqlCommand insertCommand = new SqlCommand(insert, connection);
                    insertCommand.Connection.Open();
                    insertCommand.ExecuteNonQuery();
                }
            }
            return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
}
