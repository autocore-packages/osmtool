using System;
using System.IO;
using System.Xml;
using UnityEngine;
namespace AutoCore.OSM
{
    public class OSMReader : MonoBehaviour
    {
        public string fileName;
        //private OSMData data;
        public OSMData GetOSMData()
        {
            ReadOSM(fileName, out OSMData data);
            return data;
        }
        void ReadOSM(string path,out OSMData data)
        {
            data = new OSMData();
            path = Application.streamingAssetsPath + "/" + path;
            if (File.Exists(path))
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(path);
                XmlNode OSMNode = xml.SelectSingleNode("osm");
                XmlNodeList nodeXmlList = OSMNode.SelectNodes("node");
                XmlNodeList wayXmlList = OSMNode.SelectNodes("way");
                XmlNodeList relationXmlList = OSMNode.SelectNodes("relation");
                foreach (XmlNode nodeNode in nodeXmlList)
                {
                    Node node = new Node();
                    node.id = int.Parse(nodeNode.Attributes["id"].Value);
                    XmlNodeList tags = nodeNode.SelectNodes("tag");
                    foreach (XmlNode nodeTag in tags)
                    {
                        float value = float.Parse(nodeTag.Attributes["v"].Value);
                        switch (nodeTag.Attributes["k"].Value)
                        {
                            case "ele":
                                node.ele = value;
                                break;
                            case "local_x":
                                node.local_x = value;
                                break;
                            case "local_y":
                                node.local_y = value;
                                break;
                            default:
                                break;
                        }
                    }
                    data.nodes.Add(node);
                }
                foreach (XmlNode wayNode in wayXmlList)
                {
                    Way way = new Way();
                    way.id = int.Parse(wayNode.Attributes["id"].Value);
                    XmlNodeList nds = wayNode.SelectNodes("nd");
                    foreach (XmlNode nd in nds)
                    {
                        way.nodes.Add(int.Parse(nd.Attributes["ref"].Value));
                    }
                    XmlNodeList tags = wayNode.SelectNodes("tag");
                    foreach (XmlNode nodeTag in tags)
                    {
                        string value = nodeTag.Attributes["v"].Value;
                        switch (nodeTag.Attributes["k"].Value)
                        {
                            case "type":
                                way.type = (WayType)Enum.Parse(typeof(WayType), value);
                                break;
                            case "subtype":
                                way.subType = (WaySubType)Enum.Parse(typeof(WaySubType), value);
                                break;
                            case "height":
                                way.height = float.Parse(value);
                                break;
                            default:
                                break;
                        }
                    }
                    data.ways.Add(way);
                }
                foreach (XmlNode relationNode in relationXmlList)
                {
                    Relation relation = new Relation();
                    relation.id = int.Parse(relationNode.Attributes["id"].Value);
                    XmlNodeList members = relationNode.SelectNodes("member");
                    foreach (XmlNode nodeMember in members)
                    {
                        Member member = new Member();
                        member.menberType = (MemberType)Enum.Parse(typeof(MemberType), nodeMember.Attributes["type"].Value);
                        member.refID =int.Parse( nodeMember.Attributes["ref"].Value);
                        if(nodeMember.Attributes["role"] !=null)
                        member.roleType=(RoleType)Enum.Parse(typeof(RoleType), nodeMember.Attributes["role"].Value);
                        relation.menbers.Add(member);
                    }
                    XmlNodeList tags = relationNode.SelectNodes("tag");
                    foreach (XmlNode nodeTag in tags)
                    {
                        string value = nodeTag.Attributes["v"].Value;
                        switch (nodeTag.Attributes["k"].Value)
                        {
                            case "type":
                                relation.type = (RelationType)Enum.Parse(typeof(RelationType), value);
                                break;
                            case "subtype":
                                relation.subType = (RelationSubType)Enum.Parse(typeof(RelationSubType), value);
                                break;
                            case "turn_direction":
                                relation.turn_direction = (TurnDirection)Enum.Parse(typeof(TurnDirection), value);
                                break;
                            default:
                                break;
                        }
                    }
                    data.relations.Add(relation);
                }
            }
            else
            {
                Debug.LogError("No Document");
            }
        }
    }
}
