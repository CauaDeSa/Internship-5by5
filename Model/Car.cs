namespace Model
{
    public class Car
    {
        public static readonly string INSERT = "spInsertCar";
        public static readonly string UPDATE = "spUpdateCar";
        public static readonly string GET = "spGetCarById";
        public static readonly string GETALL = "spGetAllCars";
        public static readonly string DELETE = "spDeleteCar";

        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public Insurance? Insurance { get; set; }

        override public string ToString()
        {
            return $"Id.....: {Id}\n" +
                   $"Name...: {Name}\n" +
                   $"Color..: {Color}\n" +
                   $"Year...: {Year}";
        }
    }
}