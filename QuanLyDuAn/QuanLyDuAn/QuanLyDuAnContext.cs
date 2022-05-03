using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyDuAn
{
    public partial class QuanLyDuAnContext : DbContext
    {
        public QuanLyDuAnContext(string connectionString)
            : base(connectionString)
        {
        }

        public virtual DbSet<ChiNhanh> ChiNhanhs { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<DuAn> DuAns { get; set; }
        public virtual DbSet<MSdynamicsnapshotview> MSdynamicsnapshotviews { get; set; }
        public virtual DbSet<MSmerge_dynamic_snapshots> MSmerge_dynamic_snapshots { get; set; }
        public virtual DbSet<MSmerge_partition_groups> MSmerge_partition_groups { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhanCong> PhanCongs { get; set; }
        public virtual DbSet<MSdynamicsnapshotjob> MSdynamicsnapshotjobs { get; set; }
        public virtual DbSet<MSmerge_agent_parameters> MSmerge_agent_parameters { get; set; }
        public virtual DbSet<MSmerge_altsyncpartners> MSmerge_altsyncpartners { get; set; }
        public virtual DbSet<MSmerge_articlehistory> MSmerge_articlehistory { get; set; }
        public virtual DbSet<MSmerge_conflict_QuanLyDuAn_CN01_ChiNhanh> MSmerge_conflict_QuanLyDuAn_CN01_ChiNhanh { get; set; }
        public virtual DbSet<MSmerge_conflict_QuanLyDuAn_CN01_ChucVu> MSmerge_conflict_QuanLyDuAn_CN01_ChucVu { get; set; }
        public virtual DbSet<MSmerge_conflict_QuanLyDuAn_CN01_DuAn> MSmerge_conflict_QuanLyDuAn_CN01_DuAn { get; set; }
        public virtual DbSet<MSmerge_conflict_QuanLyDuAn_CN01_NhanVien> MSmerge_conflict_QuanLyDuAn_CN01_NhanVien { get; set; }
        public virtual DbSet<MSmerge_conflict_QuanLyDuAn_CN01_PhanCong> MSmerge_conflict_QuanLyDuAn_CN01_PhanCong { get; set; }
        public virtual DbSet<MSmerge_conflicts_info> MSmerge_conflicts_info { get; set; }
        public virtual DbSet<MSmerge_contents> MSmerge_contents { get; set; }
        public virtual DbSet<MSmerge_current_partition_mappings> MSmerge_current_partition_mappings { get; set; }
        public virtual DbSet<MSmerge_errorlineage> MSmerge_errorlineage { get; set; }
        public virtual DbSet<MSmerge_generation_partition_mappings> MSmerge_generation_partition_mappings { get; set; }
        public virtual DbSet<MSmerge_genhistory> MSmerge_genhistory { get; set; }
        public virtual DbSet<MSmerge_history> MSmerge_history { get; set; }
        public virtual DbSet<MSmerge_identity_range> MSmerge_identity_range { get; set; }
        public virtual DbSet<MSmerge_log_files> MSmerge_log_files { get; set; }
        public virtual DbSet<MSmerge_metadataaction_request> MSmerge_metadataaction_request { get; set; }
        public virtual DbSet<MSmerge_past_partition_mappings> MSmerge_past_partition_mappings { get; set; }
        public virtual DbSet<MSmerge_replinfo> MSmerge_replinfo { get; set; }
        public virtual DbSet<MSmerge_sessions> MSmerge_sessions { get; set; }
        public virtual DbSet<MSmerge_settingshistory> MSmerge_settingshistory { get; set; }
        public virtual DbSet<MSmerge_supportability_settings> MSmerge_supportability_settings { get; set; }
        public virtual DbSet<MSmerge_tombstone> MSmerge_tombstone { get; set; }
        public virtual DbSet<MSrepl_errors> MSrepl_errors { get; set; }
        public virtual DbSet<MSsnapshotdeliveryprogress> MSsnapshotdeliveryprogresses { get; set; }
        public virtual DbSet<sysmergearticle> sysmergearticles { get; set; }
        public virtual DbSet<sysmergepartitioninfo> sysmergepartitioninfoes { get; set; }
        public virtual DbSet<sysmergepublication> sysmergepublications { get; set; }
        public virtual DbSet<sysmergeschemaarticle> sysmergeschemaarticles { get; set; }
        public virtual DbSet<sysmergeschemachange> sysmergeschemachanges { get; set; }
        public virtual DbSet<sysmergesubscription> sysmergesubscriptions { get; set; }
        public virtual DbSet<sysmergesubsetfilter> sysmergesubsetfilters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiNhanh>()
                .Property(e => e.MaCN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChucVu>()
                .Property(e => e.MaCV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DuAn>()
                .Property(e => e.MaDA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DuAn>()
                .Property(e => e.MaCN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DuAn>()
                .HasMany(e => e.PhanCongs)
                .WithRequired(e => e.DuAn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MSmerge_partition_groups>()
                .HasOptional(e => e.MSmerge_dynamic_snapshots)
                .WithRequired(e => e.MSmerge_partition_groups)
                .WillCascadeOnDelete();

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaCV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaCN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.PhanCongs)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhanCong>()
                .Property(e => e.MaDA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhanCong>()
                .Property(e => e.MaNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MSmerge_articlehistory>()
                .Property(e => e.percent_complete)
                .HasPrecision(5, 2);

            modelBuilder.Entity<MSmerge_articlehistory>()
                .Property(e => e.relative_cost)
                .HasPrecision(12, 2);

            modelBuilder.Entity<MSmerge_conflict_QuanLyDuAn_CN01_ChiNhanh>()
                .Property(e => e.MaCN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MSmerge_conflict_QuanLyDuAn_CN01_ChucVu>()
                .Property(e => e.MaCV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MSmerge_conflict_QuanLyDuAn_CN01_DuAn>()
                .Property(e => e.MaDA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MSmerge_conflict_QuanLyDuAn_CN01_DuAn>()
                .Property(e => e.MaCN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MSmerge_conflict_QuanLyDuAn_CN01_NhanVien>()
                .Property(e => e.MaNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MSmerge_conflict_QuanLyDuAn_CN01_NhanVien>()
                .Property(e => e.MaCV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MSmerge_conflict_QuanLyDuAn_CN01_NhanVien>()
                .Property(e => e.MaCN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MSmerge_conflict_QuanLyDuAn_CN01_PhanCong>()
                .Property(e => e.MaDA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MSmerge_conflict_QuanLyDuAn_CN01_PhanCong>()
                .Property(e => e.MaNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MSmerge_history>()
                .Property(e => e.timestamp)
                .IsFixedLength();

            modelBuilder.Entity<MSmerge_identity_range>()
                .Property(e => e.range_begin)
                .HasPrecision(38, 0);

            modelBuilder.Entity<MSmerge_identity_range>()
                .Property(e => e.range_end)
                .HasPrecision(38, 0);

            modelBuilder.Entity<MSmerge_identity_range>()
                .Property(e => e.next_range_begin)
                .HasPrecision(38, 0);

            modelBuilder.Entity<MSmerge_identity_range>()
                .Property(e => e.next_range_end)
                .HasPrecision(38, 0);

            modelBuilder.Entity<MSmerge_identity_range>()
                .Property(e => e.max_used)
                .HasPrecision(38, 0);

            modelBuilder.Entity<MSmerge_replinfo>()
                .Property(e => e.merge_jobid)
                .IsFixedLength();

            modelBuilder.Entity<MSmerge_sessions>()
                .Property(e => e.delivery_rate)
                .HasPrecision(12, 2);

            modelBuilder.Entity<MSmerge_sessions>()
                .Property(e => e.percent_complete)
                .HasPrecision(5, 2);

            modelBuilder.Entity<MSmerge_sessions>()
                .Property(e => e.timestamp)
                .IsFixedLength();

            modelBuilder.Entity<sysmergearticle>()
                .Property(e => e.schema_option)
                .IsFixedLength();

            modelBuilder.Entity<sysmergearticle>()
                .Property(e => e.procname_postfix)
                .IsFixedLength();

            modelBuilder.Entity<sysmergepublication>()
                .Property(e => e.snapshot_jobid)
                .IsFixedLength();

            modelBuilder.Entity<sysmergeschemaarticle>()
                .Property(e => e.schema_option)
                .IsFixedLength();

            modelBuilder.Entity<sysmergesubscription>()
                .Property(e => e.replnickname)
                .IsFixedLength();
        }
    }
}
