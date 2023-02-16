using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Moq;
using SGCPN.Controllers;
using SGCPN.Models;
using SGCPN.Validators;

namespace SGCPN.Test.Controllers;

public class InstitutionControllerTest
{
    private SGCPNContext _context;
    [Test]
    public async Task CreateInstitutionController()
    {
        //Arrange
        var options = new DbContextOptionsBuilder<SGCPNContext>()
             .UseInMemoryDatabase(databaseName: "InMemoryDb")
             .Options;
        _context = new SGCPNContext(options);

        var institution = new Institution();
        var validation = new InstitutionValidator();
        var controller = new InstitutionController(_context, validation);


        //Act
        var result = await controller.Create(institution);

        //Assert
        result.Should().BeOfType<ViewResult>();
        Assert.That(result, Is.Not.Null);
       

    }
}
