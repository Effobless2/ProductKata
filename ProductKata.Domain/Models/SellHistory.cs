using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductKata.Domain.Models
{
    public class SellHistory
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
    }
}
