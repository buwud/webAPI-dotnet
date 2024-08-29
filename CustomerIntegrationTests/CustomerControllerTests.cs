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

            //customer list
            var customers = JsonConvert.DeserializeObject<IEnumerable<CustomerEntity>>(await response.Content.ReadAsStringAsync());



            customers.Should().NotBeNull();
            //customers.Should().HaveCount(2);
        }
        //post 
        [Fact]
        public async Task POST_creates_customer()
        {
            var customer = new CustomerEntity
            {
                Name = "buse",
                Surname = "duran",
                Email = "buwu@gmail.com",
                Phone = "55555",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            //
            var response = await _httpClient.PostAsync("/api/Customer", new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = JsonConvert.DeserializeObject<CustomerEntity>(await response.Content.ReadAsStringAsync());
            content.Should().BeEquivalentTo(customer, options => options.ComparingByMembers<CustomerEntity>());
        }
        //put
        [Fact]
        public async Task PUT_updates_customer()
        {
            var customer = new CustomerEntity
            {
                Name = "buse",
                Surname = "duran",
                Email = "buse@gmail.com",
                Phone = "55555",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            var response = await _httpClient.PutAsync("/api/Customer/1", new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = JsonConvert.DeserializeObject<CustomerEntity>(await response.Content.ReadAsStringAsync());
            content.Should().BeEquivalentTo(customer, options => options.ComparingByMembers<CustomerEntity>());

        }
    }
}
