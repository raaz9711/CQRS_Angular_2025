using Domain;
using MediatR;

namespace Application.Products.Queries.GetProducts;

public sealed record GetProductsQuery() : IRequest<IReadOnlyList<Product>>;
