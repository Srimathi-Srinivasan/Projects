using System;

namespace librarymanagementsystem
{
    internal class program
    {
        public static void Main()
        {
            
            //books details
            int books_count;
            Console.WriteLine("Enter books count: ");
            books_count = Convert.ToInt32(Console.ReadLine());
            books[] b = new books[books_count];

            for(int i=0;i<books_count; i++)
            {
                b[i] = new books();
            }

            for(int i=0;i<books_count;i++)
            {
                b[i].getdata();
            }

            for(int i=0;i<books_count;i++)
            {
                b[i].displayData();
            }


             //authors details
            int authors_count;
            Console.WriteLine("Enter authors count: ");
            authors_count = Convert.ToInt32(Console.ReadLine());
            authors[] a = new authors[authors_count];

            for (int i = 0; i < authors_count; i++)
            {
                a[i] = new authors();
            }

            for (int i = 0; i < authors_count; i++)
            {
                a[i].getdata();
            }

            for (int i = 0; i < authors_count; i++)
            {
                a[i].displayData();
            }

            //members details
            Console.WriteLine("Enter members count: ");
            int members_count = Convert.ToInt32(Console.ReadLine());
            members[] m = new members[members_count];

            for(int i=0;i<members_count;i++)
            {
                m[i] = new members();
                m[i].getdata();
            }

            for(int i=0;i<books_count;i++)
            {
                m[i].displayData();
            }

            //rent details

            Console.WriteLine("Enter count of details: ");
            int n = Convert.ToInt32(Console.ReadLine());

            rent_details[] r = new rent_details[n];

            for(int i=0;i<n;i++)
            {
                r[i] = new rent_details();
                r[i].getdata();
            }

            for(int i=0;i<n;i++)
            {
                r[i].displayData();
                Console.WriteLine("Due days: " + r[i].check_due());
                Console.WriteLine("---------------------------------------------------------------------");
            }

            
        }
    }
}
