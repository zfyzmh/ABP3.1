using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyProject.Authorization.Roles;
using MyProject.Authorization.Users;
using MyProject.MultiTenancy;
using MyProject.EntityFrameworkCore.Models;

namespace MyProject.EntityFrameworkCore
{
    public class MyProjectDbContext : AbpZeroDbContext<Tenant, Role, User, MyProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Test> Test { get; set; }
        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options)
            : base(options)
        {
        }
    }
}
