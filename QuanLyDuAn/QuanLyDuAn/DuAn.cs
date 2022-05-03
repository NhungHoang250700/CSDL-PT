namespace QuanLyDuAn
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DuAn")]
    public partial class DuAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DuAn()
        {
            PhanCongs = new HashSet<PhanCong>();
        }

        [Key]
        [StringLength(4)]
        public string MaDA { get; set; }

        [StringLength(20)]
        public string TenDA { get; set; }

        [StringLength(4)]
        public string MaCN { get; set; }

        public DateTime? NgayBD { get; set; }

        public int? Kinhphi { get; set; }

        public Guid rowguid { get; set; }

        public virtual ChiNhanh ChiNhanh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanCong> PhanCongs { get; set; }
    }
}
