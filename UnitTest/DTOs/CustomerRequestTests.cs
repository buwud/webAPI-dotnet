using Application.Features.Customers.Dtos;

namespace CustomerUnitTest.DTOs
{
    public class CustomerRequestTests : BaseTest
    {
        [Theory]
        [InlineData("buwu", "duran", "123@gmail.com", "1111111111",0)]
        [InlineData("buwu", "duran", "123@gmail.com", null,1)]
        [InlineData("buwu", "duran", null, null,2)]
        [InlineData("buwu", null, null, null,3)]
        [InlineData(null, null, null, null,4)]
        public void ValidateModel_CreateCustomerRequest_ReturnsCorrectNumberOfErrors( string name, string surname, string email, string phone, int numberExpectedErrors )
        {
            var request = new CreateCustomerRequest
            {
                Name = name,
                Surname = surname,
                Email = email,
                Phone = phone
            };

            var errorList = ValidateModel(request);

            Assert.Equal(numberExpectedErrors, errorList.Count);
        }

    }
}
