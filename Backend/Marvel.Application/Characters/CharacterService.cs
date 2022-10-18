using Marvel.Application.Characters.Interfaces;
using Marvel.Domain.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel.Application.Characters
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }
        public async Task<MarvelSearch> GetAllCharacters()
        {
            var characters = await _characterRepository.GetAllCharacters();

            return characters;
        }
    }
}
