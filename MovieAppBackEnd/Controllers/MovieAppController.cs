using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAppBackEnd.DAL;
using MovieAppBackEnd.Models;
using MovieAppBackEnd.Models.Model.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieAppController : ControllerBase
    {
        private readonly MovieAppDbContext ctx;



        public MovieAppController(MovieAppDbContext context)
        {
            ctx = context;
        }


        [HttpPost("IsLoggedIn")]
        public User PostIsLoggedIn(Login login)
        {
            var user = ctx.Users.Find(login.UserName);


            if(user == null)
            {
                return null;

            }
            else
            {
                if(user.Password == login.Password)
                {
                    return user;
                }

                else
                {
                    return null;
                }
            }
        }


        [HttpGet("movies")]
        public IEnumerable<MovieList> GetMovies()
        {
            return ctx.MovieLists;
        }

        [HttpGet("moviesSample")]
        public string Getmovies()
        {
            return ctx.MovieLists.FirstOrDefault().ToString();
        }


        [HttpGet("movies/movie")]
        public MovieList GetMovieByName(string title)
        {
            
            var movie = ctx.MovieLists.First(movie => movie.Title == title);

            return movie;
        }


        [HttpPut("movies/movie/edit/a")]
        public MovieList PutMovie(MovieList edit)
        {

            var movie = ctx.MovieLists.First(movie => movie.Title == edit.Title);

            movie.BoxOffice = edit.BoxOffice;
            movie.Active = edit.Active;
            movie.DateOfLaunch = edit.DateOfLaunch;
            movie.Genre = edit.Genre;
            movie.HasTeaser = edit.HasTeaser;

            ctx.SaveChanges();

            return edit;
        }


        [HttpPost("addFavorite")]
        public Models.Model.MVC.Favorite PostAddFavorite(Models.Model.MVC.Favorite value)
        {
            Models.Favorite f = new Models.Favorite();
            f.Title = value.Title;
            f.UserName = value.UserName;

            var fav = ctx.favorites.Where(a => a.UserName == value.UserName && a.Title == value.Title).FirstOrDefault();
            if (fav != null)
            {
                return null;
            }
            else
            {
                ctx.favorites.Add(f);
                ctx.SaveChanges();
                Models.Model.MVC.Favorite obj = new Models.Model.MVC.Favorite();
                obj.Title = value.Title;
                obj.UserName = value.UserName;

                return obj;
                
            }
            

        }

        [HttpPost("removeFavorite")]
        public void PostRemoveFavourite(Models.Model.MVC.Favorite value)
        {
            var obj = ctx.favorites.Where(f => f.Title.Equals(value.Title) && f.UserName.Equals(value.UserName)).FirstOrDefault();

            ctx.Remove(obj);
            ctx.SaveChanges();


        }


        [HttpGet("getAllFavorite")]
        public IEnumerable<Models.Favorite> GetFavorite(string name)
        {

            var favoriteList = ctx.favorites.Where(user => user.UserName == name).ToList();

            return favoriteList;

        }
        [HttpPost("addUser")]
        public void addUser(User value)
        {

            ctx.Users.Add(value);

            ctx.SaveChanges();


        }

        [HttpPost("addMovie")]
        public MovieList addMovie(MovieList movie)
        {
            var mov = ctx.MovieLists.Where(a => a.Title == movie.Title).FirstOrDefault();
            if (mov != null)
            {
                return null;
            }
            else
            {
                ctx.MovieLists.Add(movie);

                ctx.SaveChanges();
                return movie;

            }
            


        }

        [HttpDelete("deleteMovie")]
        public void deleteMovie(string name)
        {
            var movie = ctx.MovieLists.Where(a => a.Title.Equals(name)).FirstOrDefault();
            ctx.MovieLists.Remove(movie);
            ctx.SaveChanges();
        }

        
    }
}
