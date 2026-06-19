using HelloWorld.Api;
using Xunit;

namespace HelloWorld.Api.Tests;

public sealed class GreetingServiceTests
{
    [Fact]
    public void GetMessage_ReturnsExpectedGreeting()
    {
        Assert.Equal("Hello world!", GreetingService.GetMessage());
    }
}
