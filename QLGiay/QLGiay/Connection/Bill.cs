namespace QLUniqlo.Connection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public long id { get; set; }

        public long id_emp { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string customer_name { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string customer_phone { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string item_quantity { get; set; }

        public DateTime purchase_date { get; set; }

        public double purchase_total { get; set; }

        public double discount { get; set; }

        public DateTime payment_date { get; set; }

        public DateTime created_at { get; set; }

        public DateTime update_at { get; set; }

        public DateTime? deleted_at { get; set; }

        public Guid rowguid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillDetail> BillDetails { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
