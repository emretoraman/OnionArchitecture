using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries
{
	public class GetProductByIdQuery : IRequest<Product>
	{
		public int Id { get; set; }

		public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
		{
			private readonly IApplicationDbContext _context;

			public GetProductByIdQueryHandler(IApplicationDbContext context)
			{
				_context = context;
			}

			public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
			{
				var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id);
				return product;
			}
		}
	}
}
