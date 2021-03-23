using System.Collections.Generic;
namespace AutoCore.OSM
{
    public enum WayType
    {
        line_thin, 
        stop_line, 
        traffic_light, 
        traffic_sign
    }
    public enum WaySubType
    {
        solid, 
        dashed, 
        stop_sign
    }
    public class Way : OSMElement
    {
        public WayType type;
        public WaySubType subType;
        public float height;
        public List<int> nodes;
        public Way()
        {
            nodes = new List<int>();
        }
    }
}