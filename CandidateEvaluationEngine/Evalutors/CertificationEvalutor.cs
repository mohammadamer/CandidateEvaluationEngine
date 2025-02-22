using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateEvaluationEngine.Evalutors
{
    public class CertificationEvalutor : Evaluator
    {
        public CertificationEvalutor(EvaluationEngine engine, ConsoleLogger logger)
        : base(engine, logger)
        {
        }

        public override void Evaluate(Qualification qualification)
        {
            _logger.Log("Evaluating Experience Certification...");
            _logger.Log("Validating Certification...");

            if (string.IsNullOrEmpty(qualification.Certification.ToString()))
            {
                _logger.Log("Certification must specify Certification details");
                return;
            }

            if (string.IsNullOrEmpty(qualification.NumberOfCertificates.ToString()))
            {
                _logger.Log("Certification must specify Number Of Certificates");
                return;
            }

            //Logic...
            // Evaluation based on the prestige of the certification
            int numberOfCertificates = int.Parse(qualification.NumberOfCertificates.ToString());

            if (qualification.Certification.ToLower() == "microsoft certified")
            {
                // Add a bonus for having Microsoft Certified certifications
                _engine.Evaluation = Math.Max(0, Math.Min(1000, numberOfCertificates * 100)) + 200;
            }
            else
            {
                // Default certification calculation
                _engine.Evaluation = Math.Max(0, Math.Min(1000, numberOfCertificates * 75));
            }

            if (qualification.Certification.ToLower() == "pmp")
            {
                // Add a bonus for having Project Management Professional certification
                _engine.Evaluation = Math.Max(0, Math.Min(1000, numberOfCertificates * 100)) + 150;
            }
            else
            {
                // Default certification calculation
                _engine.Evaluation = Math.Max(0, Math.Min(1000, numberOfCertificates * 75));
            }
        }
    }
}
