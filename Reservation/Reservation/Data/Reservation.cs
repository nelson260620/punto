using System;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Data
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es requerido.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La fecha es requerida.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public bool Confirmed { get; set; }
    }
}
