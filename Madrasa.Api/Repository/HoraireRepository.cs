using Madrasa.Api.Interfaces;
using Madrasa.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Madrasa.Api.Repository
{
    public class HoraireRepository : IHoraireRepository
    {
private readonly MadrasaDb _context;
        public HoraireRepository(MadrasaDb context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Horaire>> GetAllAsync()
        {
            return await _context.Horaire.ToListAsync();
        }

        public async Task<Horaire> CreateAsync(Horaire horaire)
        {
            _context.Horaire.Add(horaire);
            await _context.SaveChangesAsync();
            return horaire;
        }

        public async Task<Horaire> UpdateAsync(int id, Horaire horaire)
        {
            var horaireToUpdate = await _context.Horaire.FindAsync(id);

            if (horaireToUpdate == null)
            {
                return null;
            }

            horaireToUpdate.NumJour = horaire.NumJour;
            horaireToUpdate.Jour = horaire.Jour;
            horaireToUpdate.HDeb = horaire.HDeb;
            horaireToUpdate.HFin = horaire.HFin;
            horaireToUpdate.GroupeId = horaire.GroupeId;
            horaireToUpdate.Duree = horaire.Duree;

            await _context.SaveChangesAsync();
            return horaireToUpdate;
        }

        public async Task<Horaire> GetByIdAsync(int id)
        {
            return await _context.Horaire.FindAsync(id);
        }
    }
}
