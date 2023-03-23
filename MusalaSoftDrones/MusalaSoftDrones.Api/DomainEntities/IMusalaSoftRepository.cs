using Microsoft.AspNetCore.Mvc;

using MusalaSoftDrones.Api.DomainEntities.Enums;

namespace MusalaSoftDrones.Api.DomainEntities
{
    public interface IMusalaSoftRepository
    {
        Task RegisterDrone(Drone drone);
        Task<ActionResult<Drone>> GivenDroneDetails(string serialNumber);
        Task<ActionResult<IEnumerable<Drone>>> AvailableDrones(State state);
        Task<ActionResult<Medication>> GetMedicationByDroneId(string serialNumber);
        Task LoadMedication(Medication medication);
        Task<ActionResult<IEnumerable<Drone>>> GetAllDrone();
    }
}
