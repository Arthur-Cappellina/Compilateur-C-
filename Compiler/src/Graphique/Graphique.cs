using Microsoft.Msagl.Drawing;
using Parser;
using Color = Microsoft.Msagl.Drawing.Color;

namespace Graphique;

public class Graphique
{
    
    private static int count = 0; 
    
    public static Graph DisplayParseTree(AbstractTree ast)
    {
        Graph graph = new Graph("AST");
        TreeNode root = new TreeNode(ast.Label + " ("+count++ +")");
        foreach (AbstractTree a in ast.Childrens)
        {
            TreeNode node = ExploreNode(a);
            root.AddChild(node);
        }
        root.ReverseChilds();
        graph = TreeNode.treeToGraph(root, graph);
        return graph;
    }
    
    public static Graph DisplayParseTree(ParseTree parseTree)
    {
        Graph graph = new Graph("Parse Tree");
        TreeNode root = new TreeNode(parseTree.Symbol.GetLabel() + " ("+count++ +")");
        foreach (ParseTree p in parseTree.GetChildrens())
        {
            TreeNode node = ExploreNode(p);
            root.AddChild(node);
        }
        root.ReverseChilds();
        graph = TreeNode.treeToGraph(root, graph);
        return graph;
    }
    
    private static TreeNode ExploreNode(ParseTree parseTree)
    {
        TreeNode node = new TreeNode(parseTree.Symbol.GetLabel() + " ("+count++ +")");
        foreach (ParseTree p in parseTree.GetChildrens())
        {
            TreeNode child = ExploreNode(p);
            node.AddChild(child);
        }

        node.ReverseChilds(); 
        return node;
    }
    
    private static TreeNode ExploreNode(AbstractTree ast)
    {
        TreeNode node = new TreeNode(ast.Label + " ("+count++ +")");
        foreach (AbstractTree a in ast.Childrens)
        {
            TreeNode child = ExploreNode(a);
            node.AddChild(child);
        }

        node.ReverseChilds(); 
        return node;
    }
}
