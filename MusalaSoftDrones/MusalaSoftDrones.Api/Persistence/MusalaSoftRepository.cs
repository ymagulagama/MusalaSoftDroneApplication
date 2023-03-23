using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MusalaSoftDrones.Api.Data;
using MusalaSoftDrones.Api.DomainEntities;
using MusalaSoftDrones.Api.DomainEntities.Enums;

namespace MusalaSoftDrones.Api.Persistence
{
    /// <summary>
    /// All of the database actions covered in this class.
    /// </summary>
    public class MusalaSoftRepository : IMusalaSoftRepository
    {
        private MusalaSoftAppApiContext context;

        public MusalaSoftRepository(MusalaSoftAppApiContext context)
        {
            this.context = context;
        }
        public async Task RegisterDrone(Drone drone)
        {
            context.Drone.Add(drone);
            await context.SaveChangesAsync();
        }
        public Task<ActionResult<IEnumerable<Drone>>> AvailableDrones(State state)
        {
            throw new NotImplementedException();
        }
        public IQueryable<Drone> AvailableDrone(State state)
        {
            var drone =  context.Drone.Where(x => x.State == state).AsQueryable();
            return drone;
        }
        public async Task<ActionResult<Medication>> GetMedicationByDroneId(string serialNumber)
        {
            var medication = context.Medication.FirstOrDefault(x => x.Drones.SerialNumber == serialNumber);
            return medication;
        }

        public async Task<ActionResult<Drone>> GivenDroneDetails(string serialNumber)
        {
            var drone = context.Drone.FirstOrDefault(x => x.SerialNumber == serialNumber);
            return drone;
        }

        public async Task LoadMedication(Medication medication)
        {
            context.Medication.Add(medication);
            await context.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Drone>>> GetAllDrone()
        {
            return await context.Drone.ToListAsync();
        }
    }
}
