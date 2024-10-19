using CelainyLopez_Ap1_P1.DAL;
using CelainyLopez_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CelainyLopez_Ap1_P1.Services;

public class DeudorService(Context context)
{
    private readonly Context _context = context;

    public async Task<List<Deudores>> Listar(Expression<Func<Deudores, bool>> criterio)
    {
        return await _context.Deudores.AsNoTracking()
            .Where(criterio) 
            .ToListAsync();
    }
}
