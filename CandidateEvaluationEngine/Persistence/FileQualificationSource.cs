namespace CandidateEvaluationEngine.Persistence
{
    public class FileQualificationSource
    {
        public string GetQualificationFromSource()
        {
            return File.ReadAllText("Qualification.json");
        }
    }
}