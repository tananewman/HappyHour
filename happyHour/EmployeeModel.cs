using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAttendanceApp
{
    public class EmployeeModel
    {
        private int _drinksToday;

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime LastLogin { get; set; }

        public int DrinksToday
        {
            get => _drinksToday;
            set
            {
                _drinksToday = value;
                if (LastLogin != DateTime.Today)
                {
                    _drinksToday = 1;
                }
            }
        }
    }
}
