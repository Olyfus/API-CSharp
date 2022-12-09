using AutoMapper;
using RoguePalaceAPI.Dto.Character;
using RoguePalaceAPI.Repositories;

namespace RoguePalaceAPI.Profiles
{
    public class CharacterProfiles : Profile
    {
        public CharacterProfiles()
        {
            CreateMap<CreateCharacterDto, CharacterRepositories>;
        }
    }
}
