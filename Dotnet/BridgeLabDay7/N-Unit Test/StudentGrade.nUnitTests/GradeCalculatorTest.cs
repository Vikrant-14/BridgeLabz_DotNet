using NUnit.Framework;
using StudentGrades;

namespace StudentGrade.nUnitTests
{
    public class GradeCalculatorTest
    {

        private GradeCalculator _gradeCalculator { get; set; } = null;

        [SetUp]
        public void Setup()
        {
            _gradeCalculator = new GradeCalculator();
        }


        [TestCase(91)]
        [TestCase(92)]
        [TestCase(93)]
        [TestCase(94)]
        [TestCase(65)]
        [TestCase(09)]
        [TestCase(-1)]
        public void GetGradeByPercentage_EqualTest(int percentage)
        {
            // Assign
           // var percentage = 99;

            // Act
            var grade = _gradeCalculator.GetGradeByPercentage(percentage);

            //Assert
            Assert.AreEqual("A", grade);
        }

        [TestCase(91)]
        [TestCase(92)]
        [TestCase(93)]
        [TestCase(94)]
        [TestCase(65)]
        [TestCase(09)]
        [TestCase(-1)]
        public void GetGradeByPercentage_NotEqualTest(int percentage)
        {
            // Assign
            // var percentage = 99;

            // Act
            var grade = _gradeCalculator.GetGradeByPercentage(percentage);

            //Assert
            Assert.AreNotEqual("A", grade);
        }


    }
}