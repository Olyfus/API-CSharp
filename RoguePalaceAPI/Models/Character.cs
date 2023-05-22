using System.ComponentModel.DataAnnotations.Schema;

namespace RoguePalaceAPI.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int GroupeId { get; set; }
        [ForeignKey("GroupeId")]

        public string Pseudo { get; set; }

    }
}
