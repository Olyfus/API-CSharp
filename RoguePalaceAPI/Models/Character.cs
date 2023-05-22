using System.ComponentModel.DataAnnotations.Schema;

namespace RoguePalaceAPI.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int GroupeId { get; set; }
        [ForeignKey("GroupeId")]
        public string Race { get; set; }
        public string Class { get; set; }

    }
}
