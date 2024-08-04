
using Caraspirator.Data.Entities.Identity;
using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Caraspirator.Infrustructure.Data;
                                                       //IdentityRole<int>
public class AppDbContext : IdentityDbContext<EspkUser, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    private readonly IEncryptionProvider _encryptionProvider;
    public AppDbContext() 
    {

    }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        _encryptionProvider = new GenerateEncryptionProvider("8a4dcaaec64d412380fe4b02193cd26f");
    }

    public DbSet<EspkUser> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Part> Parts { get; set; }

    public DbSet<Car> Cars { get; set; }

    public DbSet<UserRefreshToken> UserRefreshToken { get; set; }






    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarPart>(entity => {
            entity.HasKey(cp => new { cp.CarID, cp.PartID });
            entity.HasOne(c=>c.Car)
            .WithMany(cp=>cp.CarPart)
            .HasForeignKey(fk=>fk.CarID)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(p => p.Part)
           .WithMany(cp => cp.CarPart)
           .HasForeignKey(fk => fk.PartID)
           .IsRequired()
           .OnDelete(DeleteBehavior.NoAction);

           base.OnModelCreating(modelBuilder);
            modelBuilder.UseEncryption(_encryptionProvider);
        });
      //  modelBuilder.Entity<Part>().Navigation(pt => pt.PartTrans).AutoInclude();
        //modelBuilder.Entity<Part>().HasMany(x => x.parttrans).WithOne().HasForeignKey(f => f.partid);

        //modelBuilder.Entity<Car>().HasMany(x => x.parts).WithMany(y => y.cars).UsingEntity<CarPart>(
        //     j => j.HasOne<Part>().WithMany(p => p.car_part).HasForeignKey(cp => cp.part_id),
        //     r => r.HasOne<Car>().WithMany(c => c.car_part).HasForeignKey(cp => cp.car_id),
        //     l => { l.HasKey(cp => new { cp.part_id, cp.car_id }); }
        //     );
        //modelBuilder.Entity<Car>().HasMany(x => x.parts).WithMany(y => y.cars).UsingEntity<CarPart>(
        //    j => j.HasOne<Part>().WithMany(p => p.car_part).HasForeignKey(cp => cp.part_id),
        //    r => r.HasOne(cp => cp.car).WithMany(c => c.car_part).HasForeignKey(cp => cp.car_id),
        //    l => { l.HasKey(cp => new { cp.part_id, cp.car_id }); }
        //    );
        //   modelBuilder.Entity<Part>().HasMany(x => x.parttrans).WithOne(y => y.part).HasForeignKey(k=>k.part_id);
        //modelBuilder.Entity<Part>()
        //.HasMany(e => e.Tags)
        //.WithMany(e => e.posts)
        //.UsingEntity<Car_Part>(
        //    l => l.HasOne<Part>().WithMany().HasForeignKey(e => e.TagId),
        //    r => r.HasOne<Post>().WithMany().HasForeignKey(e => e.PostId));

        //  modelBuilder.Entity<Blog>().HasOne(x=>x.blogimage).WithOne(y=>y.blog).HasForeignKey<BlogImage>(f=>f.blogforginkey);
        //  modelBuilder.Entity<Post>().HasOne(x => x.blog).WithMany(x => x.posts).HasForeignKey(x => x.bloginid).HasPrincipalKey(x => x.newid);// determine other blog column to be PrincipalKey
        //modelBuilder.Entity<Post>().HasOne(x => x.blog).WithMany(x => x.posts).HasForeignKey(s => new {s.bloginid1,s.bloginid2}).HasPrincipalKey(x=> new {x.newid1,x.newid2});// determine two colum in blog  to be compositekey

        //  modelBuilder.Entity<Blog>().HasMany<Post>().WithOne(x=>x.blog);//define relation when now nav prop in Blog table
        //modelBuilder.Entity<Blog>().HasMany(x => x.posts).WithOne();//same result
        //modelBuilder.Entity<Post>().HasOne(x => x.blog).WithMany(y => y.posts);//same result     
        //modelBuilder.Entity<User>().Property(p => p.DateRegistered).HasDefaultValueSql("GETDATE()");
        //modelBuilder.Entity<Car>()
        //  .HasMany(e => e.cars_parts)
        //  .WithMany(e => e.Posts)
        //  .UsingEntity<PostTag>(
        //      l => l.HasOne(t=>t.Tags).WithMany(t=>t.PostTags).HasForeignKey(e => e.TagId),
        //      r => r.HasOne(p=>p.Posts).WithMany(p =>p.PostTag).HasForeignKey(e => e.PostId), j => 
        //      {
        //      j.HasKey(e => new { e.PostId , e.TagId });
        //      }            
        //      );



        modelBuilder.Entity<Category>().HasData(
         new Category() { CategoryID=  1,   ParentID = 0, CategoryName = "Oil And Lubs", CategoryImage = "http://admin.queensudan.com//images//queenimage/categoryicon/Tshirtrealicon.png", Slug = "T-Shirt", IsActive = true, CreatedAt = DateTime.Now }
       , new Category() { CategoryID = 2, ParentID = 0, CategoryName = "Battary", CategoryImage = "http://admin.queensudan.com//images//queenimage/categoryicon/Dreesrealicon.png", Slug = "Dresses", IsActive = true, CreatedAt = DateTime.Now }
       , new Category() { CategoryID = 3, ParentID = 0, CategoryName = "Tools", CategoryImage = "http://admin.queensudan.com//images//queenimage/categoryicon/blouserealicon.png", Slug = "Blouses", IsActive = true, CreatedAt = DateTime.Now }
       , new Category() { CategoryID = 4, ParentID = 0, CategoryName = "Accessories", CategoryImage = "http://admin.queensudan.com//images//queenimage/categoryicon/blouserealicon.png", Slug = "Bottoms", IsActive = true, CreatedAt = DateTime.Now }
       , new Category() { CategoryID = 5, ParentID = 0, CategoryName = "Wheel And Tires", CategoryImage = "http://admin.queensudan.com//images//queenimage/categoryicon/Beauty.png", Slug = "Beauty", IsActive = true, CreatedAt = DateTime.Now }
       );



        //    modelBuilder.Entity<espk_language>().HasData(
        //  new espk_language() { langua_name = "Englis", langua_code = "en" }
        //  , new espk_language() { langua_name = "Arabic", langua_code = "Ar" }
        //);

    }


}
