using Madrasa.Api.Dtos.Professeurs;
using Madrasa.Api.Interfaces;
using Madrasa.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Madrasa.Api.Repository
{
    public class ProfesseursRepository : IProfesseursRepository
    {
        private readonly MadrasaDb _context;

        public ProfesseursRepository(MadrasaDb context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Professeurs>> GetAllAsync()
        {
            return await _context.Professeurs.ToListAsync();
        }

        public async Task<Professeurs?> GetByIdAsync(int id)
        {
            return await _context.Professeurs.FindAsync(id);
        }

        public async Task<Professeurs> CreateAsync(Professeurs professeurs)
        {
            _context.Professeurs.Add(professeurs);
            await _context.SaveChangesAsync();
            return professeurs;
        }

        public async Task<Professeurs> UpdateAsync(int id, UpdateProfesseursRequestDto professeurs)
        {
            var professeursToUpdate = await _context.Professeurs.FindAsync(id);
            if (professeursToUpdate == null)
            {
                throw new Exception("Professeurs not found");
            }

            
            professeursToUpdate.Nom = professeurs.Nom;
            professeursToUpdate.Email = professeurs.Email;
            professeursToUpdate.TelMobile = professeurs.TelMobile;

            await _context.SaveChangesAsync();
            return professeursToUpdate;
        }

        public async Task<Professeurs> DeleteAsync(int id)
        {
            var professeursToDelete = await _context.Professeurs.FindAsync(id);
            if (professeursToDelete == null)
            {
                throw new Exception("Professeurs not found");
            }

            _context.Professeurs.Remove(professeursToDelete);
            await _context.SaveChangesAsync();
            return professeursToDelete;
        }

    }
}
