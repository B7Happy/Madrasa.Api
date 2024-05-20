using Madrasa.Api.Dtos.Parent;
using Madrasa.Api.Interfaces;
using Madrasa.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Madrasa.Api.Repository
{
    public class ParentRepository : IParentRepository
    {
        private readonly MadrasaDb _context;

        public ParentRepository(MadrasaDb context)
        {
            _context = context;
        }

        public async Task<Parent> CreateAsync(Parent parent)
        {
            await _context.Parent.AddAsync(parent);
            await _context.SaveChangesAsync();
            return parent;
        }

        public async Task<Parent> UpdateAsync(int id, UpdateParentRequestDto parent)
        {
            var existingParent = await _context.Parent.FirstOrDefaultAsync(x => x.Id == id);

            if (existingParent == null)
            {
                throw new Exception("Parent not found");
            }

            existingParent.Prenom = parent.Prenom;
            existingParent.Nom = parent.Nom;
            existingParent.Email = parent.Email;
            existingParent.TelMobile = parent.TelMobile;


            await _context.SaveChangesAsync();
            return existingParent;
        }
    }
}
