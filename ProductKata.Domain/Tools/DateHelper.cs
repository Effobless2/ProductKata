using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductKata.Domain.Tools
{
    public class DateHelper
    {
        public DateTime Now { get; set; } = DateTime.UtcNow;

        public bool AfterSixMonths(DateTime d1)
        {
            return (Now - d1).TotalDays / (365.25 / 12) < 6;
        }

        public bool AfterOneYear(DateTime d1)
        {
            return (Now - d1).TotalDays / (365.25) < 1;
        }
    }
}
