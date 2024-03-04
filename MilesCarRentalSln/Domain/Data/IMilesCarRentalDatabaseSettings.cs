namespace Domain.Data
{
    public interface IMilesCarRentalDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string ClienteCollection {  get; set; }
        string VehiculoCollection { get; set; }
        string LocalidadCollection { get; set; }
        string ReservacionCollection { get; set; }
        string UsuarioCollection { get; set; }

    }
}
