using Microsoft.AspNetCore.Mvc;
using ConAPI.Domain;
using ConAPI.Repositories;

namespace ConAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SimpleController : ControllerBase
{
    private ISimpleObjectRepository _repository;

    public SimpleController(ISimpleObjectRepository repository)
    {
        this._repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        IEnumerable<SimpleObject> rsp = await _repository.GetObjects();

        return Ok(rsp);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]SimpleObject request)
    {
        int rsp = await _repository.InsertObject(request);

        return Created();
    }

}
