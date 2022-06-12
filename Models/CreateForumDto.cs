using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learningSystem.Entities;
using System.ComponentModel.DataAnnotations;

namespace learningSystem.Entities
{
    public class CreateForumDto
    {
        public string author { get; set; }
        public string title { get; set; }
        public string text { get; set; }
    }

}
