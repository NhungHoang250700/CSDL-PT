namespace QuanLyDuAn
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MSmerge_past_partition_mappings
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short publication_number { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int tablenick { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid rowguid { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int partition_id { get; set; }

        public long? generation { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte reason { get; set; }
    }
}
