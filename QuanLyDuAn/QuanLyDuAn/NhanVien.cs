namespace QuanLyDuAn
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            PhanCongs = new HashSet<PhanCong>();
        }

        [Key]
        [StringLength(4)]
        public string MaNV { get; set; }

        [StringLength(20)]
        public string Ho { get; set; }

        [StringLength(10)]
        public string Ten { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [StringLength(4)]
        public string MaCV { get; set; }

        [StringLength(4)]
        public string MaCN { get; set; }

        public Guid rowguid { get; set; }

        public virtual ChiNhanh ChiNhanh { get; set; }

        public virtual ChucVu ChucVu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanCong> PhanCongs { get; set; }
    }
}
