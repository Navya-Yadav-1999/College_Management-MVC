using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeManagement.Models.DataModel;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.DataBase
{
    public class CollegeManagementContext:DbContext
    {

        public CollegeManagementContext(DbContextOptions<CollegeManagementContext> options)
            : base(options)
        {

        }

        public DbSet<Student> Student { get; set; }

        public DbSet<User> users { get; set; }

        public DbSet<Teacher> Teacher { get; set; }
    }
}
