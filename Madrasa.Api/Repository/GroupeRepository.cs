using Madrasa.Api.Dtos.Groupe;
using Madrasa.Api.Interfaces;
using Madrasa.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Madrasa.Api.Repository
{
    public class GroupeRepository : IGroupeRepository
    {
        private readonly MadrasaDb _context;
        public GroupeRepository(MadrasaDb context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Groupe>> GetAllAsync()
        {
            return await _context.Groupe.ToListAsync();
        }

        public async Task<Groupe> CreateAsync(Groupe groupe)
        {
            await _context.Groupe.AddAsync(groupe);
            await _context.SaveChangesAsync();
            return groupe;
        }

        public async Task<Groupe> UpdateAsync(int id, UpdateGroupe groupe)
        {
            var groupeToUpdate = await _context.Groupe.FindAsync(id);
            
            if (groupeToUpdate == null)
            {
                throw new Exception("Groupe not found");
            }

            groupeToUpdate.Nom = groupe.Nom;

            await _context.SaveChangesAsync();
            return groupeToUpdate;
        }

        public async Task<Groupe> DeleteAsync(int id)
        {
            var groupeToDelete = await _context.Groupe.FindAsync(id);
            
            if (groupeToDelete == null)
            {
                throw new Exception("Groupe not found");
            }

            _context.Groupe.Remove(groupeToDelete);
            await _context.SaveChangesAsync();
            return groupeToDelete;
        }
    }
}
