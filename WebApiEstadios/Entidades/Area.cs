namespace WebApiEstadios.Entidades
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public uint Capacity { get; set;}
        public uint Available { get; set;}
        public uint Taken { get; set;}
        public int EstadioId { get; set; }
        public Estadio Estadio { get; set; }
    }
}
