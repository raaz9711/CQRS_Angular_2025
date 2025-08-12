using Application.Common.Abstractions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.Queries.GetProducts;

public sealed class GetProductsHandler(IAppDbContext db) : IRequestHandler<GetProductsQuery, IReadOnlyList<Product>>
{
    public async Task<IReadOnlyList<Product>> Handle(GetProductsQuery request, CancellationToken ct) =>
        await db.Products.AsNoTracking().OrderByDescending(p => p.Id).ToListAsync(ct);
}
