namespace FirstMVCApp.Models
{
    public class Pen
    {
        public int PenId { get; set; }
        public string PenName { get; set; }
        public float Price { get; set; }

        public static List<Pen> pens = new List<Pen>();

        public Pen()
        {

        }

        public Pen(int penid, string penname, float price)
        {
            PenId = penid;
            PenName = penname;
            Price = price;
        }

        public List<Pen> getPenDetails()
        {
            pens.Add(new Pen(101, "Parker", 400));
            pens.Add(new Pen(102, "Ronalds", 500));
            return pens;
        }
    }
}
