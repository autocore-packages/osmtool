using System.Collections.Generic;

namespace AutoCore.OSM
{
    public class OSMData
    {
        public List<Node> nodes;
        public List<Way> ways;
        public List<Relation> relations;
        public OSMData()
        {
            nodes = new List<Node>();
            ways = new List<Way>();
            relations = new List<Relation>();
        }
    }
}