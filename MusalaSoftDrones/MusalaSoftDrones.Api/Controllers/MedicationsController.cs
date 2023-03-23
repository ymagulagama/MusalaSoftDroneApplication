using Microsoft.AspNetCore.Mvc;
using MusalaSoftDrones.Api.DomainEntities;

namespace MusalaSoftDrones.Api.Controllers
{
    /// <summary>
    /// This class mange medication related actions.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationsController : ControllerBase
    {
        private readonly IMusalaSoftRepository _repository;

        public MedicationsController(IMusalaSoftRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<Medication>> LoadMedication(Medication medication)
        {
            await _repository.LoadMedication(medication);

            return CreatedAtAction("LoadMedication", medication);
        }

        // GET: api/Medications/5
        [HttpGet("{serialNumber}")]
        public async Task<ActionResult<Medication>> GetMedication(string serialNumber)
        {
            var medication = _repository.GetMedicationByDroneId(serialNumber);

            if (medication == null)
            {
                return NotFound();
            }

            return Ok(medication);
        }

      

    }
}