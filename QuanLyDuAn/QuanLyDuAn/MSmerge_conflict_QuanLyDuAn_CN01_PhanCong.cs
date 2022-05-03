namespace QuanLyDuAn
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MSmerge_conflict_QuanLyDuAn_CN01_PhanCong
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string MaDA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string MaNV { get; set; }

        [StringLength(30)]
        public string CongViec { get; set; }

        public DateTime? NgayBD { get; set; }

        public DateTime? NgayKT { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid rowguid { get; set; }

        public Guid? origin_datasource_id { get; set; }
    }
}
