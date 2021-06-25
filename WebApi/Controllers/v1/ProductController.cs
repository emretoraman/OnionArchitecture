using Application.Features.ProductFeatures.Commands;
using Application.Features.ProductFeatures.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
	[ApiVersion("1.0")]
	public class ProductController : BaseApiController
	{
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await Mediator.Send(new GetAllProductsQuery()));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			return Ok(await Mediator.Send(new GetProductByIdQuery() { Id = id }));
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
		{
			return Ok(await Mediator.Send(command));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateProductCommand command)
		{
			if (id != command.Id) return BadRequest();

			return Ok(await Mediator.Send(command));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			return Ok(await Mediator.Send(new DeleteProductCommand { Id = id }));
		}
	}
}
