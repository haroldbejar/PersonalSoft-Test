﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("identificacion")]
        public string Identificacion { get; set; }

        [BsonElement("nrocontacto")]
        public string NroContacto { get; set; }

        [BsonElement("direccion")]
        public string Direccion { get; set; }
    }
}
