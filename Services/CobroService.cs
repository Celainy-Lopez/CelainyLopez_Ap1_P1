using CelainyLopez_Ap1_P1.DAL;
using CelainyLopez_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CelainyLopez_Ap1_P1.Services;

public class CobroService(Context context)
{
	private readonly Context _context = context;

	private async Task<bool> Existe(int id)
	{
		return await _context.Cobros.AnyAsync(o => o.CobroId == id);
	}

	private async Task<bool> Insertar(Cobros cobro)
	{
		_context.Cobros.Add(cobro);
		await AfectarPrestamo(cobro.CobrosDetalle.ToArray());
		return await _context.SaveChangesAsync() > 0;
	}

	private async Task AfectarPrestamo(CobrosDetalle[] detalle, bool resta = true)
	{
		foreach (var item in detalle)
		{
			var prestamo = await _context.Prestamos.SingleAsync(p => p.PrestamoId == item.PrestamoId);
			if (resta)
			{
				prestamo.Balance -= item.ValorCobrado;
			}
			else
			{
				prestamo.Balance += item.ValorCobrado;
			}
		}
	}


	private async Task<bool> Modificar(Cobros cobro)
	{
        await AfectarPrestamo(cobro.CobrosDetalle.ToArray());
        _context.Update(cobro);
		return await _context.SaveChangesAsync() > 0;
	}

	public async Task<bool> Eliminar(int cobroId)
	{
		var cobro = _context.Cobros.Find(cobroId);

		await AfectarPrestamo(cobro.CobrosDetalle.ToArray(), false);

		_context.CobrosDetalle.RemoveRange(cobro.CobrosDetalle);
		_context.Cobros.Remove(cobro);

		var cantidad = await _context.SaveChangesAsync();
		return cantidad > 0;
	}

	public async Task<List<Cobros>> Listar(Expression<Func<Cobros, bool>> criterio)
	{
		return await _context.Cobros.AsNoTracking()
			.Include(d => d.Deudor)
			.Include(c => c.CobrosDetalle)
			.Where(criterio)
			.ToListAsync();
	}

	public async Task<Cobros?> Buscar(int id)
	{
		return await _context.Cobros
			.Include(d => d.Deudor)
			.Include(c => c.CobrosDetalle)
			.FirstOrDefaultAsync(o => o.CobroId == id);
	}

	public async Task<bool> Guardar(Cobros cobro)
	{
		if (!await Existe(cobro.CobroId))
		{
			return await Insertar(cobro);
		}
		else
		{
			return await Modificar(cobro);
		}

	}
}