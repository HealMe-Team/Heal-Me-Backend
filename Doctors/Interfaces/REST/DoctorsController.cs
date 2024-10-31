using System.Net.Mime;
using HealMeAppBackend.API.Doctors.Domain.Model.Queries;
using HealMeAppBackend.API.Doctors.Domain.Services;
using HealMeAppBackend.API.Doctors.Interfaces.REST.Resources;
using HealMeAppBackend.API.Doctors.Interfaces.REST.Transform;
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
    [HttpPost]
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

    [HttpGet]
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

    [HttpGet("{id}")]
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
}