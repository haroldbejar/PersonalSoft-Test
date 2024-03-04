using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models
{
    public class Vehiculo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("modelo")]
        public string Modelo { get; set; }

        [BsonElement("marca")]
        public string Marca { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("localidadid")]
        public string LocalidadId { get; set; }

        [BsonElement("disponibilidad")]
        public bool Disponibilidad { get; set; }

        [BsonElement("urlimage")]
        public string UrlImage { get; set; }
    }
}
