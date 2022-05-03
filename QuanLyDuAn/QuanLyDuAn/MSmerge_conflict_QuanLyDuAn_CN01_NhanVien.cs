namespace QuanLyDuAn
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MSmerge_conflict_QuanLyDuAn_CN01_NhanVien
    {
        [Key]
        [Column(Order = 0)]
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

        [Key]
        [Column(Order = 1)]
        public Guid rowguid { get; set; }

        public Guid? origin_datasource_id { get; set; }
    }
}
