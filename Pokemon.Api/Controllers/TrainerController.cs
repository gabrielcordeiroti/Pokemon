using Microsoft.AspNetCore.Mvc;
using Pokemon.Application.Interfaces;
using Pokemon.Application.Validations;
using Pokemon.Domain.Entities;

namespace Pokemon.Api.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpPost("api/poketrainer")]
        public async Task<IActionResult> AddTrainer([FromBody]PokeTrainer trainerInput)
        {
            try
            {
                var validador = new PokeTrainerValidator();
                var y = validador.Validate(trainerInput);
                if (y.IsValid)
                {
                    var newTrainerId = await _trainerService.AddTrainerAsync(trainerInput);

                    return Ok(new { message = "Successfully registered poketrainer", id = newTrainerId });
                }
                else
                {
                    return UnprocessableEntity(new { message = y.ToString() });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException);
            }
        }

        [HttpGet("api/poketrainer")]
        public async Task<IActionResult> GetAllTrainers()
        {
            try
            {
                var trainers = await _trainerService.GetAllTrainersAsync();
                return Ok(new { message = "PokeTrainer successfully found", trainers = trainers });
            }
            catch (Exception ex)
            {
                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException);
            }
            
        }

        [HttpGet("api/poketrainer/{id}")]
        public async Task<IActionResult> GetTrainerById(int id)
        {
            try
            {
                var trainer = await _trainerService.GetTrainerByIdAsync(id);

                if (trainer == null)
                {
                    return NotFound(new { message = "Poketrainer not found" });
                }

                return Ok(new { message = "PokeTrainer successfully found", trainer = trainer });
            }
            catch (Exception ex)
            {
                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException);
            }
            
        }

        [HttpPut("api/poketrainer/{id}")]
        public async Task<IActionResult> UpdateTrainer([FromBody]PokeTrainer updatedTrainer, int id)
        {
            try
            {
                var validador = new PokeTrainerValidator();
                var y = validador.Validate(updatedTrainer);
                if (y.IsValid)
                {
                    if (updatedTrainer.Id != id)
                    {
                        return UnprocessableEntity(new { message = "The object id cannot be different from the url" });
                    }
                    if (await _trainerService.GetTrainerByIdAsync(updatedTrainer.Id) == null)
                    {
                        return NotFound(new { message = "Poketrainer not found" });
                    }

                    var result = await _trainerService.UpdateTrainerAsync(updatedTrainer);
                    return Ok(new { message = "Poketrainer updated successfully", id = result });
                }
                else
                {
                    return UnprocessableEntity(new { message = y.ToString() });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException);
            }
        }

        [HttpPost("api/poketrainer/{trainerId}/capture/{pokemonId}")]
        public async Task<ActionResult<bool>> CapturePokemonAsync(int trainerId, int pokemonId)
        {
            try
            {
                var captured = await _trainerService.CapturePokemonAsync(trainerId, pokemonId);

                if (captured)
                {
                    return Ok(new { message = "Pokemon captured", pokemon = pokemonId });
                }
                else
                {
                    return NotFound(new { message = "Poketrainer not found" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException);
            }
        }

        [HttpGet("api/poketrainer/{trainerId}/caught-pokemons")]
        public async Task<ActionResult<List<PokemonCaught>>> GetCapturedPokemonsByTrainerIdAsync(int trainerId)
        {
            try
            {
                var capturedPokemons = await _trainerService.GetCapturedPokemonsByTrainerIdAsync(trainerId);
                return Ok(capturedPokemons);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error getting caught pokemons: {ex.Message}");
            }
        }

        [HttpDelete("api/poketrainer/{id}")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            try
            {
                var trainer = await _trainerService.GetTrainerByIdAsync(id);

                if(trainer == null)
                {
                    return NotFound(new { message = "PokeTrainer not found" });
                }

                await _trainerService.DeleteTrainerAsync(id);

                return Ok(new { message = "PokeTrainer successfully delete" });
            }
            catch (Exception ex)
            {
                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException);
            }
        }
    }
}
