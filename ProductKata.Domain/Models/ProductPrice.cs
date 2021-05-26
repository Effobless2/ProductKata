using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductKata.Domain.Models
{
    public class ProductPrice
    {
        public ProductCatalog Product { get; set; }
        public Price Price { get; set; }
    }
}
