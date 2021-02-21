using Microsoft.SqlServer.Server;
using System;
using System.Data.SqlTypes;
using System.IO;
using System.Xml.Linq;

public partial class UserDefinedFunctions
{
    //XDocument doc = ConversorCsvXml.ConvertCsvToXML(csv, new[] { "," });

    [SqlFunction(DataAccess = DataAccessKind.None, FillRowMethodName = "FillRow ", IsDeterministic = true)]
        public static SqlString uf_LoadDataFromCsvIntoXml(SqlString path, SqlString separator)
	    {
             string csvString = File.ReadAllText((string)path);
             var sep = new[] { "\r\n" };
             string[] rows = csvString.Split(sep, StringSplitOptions.RemoveEmptyEntries);
             var xsurvey = new XDocument(
                 new XDeclaration("1.0", "UTF-8", "yes"));
             var xroot = new XElement("root");
             for (int i = 0; i < rows.Length; i++)
             {
                 if (i > 0)
                 {
                     xroot.Add(rowCreator(rows[i], rows[0],new[]{(string)separator}));
                 }
             }
             xsurvey.Add(xroot);
             return (SqlString) xsurvey.ToString();
        }
        private static XElement rowCreator(string row,
                       string firstRow, string[] separatorField)
        {
            string[] temp = row.Split(separatorField, StringSplitOptions.None);
            string[] names = firstRow.Split(separatorField, StringSplitOptions.None);
            var xrow = new XElement("row");
            for (int i = 0; i < temp.Length; i++)
            {
                var xvar = new XElement("var",
                                        new XAttribute("name", names[i]),
                                        new XAttribute("value", temp[i]));
                xrow.Add(xvar);
            }
            return xrow;
        }
}
