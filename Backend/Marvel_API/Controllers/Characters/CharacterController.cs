using Marvel.Application.Characters.Interfaces;
using Marvel.Domain.Characters;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Marvel_API.Controllers.Characters
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public ActionResult<List<MarvelSearch>> Get()
        {

            try
            {
                var charactersFromService = _characterService.GetAllCharacters();
                return Ok(charactersFromService);

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


    }
}
