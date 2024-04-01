namespace Madrasa.Api.Model
{
    public class Groupe
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<Classes> Classes { get; set; }

    }

    enum Group : int
    {
        GRP1 = 1,
        GRP2 = 2,
        GRP3 = 3
    }
}
