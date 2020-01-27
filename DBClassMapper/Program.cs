using Microsoft.Build.Evaluation;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClassMapper
{
	class Program
	{
		static void Main(string[] args)
		{
			string ClassFile = "";
			using (SqlConnection sqlConnection = new SqlConnection(DBConnection.Cnn("localDB")))
			{
				DataTable dt = new DataTable();
				sqlConnection.Open();
				SqlCommand cmd = new SqlCommand("dbo.CreateClassModel", sqlConnection);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@TableName", "Transakcje"));
				cmd.Parameters.Add(new SqlParameter("@TableSchema", "dbo"));
				cmd.Parameters.Add("@result", SqlDbType.VarChar, 8000).Direction = ParameterDirection.Output;
				cmd.ExecuteNonQuery();
				var result = cmd.Parameters["@result"].Value;
				string NewClass = result.ToString();
				string workingDirectory = Environment.CurrentDirectory;
				ClassFile = Directory.GetParent(workingDirectory).Parent.FullName + "\\" + "Transakcje" + ".cs";
				System.IO.File.WriteAllText(ClassFile, NewClass);
			}
			var collection = new ProjectCollection();

			var project = collection.LoadProject(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\" + "DBClassMapper.csproj");
				project.AddItem("Class", ClassFile);
				project.Save();

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
			Transakcje das = new Transakcje();

		}

	}
}
