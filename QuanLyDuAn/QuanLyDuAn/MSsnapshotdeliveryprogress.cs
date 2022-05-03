namespace QuanLyDuAn
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MSsnapshotdeliveryprogress")]
    public partial class MSsnapshotdeliveryprogress
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(260)]
        public string session_token { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int progress_token_hash { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(500)]
        public string progress_token { get; set; }

        public DateTime? progress_timestamp { get; set; }
    }
}
