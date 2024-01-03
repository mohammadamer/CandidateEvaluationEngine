using Xunit;

namespace CandidateEvaluationEngine.Tests
{
    public class JsonQualificationSerializerGetQualificationFromJsonString
    {
        [Fact]
        public void ReturnsDefaultQualificationFromEmptyJsonString()
        {
            var inputJson = "{}";
            var serializer = new JsonQualificationSerializer();

            var result = serializer.GetQualificationFromJsonString(inputJson);

            var qualification = new Qualification();
            AssertQualificationsEqual(result, qualification);
        }


        [Fact]
        public void ReturnsSimplEducationQualificationFromValidJsonString()
        {
            var inputJson = @"{
              ""TypeOfQualification"": ""Education"",
              ""TypeOfEducation"": ""Higher"",
              ""YearOfEntry"": 2003,
              ""YearOfGraduation"": 2007,
              ""EducationalInstituteName"": ""SVU""
            }
            ";


            var serializer = new JsonQualificationSerializer();

            var result = serializer.GetQualificationFromJsonString(inputJson);

            var qualification = new Qualification{ TypeOfEducation = EducationType.Higher, TypeOfQualification = QualificationType.Education,
                YearOfEntry = 2003, YearOfGraduation = 2007, EducationalInstituteName = "SVU" };
            AssertQualificationsEqual(result, qualification);
        }

        private static void AssertQualificationsEqual(Qualification result, Qualification qualification)
        {
            Assert.Equal(qualification.TypeOfQualification, result.TypeOfQualification);
            Assert.Equal(qualification.TypeOfEducation, result.TypeOfEducation);
            Assert.Equal(qualification.YearOfEntry, result.YearOfEntry);
            Assert.Equal(qualification.YearOfGraduation, result.YearOfGraduation);
            Assert.Equal(qualification.EducationalInstituteName, result.EducationalInstituteName);

            Assert.Equal(qualification.Experience, result.Experience);
            Assert.Equal(qualification.YearOfExperience, result.YearOfExperience);

            Assert.Equal(qualification.Certification, result.Certification);
            Assert.Equal(qualification.NumberOfCertificates, result.NumberOfCertificates);
        }
    }
}