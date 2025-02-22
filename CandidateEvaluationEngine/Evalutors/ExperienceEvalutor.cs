using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateEvaluationEngine.Evalutors
{
    public class ExperienceEvalutor : Evaluator
    {

        public ExperienceEvalutor(EvaluationEngine engine, ConsoleLogger logger)
      : base(engine, logger)
        {
        }

        public override void Evaluate(Qualification qualification)
        {
            _logger.Log("Evaluating Experience Qualification...");
            _logger.Log("Validating Qualification...");

            if (string.IsNullOrEmpty(qualification.Experience.ToString()))
            {
                _logger.Log("Experience must specify Experience details");
                return;
            }

            if (string.IsNullOrEmpty(qualification.YearOfExperience.ToString()))
            {
                _logger.Log("Experience must specify Year Of Experience");
                return;
            }

            //Logic...
            // Evaluation based on specialized experience
            int yearsOfExperience = qualification.YearOfExperience;

            if (qualification.Experience.ToLower() == "data science")
            {
                // Add a bonus for having experience in data science
                _engine.Evaluation = Math.Max(0, Math.Min(1000, yearsOfExperience * 75)) + 400;
            }
            else
            {
                // Default experience calculation
                _engine.Evaluation = Math.Max(0, Math.Min(1000, yearsOfExperience * 50));
            }

            if (qualification.Experience.ToLower() == "manager")
            {
                // Add a bonus for having management experience
                _engine.Evaluation = Math.Max(0, Math.Min(1000, yearsOfExperience * 100)) + 200;
            }
            else
            {
                // Default experience calculation
                _engine.Evaluation = Math.Max(0, Math.Min(1000, yearsOfExperience * 50));
            }
        }
    }
}
