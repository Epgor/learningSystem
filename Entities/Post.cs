using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace learningSystem.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public string Text { get; set; }
        public int ForumId { get; set; }
        public Forum Forum { get; set; }


    }

}

//var dat1 = new DateTime();
// The following method call displays 1/1/0001 12:00:00 AM.
//Console.WriteLine(dat1.ToString(System.Globalization.CultureInfo.InvariantCulture));
// The following method call displays True.
//Console.WriteLine(dat1.Equals(DateTime.MinValue)); 