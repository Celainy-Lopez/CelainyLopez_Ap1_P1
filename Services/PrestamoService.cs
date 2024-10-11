using CelainyLopez_Ap1_P1.DAL;
using CelainyLopez_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CelainyLopez_Ap1_P1.Services;

public class PrestamoService(Context context)
{
    private readonly Context _context = context;

    private async Task<bool> Existe(int id)
    {
        return await _context.Prestamos.AnyAsync(o => o.PrestamoId == id);
    }

    private async Task<bool> Insertar(Prestamos prestamo)
    {
        _context.Prestamos.Add(prestamo);
        return await _context.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Prestamos prestamo)
    {
        _context.Update(prestamo);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        var prestamo = await _context.Prestamos.FirstOrDefaultAsync(o => o.PrestamoId == id);
        if(prestamo != null)
        {
            _context.Prestamos.Remove(prestamo);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
        
    }

    public async Task<List<Prestamos>> Listar(Expression<Func<Prestamos, bool>> criterio)
    {
        return await _context.Prestamos.AsNoTracking()
            .Include(d => d.Deudor)
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<Prestamos?> Buscar(int id)
    {
        return await _context.Prestamos
            .Include(d => d.Deudor)
            .FirstOrDefaultAsync(o => o.PrestamoId == id);
    }

    public async Task<bool> Guardar(Prestamos prestamo)
    {
        if(!await Existe(prestamo.PrestamoId))
        {
            return await Insertar(prestamo);
        }
        else
        {
            return await Modificar(prestamo);
        }
        
    }
}
