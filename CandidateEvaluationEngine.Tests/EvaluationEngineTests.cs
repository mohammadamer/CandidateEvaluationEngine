using Xunit;
using System.Text.Json;

namespace CandidateEvaluationEngine.Tests
{
    public class EvaluationEngineTests
    {
        [Fact]
        public void ReturnsEvaluation250ForExperienceOf5YearsDataScienceQualification()
        {
            var qualification = new Qualification
            {
                TypeOfQualification = QualificationType.Experience,
                Experience = "data science",
                YearOfExperience = 5
            };
            string json = JsonSerializer.Serialize(qualification);
            File.WriteAllText("qualification.json", json);

            var engine = new EvaluationEngine();
            engine.Evaluate();
            var result = engine.Evaluation;

            Assert.Equal(250, result);
        }

        [Fact]
        public void ReturnsEvaluation1400ForHigherEducationAtSVU2003And2007Qualification()
        {
            var qualification = new Qualification
            {
                TypeOfQualification = QualificationType.Education,
                Experience = "Higher",
                YearOfEntry = 2003,
                YearOfGraduation = 2007,
                EducationalInstituteName = "SVU"
            };
            string json = JsonSerializer.Serialize(qualification);
            File.WriteAllText("qualification.json", json);

            var engine = new EvaluationEngine();
            engine.Evaluate();
            var result = engine.Evaluation;

            Assert.Equal(1400, result);
        }
    }
}