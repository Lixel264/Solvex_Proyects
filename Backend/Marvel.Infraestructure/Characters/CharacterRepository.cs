using Marvel.Application.Characters.Interfaces;
using Marvel.Domain.Characters;
using Marvel.Infraestructure.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel.Infraestructure.Characters
{
    public class CharacterRepository : ICharacterRepository
    {

        private readonly IMarvelRestClient<MarvelSearch> _marvelRestClient;
        public CharacterRepository(IMarvelRestClient<MarvelSearch> marvelRestClient)
        {
            _marvelRestClient = marvelRestClient;
        }
        public async Task<MarvelSearch> GetAllCharacters()
        {
            return await _marvelRestClient.GetAllAsync("characters");
            
        }
    }
}
