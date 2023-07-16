using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        [JsonIgnore]
        [NotMapped]
        public List<string> Errors { get; protected set; } = new List<string>();

        [JsonIgnore]
        [NotMapped]
        public bool IsValid => !Errors.Any();
    }
}
