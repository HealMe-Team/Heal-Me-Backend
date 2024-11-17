using System.Net.Mime;
using HealMeAppBackend.API.Products.Application.Internal;
using HealMeAppBackend.API.Products.Domain.Model.Queries;
using HealMeAppBackend.API.Products.Domain.Services;
using HealMeAppBackend.API.Products.Interfaces.REST.Resources;
using HealMeAppBackend.API.Products.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HealMeAppBackend.API.Products.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Products")]
public class ProductsController(
    IProductCommandService productCommandService,
    IProductQueryService productQueryService) : ControllerBase
{
    [HttpPost]
    [Authorize]
    [SwaggerOperation(
        Summary = "Create a product",
        Description = "Create a product with a given name, description, price, and rating",
        OperationId = "CreateProduct"
        )]
    [SwaggerResponse(201, "The product was created", typeof(ProductResource))]
    public async Task<ActionResult> CreateProduct([FromBody] CreateProductResource resource)
    {
        var createProductCommand = CreateProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await productCommandService.Handle(createProductCommand);

        if (result is null) return BadRequest();

        return CreatedAtAction(nameof(GetProductById), new { id = result.Id }, ProductResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet]
    [Authorize]
    [SwaggerOperation(
        Summary = "Gets a product by name",
        Description = "Gets a product for a given name",
        OperationId = "GetProductByName"
        )]
    [SwaggerResponse(200, "Result(s) was/were found", typeof(ProductResource))]
    public async Task<ActionResult> GetProductByName([FromQuery] string name)
    {
        var getProductByNameQuery = new GetProductByNameQuery(name);
        var result = await productQueryService.Handle(getProductByNameQuery);
        if (result is null) return BadRequest();
        var resource = ProductResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet("{id}")]
    [Authorize]
    [SwaggerOperation(
        Summary = "Gets a product by id",
        Description = "Gets a product for a given product identifier",
        OperationId = "GetProductById"
        )]
    [SwaggerResponse(200, "The product was found", typeof(ProductResource))]
    public async Task<ActionResult> GetProductById(int id)
    {
        var getProductByIdQuery = new GetProductByIdQuery(id);
        var result = await productQueryService.Handle(getProductByIdQuery);
        if (result is null) return BadRequest();
        var resource = ProductResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet("rating/{rating}")]
    [Authorize]
    [SwaggerOperation(
    Summary = "Gets Product by rating",
    Description = "Gets all Product with the specified rating",
    OperationId = "GetProductsByRating"
)]
    [SwaggerResponse(200, "Products were found", typeof(IEnumerable<ProductResource>))]
    public async Task<ActionResult> GetProductsByRating(int rating)
    {
        var getProductByRatingQuery = new GetProductByRatingQuery(rating);
        var results = await productQueryService.Handle(getProductByRatingQuery);

        if (results == null || !results.Any())
            return NotFound();

        var resources = results.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

}
