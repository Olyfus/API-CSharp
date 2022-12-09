namespace RoguePalaceAPI.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public List<Character> Compagnon { get; set; }


    }
}
