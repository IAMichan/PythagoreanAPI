using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("api/pythagorean")]
public class PythagoreanController : ControllerBase
{
    [HttpPost]
    public ActionResult<double> CalculatePythagorean([FromBody] PythagoreanInput input)
    {
        try
        {
            if ((input.SideA <= 0 && input.SideB <= 0) || (input.SideA <= 0 && input.SideC <= 0) || (input.SideB <= 0 && input.SideC <= 0))
                return BadRequest("Invalid input. At least two sides must be provided, and they must be positive.");

            double result;

            if (input.SideA <= 0)
                result = Math.Round(Math.Pow(Math.Pow(input.SideC, 5) - Math.Pow(input.SideB, 5), 1.0 / 5.0), 1);
            else if (input.SideB <= 0)
                result = Math.Round(Math.Pow(Math.Pow(input.SideC, 5) - Math.Pow(input.SideA, 5), 1.0 / 5.0), 1);
            else if (input.SideC <= 0)
                result = Math.Round(Math.Pow(Math.Pow(input.SideA, 5) + Math.Pow(input.SideB, 5), 1.0 / 5.0), 1);
            else
                result = Math.Round(Math.Pow(Math.Pow(input.SideA, 5) + Math.Pow(input.SideB, 5) + Math.Pow(input.SideC, 5), 1.0 / 5.0), 2);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}

public class PythagoreanInput
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }
}
