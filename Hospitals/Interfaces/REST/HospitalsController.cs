using System.Net.Mime;
using HealMeAppBackend.API.Hospitals.Application.Internal;
using HealMeAppBackend.API.Hospitals.Domain.Model.Queries;
using HealMeAppBackend.API.Hospitals.Domain.Services;
using HealMeAppBackend.API.Hospitals.Interfaces.REST.Resources;
using HealMeAppBackend.API.Hospitals.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HealMeAppBackend.API.Hospitals.Interfaces.REST;
    /// <summary>
    ///     Controller for managing hospital-related operations.
    /// </summary>
    /// <remarks>
    ///     Provides endpoints for creating hospitals, retrieving hospitals by various criteria, 
    ///     and managing their data in a RESTful manner.
    /// </remarks>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Hospitals")]

        /// <summary>
        ///     Initializes a new instance of the <see cref="HospitalsController"/> class.
        /// </summary>
        /// <param name="hospitalCommandService">Service for handling hospital commands.</param>
        /// <param name="hospitalQueryService">Service for handling hospital queries.</param>
public class HospitalsController(
    IHospitalCommandService hospitalCommandService,
    IHospitalQueryService hospitalQueryService) : ControllerBase
{
     /// <summary>
    ///     Creates a new hospital.
    /// </summary>
    /// <param name="resource">The hospital details for creation.</param>
    /// <returns>The created hospital as a resource.</returns>
    [HttpPost]
    [Authorize]
    [SwaggerOperation(
        Summary = "Create a hospital",
        Description = "Create a hospital with a given name, description, location, and rating",
        OperationId = "CreateHospital"
        )]
    [SwaggerResponse(201, "The hospital was created", typeof(HospitalResource))]
    public async Task<ActionResult> CreateHospital([FromBody] CreateHospitalResource resource)
    {
        var createHospitalCommand = CreateHospitalCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await hospitalCommandService.Handle(createHospitalCommand);

        if (result is null) return BadRequest();

        return CreatedAtAction(nameof(GetHospitalById), new { id = result.Id }, HospitalResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    /// <summary>
    ///     Retrieves a hospital by its name.
    /// </summary>
    /// <param name="name">The name of the hospital to retrieve.</param>
    /// <returns>The hospital resource if found.</returns>
    [HttpGet]
    [Authorize]
    [SwaggerOperation(
        Summary = "Gets a hospital according to parameters",
        Description = "Gets a hospital for a given name",
        OperationId = "GetHospitalByName"
        )]
    [SwaggerResponse(200, "Result(s) was/were found", typeof(HospitalResource))]
    public async Task<ActionResult> GetHospitalByName([FromQuery] string name)
    {
        var getHospitalByNameQuery = new GetHospitalByNameQuery(name);
        var result = await hospitalQueryService.Handle(getHospitalByNameQuery);
        if (result is null) return BadRequest();
        var resource = HospitalResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

     /// <summary>
    ///     Retrieves a hospital by its ID.
    /// </summary>
    /// <param name="id">The ID of the hospital to retrieve.</param>
    /// <returns>The hospital resource if found.</returns>
    [HttpGet("{id}")]
    [Authorize]
    [SwaggerOperation(
        Summary = "Gets a hospital by id",
        Description = "Gets a hospital for a given hospital identifier",
        OperationId = "GetHospitalById"
        )]
    [SwaggerResponse(200, "The hospital was found", typeof(HospitalResource))]
    public async Task<ActionResult> GetHospitalById(int id)
    {
        var getHospitalByIdQuery = new GetHospitalByIdQuery(id);
        var result = await hospitalQueryService.Handle(getHospitalByIdQuery);
        if (result is null) return BadRequest();
        var resource = HospitalResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    /// <summary>
    ///     Retrieves hospitals by their rating.
    /// </summary>
    /// <param name="rating">The rating to filter hospitals by.</param>
    /// <returns>A list of hospitals with the specified rating.</returns>
    [HttpGet("rating/{rating}")]
    [Authorize]
    [SwaggerOperation(
    Summary = "Gets hospital by rating",
    Description = "Gets all hospital with the specified rating",
    OperationId = "GetHospitalByRating"
)]
    [SwaggerResponse(200, "Hospitals were found", typeof(IEnumerable<HospitalResource>))]
    public async Task<ActionResult> GetHospitalsByRating(int rating)
    {
        var getHospitalByRatingQuery = new GetHospitalByRatingQuery(rating);
        var results = await hospitalQueryService.Handle(getHospitalByRatingQuery);

        if (results == null || !results.Any())
            return NotFound();

        var resources = results.Select(HospitalResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

}
