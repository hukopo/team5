using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace thegame.Controllers
{
    [Route("api/game")]
    public class GameController : Controller
    {
        [HttpGet("score")]
        public IActionResult Score()
        {
            var random = new Random();
            return Ok((int)Math.Pow(2, random.Next(1, 7)));
        }

        [HttpGet("{userId}/map")]
        [Produces("application/json")]
        public IActionResult Map([FromRoute] Guid userId)
        {
            //var mapRepo = GamesKeeper.GetMap(userId);
            var random = new Random();
            var x = Math.Pow(2, random.Next(1, 7));
            var map = new[,]
            {
                {
                     (int)Math.Pow(2, random.Next(1, 7)), (int)Math.Pow(2, random.Next(1, 7)), (int)Math.Pow(2, random.Next(1, 7)), 

                },
                {
                    (int)Math.Pow(2, random.Next(1, 7)),(int)Math.Pow(2, random.Next(1, 7)),(int)Math.Pow(2, random.Next(1, 7)),
                },
                {
                    (int)Math.Pow(2, random.Next(1, 7)), (int)Math.Pow(2, random.Next(1, 7)), (int)Math.Pow(2, random.Next(1, 7))

                }

               /* {
                     (int)Math.Pow(2, random.Next(1, 7)), (int)Math.Pow(2, random.Next(1, 7)), (int)Math.Pow(2, random.Next(1, 7)), (int)Math.Pow(2, random.Next(1, 7))

                },
                {
                    (int)Math.Pow(2, random.Next(1, 7)),(int)Math.Pow(2, random.Next(1, 7)),(int)Math.Pow(2, random.Next(1, 7)),(int)Math.Pow(2, random.Next(1, 7))
                },
                {
                    (int)Math.Pow(2, random.Next(1, 7)), (int)Math.Pow(2, random.Next(1, 7)), (int)Math.Pow(2, random.Next(1, 7)), (int)Math.Pow(2, random.Next(1, 7))

                },
                {
                    (int)Math.Pow(2, random.Next(1, 7)), (int)Math.Pow(2, random.Next(1, 7)), (int)Math.Pow(2, random.Next(1, 7)), (int)Math.Pow(2, random.Next(1, 7))

                } */
            };
            return Ok(map);
        }

        [Route("{userId}/move/{side}")]
        [Produces("application/json")]
        public IActionResult Move([FromRoute] Guid userId, [FromRoute] string direction)
        {
            // var dirs = Enum.GetNames(typeof(Direction)).Select(x => x.ToLower());
            //if (dirs.Contains(direction))
            //{
//                GamesKeeper.MakeMove(userId, direction);
            //Console.WriteLine(123);
            return Ok(direction);
            // }
            //return BadRequest();
        }
    }
}