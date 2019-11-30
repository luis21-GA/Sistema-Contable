namespace SistemasContables.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AsientoDiario")]
    public partial class AsientoDiario
    {
        [Key]
        [Display(Name = "N° Partida")]
        public int idAsiento { get; set; }
        [Display(Name = "Codigo")]
        public int CodigoCuenta { get; set; }
        [Display(Name = "Codigo")]
        public int CodigoCuenta1 { get; set; }
        [Display(Name = "Debe")]
        public double Debe1 { get; set; }
        [Display(Name = "Haber")]
        public double Haber1 { get; set; }
        [Display(Name = "Debe")]
        public double Debe2 { get; set; }
        [Display(Name = "Haber")]
        public double Haber2 { get; set; }
        [Display(Name = "Fecha")]
       [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [StringLength(250)]
        public string DEscripcion { get; set; }

        public virtual Cuentas Cuentas { get; set; }

        public virtual Cuentas Cuentas1 { get; set; }
    }
}
