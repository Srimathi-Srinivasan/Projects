using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarymanagementsystem
{
    internal class books
    {
        int book_id;
        string book_title;
        int author_id;
        int price;
        float rating;
        int available_copies;

        public void getdata()
        {
            Console.WriteLine("Enter book id,book title,author id,price,rating,available copies: ");
            book_id = Convert.ToInt32(Console.ReadLine());
            book_title = Console.ReadLine();
            author_id = Convert.ToInt32(Console.ReadLine()); 
            price = Convert.ToInt32(Console.ReadLine());
            rating = float.Parse(Console.ReadLine());
            available_copies = Convert.ToInt32(Console.ReadLine());
        }

        public void displayData()
        {
            Console.WriteLine("book id: "+book_id);
            Console.WriteLine("book title: "+book_title);
            Console.WriteLine("author id: "+author_id);
            Console.WriteLine("price: "+price);
            Console.WriteLine("rating: "+rating);
            Console.WriteLine("available copies: "+available_copies);
            Console.WriteLine("---------------------------------------------------------------------");
        }
    }

    internal class authors
    {
        int author_id;
        string author_name;
        string books_written;

        public void getdata()
        {
            Console.WriteLine("Enter author id,author name,books written:");
            author_id=Convert.ToInt32(Console.ReadLine());
            author_name = Console.ReadLine();
            books_written = Console.ReadLine();
        }

        public void displayData()
        {
            Console.WriteLine("author id: "+author_id);
            Console.WriteLine("author name: "+author_name);
            Console.WriteLine("books written: "+books_written);
            Console.WriteLine("---------------------------------------------------------------------");
        }
    }

    internal class members
    {
        int member_id;
        string member_name;
        string address;

        public void getdata()
        {
            Console.WriteLine("Enter member id,member name,address: ");
            member_id=Convert.ToInt32(Console.ReadLine());
            member_name = Console.ReadLine();
            address = Console.ReadLine();
        }
        public void displayData()
        {
            Console.WriteLine("member id: "+member_id);
            Console.WriteLine("memeber name: "+member_name);
            Console.WriteLine("address: "+address);
            Console.WriteLine("---------------------------------------------------------------------");
        }
    }

    internal class rent_details
    {
        int reader_id;
        int book_id;
        DateTime borrow_date;
        DateTime return_date;

        public void getdata()
        {
            Console.WriteLine("Enter reader id,book id,borrow date,return date: ");
            reader_id=Convert.ToInt32(Console.ReadLine());
            book_id=Convert.ToInt32(Console.ReadLine());
            borrow_date = Convert.ToDateTime(Console.ReadLine());
            return_date = Convert.ToDateTime(Console.ReadLine());
        }

        public void displayData()
        {
            Console.WriteLine("reader id: "+reader_id);
            Console.WriteLine("book id: "+book_id);
            Console.WriteLine("borrow date: "+borrow_date);
            Console.WriteLine("return date: " + return_date);
            
        }

        public int check_due()
        {

            //string datediff = (return_date - borrow_date).TotalDays.ToString();
            //sint datedifference = Convert.ToInt32(datediff);
            int datedifference = Convert.ToInt32((return_date - borrow_date).TotalDays.ToString());
            if (datedifference <= 10)
            {
                return 0;
            }
            else
            {
                return datedifference-10;
            }
        }
    }
}
