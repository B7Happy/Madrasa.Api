using Madrasa.Api.Dtos.Maison;
using Madrasa.Api.Interfaces;
using Madrasa.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Madrasa.Api.Repository
{
    public class MaisonRepository : IMaisonRepository
    {
        private readonly MadrasaDb _context;
        public MaisonRepository(MadrasaDb context)
        {
            _context = context;
        }

        public async Task<Maison> CreateAsync(Maison maison)
        {
            await _context.Maison.AddAsync(maison);
            await _context.SaveChangesAsync();
            return maison;
        }

        public async Task<Maison> DeleteAsync(int id)
        {
            var maison = await _context.Maison.FirstOrDefaultAsync(x => x.Id == id);

            if (maison == null)
            {
                throw new Exception("Maison not found");
            }

            _context.Maison.Remove(maison);
            await _context.SaveChangesAsync();
            return maison;
        }

        public async Task<IEnumerable<Maison>> GetAllAsync()
        {
            return await _context.Maison.ToListAsync();
        }

        public async Task<Maison?> GetByIdAsync(int id)
        {
            return await _context.Maison.FindAsync(id);
        }

        public async Task<Maison> UpdateAsync(int id, UpdateMaisonRequestDto maison)
        {
            var existingMaison = await _context.Maison.FirstOrDefaultAsync(x => x.Id == id);

            if (existingMaison == null)
            {
                throw new Exception("Maison not found");
            }

            existingMaison.Adresse = maison.Adresse;
            existingMaison.Complement = maison.Complement;
            existingMaison.CodePostal = maison.CodePostal;
            existingMaison.Ville = maison.Ville;
            existingMaison.TelDomicile = maison.TelDomicile;
            existingMaison.Adherent = maison.Adherent;
            existingMaison.Categorie = maison.Categorie;

            await _context.SaveChangesAsync();
            return existingMaison;
        }

    }
}
