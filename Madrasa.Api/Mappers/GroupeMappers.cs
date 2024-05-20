using Madrasa.Api.Dtos.Groupe;
using Madrasa.Api.Model;

namespace Madrasa.Api.Mappers
{
    public static class GroupeMappers
    {
        //public static GroupeDto ToGroupeDto(this Groupe groupe)
        //{
        //    return new GroupeDto
        //    {
        //        Id = groupe.Id,
        //        Nom = groupe.Nom
        //    };
        //}

        public static Groupe ToGroupeFromCreateGroupeDto(this CreateGroupeDto createGroupeDto)
        {
            return new Groupe
            {
                Nom = createGroupeDto.Nom
            };
        }
    }
}
