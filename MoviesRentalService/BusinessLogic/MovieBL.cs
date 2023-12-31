﻿using MoviesRentalService.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace MoviesRentalService.BusinessLogic
{
    public class MovieBL
    {
        private readonly DataAccess _dataAccess;

        public MovieBL()
        {
            _dataAccess = new DataAccess();
        }

        public bool AddMovie(string name, string imagePath, string description)
        {
            string query = "INSERT INTO dbo.[Movie] (Name,imagePath,description,IsActive,DateCreated) VALUES (@name,@imagepath,@description,@isactive,@datecreated)";

            var param = new Dictionary<string, object>()
            {
                { "@name", name},
                { "@imagepath", imagePath},
                { "@description", description},
                { "@isactive", true },
                { "@datecreated", DateTime.Now }
            };

            return _dataAccess.ExecuteWriteQuery(query, param);
        }

        public bool DeleteMovie(int movieId)
        {
            string query = string.Format("DELETE FROM dbo.[Movie] WHERE MovieId = {0}", movieId);

            return _dataAccess.ExecuteWriteQuery(query, new Dictionary<string, object>());
        }

        public List<ExpandoObject> GetAllMovies()
        {
            string query = "SELECT MovieId,Name,ImagePath FROM dbo.[Movie] WHERE IsActive = 1";

            var datatable = _dataAccess.ExecuteReadQuery(query);

            if (datatable.Rows.Count < 1)
                return null;

            var list = new List<ExpandoObject>();

            foreach(DataRow row in datatable.Rows)
            {
                dynamic obj = new ExpandoObject();
                obj.MovieId = Convert.ToInt32(row["MovieId"]);
                obj.MovieName = row["Name"].ToString();
                obj.ImagePath = row["ImagePath"].ToString();
                obj.IsSuccess = true;
                obj.Message = "Movies Listed Success";

                list.Add(obj);
            }

            return list;
        }

        public object GetMovie(int movieId)
        {
            string query = string.Format("SELECT MovieId,Name,ImagePath,Description FROM dbo.[Movie] WHERE MovieId = {0} AND IsActive = 1", movieId);

            var datatable = _dataAccess.ExecuteReadQuery(query);

            if (datatable.Rows.Count < 1)
                return null;
    
            DataRow row = datatable.Rows[0];
            dynamic obj = new ExpandoObject();

            obj.MovieId = Convert.ToInt32(row["MovieId"]);
            obj.MovieName = row["Name"].ToString();
            obj.ImagePath = row["ImagePath"].ToString();
            obj.Description = row["Description"].ToString();
            obj.IsSuccess = true;
            obj.Message = "Movies Listed Success";

            return obj;
        }

        public List<ExpandoObject> GetRentedMoviesbyUser(int userId)
        {
            string query = string.Format(@"SELECT m.MovieId,m.Name,m.ImagePath,mr.DateRented FROM dbo.[Movie] m 
                                           INNER JOIN MovieRental mr ON mr.MovieId = m.MovieId
                                           WHERE mr.UserId = {0} AND mr.IsRented = 1 AND m.IsActive = 1", userId);

            var datatable = _dataAccess.ExecuteReadQuery(query);

            if (datatable.Rows.Count < 1)
                return null;

            var list = new List<ExpandoObject>();

            foreach (DataRow row in datatable.Rows)
            {
                dynamic obj = new ExpandoObject();
                obj.MovieId = Convert.ToInt32(row["MovieId"]);
                obj.MovieName = row["Name"].ToString();
                obj.ImagePath = row["ImagePath"].ToString();
                obj.DateRented = Convert.ToDateTime(row["DateRented"]);
                obj.IsSuccess = true;
                obj.Message = "Movies Listed Success";

                list.Add(obj);
            }

            return list;
        }

        public bool RentMovie(int userId, int movieId)
        {
            string query = "INSERT INTO dbo.[MovieRental] (UserId,MovieId,DateRented,IsRented) VALUES (@userid,@movieid,@daterented,@isrented)";

            var param = new Dictionary<string, object>()
            {
                { "@userid", userId},
                { "@movieid", movieId},
                { "@daterented", DateTime.Now},
                { "@isrented", true }
            };

            return _dataAccess.ExecuteWriteQuery(query, param);
        }

        public bool CheckMovieAlreadyRented(int userId, int movieId)
        {
            string query = String.Format("SELECT 1 FROM dbo.[MovieRental] WHERE UserId = {0} AND MovieId = {1} AND IsRented = 1", userId, movieId);

            var dt = _dataAccess.ExecuteReadQuery(query);

            return dt.Rows.Count > 0;
        }
    }
}