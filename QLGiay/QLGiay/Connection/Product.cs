namespace QLUniqlo.Connection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public long id { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string name { get; set; }

        public double price { get; set; }

        public long id_category { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string description { get; set; }

        public long id_attribute { get; set; }

        public int quantity { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }

        public DateTime? deleted_at { get; set; }

        public Guid rowguid { get; set; }

        public virtual Attribute Attribute { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillDetail> BillDetails { get; set; }

        public virtual Category Category { get; set; }
    }
}
