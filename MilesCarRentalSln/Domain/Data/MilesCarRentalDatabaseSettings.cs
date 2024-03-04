namespace Domain.Data
{
    public class MilesCarRentalDatabaseSettings : IMilesCarRentalDatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string ClienteCollection { get; set; } = string.Empty;
        public string VehiculoCollection { get; set; } = string.Empty;
        public string LocalidadCollection { get; set; } = string.Empty;
        public string ReservacionCollection { get; set; } = string.Empty;
        public string UsuarioCollection { get; set; } = string.Empty;
    }
}
