using System;
using Newtonsoft.Json.Linq;

namespace lab.Graph
{
    public class GraphDto
    {

        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; } 

    }
}
