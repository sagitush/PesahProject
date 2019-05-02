using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace question_2
{
    class Supplier
    {
        public Int32 IdSupplier { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }

        public override int GetHashCode()

        {

            return (int)IdSupplier;

        }



        public override string ToString()

        {

            return $"{IdSupplier} {User} {Password} {CompanyName}";

        }



        public override bool Equals(object obj)

        {

            if (obj == null)

                return false;



            Supplier other = obj as Supplier;

            if (other == null)

                return false;



            return this.IdSupplier == other.IdSupplier;

        }


    }
}
