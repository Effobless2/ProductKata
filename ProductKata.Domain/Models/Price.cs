using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductKata.Domain.Models
{
    public class Price
    {
        public int ProductId { get; set; }
        public DateTime UpdateDate { get; set; }
        public double CurrentPrice { get; set; }
    }
}
