using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateEvaluationEngine.Evalutors
{
    public class EvaluatorFactory
    {
        public Evaluator GetEvaluator(QualificationType qualificationType, EvaluationEngine engine)
        {
            switch (qualificationType)
            {
                case QualificationType.Education:
                    return new EducationEvaulator(engine, engine.Logger);
                case QualificationType.Certification:
                    return new CertificationEvalutor(engine, engine.Logger);
                case QualificationType.Experience:
                    return new ExperienceEvalutor(engine, engine.Logger);
                default:
                    return new UnknownQualificationEvalutor(engine, engine.Logger);
            }
        }
    }
}
