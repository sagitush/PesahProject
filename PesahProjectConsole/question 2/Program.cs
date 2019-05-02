using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace question_2
{
    class Program
    {
        static void Main(string[] args)
        {

             MainMenu();

        }

        public static void SupplierMenu(Supplier supplier)
        {
            Console.WriteLine("Choose from the foliowing:");

            Console.WriteLine("1.Add product to inventory");

            Console.WriteLine("2.View all products belong to you");

            int b = Convert.ToInt32(Console.ReadLine());

            switch (b)
            {
                case 1:

                    SupplierDAO.AddProduct(supplier.IdSupplier);

                    break;

                case 2:

                    SupplierDAO.SelectAllProductsS(supplier.IdSupplier);

                    break;

            }
        }
        public static void CustomerMenu(Customer customer)

            {

            Console.WriteLine("Choose from the foliowing:");

            Console.WriteLine("1.View all my shopping list");

            Console.WriteLine("2.View all products");

            Console.WriteLine("3.Order product");

            int b = Convert.ToInt32(Console.ReadLine());

            switch (b)
            {
                case 1:

                    CustomerDAO.SelectShoppinList(customer.IdCustomer);

                    break;

                case 2:

                    CustomerDAO.SelectAllProductsC();

                    break;

                case 3:

                    CustomerDAO.OrderProduct(customer.IdCustomer);

                    break;
            }
        }

        public static void MainMenu()
        {
          Console.WriteLine("Hello friend,");

          Console.WriteLine("Please Choose from the foliowing:");

          Console.WriteLine("1.Existing customer");

          Console.WriteLine("2.New client");

          Console.WriteLine("3.Existing supplier");

          Console.WriteLine("4.New supplier");

          int a = Convert.ToInt32(Console.ReadLine());

            switch (a)
            {
                case 1:

                    Customer c = CustomerDAO.FindCustomer();

                    if (c != null)
                    {
                        CustomerMenu(c);
                    }
                    break;
                case 2:

                    CustomerDAO.NewCustomer();

                    MainMenu();

                    break;
                case 3:

                    Supplier s= SupplierDAO.FindSupplier();

                    if(s!=null)
                    {
                        SupplierMenu(s);
                    }
                   
                    break;


                case 4:

                    SupplierDAO.NewSupplier();

                    MainMenu();

                    break;

            }

        }

     }
}

