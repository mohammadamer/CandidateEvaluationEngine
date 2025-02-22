using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateEvaluationEngine.Evalutors
{
    public class EducationEvaulator : Evaluator
    {
        public EducationEvaulator(EvaluationEngine engine, ConsoleLogger logger)
        : base(engine, logger)
        {
        }

        public override void Evaluate(Qualification qualification)
        {
            //Business rules...Several Business rules...

            _logger.Log("Evaluating Education Qualification...");
            _logger.Log("Validating Qualification");

            //Vaildations...Many Validations
            if (string.IsNullOrEmpty(qualification?.TypeOfEducation.ToString()))
            {
                _logger.Log("Education must specify Type Of Education");
                return;
            }

            if (string.IsNullOrEmpty(qualification.YearOfEntry.ToString()))
            {
                _logger.Log("Education must specify YearOfEntry");
                return;
            }

            if (string.IsNullOrEmpty(qualification.YearOfGraduation.ToString()))
            {
                _logger.Log("Education must specify Year Of Graduation");
                return;
            }

            if (string.IsNullOrEmpty(qualification.EducationalInstituteName.ToString()))
            {
                _logger.Log("Education must specify Name Of Educational Institute");
                return;
            }

            //Logic...
            int entryYear = qualification.YearOfEntry;
            int graduationYear = qualification.YearOfGraduation;
            int yearsOfEducation = graduationYear - entryYear;

            // Normalize to a scale between 0 and 1000
            _engine.Evaluation = Math.Max(0, Math.Min(1000, yearsOfEducation * 100));

            // Additional logic based on type of education
            if (qualification.TypeOfEducation == EducationType.Higher)
            {
                // Add a bonus for having a Higher Education.
                _engine.Evaluation += 400;
            }

            // Additional logic based on type of education
            if (qualification.TypeOfEducation == EducationType.MasterDegree)
            {
                // Add a bonus for having a master's degree
                _engine.Evaluation += 600;
            }

            string instituteName = qualification?.EducationalInstituteName?.ToLower();
            if (instituteName.Contains("harvard"))
            {
                // Add a bonus for having studied at Harvard
                _engine.Evaluation += Math.Max(0, Math.Min(1000, 500)) + 300;
            }
            else
            {
                // Default education calculation
                _engine.Evaluation += Math.Max(0, Math.Min(1000, 400));
            }
        }
    }
}
