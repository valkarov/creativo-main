using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreativoApiV2.Model
{
    public class CreativoDB : DbContext
    {
        public CreativoDB(DbContextOptions<CreativoDB> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=PABLOPC\\SQLEXPRESS;Initial Catalog=CreativoDBV2;Integrated Security=True;Encrypt=False");
        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Canton> Cantons { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<WorkshopPhoto> WorkshopPhotos { get; set; }
        public DbSet<WorkshopType> WorkshopTypes { get; set; }
        public DbSet<Entrepeneurship> Entrepeneurships { get; set; }
        public DbSet<EntrepeneurshipSocial> EntrepeneurshipSocials { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<SocialType> SocialTypes { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<ForumComment> ForumComments { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EntrepeneurshipAdmin> EntrepeneurshipAdmins { get; set; }
        public DbSet<WorkShopClient> WorkShopClients { get; set; }

        // Relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<District>()
                .HasOne(d => d.Canton)
                .WithMany(c => c.Districts)
                .HasForeignKey(d => d.CantonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Canton>()
                .HasOne(c => c.Province)
                .WithMany(p => p.Cantons)
                .HasForeignKey(c => c.ProvinceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Workshop>()
                .HasOne(w => w.WorkshopType)
                .WithMany()
                .HasForeignKey(w => w.WorkshopTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Entrepeneurship>()
                .HasOne(e => e.District)
                .WithMany(d => d.Entrepeneurships)
                .HasForeignKey(e => e.DistrictId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EntrepeneurshipSocial>()
                .HasOne(es => es.Entrepeneurship)
                .WithMany(e => e.EntrepeneurshipSocials)
                .HasForeignKey(es => es.EntrepeneurshipId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EntrepeneurshipSocial>()
                .HasOne(es => es.Social)
                .WithMany()
                .HasForeignKey(es => es.SocialId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Social>()
                .HasOne(s => s.SocialType)
                .WithMany()
                .HasForeignKey(s => s.SocialTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ForumComment>()
                .HasOne(fc => fc.Forum)
                .WithMany(f => f.ForumComments)
                .HasForeignKey(fc => fc.ForumId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.District)
                .WithMany(d => d.Orders)
                .HasForeignKey(o => o.DistrictId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Entrepeneurship)
                .WithMany(e => e.Orders)
                .HasForeignKey(o => o.EntrepeneurshipId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Inventory)
                .WithMany()
                .HasForeignKey(op => op.InventoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EntrepeneurshipAdmin>()
                .HasOne(ea => ea.Entrepeneurship)
                .WithMany()
                .HasForeignKey(ea => ea.EntrepeneurshipId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EntrepeneurshipAdmin>()
                .HasOne(ea => ea.User)
                .WithMany()
                .HasForeignKey(ea => ea.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkShopClient>()
                .HasOne(wc => wc.Workshop)
                .WithMany()
                .HasForeignKey(wc => wc.WorkshopId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkShopClient>()
                .HasOne(wc => wc.User)
                .WithMany()
                .HasForeignKey(wc => wc.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Forum>()
                .HasMany(f => f.ForumComments)
                .WithOne(fc => fc.Forum)
                .HasForeignKey(fc => fc.ForumId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SocialType>()
                .HasMany(s => s.socials)
                .WithOne(es => es.SocialType)
                .HasForeignKey(es => es.SocialTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Entrepeneurship>().
                HasMany(e => e.EntrepeneurshipSocials)
                .WithOne(es => es.Entrepeneurship)
                .HasForeignKey(es => es.EntrepeneurshipId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Entrepeneurship>().
                HasMany(e => e.Orders)
                .WithOne(o => o.Entrepeneurship)
                .HasForeignKey(o => o.EntrepeneurshipId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Inventory>().HasMany(i => i.OrderProducts)
                .WithOne(op => op.Inventory)
                .HasForeignKey(op => op.InventoryId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Workshop>().HasMany(w => w.WorkshopPhotos)
                .WithOne(wp => wp.Workshop)
                .HasForeignKey(wp => wp.WorkshopId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkshopType>().HasMany(wt => wt.Workshops)
                .WithOne(w => w.WorkshopType)
                .HasForeignKey(w => w.WorkshopTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    //Question Part
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string Answer { get; set; }
    }

    //Location Part
    public class District
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CantonId { get; set; }
        [ForeignKey("CantonId")]
        public virtual Canton Canton { get; set; }

        public virtual ICollection<Entrepeneurship> Entrepeneurships { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
    public class Canton
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }

        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set; }

        public virtual ICollection<District> Districts { get; set; }
    }
    public class Province
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Canton> Cantons { get; set; }
    }

    //Workshop Part
    public class Workshop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public float Price { get; set; }
        public string Link { get; set; }
        public int EntrepeneurshipId { get; set; }
        [ForeignKey("EntrepeneurshipId")]
        public virtual Entrepeneurship Entrepeneurship { get; set; }
        public int WorkshopTypeId { get; set; }
        [ForeignKey("WorkshopTypeId")]
        public virtual WorkshopType WorkshopType { get; set; }

        public virtual ICollection<WorkshopPhoto> WorkshopPhotos { get; set; }

    }

    public class WorkshopPhoto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Path { get; set; }
        public int WorkshopId { get; set; }

        [ForeignKey("WorkshopId")]
        public virtual Workshop Workshop { get; set; }
    }

    public class WorkshopType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Workshop> Workshops { get; set; }
    }

    //Entrepeneurship Part
    public class Entrepeneurship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public int state { get; set; }
        public string Reason { get; set; }
        public string Sinpe { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int DistrictId { get; set; }

        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }
        
        public int EntrepeneurshipTypeId { get; set; }
        [ForeignKey("EntrepeneurshipTypeId")]
        public virtual EntrepeneurshipType EntrepeneurshipType { get; set; }

        public virtual ICollection<EntrepeneurshipSocial> EntrepeneurshipSocials { get; set; }

        public virtual ICollection<Order> Orders { get; set; }


    }

    public class EntrepeneurshipType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class EntrepeneurshipSocial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int EntrepeneurshipId { get; set; }
        [ForeignKey("EntrepeneurshipId")]
        public virtual Entrepeneurship Entrepeneurship { get; set; }
        public int SocialId { get; set; }

        [ForeignKey("SocialId")]
        public virtual Social Social { get; set; }
    }

        //Social Part
        public class Social
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }

        public int SocialTypeId { get; set; }

        [ForeignKey("SocialTypeId")]
        public virtual SocialType SocialType { get; set; }
    }
    public class SocialType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Social> socials { get; set; }
    }


    //Forum Part
    public class Forum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public virtual ICollection<ForumComment> ForumComments { get; set; }
    }

    public class ForumComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public int ForumId { get; set; }

        [ForeignKey("ForumId")]
        public virtual Forum Forum { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }
    }


    //Inventory Part

    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }

    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public int State { get; set; }
        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }

        public int DeliveryManId { get; set; }
        [ForeignKey("DeliveryManId")]
        public virtual User DeliveryMan { get; set; }
        public int EntrepeneurshipId { get; set; }
        
        public DateTime Date { get; set; }

        public DateTime DeliveryDate { get; set; }

        [ForeignKey("EntrepeneurshipId")]
        public virtual Entrepeneurship Entrepeneurship { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
    public class OrderProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }



    }

    //user Part
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Cedula { get; set; }
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        public virtual List<UserRoles> Roles { get; set; }

    }

    public class UserRoles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }

    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class EntrepeneurshipAdmin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EntrepeneurshipId { get; set; }
        public virtual Entrepeneurship Entrepeneurship { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
    public class WorkShopClient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string State { get; set; }
        public string lastDigits { get; set; }
        public float price { get; set; }
        public int WorkshopId { get; set; }
        [ForeignKey("WorkshopId")]
        public virtual Workshop Workshop { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
