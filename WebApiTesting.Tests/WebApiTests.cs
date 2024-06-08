using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace WebApiTesting.Tests;

public class WebApiTests
{
    private WebApplicationFactory<Program> factory;

    [SetUp]
    public void Setup()
    {
        factory = new WebApplicationFactory<Program>();
    }

    [Test]
    public async Task HttpCallSucceeds()
    {
        using var httpClient = factory.CreateClient();

        var weatherForecasts = await httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>(
            "/WeatherForecast"
        );

        weatherForecasts.Should().HaveCount(5);
    }

    [TearDown]
    public void TearDown()
    {
        factory.Dispose();
    }
}
