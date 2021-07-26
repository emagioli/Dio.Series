using System;
using System.Collections.Generic;
using Dio.Series.Interfaces;

namespace Dio.Series
{
    public class SeriesRepository : IRepository<Series>
    {
        private List<Series> seriesList = new List<Series>();
        public List<Series> List()
        {
            return seriesList;
        }
        public Series GetById(int id)
        {
            return seriesList[id];
        }
        public void Insert(Series entity)
        {
            seriesList.Add(entity);
        }
        public void Delete(int id)
        {
            seriesList[id].Delete();
        }
        public void Update(int id, Series entity)
        {
            seriesList[id] = entity;
        }
        public int NextId()
        {
            return seriesList.Count;
        }
    }
}
