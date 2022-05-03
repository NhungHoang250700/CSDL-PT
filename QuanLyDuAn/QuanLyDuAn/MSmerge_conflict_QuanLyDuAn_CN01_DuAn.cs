namespace QuanLyDuAn
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MSmerge_conflict_QuanLyDuAn_CN01_DuAn
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string MaDA { get; set; }

        [StringLength(20)]
        public string TenDA { get; set; }

        [StringLength(4)]
        public string MaCN { get; set; }

        public DateTime? NgayBD { get; set; }

        public int? Kinhphi { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid rowguid { get; set; }

        public Guid? origin_datasource_id { get; set; }
    }
}
