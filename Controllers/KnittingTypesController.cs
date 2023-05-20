using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KnittingTypesController : ControllerBase
{
    private static readonly List<KnittingType> KnittingTypes = new()
    {
        new()
        {
            Id = "gloves",
            ImageSource = "gloves.png",
            Label = "Gloves"
        },
        new()
        {
            Id = "hat",
            ImageSource = "hat.png",
            Label = "Hat"
        },
        new()
        {
            Id = "scarf",
            ImageSource = "scarf.png",
            Label = "Scarf"
        },
        new()
        {
            Id = "socks",
            ImageSource = "socks.png",
            Label = "Socks"
        },
        new()
        {
            Id = "sweater",
            ImageSource = "sweater.png",
            Label = "Sweater"
        }
    };

    private readonly ILogger<KnittingTypesController> _logger;

    public KnittingTypesController(ILogger<KnittingTypesController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetKnittingTypes")]
    public IEnumerable<KnittingType> Get()
    {
        var list = KnittingTypes.ToArray();

        _logger.LogInformation("GetKnittingTypes", list.Length);

        return list;
    }
}
