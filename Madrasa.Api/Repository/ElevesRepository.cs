using Madrasa.Api.Dtos.Eleves;
using Madrasa.Api.Interfaces;
using Madrasa.Api.Mappers;
using Madrasa.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Madrasa.Api.Repository
{
    public class ElevesRepository : IElevesRepository
    {
        private readonly MadrasaDb _context;
        public ElevesRepository(MadrasaDb context) {
            _context = context;
        }

        public async Task<Eleves> CreateAsync(Eleves eleve)
        {
            await _context.Eleves.AddAsync(eleve);
            await _context.SaveChangesAsync();
            return eleve;
        }

        public async Task<Eleves> DeleteAsync(int id)
        {
            var eleve = await _context.Eleves.FirstOrDefaultAsync(x => x.Id == id);

            if (eleve == null)
            {
                throw new Exception("Eleve not found");
            }

            _context.Eleves.Remove(eleve);
            await _context.SaveChangesAsync();
            return eleve;
        }

        public async Task<IEnumerable<Eleves>> GetAllAsync()
        {
            return await _context.Eleves.Include(c => c.Maison).ToListAsync();
        }

        public async Task<IEnumerable<Eleves>> GetAllEleveInClasseAsync()
        {
            return await _context.Eleves.Where(c => c.ClassesId != null).Include(c => c.Maison).Include(c => c.Classes).ToListAsync();
        }

        public async Task<Eleves?> GetByIdAsync(int id)
        {
            return await _context.Eleves.Include(c => c.Maison).Include(c => c.Maison.Parent).FirstOrDefaultAsync(x => x.Id == id);
        }



        public async Task<Eleves> UpdateAsync(int id, UpdateEleveRequestDto eleve)
        {
            var existingEleve = await _context.Eleves.FirstOrDefaultAsync(x => x.Id == id);

            if (existingEleve == null)
            {
                throw new Exception("Eleve not found");
            }

            existingEleve.Suspendu = eleve.Suspendu;
            existingEleve.Email = eleve.Email;
            existingEleve.Nom = eleve.Nom;
            existingEleve.Prenom = eleve.Prenom;
            existingEleve.Sexe = eleve.Sexe;
            existingEleve.DateNaissance = eleve.DateNaissance;
            existingEleve.LieuNaissance = eleve.LieuNaissance;
            existingEleve.TelMobile = eleve.TelMobile;
            existingEleve.ClassesId = eleve.ClassesId;
            existingEleve.MaisonId = eleve.MaisonId;
            existingEleve.DateEntree = eleve.DateEntree;

            await _context.SaveChangesAsync();

            return existingEleve;
        }
    }
}
