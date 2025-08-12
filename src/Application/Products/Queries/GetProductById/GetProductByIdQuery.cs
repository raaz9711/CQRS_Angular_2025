using Domain;
using MediatR;

namespace Application.Products.Queries.GetProductById;

public sealed record GetProductByIdQuery(int Id) : IRequest<Product?>;
