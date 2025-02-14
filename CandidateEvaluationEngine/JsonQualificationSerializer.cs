using System.Text.Json.Serialization;
using System.Text.Json;

namespace CandidateEvaluationEngine
{
    public class JsonQualificationSerializer
    {
        public Qualification GetQualificationFromJsonString(string jsonString)
        {
            return JsonSerializer.Deserialize<Qualification>(jsonString, new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                PropertyNameCaseInsensitive = true // If you want case-insensitive property matching
            });
        }
    }
}