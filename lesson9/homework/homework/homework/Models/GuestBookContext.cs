﻿using Microsoft.EntityFrameworkCore;

namespace homework.Models {
    public class GuestBookContext : DbContext {
        public DbSet<Users> Users { get; set; }
        public DbSet<Messages> Messages { get; set; }

        public GuestBookContext(DbContextOptions<GuestBookContext> options) : base(options) {
            if (Database.EnsureCreated()) {
                SaveChanges();
            }
        }
    }
}
