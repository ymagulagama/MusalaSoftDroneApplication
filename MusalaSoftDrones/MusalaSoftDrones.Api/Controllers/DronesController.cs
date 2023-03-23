using Microsoft.AspNetCore.Mvc;

using MusalaSoftDrones.Api.DomainEntities;
using MusalaSoftDrones.Api.DomainEntities.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusalaSoftDrones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DronesController : ControllerBase
    {

        private readonly IMusalaSoftRepository _repository;

        public DronesController(IMusalaSoftRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<Drone>> RegisterDrone(Drone drone)
        {
            await _repository.RegisterDrone(drone);

            return CreatedAtAction("RegisterDrone", drone);
        }

        // GET: api/Drones/5
        [HttpGet("{serialNumber}")]
        public async Task<ActionResult<Drone>> DroneDetailsById(string serialNumber)
        {
            var drone = await _repository.GivenDroneDetails(serialNumber);

            if (drone == null)
            {
                return NotFound();
            }

            return Ok(drone);
        }

        // GET: api/Drones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drone>>> GetAllDrone()
        {
            var drone = await _repository.GetAllDrone();
            return Ok(drone);
        }


        // GET: api/Drones/1
        [Route("[action]/{state}")]
        [HttpGet]
        public async Task<ActionResult<Drone>> DroneDetailsByState(State state)
        {
            var drone = await _repository.AvailableDrones(state);

            if (drone == null)
            {
                return NotFound();
            }

            return Ok(drone);
        }
    }
}
