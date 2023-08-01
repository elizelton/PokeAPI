using Base.Exceptions;
using Domain.Entities;

namespace Tests;

public class MasterEntityTests
{
    [Fact]
    public void Master_Constructor_ShouldSetPropertiesCorrectly()
    {
        // Arrange
        string name = "Ash Ketchum";
        DateTime birthDate = new DateTime(1990, 5, 15);
        string email = "ash@example.com";
        string document = "123456789";

        // Act
        Master master = new Master(name, birthDate, email, document);

        // Assert
        Assert.Equal(name, master.Name);
        Assert.Equal(birthDate, master.BirthDate);
        Assert.Equal(email, master.Email);
        Assert.Equal(document, master.Document);
    }

    [Fact]
    public void Master_Constructor_ShouldThrowExceptionForInvalidAge()
    {
        // Arrange
        string name = "Trainer with Invalid Age";
        DateTime invalidBirthDate = DateTime.Now.AddYears(-7).AddDays(-1);
        string email = "invalid@example.com";
        string document = "987654321";

        // Act and Assert
        Assert.Throws<AppException>(() => new Master(name, invalidBirthDate, email, document));
    }
    
    [Fact]
    public void Master_Constructor_ShouldThrowExceptionForInvalidEmail()
    {
        // Arrange
        string name = "Trainer with Invalid Email";
        DateTime birthDate = new DateTime(1992, 6, 25);
        string invalidEmail = "invalidemail";
        string document = "987654321";

        // Act and Assert
        Assert.Throws<AppException>(() => new Master(name, birthDate, invalidEmail, document));
    }

    [Fact]
    public void Master_Constructor_ShouldThrowExceptionForInvalidName()
    {
        // Arrange
        string invalidName = "";
        DateTime birthDate = new DateTime(1992, 6, 25);
        string email = "";
        string document = "987654321";

        // Act and Assert
        Assert.Throws<AppException>(() => new Master(invalidName, birthDate, email, document));
    }

    [Fact]
    public void Master_Constructor_ShouldThrowExceptionForInvalidDocument()
    {
        // Arrange
        string name = "Trainer with Invalid Document";
        DateTime birthDate = new DateTime(1992, 6, 25);
        string email = "valid@mail.com";
        string invalidDocument = "asbdslkjsd";

        // Act and Assert
        Assert.Throws<AppException>(() => new Master(name, birthDate, email, invalidDocument));

    }
}