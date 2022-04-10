namespace QLUniqlo.Connection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Bills = new HashSet<Bill>();
        }

        public long id { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string name { get; set; }

        public DateTime birthday { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string address { get; set; }

        [Required]
        [StringLength(50)]
        public string phone { get; set; }

        public decimal salary { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string role { get; set; }

        public long id_branch { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }

        public DateTime? deleted_at { get; set; }

        public Guid rowguid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }

        public virtual Branch Branch { get; set; }
    }
}
