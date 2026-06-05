using System.Data;
using System.IO;

namespace greenPointofSales.Helpers
{
    public static class ExportHelper
    {
        public static void ExportDataTableToCSV(DataTable dt, string filePath)
        {
            using var sw = new StreamWriter(filePath);

            string[] headers = new string[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                headers[i] = dt.Columns[i].ColumnName;
            }
            sw.WriteLine(string.Join(",", headers));

            foreach (DataRow row in dt.Rows)
            {
                string[] cells = new string[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string val = row[i]?.ToString() ?? "";
                    val = val.Replace(",", ".");
                    cells[i] = $"\"{val}\"";
                }
                sw.WriteLine(string.Join(",", cells));
            }
        }
    }
}