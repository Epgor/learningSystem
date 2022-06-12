using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learningSystem.Entities;


namespace learningSystem.Entities
{
    public class ForumDto
    {
        public int id { get; set; }
        public string author { get; set; }
        public string data { get; set; }
        public string title { get; set; }
        public string text { get; set; }

    }

}
