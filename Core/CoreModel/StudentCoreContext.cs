using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CoreModel
{
    public class StudentCoreContext : DbContext
    {
        public StudentCoreContext() { }
        public StudentCoreContext(DbContextOptions<StudentCoreContext> options) : base(options) { }
        public DbSet<StudentCoreModel> StudentRecord { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=Aniket\\SQLEXPRESS;database=dbStudent1;integrated security=true;TrustServerCertificate=True");
            }

        }

    }
}
