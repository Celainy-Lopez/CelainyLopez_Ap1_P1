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
        return await _context.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Cobros cobro)
    {
        _context.Update(cobro);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        var cobro = await _context.Prestamos.FirstOrDefaultAsync(o => o.PrestamoId == id);
        if (cobro != null)
        {
            _context.Prestamos.Remove(cobro);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;

    }

    public async Task<List<Cobros>> Listar(Expression<Func<Cobros, bool>> criterio)
    {
        return await _context.Cobros.AsNoTracking()
            .Include(d => d.Deudor)
            .Include(c => c.Prestamo)
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<Cobros?> Buscar(int id)
    {
        return await _context.Cobros
            .Include(d => d.Deudor)
            .Include(c => c.Prestamo)
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
