using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Nutricao.Core.Interfaces;

namespace WebApplicationIntegrationTest.ControllerTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        public Mock<IFoodCalc> FoodCalcMock { get; }

        public CustomWebApplicationFactory()
        {
            FoodCalcMock = new Mock<IFoodCalc>();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);

            builder.ConfigureTestServices(services =>
            {
                services.AddSingleton(FoodCalcMock.Object);
            });
        }
    }
}
