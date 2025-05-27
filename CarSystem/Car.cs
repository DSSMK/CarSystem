namespace CarSystem
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string Model { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Color: {Color}, Price: {Price}, Model: {Model}";
        }
    }
}



