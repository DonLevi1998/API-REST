using System;
using apirest.Controllers;
using apirest.Data;
using apirest.Models;
using Microsoft.EntityFrameworkCore;

namespace apirest.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Hello> Hello { get; set; }
}
