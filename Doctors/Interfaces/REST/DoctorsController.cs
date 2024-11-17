using System.Net.Mime;
using HealMeAppBackend.API.Doctors.Domain.Model.Queries;
using HealMeAppBackend.API.Doctors.Domain.Services;
using HealMeAppBackend.API.Doctors.Interfaces.REST.Resources;
using HealMeAppBackend.API.Doctors.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

namespace HealMeAppBackend.API.Doctors.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Doctors")]
public class DoctorsController(
    IDoctorCommandService doctorCommandService,
    IDoctorQueryService doctorQueryService) : ControllerBase
{
    /// <summary>
    ///     Creates a new doctor.
    /// </summary>
    /// <param name="resource">The resource containing the doctor's details.</param>
    /// <returns>A response with the created doctor's details.</returns>
    
    [HttpPost]
    [Authorize]
    [SwaggerOperation(
        Summary = "Create a doctor",
        Description = "Create a doctor with a given name, description, and rating",
        OperationId = "CreateDoctor"
        )]
    [SwaggerResponse(201, "The doctor was created", typeof(DoctorResource))]
    public async Task<ActionResult> CreateDoctor([FromBody] CreateDoctorResource resource)
    {
        var createDoctorCommand = CreateDoctorCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await doctorCommandService.Handle(createDoctorCommand);

        if (result is null) return BadRequest();

        return CreatedAtAction(nameof(GetDoctorById), new { id = result.Id }, DoctorResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    /// <summary>
    ///     Gets a doctor by name.
    /// </summary>
    /// <param name="name">The doctor's name.</param>
    /// <returns>The doctor's details.</returns>
    
    [HttpGet]
    [Authorize]
    [SwaggerOperation(
        Summary = "Gets a doctor according to parameters",
        Description = "Gets a doctor for a given name",
        OperationId = "GetDoctorByName"
        )]
    [SwaggerResponse(200, "Result(s) was/were found", typeof(DoctorResource))]
    public async Task<ActionResult> GetDoctorByName([FromQuery] string name)
    {
        var getDoctorByNameQuery = new GetDoctorByNameQuery(name);
        var result = await doctorQueryService.Handle(getDoctorByNameQuery);
        if (result is null) return BadRequest();
        var resource = DoctorResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    /// <summary>
    /// Gets a doctor by ID.
    /// </summary>
    /// <param name="id">The doctor's ID.</param>
    /// <returns>The doctor's details.</returns>
    [HttpGet("{id}")]
    [Authorize]
    [SwaggerOperation(
        Summary = "Gets a doctor by id",
        Description = "Gets a doctor for a given doctor identifier",
        OperationId = "GetDoctorById"
        )]
    [SwaggerResponse(200, "The doctor was found", typeof(DoctorResource))]
    public async Task<ActionResult> GetDoctorById(int id)
    {
        var getDoctorByIdQuery = new GetDoctorByIdQuery(id);
        var result = await doctorQueryService.Handle(getDoctorByIdQuery);
        if (result is null) return BadRequest();
        var resource = DoctorResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

     /// <summary>
    ///     Gets doctors by rating.
    /// </summary>
    /// <param name="rating">The doctors' rating.</param>
    /// <returns>A list of doctors with the specified rating.</returns>
    
    [HttpGet("rating/{rating}")]
    [Authorize]
    [SwaggerOperation(
    Summary = "Gets doctors by rating",
    Description = "Gets all doctors with the specified rating",
    OperationId = "GetDoctorsByRating"
)]
    [SwaggerResponse(200, "Doctors were found", typeof(IEnumerable<DoctorResource>))]
    public async Task<ActionResult> GetDoctorsByRating(int rating)
    {
        var getDoctorByRatingQuery = new GetDoctorByRatingQuery(rating);
        var results = await doctorQueryService.Handle(getDoctorByRatingQuery);

        if (results == null || !results.Any())
            return NotFound();

        var resources = results.Select(DoctorResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

}
