using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace question_2
{
    class Product
    {
        public Int32 IdProduct { get; set; }
        public string ProductName { get; set; }
        public int SupplierNumber { get; set; }
        public int Price {get; set; }
        public int Quantity { get; set; }

        public override int GetHashCode()

        {

            return (int)IdProduct;

        }



        public override string ToString()

        {

            return $"{IdProduct} {ProductName} {SupplierNumber} {Price} {Quantity} ";

        }



        public override bool Equals(object obj)

        {

            if (obj == null)

                return false;



            Product other = obj as Product;

            if (other == null)

                return false;



            return this.IdProduct == other.IdProduct;

        }


    }
}
