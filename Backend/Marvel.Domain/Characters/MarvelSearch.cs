using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel.Domain.Characters
{
    public class MarvelSearch
    {
        public string AttributionText { get; set; }
        public Datawrapper Data { get; set; }

        public class Datawrapper
        {
            public List<Result> Results { get; set; }
        }

        public class Result
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public ComicList comics { get; set; }
            public Image Thumbnail { get; set; }

            public class Image
            {
                public string Path { get; set; }
                public string Extension { get; set; }
            }

            public class ComicList
            {
                public int available { get; set; }
                public string collectionURI { get; set; }
                public List<ComicSummary> items { get; set; }
                public int returned { get; set; }
            }

            public class ComicSummary
            {
                public string resourceURI { get; set; }
                public string name { get; set; }
                public string type { get; set; }
            }
        }
    }
}
