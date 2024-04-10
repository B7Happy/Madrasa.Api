﻿using Madrasa.Api.Dtos.Eleves;
using Madrasa.Api.Model;

namespace Madrasa.Api.Interfaces
{
    public interface IElevesRepository
    {
        Task<IEnumerable<Eleves>> GetAllAsync();
        Task<IEnumerable<Eleves>> GetAllEleveInClasseAsync();
        Task<Eleves?> GetByIdAsync(int id);
        Task<Eleves> CreateAsync(Eleves eleve);
        Task<Eleves> UpdateAsync(int id, UpdateEleveRequestDto eleve);
        Task<Eleves> DeleteAsync(int id);
    }
}
