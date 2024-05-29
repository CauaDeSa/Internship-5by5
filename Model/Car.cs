namespace Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }

        override public string ToString()
        {
            return $"Id.....: {Id}\n" +
                   $"Name...: {Name}\n" +
                   $"Color..: {Color}\n" +
                   $"Year...: {Year}";
        }
    }
}