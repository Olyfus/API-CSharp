namespace RoguePalaceAPI.Dto.Character
{
    public class CreateCharacterDto
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public int GroupeId { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
    }
}
