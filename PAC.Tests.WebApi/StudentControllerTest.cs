namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;

[TestClass]
public class StudentControllerTest
{
        [TestInitialize]
        public void InitTest()
        {
        }
        [TestMethod]
        public void PostStudentOk()
        {
            // Arrange
            Mock<IStudentLogic> studentLogicMock = new Mock<IStudentLogic>();
            studentLogicMock.Setup(x => x.InsertStudents(It.IsAny<Student>()));

            var controller = new StudentController(studentLogicMock.Object);

            var newStudent = new Student
            {
                Name = "Ana",
            };

            // Act
            var result = controller.Post(newStudent);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void PostStudentFail()
        {
        // Arrange
            Mock<IStudentLogic> studentLogicMock = new Mock<IStudentLogic>();
        studentLogicMock.Setup(x => x.InsertStudents(It.IsAny<Student>()));
            var controller = new StudentController(studentLogicMock.Object);

            var newStudent = new Student
            {
                Name = "Ana",
            };

            // Act
            var result = controller.Post(newStudent);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
}
