using Examino.Application.Functions.PeselChecker;
using NUnit.Framework;

namespace Examino.Tests;

public class PeselCheckerTest
{
    [Test]
    public void peselShouldBeMarkedAsInvalid()
    {
        //Arrange
        string notValidPesel = "123456789";
        //Act
        var objectUnderTest = new PeselChecker(notValidPesel);
        //Assert
        Assert.IsFalse(objectUnderTest.isValid());
    }

    [Test]
    public void peselShouldBeMarkedAsValid()
    {
        //Arrange
        string validPesel = "97101312725";
        //Act
        var objectUnderTest = new PeselChecker(validPesel);
        //Assert
        Assert.IsTrue(objectUnderTest.isValid());
    }
    
    [Test]
    public void peselCheckerShouldReturnMaleGender()
    {
        //Arrange
        string validMalePesel = "52102936374";
        //Act
        var objectUnderTest = new PeselChecker(validMalePesel);
        //Assert
        Assert.AreEqual("Mężczyzna",objectUnderTest.getSex());
    }
    [Test]
    public void peselCheckerShouldReturnFemaleGender()
    {
        //Arrange
        string validFemalePesel = "81021722762";
        //Act
        var objectUnderTest = new PeselChecker(validFemalePesel);
        //Assert
        Assert.AreEqual("Kobieta",objectUnderTest.getSex());
    }
}