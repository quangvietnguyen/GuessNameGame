using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Movie
    {
        public string Name { get; set; }

        public Movie(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}
