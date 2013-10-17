using Microsoft.AspNet.Identity.EntityFramework;

namespace MvcCategorySubcategoryOneDDL.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {  
    }

    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public System.Data.Entity.DbSet<MvcCategorySubcategoryOneDDL.Models.State> States { get; set; }

        public System.Data.Entity.DbSet<MvcCategorySubcategoryOneDDL.Models.District> Districts { get; set; }
    }
}