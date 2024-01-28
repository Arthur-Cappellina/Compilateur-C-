namespace Graphique;
using System.Windows.Forms;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;

public class TreeVisualizer : Form
{
    
        private static int openFormCount = 0;
        private static readonly object lockObject = new object();

        public static void DrawTree(Graph graph, Graph g2)
        {
            // Créer une copie indépendante du graphique pour chaque fenêtre

            // Créer les viewers et les formulaires pour chaque fenêtre
            GViewer viewer1 = new GViewer();
            viewer1.Graph = graph;

            Form form1 = new Form();
            form1.FormClosed += FormClosedHandler;
            form1.Tag = viewer1; // Tag est utilisé pour stocker une référence à l'objet GViewer
            form1.SuspendLayout();
            viewer1.Dock = DockStyle.Fill;
            form1.Name = "AST";
            form1.Controls.Add(viewer1);
            form1.ResumeLayout();

            GViewer viewer2 = new GViewer();
            viewer2.Graph = g2;

            Form form2 = new Form();
            form2.FormClosed += FormClosedHandler;
            form2.Tag = viewer2; // Tag est utilisé pour stocker une référence à l'objet GViewer
            form2.SuspendLayout();
            viewer2.Dock = DockStyle.Fill;
            form2.Name = "Parse Tree";
            form2.Controls.Add(viewer2);
            form2.ResumeLayout();

            // Afficher simultanément les deux fenêtres
            form1.ShowDialog();
            form2.ShowDialog();

            // Démarrer l'application
            Application.Run();
        }

        private static void FormClosedHandler(object sender, FormClosedEventArgs e)
        {
            lock (lockObject)
            {
                openFormCount--;

                if (openFormCount == 0)
                {
                    Application.Exit();
                }
            }
        }

    private static Graph CloneGraph(Graph original)
    {
        Graph clone = new Graph("clone");
        foreach (Node node in original.Nodes)
        {
            Node clonedNodeSpecial = new Node(node.Id);

            clone.AddNode(clonedNodeSpecial);
        }

        foreach (Edge edge in original.Edges)
        {
            clone.AddEdge(edge.Source, edge.Target);
        }

        return clone;
    }
}