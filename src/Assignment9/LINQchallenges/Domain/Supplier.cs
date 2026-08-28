using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQchallenges.Domain
{
    internal class Supplier
    {
        public int SupplierId { get; set; }

        public string SupplierName { get; set; }

        public int ProductId { get; set; }

        public override string ToString()
        {
            return $"{this.SupplierId}, {this.SupplierName}, {this.ProductId}";
        }
    }
}
