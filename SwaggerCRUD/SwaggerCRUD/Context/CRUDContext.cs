using Microsoft.EntityFrameworkCore;
using SwaggerCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerCRUD.Context
{
    public class CRUDContext:DbContext
    {
        public CRUDContext(DbContextOptions<CRUDContext>options) :base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
