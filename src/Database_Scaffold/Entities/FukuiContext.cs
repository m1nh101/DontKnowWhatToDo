using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Database_Scaffold.Entities;

public partial class FukuiContext : DbContext
{
    public FukuiContext()
    {
    }

    public FukuiContext(DbContextOptions<FukuiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BankBranchMst> BankBranchMsts { get; set; }

    public virtual DbSet<BankMst> BankMsts { get; set; }

    public virtual DbSet<DepartmentMst> DepartmentMsts { get; set; }

    public virtual DbSet<DivisionMst> DivisionMsts { get; set; }

    public virtual DbSet<FiscalYearMst> FiscalYearMsts { get; set; }

    public virtual DbSet<PositionMst> PositionMsts { get; set; }

    public virtual DbSet<RoleMst> RoleMsts { get; set; }

    public virtual DbSet<StockTransTbl> StockTransTbls { get; set; }

    public virtual DbSet<StockholderMst> StockholderMsts { get; set; }

    public virtual DbSet<StockholderTypeMst> StockholderTypeMsts { get; set; }

    public virtual DbSet<UserMst> UserMsts { get; set; }

    public virtual DbSet<UserRoleMap> UserRoleMaps { get; set; }

    public virtual DbSet<YearJpnMst> YearJpnMsts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=fukui;UID=postgres;PWD=M1ng@2002");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BankBranchMst>(entity =>
        {
            entity.HasKey(e => e.BankBranchCd).HasName("bank_branch_mst_pkey");

            entity.ToTable("bank_branch_mst");

            entity.Property(e => e.BankBranchCd)
                .HasMaxLength(3)
                .HasColumnName("bank_branch_cd");
            entity.Property(e => e.AvailFlg).HasColumnName("avail_flg");
            entity.Property(e => e.BankBranchName)
                .HasMaxLength(255)
                .HasColumnName("bank_branch_name");
            entity.Property(e => e.BankBranchNameKana)
                .HasMaxLength(255)
                .HasColumnName("bank_branch_name_kana");
            entity.Property(e => e.BankCd)
                .HasMaxLength(4)
                .HasColumnName("bank_cd");
            entity.Property(e => e.DeleteFlg).HasColumnName("delete_flg");
            entity.Property(e => e.RegistBy).HasColumnName("regist_by");
            entity.Property(e => e.RegistDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("regist_date");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("update_date");

            entity.HasOne(d => d.BankCdNavigation).WithMany(p => p.BankBranchMsts)
                .HasForeignKey(d => d.BankCd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bank_branch_mst_bank_cd_foreign");
        });

        modelBuilder.Entity<BankMst>(entity =>
        {
            entity.HasKey(e => e.BankCd).HasName("bank_mst_pkey");

            entity.ToTable("bank_mst");

            entity.Property(e => e.BankCd)
                .HasMaxLength(4)
                .HasColumnName("bank_cd");
            entity.Property(e => e.AvailFlg).HasColumnName("avail_flg");
            entity.Property(e => e.BankName)
                .HasMaxLength(255)
                .HasColumnName("bank_name");
            entity.Property(e => e.BankNameKana)
                .HasMaxLength(255)
                .HasColumnName("bank_name_kana");
            entity.Property(e => e.DeleteFlg).HasColumnName("delete_flg");
            entity.Property(e => e.RegistBy).HasColumnName("regist_by");
            entity.Property(e => e.RegistDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("regist_date");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<DepartmentMst>(entity =>
        {
            entity.HasKey(e => e.DeptCd).HasName("department_mst_pkey");

            entity.ToTable("department_mst");

            entity.Property(e => e.DeptCd)
                .HasMaxLength(4)
                .HasColumnName("dept_cd");
            entity.Property(e => e.AvailFlg).HasColumnName("avail_flg");
            entity.Property(e => e.DeleteFlg).HasColumnName("delete_flg");
            entity.Property(e => e.DeptDisplayOrder).HasColumnName("dept_display_order");
            entity.Property(e => e.DeptName)
                .HasMaxLength(24)
                .HasColumnName("dept_name");
            entity.Property(e => e.JinjiDeptCd)
                .HasMaxLength(5)
                .HasColumnName("jinji_dept_cd");
            entity.Property(e => e.RegistBy).HasColumnName("regist_by");
            entity.Property(e => e.RegistDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("regist_date");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<DivisionMst>(entity =>
        {
            entity.HasKey(e => e.DivCd).HasName("division_mst_pkey");

            entity.ToTable("division_mst");

            entity.Property(e => e.DivCd)
                .HasMaxLength(4)
                .HasColumnName("div_cd");
            entity.Property(e => e.AvailFlg).HasColumnName("avail_flg");
            entity.Property(e => e.DeleteFlg).HasColumnName("delete_flg");
            entity.Property(e => e.DeptCd)
                .HasMaxLength(4)
                .HasColumnName("dept_cd");
            entity.Property(e => e.DivDisplayOrder).HasColumnName("div_display_order");
            entity.Property(e => e.DivName)
                .HasMaxLength(24)
                .HasColumnName("div_name");
            entity.Property(e => e.JinjiDivCd)
                .HasMaxLength(5)
                .HasColumnName("jinji_div_cd");
            entity.Property(e => e.RegistBy).HasColumnName("regist_by");
            entity.Property(e => e.RegistDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("regist_date");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("update_date");

            entity.HasOne(d => d.DeptCdNavigation).WithMany(p => p.DivisionMsts)
                .HasForeignKey(d => d.DeptCd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("division_mst_dept_cd_foreign");
        });

        modelBuilder.Entity<FiscalYearMst>(entity =>
        {
            entity.HasKey(e => e.FiscalYearCd).HasName("fiscal_year_mst_pkey");

            entity.ToTable("fiscal_year_mst");

            entity.Property(e => e.FiscalYearCd)
                .ValueGeneratedNever()
                .HasColumnName("fiscal_year_cd");
            entity.Property(e => e.AvailFlg).HasColumnName("avail_flg");
            entity.Property(e => e.DeleteFlg).HasColumnName("delete_flg");
            entity.Property(e => e.FiscalYearEndDate).HasColumnName("fiscal_year_end_date");
            entity.Property(e => e.FiscalYearStartDate).HasColumnName("fiscal_year_start_date");
            entity.Property(e => e.NormalDividendPrice).HasColumnName("normal_dividend_price");
            entity.Property(e => e.RegistBy).HasColumnName("regist_by");
            entity.Property(e => e.RegistDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("regist_date");
            entity.Property(e => e.SpecialDividendPrice).HasColumnName("special_dividend_price");
            entity.Property(e => e.StockConversionFactor).HasColumnName("stock_conversion_factor");
            entity.Property(e => e.StockGmScheduleDate).HasColumnName("stock_gm_schedule_date");
            entity.Property(e => e.StockPaymentScheduleDate).HasColumnName("stock_payment_schedule_date");
            entity.Property(e => e.StockUnitPrice).HasColumnName("stock_unit_price");
            entity.Property(e => e.TaxRate).HasColumnName("tax_rate");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("update_date");
            entity.Property(e => e.YearCd)
                .HasMaxLength(1)
                .HasColumnName("year_cd");

            entity.HasOne(d => d.YearCdNavigation).WithMany(p => p.FiscalYearMsts)
                .HasForeignKey(d => d.YearCd)
                .HasConstraintName("fiscal_year_mst_year_cd_foreign");
        });

        modelBuilder.Entity<PositionMst>(entity =>
        {
            entity.HasKey(e => e.PositionCd).HasName("position_mst_pkey");

            entity.ToTable("position_mst");

            entity.Property(e => e.PositionCd)
                .HasMaxLength(4)
                .HasColumnName("position_cd");
            entity.Property(e => e.AvailFlg).HasColumnName("avail_flg");
            entity.Property(e => e.DeleteFlg).HasColumnName("delete_flg");
            entity.Property(e => e.PosDisplayOrder).HasColumnName("pos_display_order");
            entity.Property(e => e.PositionName)
                .HasMaxLength(24)
                .HasColumnName("position_name");
            entity.Property(e => e.RegistBy).HasColumnName("regist_by");
            entity.Property(e => e.RegistDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("regist_date");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<RoleMst>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_mst_pkey");

            entity.ToTable("role_mst");

            entity.HasIndex(e => e.Id, "role_mst_id_index");

            entity.HasIndex(e => e.RoleName, "role_mst_role_name_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvailFlg).HasColumnName("avail_flg");
            entity.Property(e => e.DeleteFlg).HasColumnName("delete_flg");
            entity.Property(e => e.RegistBy).HasColumnName("regist_by");
            entity.Property(e => e.RegistDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("regist_date");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .HasColumnName("role_name");
            entity.Property(e => e.RoleNameShort)
                .HasMaxLength(255)
                .HasColumnName("role_name_short");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<StockTransTbl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("stock_trans_tbl_pkey");

            entity.ToTable("stock_trans_tbl");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvailFlg).HasColumnName("avail_flg");
            entity.Property(e => e.DeleteFlg).HasColumnName("delete_flg");
            entity.Property(e => e.FiscalYearCd).HasColumnName("fiscal_year_cd");
            entity.Property(e => e.FromStkCd)
                .HasMaxLength(4)
                .HasColumnName("from_stk_cd");
            entity.Property(e => e.RegistBy).HasColumnName("regist_by");
            entity.Property(e => e.RegistDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("regist_date");
            entity.Property(e => e.StkNumber).HasColumnName("stk_number");
            entity.Property(e => e.StkTransDate).HasColumnName("stk_trans_date");
            entity.Property(e => e.StkUnitPrice).HasColumnName("stk_unit_price");
            entity.Property(e => e.ToStkCd)
                .HasMaxLength(4)
                .HasColumnName("to_stk_cd");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("update_date");

            entity.HasOne(d => d.FiscalYearCdNavigation).WithMany(p => p.StockTransTbls)
                .HasForeignKey(d => d.FiscalYearCd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("stock_trans_tbl_fiscal_year_cd_foreign");

            entity.HasOne(d => d.FromStkCdNavigation).WithMany(p => p.StockTransTblFromStkCdNavigations)
                .HasForeignKey(d => d.FromStkCd)
                .HasConstraintName("stock_trans_tbl_from_stk_cd_foreign");

            entity.HasOne(d => d.ToStkCdNavigation).WithMany(p => p.StockTransTblToStkCdNavigations)
                .HasForeignKey(d => d.ToStkCd)
                .HasConstraintName("stock_trans_tbl_to_stk_cd_foreign");
        });

        modelBuilder.Entity<StockholderMst>(entity =>
        {
            entity.HasKey(e => e.StkCd).HasName("stockholder_mst_pkey");

            entity.ToTable("stockholder_mst");

            entity.Property(e => e.StkCd)
                .HasMaxLength(4)
                .HasColumnName("stk_cd");
            entity.Property(e => e.AccountNo)
                .HasMaxLength(7)
                .HasColumnName("account_no");
            entity.Property(e => e.AvailFlg).HasColumnName("avail_flg");
            entity.Property(e => e.BankBranchCd)
                .HasMaxLength(3)
                .HasColumnName("bank_branch_cd");
            entity.Property(e => e.BankCd)
                .HasMaxLength(4)
                .HasColumnName("bank_cd");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.DeleteFlg).HasColumnName("delete_flg");
            entity.Property(e => e.JoinDate).HasColumnName("join_date");
            entity.Property(e => e.Mynumber)
                .HasMaxLength(12)
                .HasColumnName("mynumber");
            entity.Property(e => e.MynumberCd)
                .HasMaxLength(12)
                .HasColumnName("mynumber_cd");
            entity.Property(e => e.RegistBy).HasColumnName("regist_by");
            entity.Property(e => e.RegistDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("regist_date");
            entity.Property(e => e.StkAddress1)
                .HasMaxLength(50)
                .HasColumnName("stk_address1");
            entity.Property(e => e.StkAddress2)
                .HasMaxLength(50)
                .HasColumnName("stk_address2");
            entity.Property(e => e.StkName)
                .HasMaxLength(20)
                .HasColumnName("stk_name");
            entity.Property(e => e.StkNameKana)
                .HasMaxLength(30)
                .HasColumnName("stk_name_kana");
            entity.Property(e => e.StkTypeCd)
                .HasMaxLength(3)
                .HasColumnName("stk_type_cd");
            entity.Property(e => e.StkZipcode1)
                .HasMaxLength(5)
                .HasColumnName("stk_zipcode1");
            entity.Property(e => e.StkZipcode2)
                .HasMaxLength(5)
                .HasColumnName("stk_zipcode2");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("update_date");

            entity.HasOne(d => d.BankBranchCdNavigation).WithMany(p => p.StockholderMsts)
                .HasForeignKey(d => d.BankBranchCd)
                .HasConstraintName("stockholder_mst_bank_branch_cd_foreign");

            entity.HasOne(d => d.BankCdNavigation).WithMany(p => p.StockholderMsts)
                .HasForeignKey(d => d.BankCd)
                .HasConstraintName("stockholder_mst_bank_cd_foreign");

            entity.HasOne(d => d.StkTypeCdNavigation).WithMany(p => p.StockholderMsts)
                .HasForeignKey(d => d.StkTypeCd)
                .HasConstraintName("stockholder_mst_stk_type_cd_foreign");
        });

        modelBuilder.Entity<StockholderTypeMst>(entity =>
        {
            entity.HasKey(e => e.StkTypeCd).HasName("stockholder_type_mst_pkey");

            entity.ToTable("stockholder_type_mst");

            entity.Property(e => e.StkTypeCd)
                .HasMaxLength(3)
                .HasColumnName("stk_type_cd");
            entity.Property(e => e.AvailFlg).HasColumnName("avail_flg");
            entity.Property(e => e.DeleteFlg).HasColumnName("delete_flg");
            entity.Property(e => e.RegistBy).HasColumnName("regist_by");
            entity.Property(e => e.RegistDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("regist_date");
            entity.Property(e => e.StkTypeName)
                .HasMaxLength(10)
                .HasColumnName("stk_type_name");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("update_date");
        });

        modelBuilder.Entity<UserMst>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_mst_pkey");

            entity.ToTable("user_mst");

            entity.HasIndex(e => e.LoginId, "user_mst_login_id_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvailFlg).HasColumnName("avail_flg");
            entity.Property(e => e.DeleteFlg).HasColumnName("delete_flg");
            entity.Property(e => e.DivCd)
                .HasMaxLength(4)
                .HasColumnName("div_cd");
            entity.Property(e => e.LastLoginDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("last_login_date");
            entity.Property(e => e.LoginId)
                .HasMaxLength(255)
                .HasColumnName("login_id");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.RegistBy).HasColumnName("regist_by");
            entity.Property(e => e.RegistDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("regist_date");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("update_date");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .HasColumnName("user_name");

            entity.HasOne(d => d.DivCdNavigation).WithMany(p => p.UserMsts)
                .HasForeignKey(d => d.DivCd)
                .HasConstraintName("user_mst_div_cd_foreign");
        });

        modelBuilder.Entity<UserRoleMap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_role_map_pkey");

            entity.ToTable("user_role_map");

            entity.HasIndex(e => e.Id, "user_role_map_id_index");

            entity.HasIndex(e => e.RoleId, "user_role_map_role_id_index");

            entity.HasIndex(e => e.UserId, "user_role_map_user_id_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvailFlg).HasColumnName("avail_flg");
            entity.Property(e => e.DeleteFlg).HasColumnName("delete_flg");
            entity.Property(e => e.RegistBy).HasColumnName("regist_by");
            entity.Property(e => e.RegistDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("regist_date");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("update_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoleMaps)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("user_role_map_role_id_foreign");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoleMaps)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_role_map_user_id_foreign");
        });

        modelBuilder.Entity<YearJpnMst>(entity =>
        {
            entity.HasKey(e => e.YearCd).HasName("year_jpn_mst_pkey");

            entity.ToTable("year_jpn_mst");

            entity.Property(e => e.YearCd)
                .HasMaxLength(1)
                .HasColumnName("year_cd");
            entity.Property(e => e.AvailFlg).HasColumnName("avail_flg");
            entity.Property(e => e.DeleteFlag).HasColumnName("delete_flag");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.RegistBy).HasColumnName("regist_by");
            entity.Property(e => e.RegistDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("regist_date");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("timestamp(0) without time zone")
                .HasColumnName("update_date");
            entity.Property(e => e.YearName)
                .HasMaxLength(6)
                .HasColumnName("year_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
