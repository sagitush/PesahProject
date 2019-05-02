using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace question_2
{
    class Order
    {

        public Int64 IdOrder { get; set; }
        public int CustomerNumber { get; set; }
        public int ProductNumber { get; set; }
        public int Qty { get; set; }
        public int TotalPrice { get; set; }

        public override int GetHashCode()

        {

            return (int)IdOrder;

        }



        public override string ToString()

        {

            return $"{IdOrder} {CustomerNumber} {ProductNumber} {Qty} {TotalPrice} ";

        }



        public override bool Equals(object obj)

        {

            if (obj == null)

                return false;



            Order other = obj as Order;

            if (other == null)

                return false;



            return this.IdOrder == other.IdOrder;

        }

    }
}
