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
				ClassFile = Directory.GetParent(workingDirectory).Parent.Parent.FullName + "\\" + "Transakcje" + ".cs";
				System.IO.File.WriteAllText(ClassFile, NewClass);
			}
			// Get a path to the file(s) to compile.
			FileInfo sourceFile = new FileInfo(ClassFile);

			// Prepary a file path for the compiled library.
			string outputName = string.Format(@"{0}\{1}.dll",
				Environment.CurrentDirectory,
				Path.GetFileNameWithoutExtension(sourceFile.Name));

			// Compile the code as a dynamic-link library.
			bool success = Compile(sourceFile, new CompilerParameters()
			{
				GenerateExecutable = false, // compile as library (dll)
				OutputAssembly = outputName,
				GenerateInMemory = false, // as a physical file
			});

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();

		}

		private static bool Compile(FileInfo sourceFile, CompilerParameters options)
		{
			CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

			CompilerResults results = provider.CompileAssemblyFromFile(options, sourceFile.FullName);

			if (results.Errors.Count > 0)
			{
				Console.WriteLine("Errors building {0} into {1}", sourceFile.Name, results.PathToAssembly);
				foreach (CompilerError error in results.Errors)
				{
					Console.WriteLine("  {0}", error.ToString());
					Console.WriteLine();
				}
				return false;
			}
			else
			{
				Console.WriteLine("Source {0} built into {1} successfully.", sourceFile.Name, results.PathToAssembly);
				return true;
			}
		}
	}
}
