using MoviesRentalService.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;

namespace MoviesRentalService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MoviesService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MoviesService.svc or MoviesService.svc.cs at the Solution Explorer and start debugging.
    public class MoviesService : IMoviesService
    {
        private readonly MovieBL _businessLogic;

        public MoviesService()
        {
            _businessLogic = new MovieBL();
        }

        public bool AddMovie(string name, string imagePath, string description)
        {
            return _businessLogic.AddMovie(name, imagePath, description);
        }

        public bool DeleteMove(int movieId)
        {
            return _businessLogic.DeleteMovie(movieId);
        }

        public string GetAllMovies()
        {
            var movies = _businessLogic.GetAllMovies();

            return movies == null ? null : JsonConvert.SerializeObject(movies);
        }

        public string GetMovie(int movieId)
        {
            var movie = _businessLogic.GetMovie(movieId);
            return movie == null ? null : JsonConvert.SerializeObject(movie);
        }

        public bool RentMovie(int movieId, int userId)
        {
            return _businessLogic.RentMovie(userId, movieId);
        }
    }
}
