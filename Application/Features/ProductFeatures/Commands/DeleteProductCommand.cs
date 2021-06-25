using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
	public class DeleteProductCommand : IRequest<int>
	{
		public int Id { get; set; }

		public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
		{
			private readonly IApplicationDbContext _context;

			public DeleteProductCommandHandler(IApplicationDbContext context)
			{
				_context = context;
			}

			public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
			{
				var product = await _context.Products.FirstOrDefaultAsync();
				if (product == null) return default;

				_context.Products.Remove(product);
				await _context.SaveChangesAsync();

				return product.Id;
			}
		}
	}
}
