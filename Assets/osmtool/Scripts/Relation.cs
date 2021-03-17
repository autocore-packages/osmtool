using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AutoCore.OSM
{
    public enum RelationType
    {
        lanelet = 0,
        regulatory_element=1
    }
    public enum RelationSubType
    {
        road = 0,
        traffic_light=1,
        traffic_sign=2
    }
    public enum TurnDirection
    {
        left=0,
        right=1
    }
    public class Relation : OSMElement
    {
        public RelationType type;
        public RelationSubType subType;
        public TurnDirection turn_direction;
        public List<Member> menbers;
        public Relation()
        {
            menbers = new List<Member>();
        }
    }
}