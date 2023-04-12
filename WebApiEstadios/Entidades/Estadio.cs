using System.ComponentModel.DataAnnotations;

namespace WebApiEstadios.Entidades
{
    public class Estadio
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese el nombre({0}) del estadio")]
        [StringLength(maximumLength: 50,MinimumLength = 4, ErrorMessage = "Reduzca el nombre o mejor use siglas")]
        public string Name { get; set;}

        [Required(ErrorMessage = "Ingrese el propietario({0}) del estadio")]
        [StringLength(maximumLength: 50, MinimumLength = 4, ErrorMessage = "Reduzca el nombre o mejor use siglas")]
        public string Owner { get; set;}

        [Required(ErrorMessage = "Ingrese la localizacion({0}) del estadio")]
        [StringLength(maximumLength: 50, MinimumLength = 4, ErrorMessage = "Reduzca el nombre o mejor use siglas")]
        public string Coords { get; set;}

        [Range(0, 30000, ErrorMessage ="Ingrese una cantidad({0}) entre 0 y 3000")]
        public uint ParkingCapacity { get; set;}

        [Required(ErrorMessage = "Ingrese la cantidad total de asientos({0}) que dispone el estadio")]
        [Range(0, 150000, ErrorMessage = "Ingrese una cantidad entre 0 y 150000")]
        public uint TotalSeats { get; set;}


        public List<Area> Areas { get; set;}
        //public EstadioType EstadioType { get; set; }
    }
}
