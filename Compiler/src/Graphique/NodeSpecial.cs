namespace Graphique;

using System.Collections.Generic;
public class NodeSpecial
{
    public int Value { get; set; }
    public List<NodeSpecial> Children { get; set; }

    public NodeSpecial(int value)
    {
        Value = value;
        Children = new List<NodeSpecial>();
    }
}

    