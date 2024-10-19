﻿using CelainyLopez_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace CelainyLopez_Ap1_P1.DAL;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
	public DbSet<Prestamos>	Prestamos { get; set; }
	public DbSet<Deudores> Deudores { get; set; }

    public DbSet<Cobros> Cobros { get; set; }

	public DbSet<CobrosDetalle> CobrosDetalle { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<Deudores> ().HasData(new List<Deudores>()
		{ 
			new Deudores() { DeudorId = 1, Nombres = "Juan Perez"  },
			new Deudores() { DeudorId = 2 , Nombres = "Jerony Ulises"},
			new Deudores() {DeudorId = 3 , Nombres = "Wilmer Castillo" }
		});

	}

}
