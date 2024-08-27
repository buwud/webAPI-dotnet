using Core.Entities;
using CustomerIntegrationTests.Fixtures;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CustomerIntegrationTests
{
    public class CustomerControllerTests : IntegrationTest
    {
        public CustomerControllerTests( ApiWebApplicationFactory fixture ) : base(fixture) { }

        [Fact]
        public async Task GET_retrieves_customers()
        {
            var response = await _httpClient.GetAsync("/api/Customer");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var customers = JsonConvert.DeserializeObject<CustomerEntity>(await response.Content.ReadAsStringAsync());

            customers.Should().NotBeNull();
            //customers.Should().HaveCount(2);
        }
    }
}
