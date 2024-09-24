using CelainyLopez_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace CelainyLopez_Ap1_P1.DAL;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
	public DbSet<Registros>	Registros { get; set; }
}
