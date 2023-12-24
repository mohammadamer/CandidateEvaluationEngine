// See https://aka.ms/new-console-template for more information
using CandidateEvaluationEngine;

Console.WriteLine("Starting Job Candidate Evaluation Engine...");
var engine = new EvaluationEngine();
engine.Evaluate();

if(engine.Evaluation > 0 )
{
    Console.WriteLine($"Evaluation: {engine.Evaluation}");
}
else
{
    Console.WriteLine("No Evaluation produced.");
}
