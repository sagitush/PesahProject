using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace question_2
{
    class Customer
    {
        public Int32 IdCustomer { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CreditNumber { get; set; }

        public override int GetHashCode()

        {

            return (int)IdCustomer;

        }



        public override string ToString()

        {

            return $"{IdCustomer} {User} {Password} {FirstName} {LastName} {CreditNumber} ";

        }



        public override bool Equals(object obj)

        {

            if (obj == null)

                return false;



            Customer other = obj as Customer;

            if (other == null)

                return false;



            return this.IdCustomer == other.IdCustomer;

        }



    }
}

