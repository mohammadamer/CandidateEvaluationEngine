using System.Text.Json.Serialization;
using System.Text.Json;

namespace CandidateEvaluationEngine.Persistence
{
    public class JsonQualificationSerializer
    {
        public Qualification GetQualificationFromJsonString(string jsonString)
        {
            var qualification = JsonSerializer.Deserialize<Qualification>(jsonString, new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                PropertyNameCaseInsensitive = true // If you want case-insensitive property matching
            });
            return qualification ?? throw new InvalidOperationException("Deserialization returned null");
        }
    }
}