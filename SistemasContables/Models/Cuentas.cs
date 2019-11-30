namespace SistemasContables.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cuentas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cuentas()
        {
            AsientoDiario = new HashSet<AsientoDiario>();
            AsientoDiario1 = new HashSet<AsientoDiario>();
        }

        [Key]
        [Display(Name = "Codigo")]
        public int CodigoCuenta { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Cuenta")]
        public string nombre { get; set; }

        [StringLength(250)]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        [Display(Name = "codigo")]
        public int idCategoria { get; set; }

        [Display(Name = "Deudor")]
        public double? Cargos { get; set; }
        [Display(Name = "Acreedor")]
        public double? Abonos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AsientoDiario> AsientoDiario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AsientoDiario> AsientoDiario1 { get; set; }

        public virtual Category Category { get; set; }
    }
}
