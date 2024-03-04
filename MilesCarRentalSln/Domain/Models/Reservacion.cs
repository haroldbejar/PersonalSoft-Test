using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models
{
    public class Reservacion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("clienteid")]
        public string ClienteId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("vehiculoid")]
        public string VehiculoId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("localidadrecogidaid")]
        public string LocalidadRecogidaId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("localidadevolucionid")]
        public string LocalidaDevolucionId { get; set; }

        [BsonElement("fecharecogida")]
        public DateTime FechaRecogida { get; set; }

        [BsonElement("fechadevolucion")]
        public DateTime FechaDevolucion { get; set; }
    }
}
