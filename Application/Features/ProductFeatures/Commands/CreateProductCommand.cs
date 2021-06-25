using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
	public class CreateProductCommand : IRequest<int>
	{
		public string Name { get; set; }
		public string Barcode { get; set; }
		public string Description { get; set; }
		public decimal Rate { get; set; }

		public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
		{
			private readonly IApplicationDbContext _context;

			public CreateProductCommandHandler(IApplicationDbContext context)
			{
				_context = context;
			}

			public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
			{
				var product = new Product
				{
					Name = request.Name,
					Barcode = request.Barcode,
					Description = request.Description,
					Rate = request.Rate
				};

				await _context.Products.AddAsync(product);
				await _context.SaveChangesAsync();

				return product.Id;
			}
		}
	}
}
