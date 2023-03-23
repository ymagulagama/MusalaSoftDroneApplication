namespace MusalaSoftDrones.Api.DomainEntities.Enums
{
    /// <summary>
    /// Drone related states are mention in this class.
    /// </summary>
    public enum State
    {
        IDLE,
        LOADING,
        LOADED,
        DELIVERING,
        DELIVERED,
        RETURNING
    }
}
