using System.Text.Json;
using System.Text.Json.Serialization;

namespace CandidateEvaluationEngine
{
    public class EvaluationEngine
    {
        public decimal Evaluation { get; set; }
        public EvaluationEngine() { }

        public void Evaluate()
        {
            //logging...
            Console.WriteLine("Starting Evaluation.");
            Console.WriteLine("Loading Qualification.");

            //Persistence...
            string qualificationJson = File.ReadAllText("C:\\PS-PlayGround\\DEV Projects\\CandidateEvaluationEngine\\CandidateEvaluationEngine\\Qualification.json");

            //Encoding...
            var qualification = JsonSerializer.Deserialize<Qualification>(qualificationJson, new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                PropertyNameCaseInsensitive = true // If you want case-insensitive property matching
            });

            switch (qualification?.TypeOfQualification)
            {
                //Business rules...Several Business rules...
                case QualificationType.Education:
                    Console.WriteLine("Evaluating Education Qualification...");
                    Console.WriteLine("Validating Qualification");

                    //Vaildations...Many Validations
                    if (string.IsNullOrEmpty(qualification?.TypeOfEducation.ToString()))
                    {
                        Console.WriteLine("Education must specify Type Of Education");
                        return;
                    }

                    if (string.IsNullOrEmpty(qualification.YearOfEntry.ToString()))
                    {
                        Console.WriteLine("Education must specify YearOfEntry");
                        return;
                    }

                    if (string.IsNullOrEmpty(qualification.YearOfGraduation.ToString()))
                    {
                        Console.WriteLine("Education must specify Year Of Graduation");
                        return;
                    }

                    if (string.IsNullOrEmpty(qualification.EducationalInstituteName.ToString()))
                    {
                        Console.WriteLine("Education must specify Name Of Educational Institute");
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
                    Console.WriteLine("Evaluating Experience Qualification...");
                    Console.WriteLine("Validating Qualification...");

                    if (string.IsNullOrEmpty(qualification.Experience.ToString()))
                    {
                        Console.WriteLine("Experience must specify Experience details");
                        return;
                    }

                    if (string.IsNullOrEmpty(qualification.YearOfExperience.ToString()))
                    {
                        Console.WriteLine("Experience must specify Year Of Experience");
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
                    Console.WriteLine("Evaluating Experience Certification...");
                    Console.WriteLine("Validating Certification...");

                    if (string.IsNullOrEmpty(qualification.Certification.ToString()))
                    {
                        Console.WriteLine("Certification must specify Certification details");
                        return;
                    }

                    if (string.IsNullOrEmpty(qualification.NumberOfCertificates.ToString()))
                    {
                        Console.WriteLine("Certification must specify Number Of Certificates");
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
                    Console.WriteLine("Unknown Education Type");
                    break;
            }
            Console.WriteLine("Evaluation completed.");
        }
    }
}
