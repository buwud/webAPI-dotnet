using Application.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_Nilvera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController( IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _unitOfWork.Customers.GetAllAsync();
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById( int id )
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            if ( customer == null ) return NotFound();
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Create( [FromBody] CustomerEntity customer )
        {
            await _unitOfWork.Customers.AddAsync(customer);
            return Ok(customer);
        }
        [HttpPut]
        public async Task<IActionResult> Update( CustomerEntity customer )
        {
            await _unitOfWork.Customers.UpdateAsync(customer);
            return Ok(customer);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete( int id )
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            if ( customer == null ) return NotFound();
            var data = await _unitOfWork.Customers.DeleteAsync(id);
            return Ok(data);
        }

    }
}
