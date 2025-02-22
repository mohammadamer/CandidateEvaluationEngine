using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateEvaluationEngine.Evalutors
{
    public abstract class Evaluator
    {
        protected readonly EvaluationEngine _engine;
        protected readonly ConsoleLogger _logger;

        public Evaluator(EvaluationEngine engine, ConsoleLogger logger)
        {
            _engine = engine;
            _logger = logger;
        }

        public abstract void Evaluate(Qualification qualification);
    }
}
