
using UnityEngine;
public class Node : OSMElement
{
    public float ele;
    public float local_x;
    public float local_y;
    public Node() { }
    public Vector3 GetPosition()
    {
        return new Vector3(local_x, ele, local_y);
    }
}
