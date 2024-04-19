using Logger.Base;
using Moq;

namespace Logger.Test
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public async Task TestForSuccessfulDependency()
        {
            // Arrange
            Mock<ILogger> mockClient = new();
            Property property = new(new Dictionary<string, string> { { "TestProperty", "TestValue" } });
            mockClient
                .Setup(client => client.Start(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Property>()))
                .Returns<string, string, Property>((name, operation, prop) => new DependencyOperation(mockClient.Object, name, operation, prop));

            // Act
            using DependencyOperation dependency = mockClient.Object.Start("TestClassName", "TestOperationName", property);
            await mockClient.Object.Information("Information");
        }

        [TestMethod]
        public async Task TestForFailedDependency()
        {
            // Arrange
            Mock<ILogger> mockClient = new();
            Property property = new(new Dictionary<string, string> { { "TestProperty", "TestValue" } });
            mockClient
                .Setup(client => client.Start(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Property>()))
                .Returns<string, string, Property>((name, operation, prop) => new DependencyOperation(mockClient.Object, name, operation, prop));

            // Act
            using DependencyOperation dependency = mockClient.Object.Start("TestClassName", "TestOperationName", property);
            await mockClient.Object.Warning("Warning");
            await mockClient.Object.Error(new ExceptionMessage(new Exception("Test Exception"), "Test Fail Result"));
            dependency.Fail();
        }
    }
}