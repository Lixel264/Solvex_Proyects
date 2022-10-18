using Marvel.Domain.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel.Application.Characters.Interfaces
{
    public interface ICharacterService
    {
        Task<MarvelSearch> GetAllCharacters();
    }
}
