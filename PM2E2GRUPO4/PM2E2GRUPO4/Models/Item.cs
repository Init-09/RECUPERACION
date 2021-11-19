﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;


namespace PM2E2GRUPO4.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; } 
        public string Img { get; set; }
        public string Descripcion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}