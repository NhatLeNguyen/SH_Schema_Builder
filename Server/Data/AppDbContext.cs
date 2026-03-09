using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data;

public partial class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Tier> Tiers { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<SchemaAttribute> Attributes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Cấu hình relationship
        builder.Entity<Group>()
            .HasOne(g => g.Tier)
            .WithMany(t => t.Groups)
            .HasForeignKey(g => g.TierId);

        builder.Entity<SchemaAttribute>()
            .HasOne(a => a.Group)
            .WithMany(g => g.Attributes)
            .HasForeignKey(a => a.GroupId);
            
        builder.Entity<Group>()
            .HasOne(g => g.ParentGroup)
            .WithMany(g => g.SubGroups)
            .HasForeignKey(g => g.ParentGroupId)
            .OnDelete(DeleteBehavior.Restrict);
            
        // Seed 5 tầng
        builder.Entity<Tier>().HasData(
            new Tier { Id = 1, Name = "Định danh cá nhân", Nature = "Cố định", Color = "#2196F3", Description = "Thông tin không thay đổi (Họ tên, ngày sinh, giới tính...)" },
            new Tier { Id = 2, Name = "Pháp lý", Nature = "Ít thay đổi", Color = "#4CAF50", Description = "Thông tin pháp lý (CMND/CCCD, hộ chiếu...)" },
            new Tier { Id = 3, Name = "BHYT & Quyền lợi", Nature = "Thay đổi định kỳ", Color = "#9C27B0", Description = "Thông tin bảo hiểm, thẻ ưu đãi..." },
            new Tier { Id = 4, Name = "Di truyền", Nature = "Bất biến", Color = "#FF9800", Description = "\"Đặc điểm gốc?\" — Bất biến" },
            new Tier { Id = 5, Name = "Sinh học biến động", Nature = "Biến động liên tục", Color = "#F44336", Description = "\"Hiện trạng?\" — Biến động liên tục" }
        );

        // Gọi các file seed part partial class
        SeedTier1to3.Seed(builder);
        SeedTier4.Seed(builder);
        SeedTier5.Seed(builder);
    }
}
