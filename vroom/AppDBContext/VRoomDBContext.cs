using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vroom.Models;

namespace vroom.AppDBContext
{
    public class VRoomDBContext:DbContext
    {
        public VRoomDBContext(DbContextOptions<VRoomDBContext> options) :
            base(options)
        {

        }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
    }
}
