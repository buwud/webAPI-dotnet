using Dapper;
using Domain;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Application.Features.Customers.Queries
{
    public class GetAllQuery : IRequest<IEnumerable<CustomerEntity>>
    {

    }
}
