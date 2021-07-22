using System.Diagnostics;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieTableDLL.Models;
using MovieReminderAPI.Model;
using System.Linq;

namespace MovieReminderAPI.Controllers
{
    [ApiController]
    [Route("moviedate")]
    public class MovieDateReminderController : ControllerBase
    {
        // DB Context
        private readonly MovieContext _context;

        // Constructor
        public MovieDateReminderController(MovieContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public ActionResult<IEnumerable<MovieModels>> GetMovies()
        {
            var items = _context.MovieModels.ToList();
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<MovieModels> GetMoviesById(int id)
        {
            if (id.ToString() == null)
            {
                return BadRequest();
            }

            var item = _context.MovieModels.FirstOrDefault(i => i.ID == id);
            return item;
        }

        // POST
        // with JSON
        [HttpPost]
        public ActionResult<MovieModels> PostMovie(MovieModels movieModels)
        {
            try
            {
                if (movieModels != null)
                {
                    var value = new MovieModels
                    {
                        MovieName = movieModels.MovieName,
                        MovieReleaseDate = movieModels.MovieReleaseDate,
                        MovieAddedDdate = movieModels.MovieAddedDdate
                    };

                    _context.MovieModels.Add(value);
                    _context.SaveChanges();

                    return Ok();
                    // return CreatedAtAction(
                    //     nameof(GetMoviesById), new { id = movieModels.ID }, movieModels);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // with query
        [HttpPost("moviequery")]
        public ActionResult<MovieModels> PostMovieQuery([FromQuery] MovieModels movieModels)
        {
            try
            {
                if (movieModels != null)
                {
                    var value = new MovieModels
                    {
                        MovieName = movieModels.MovieName,
                        MovieReleaseDate = movieModels.MovieReleaseDate,
                        MovieAddedDdate = movieModels.MovieAddedDdate
                    };

                    _context.MovieModels.Add(value);
                    _context.SaveChanges();

                    return Ok();
                    // return CreatedAtAction(
                    //     nameof(GetMoviesById), new { id = movieModels.ID }, movieModels);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // PUT
        [HttpPut("changemoviedata/{id}")]
        public ActionResult<MovieModels> ChangeMovieData(int id, MovieModels movieModels)
        {
            try
            {
                if (id.ToString() != null)
                {
                    if (movieModels != null)
                    {
                        var selectedMovie = _context.MovieModels.Where(i => i.ID == id).FirstOrDefault<MovieModels>();
                        if (selectedMovie != null)
                        {
                            selectedMovie.MovieName = movieModels.MovieName;
                            selectedMovie.MovieAddedDdate = movieModels.MovieAddedDdate;
                            selectedMovie.MovieReleaseDate = movieModels.MovieReleaseDate;

                            _context.SaveChanges();
                            return Ok();
                        }
                    }
                    return BadRequest();
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // DELETE
        [HttpDelete("deletemovie/{id}")]
        public ActionResult<MovieModels> DeleteMovie(int id)
        {
            if (id.ToString() != null)
            {
                var delItem = _context.MovieModels.Where(i => i.ID == id).First<MovieModels>();
                if (delItem != null)
                {
                    _context.Remove<MovieModels>(delItem);
                    _context.SaveChanges();
                    return Ok();
                }
                return BadRequest();
            }
            return BadRequest();
        }
    }
}