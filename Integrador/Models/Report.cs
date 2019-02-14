using Integrador.Models.Interface;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Models.Clases
{
    public class Report 
    {
        public ObjectId Id { get; set; }
        public string SearchName { get; set; }
        public string DisplayName { get; set; }
        public int Periodo { get; set; }
        public double Value { get; set; }

        public Report(string _searchName, string _displayName, int _periodo, double _value)
        {
            SearchName = _searchName;
            DisplayName = _displayName;
            Periodo = _periodo;
            Value = _value;
        }
    }

}