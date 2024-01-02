using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateEvaluationEngine
{
    public class FileQualificationSource
    {
        public string GetQualificationFromSource()
        {
            return File.ReadAllText("Qualification.json");
        }
    }
}