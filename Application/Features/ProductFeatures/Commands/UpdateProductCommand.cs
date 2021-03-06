using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
	public class UpdateProductCommand : IRequest<int>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Barcode { get; set; }
		public string Description { get; set; }
		public decimal Rate { get; set; }

		public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
		{
			private readonly IApplicationDbContext _context;

			public UpdateProductCommandHandler(IApplicationDbContext context)
			{
				_context = context;
			}

			public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
			{
				var product = await _context.Products.FirstOrDefaultAsync();
				if (product == null) return default;

				product.Name = request.Name;
				product.Barcode = request.Barcode;
				product.Description = request.Description;
				product.Rate = request.Rate;

				await _context.SaveChangesAsync();

				return product.Id;
			}
		}
	}
}
