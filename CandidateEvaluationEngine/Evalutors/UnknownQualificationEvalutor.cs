using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateEvaluationEngine.Evalutors
{
    public class UnknownQualificationEvalutor : Evaluator
    {
        public UnknownQualificationEvalutor(EvaluationEngine engine, ConsoleLogger logger)
        : base(engine, logger)
        {
        }

        public override void Evaluate(Qualification qualification)
        {
            _logger.Log("Unknown Qualification...");
        }
    }
}
