using Madrasa.Api.Dtos.Classes;
using Madrasa.Api.Interfaces;
using Madrasa.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Madrasa.Api.Repository
{
    public class ClassesRepository : IClassesRepository
    {
        private readonly MadrasaDb _context;

        public ClassesRepository(MadrasaDb context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Classes>> GetAllAsync()
        {
            return await _context.Classes.Include(x => x.Professeurs).ToListAsync();
        }

        public async Task<Classes?> GetByIdAsync(int id)
        {
            return await _context.Classes.FindAsync(id);
        }

        public async Task<Classes> CreateAsync(Classes classe)
        {
            _context.Classes.Add(classe);
            await _context.SaveChangesAsync();
            return classe;
        }

        public async Task<Classes> UpdateAsync(int id, UpdateClassesRequestDto classe)
        {
            var classeToUpdate = await _context.Classes.FindAsync(id);
            if (classeToUpdate == null)
            {
                throw new Exception("Classe not found");
            }

            classeToUpdate.Classe = classe.Classe;
            classeToUpdate.ProfesseursId = classe.ProfesseursId;
            classeToUpdate.GroupeId = classe.GroupeId;

            await _context.SaveChangesAsync();
            return classeToUpdate;
        }

        public async Task<Classes> DeleteAsync(int id)
        {
            var classeToDelete = await _context.Classes.FindAsync(id);
            if (classeToDelete == null)
            {
                throw new Exception("Classe not found");
            }

            _context.Classes.Remove(classeToDelete);
            await _context.SaveChangesAsync();
            return classeToDelete;
        }
    }
}
