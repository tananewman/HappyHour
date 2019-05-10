using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace EventAttendanceApp
{
    public class SqliteDataAccess
    {
        public static List<EmployeeModel> LoadEmployees()
        {
            using (IDbConnection connect = new SQLiteConnection(LoadConnectionString()))
            {
                var output = connect.Query<EmployeeModel>("SELECT * FROM Employee", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveEmployee(EmployeeModel employee)
        {
            using (IDbConnection connect = new SQLiteConnection(LoadConnectionString()))
            {
                connect.Execute("INSERT into Employee (EmployeeID, EmployeeName, LastLogin, DrinksToday) values (@EmployeeID, @EmployeeName, @LastLogin, @DrinksToday)", employee);
                //connect.Execute("INSERT into Employee (EmployeeID) values (@EmployeeID)", employee);
                //connect.Execute("INSERT into Employee (EmployeeName) values (@EmployeeName)", employee);
                //connect.Execute("INSERT into Employee (LastLogin) values (@LastLogin)", employee);
                //connect.Execute("INSERT into Employee (DrinksToday) values (@DrinksToday)", employee);
            }
        }

        private static string LoadConnectionString(string id ="HappyHourDb")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
