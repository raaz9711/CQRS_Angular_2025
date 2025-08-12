using Application.Common.Abstractions;
using Domain;
using MediatR;

namespace Application.Products.Commands.CreateProduct;

public sealed class CreateProductHandler(IAppDbContext db) : IRequestHandler<CreateProductCommand, int>
{
    public async Task<int> Handle(CreateProductCommand request, CancellationToken ct)
    {
        var entity = new Product { Name = request.Name, Price = request.Price };
        db.Products.Add(entity);
        await db.SaveChangesAsync(ct);
        return entity.Id;
    }
}
