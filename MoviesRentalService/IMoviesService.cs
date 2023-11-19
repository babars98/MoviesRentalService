using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MoviesRentalService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMoviesService" in both code and config file together.
    [ServiceContract]
    public interface IMoviesService
    {
        [OperationContract]
        string GetAllMovies();

        [OperationContract]
        string GetMovie(int movieId);

        [OperationContract]
        bool AddMovie(string name, string imagePath, string description);

        [OperationContract]
        bool DeleteMove(int movieId);

        [OperationContract]
        bool RentMovie(int movieId, int userId);

    }
}
