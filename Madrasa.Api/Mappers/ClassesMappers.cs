using Madrasa.Api.Dtos.Classes;
using Madrasa.Api.Model;

namespace Madrasa.Api.Mappers
{
    public static class ClassesMappers
    {
        public static ClassesDto ToClassesDto(this Classes classes)
        {
            return new ClassesDto
            {
                Id = classes.Id,
                Classe = classes.Classe,
                ProfesseursId = classes.ProfesseursId,
                GroupeId = classes.GroupeId
            };
        }

        public static Classes ToClassesFromCreateClassesDto(this CreateClassesRequestDto createClassesRequest)
        {
            return new Classes
            {
                Classe = createClassesRequest.Classe,
                ProfesseursId = createClassesRequest.ProfesseursId,
                GroupeId = createClassesRequest.GroupeId
            };
        }

        public static Classes UpdateClasseRequestDto(this UpdateClassesRequestDto updateClasssesRequest)
        {
            return new Classes
            {
                Classe = updateClasssesRequest.Classe,
                ProfesseursId = updateClasssesRequest.ProfesseursId,
                GroupeId = updateClasssesRequest.GroupeId
            };
        }

        public static Classes ToClassesFromCreateDTO(this CreateClassesRequestDto createClassesRequest)
        {
            return new Classes
            {
                Classe = createClassesRequest.Classe,
                ProfesseursId = createClassesRequest.ProfesseursId,
                GroupeId = createClassesRequest.GroupeId
            };
        }

        public static Classes ToElevesClasses(this Classes Classes)
        {
            return new Classes
            {
                Classe = Classes.Classe
            };
        }
    }
}
