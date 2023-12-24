
namespace CandidateEvaluationEngine
{
    public class Qualification
    {
        public QualificationType TypeOfQualification { get; set; }

        #region Education
        public EducationType TypeOfEducation { get; set; }
        public int YearOfEntry { get; set; }
        public int YearOfGraduation { get; set; }
        public string EducationalInstituteName { get; set; }
        #endregion

        #region Experience
        public string Experience { get; set; }
        public int YearOfExperience { get; set; }
        #endregion

        #region Certification
        public string Certification { get; set; }
        public int NumberOfCertificates { get; set; }
        #endregion
    }
}
