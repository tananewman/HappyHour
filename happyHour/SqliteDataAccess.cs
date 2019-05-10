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

        public static EmployeeModel GetEmployeeByBadgeNumber(string badgeNumber)
        {
            using (IDbConnection connect = new SQLiteConnection(LoadConnectionString()))
            {
                var badgeNumberInt = int.Parse(badgeNumber);
                var existingEmployee = connect.Query<EmployeeModel>($"SELECT * FROM Employee WHERE EmployeeID = {badgeNumberInt}", new DynamicParameters());
                return existingEmployee.FirstOrDefault();
            }
        }

        public static void SaveEmployee(EmployeeModel employee)
        {
            using (IDbConnection connect = new SQLiteConnection(LoadConnectionString()))
            {
                var existingEmployee = connect.Query<EmployeeModel>($"SELECT * FROM Employee WHERE EmployeeID = {employee.EmployeeId}", new DynamicParameters());
                var employeeModels = existingEmployee.ToList();
                if (employeeModels.Count > 0)
                {
                    connect.Execute($"UPDATE Employee SET DrinksToday = @DrinksToday WHERE EmployeeId = @EmployeeID", employee);
                }
                else
                {
                    connect.Execute("INSERT into Employee (EmployeeID, EmployeeName, LastLogin, DrinksToday) values (@EmployeeID, @EmployeeName, @LastLogin, @DrinksToday)", employee);
                }
            }
        }

        private static string LoadConnectionString(string id ="HappyHourDb")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
