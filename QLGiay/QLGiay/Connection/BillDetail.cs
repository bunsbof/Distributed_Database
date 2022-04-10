namespace QLUniqlo.Connection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BillDetail
    {
        public long id { get; set; }

        public long id_bill { get; set; }

        public long id_product { get; set; }

        public int quantity { get; set; }

        public double purchase_price { get; set; }

        public DateTime create_at { get; set; }

        public DateTime updated_at { get; set; }

        public DateTime? deleted_at { get; set; }

        public Guid rowguid { get; set; }

        public virtual Bill Bill { get; set; }

        public virtual Product Product { get; set; }
    }
}
