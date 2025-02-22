using CandidateEvaluationEngine.Evalutors;
using CandidateEvaluationEngine.Persistence;

namespace CandidateEvaluationEngine
{
    public class EvaluationEngine
    {
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        public FileQualificationSource QualificationSource { get; set; } = new FileQualificationSource();
        public JsonQualificationSerializer QualificationSerializer { get; set; } = new JsonQualificationSerializer();
        public decimal Evaluation { get; set; }
        public EvaluationEngine() { }

        public void Evaluate()
        {
            //logging...
            Logger.Log("Starting Evaluation.");
            Logger.Log("Loading Qualification.");

            //Persistence...
            string qualificationJson = QualificationSource.GetQualificationFromSource();

            //Encoding...
            var qualification = QualificationSerializer.GetQualificationFromJsonString(qualificationJson);

            //Evaluation...
            Logger.Log("Evaluating Qualification.");
            var factory = new EvaluatorFactory();
            var evaluator = factory.GetEvaluator(qualification.TypeOfQualification, this);
            evaluator.Evaluate(qualification);

            Logger.Log("Evaluation completed.");
        }
    }
}