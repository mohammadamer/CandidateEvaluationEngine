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

            switch (qualification?.TypeOfQualification)
            {
                //Business rules...Several Business rules...
                case QualificationType.Education:
                    Logger.Log("Evaluating Education Qualification...");
                    Logger.Log("Validating Qualification");

                    //Vaildations...Many Validations
                    if (string.IsNullOrEmpty(qualification?.TypeOfEducation.ToString()))
                    {
                        Logger.Log("Education must specify Type Of Education");
                        return;
                    }

                    if (string.IsNullOrEmpty(qualification.YearOfEntry.ToString()))
                    {
                        Logger.Log("Education must specify YearOfEntry");
                        return;
                    }

                    if (string.IsNullOrEmpty(qualification.YearOfGraduation.ToString()))
                    {
                        Logger.Log("Education must specify Year Of Graduation");
                        return;
                    }

                    if (string.IsNullOrEmpty(qualification.EducationalInstituteName.ToString()))
                    {
                        Logger.Log("Education must specify Name Of Educational Institute");
                        return;
                    }

                    //Logic...
                    int entryYear = qualification.YearOfEntry;
                    int graduationYear = qualification.YearOfGraduation;
                    int yearsOfEducation = graduationYear - entryYear;

                    // Normalize to a scale between 0 and 1000
                    Evaluation = Math.Max(0, Math.Min(1000, yearsOfEducation * 100));

                    // Additional logic based on type of education
                    if (qualification.TypeOfEducation == EducationType.Higher)
                    {
                        // Add a bonus for having a Higher Education.
                        Evaluation += 400;
                    }

                    // Additional logic based on type of education
                    if (qualification.TypeOfEducation == EducationType.MasterDegree)
                    {
                        // Add a bonus for having a master's degree
                        Evaluation += 600;
                    }

                    string instituteName = qualification?.EducationalInstituteName?.ToLower();
                    if (instituteName.Contains("harvard"))
                    {
                        // Add a bonus for having studied at Harvard
                        Evaluation += Math.Max(0, Math.Min(1000, 500)) + 300;
                    }
                    else
                    {
                        // Default education calculation
                        Evaluation += Math.Max(0, Math.Min(1000, 400));
                    }

                    break;

                case QualificationType.Experience:
                    Logger.Log("Evaluating Experience Qualification...");
                    Logger.Log("Validating Qualification...");

                    if (string.IsNullOrEmpty(qualification.Experience.ToString()))
                    {
                        Logger.Log("Experience must specify Experience details");
                        return;
                    }

                    if (string.IsNullOrEmpty(qualification.YearOfExperience.ToString()))
                    {
                        Logger.Log("Experience must specify Year Of Experience");
                        return;
                    }

                    //Logic...
                    // Evaluation based on specialized experience
                    int yearsOfExperience = qualification.YearOfExperience;

                    if (qualification.Experience.ToLower() == "data science")
                    {
                        // Add a bonus for having experience in data science
                        Evaluation = Math.Max(0, Math.Min(1000, yearsOfExperience * 75)) + 400;
                    }
                    else
                    {
                        // Default experience calculation
                        Evaluation = Math.Max(0, Math.Min(1000, yearsOfExperience * 50));
                    }

                    if (qualification.Experience.ToLower() == "manager")
                    {
                        // Add a bonus for having management experience
                        Evaluation = Math.Max(0, Math.Min(1000, yearsOfExperience * 100)) + 200;
                    }
                    else
                    {
                        // Default experience calculation
                        Evaluation = Math.Max(0, Math.Min(1000, yearsOfExperience * 50));
                    }

                    break;

                case QualificationType.Certification:
                    Logger.Log("Evaluating Experience Certification...");
                    Logger.Log("Validating Certification...");

                    if (string.IsNullOrEmpty(qualification.Certification.ToString()))
                    {
                        Logger.Log("Certification must specify Certification details");
                        return;
                    }

                    if (string.IsNullOrEmpty(qualification.NumberOfCertificates.ToString()))
                    {
                        Logger.Log("Certification must specify Number Of Certificates");
                        return;
                    }

                    //Logic...
                    // Evaluation based on the prestige of the certification
                    int numberOfCertificates = int.Parse(qualification.NumberOfCertificates.ToString());

                    if (qualification.Certification.ToLower() == "microsoft certified")
                    {
                        // Add a bonus for having Microsoft Certified certifications
                        Evaluation = Math.Max(0, Math.Min(1000, numberOfCertificates * 100)) + 200;
                    }
                    else
                    {
                        // Default certification calculation
                        Evaluation = Math.Max(0, Math.Min(1000, numberOfCertificates * 75));
                    }

                    if (qualification.Certification.ToLower() == "pmp")
                    {
                        // Add a bonus for having Project Management Professional certification
                        Evaluation = Math.Max(0, Math.Min(1000, numberOfCertificates * 100)) + 150;
                    }
                    else
                    {
                        // Default certification calculation
                        Evaluation = Math.Max(0, Math.Min(1000, numberOfCertificates * 75));
                    }

                    break;

                default:
                    Logger.Log("Unknown Education Type");
                    break;
            }
            Logger.Log("Evaluation completed.");
        }
    }
}