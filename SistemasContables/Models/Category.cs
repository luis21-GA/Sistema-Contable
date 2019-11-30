namespace SistemasContables.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Cuentas = new HashSet<Cuentas>();
        }

        [Key]
        [Display(Name = "Codigo")]
        public int idCategoria { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name ="Cuenta")]
        public string nombre { get; set; }

        [StringLength(250)]
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cuentas> Cuentas { get; set; }
    }
}
