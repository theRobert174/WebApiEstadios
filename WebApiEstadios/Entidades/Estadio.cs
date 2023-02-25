namespace WebApiEstadios.Entidades
{
    public class Estadio
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string Owner { get; set;}
        public string Coords { get; set;}
        public uint ParkingCapacity { get; set;}
        public uint TotalSeats { get; set;}
    }
}
