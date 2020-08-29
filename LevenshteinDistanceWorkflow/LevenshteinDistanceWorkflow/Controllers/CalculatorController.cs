using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LevenshteinDistanceWorkflow.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LevenshteinDistanceWorkflow.Controllers
{    
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        /// <summary>
        /// Calculate the distance between words
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        
        // GET api/[Controller]?firstWord=[source]&secondWord=[target]
        [Authorize]
        [HttpGet]
        public int GetDistance(string source, string target)
        {
            try
            {
                //Validation for input parameters
                if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(target))
                {
                    throw new ArgumentNullException("Input values are empty.");
                }

                if (!Regex.IsMatch(source, @"^[a-zA-Z]+$") || !Regex.IsMatch(target, @"^[a-zA-Z]+$"))
                {
                    throw new ArgumentOutOfRangeException("Input values are not valid.");
                }

                //Compute distance
                return CalculateDistanceService.Compute(source, target);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        [AllowAnonymous]
        [HttpGet("Welcome")]
        public string Welcome()
        {
            try
            {
                return "The API Server is running successfully.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}