﻿using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerSwag.Common
{
    public class Users
    {
        [PrimaryKey]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }


    }
}
