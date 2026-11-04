using ECommerceProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Data;

public class BookstoreDbContext : IdentityDbContext<ApplicationUser>
{
    public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Category>()
            .HasIndex(category => category.Name)
            .IsUnique();

        builder.Entity<Book>()
            .HasOne(book => book.Category)
            .WithMany(category => category.Books)
            .HasForeignKey(book => book.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Phiêu lưu", Description = "Những hành trình và cuộc khám phá." },
            new Category { Id = 2, Name = "Hài hước", Description = "Truyện nhẹ nhàng, vui nhộn." },
            new Category { Id = 3, Name = "Trinh thám", Description = "Những vụ án và bí ẩn cần lời giải." },
            new Category { Id = 4, Name = "Giả tưởng", Description = "Thế giới kỳ ảo và phép màu." }
        );

        builder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Hành trình đảo xa", Author = "Nguyễn Minh An", Description = "Một chuyến phiêu lưu bắt đầu từ bến cảng nhỏ, nơi tình bạn và lòng can đảm được thử thách.", Price = 45000m, Stock = 18, IsFeatured = true, CategoryId = 1 },
            new Book { Id = 2, Title = "Ngày nghỉ bất ngờ", Author = "Trần Thu Hà", Description = "Những câu chuyện ngắn vui vẻ về một gia đình luôn gặp các tình huống dở khóc dở cười.", Price = 38000m, Stock = 12, IsFeatured = true, CategoryId = 2 },
            new Book { Id = 3, Title = "Bí mật căn phòng số 7", Author = "Lê Hoàng Nam", Description = "Một manh mối tưởng như bình thường mở ra vụ mất tích bí ẩn trong khu phố cũ.", Price = 52000m, Stock = 9, IsFeatured = true, CategoryId = 3 },
            new Book { Id = 4, Title = "Khu rừng ánh trăng", Author = "Phạm Ngọc Mai", Description = "Cánh cửa dẫn đến khu rừng kỳ lạ chỉ xuất hiện vào những đêm trăng sáng.", Price = 49000m, Stock = 15, IsFeatured = true, CategoryId = 4 },
            new Book { Id = 5, Title = "Con thuyền giấy", Author = "Đỗ Hải Yến", Description = "Hai người bạn cùng đi tìm nguồn của dòng sông bí ẩn chảy qua làng.", Price = 42000m, Stock = 7, IsFeatured = false, CategoryId = 1 },
            new Book { Id = 6, Title = "Tiệm bánh của chú mèo", Author = "Vũ Thanh Bình", Description = "Một tiệm bánh nhỏ mang đến nhiều cuộc gặp gỡ dễ thương và tiếng cười.", Price = 35000m, Stock = 0, IsFeatured = false, CategoryId = 2 },
            new Book { Id = 7, Title = "Bức thư không người gửi", Author = "Hoàng Bảo Châu", Description = "Một lá thư cũ khiến cô phóng viên lần theo dấu vết của câu chuyện đã bị lãng quên.", Price = 56000m, Stock = 6, IsFeatured = false, CategoryId = 3 },
            new Book { Id = 8, Title = "Thành phố trên mây", Author = "Nguyễn Gia Huy", Description = "Một cậu bé tìm thấy con đường đến thành phố trôi giữa những tầng mây.", Price = 47000m, Stock = 11, IsFeatured = false, CategoryId = 4 }
        );
    }
}
