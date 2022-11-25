using ElectronicsAppLibrary.Models;

namespace ElectronicsAppLibrary
{
    public class CategoryClass
    {
        public static ElectronicsShoppingContext db = new ElectronicsShoppingContext();
        private static Category c = new Category();

        public static void AddCategory(string cname, int count)
        {
            
            c.CategoryName = cname;
            c.Count = count;
            db.Categories.Add(c);
            db.SaveChanges();
        }

        public static void DeleteCategory(int cid)
        {
            c = db.Categories.Find(cid);
            db.Categories.Remove(c);
            db.SaveChanges();
        }

        public static void UpdateCategoryCount(int cid, int count)
        {
            c = db.Categories.Find(cid);
            c.Count = count;
            db.Categories.Update(c);
            db.SaveChanges();
        }

        public static void DisplayCategories()
        {
            foreach (var item in db.Categories)
            {
                Console.WriteLine("CategoryID: " + item.CategoryId + "\nCategory Name: " + c.CategoryName + "\nCount: " + c.Count);
                Console.WriteLine();
            }
        }

    }
}