using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using Dapper;
using NUnit.Framework;

namespace Blog.Tests.Utilities
{
    public class ExcelDataReader
    {
        public static string TestDataFileConnection()
        {
            var path = Path.GetFullPath(Path.Combine(
                TestContext.CurrentContext.TestDirectory,
                ConfigurationManager.AppSettings["TestDataPath"]));
            return $"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = { path }; Extended Properties=Excel 12.0;";
        }

        public static T GetTestData<T>()
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                var sheetName = typeof(T).Name;
                var keyName = TestContext.CurrentContext.Test.Name;

                connection.Open();
                var query = $"SELECT * FROM [{sheetName}$] WHERE Key = '{keyName}'";

                return connection.Query<T>(query).Single();
            }
        }
    }
}
