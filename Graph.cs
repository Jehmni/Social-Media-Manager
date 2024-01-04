using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task_B;

namespace stringGraph
{
    public class Graph
    {
        // a list that will hold the nodes in the graph
        private LinkedList<GraphNode> nodes;

        // constructor to set the list of nodes to an empty list
        public Graph()
        {
            nodes = new LinkedList<GraphNode>();
        }

        public void AddNode(String id)
        {
            nodes.AddLast(new GraphNode(id));
        }

        // return node when id specified
        public GraphNode GetNode(String id)
        {
            foreach (GraphNode node in nodes)
            {
                if (id.CompareTo(node.ID) == 0)
                    return node;
            }

            return null;
        }

        // add a directed edge between node "from" and node "to" (here given in input by their "id")
        // get the graphnodes that correspond to the IDs in input
        // use the method in graphnode to add a directed edge
        public void AddEdge(string from, string to)
        {
            // get the graphnode that corresponds to the node with id = from
            GraphNode node1 = GetNode(from);

            // get the graphnode that corresponds to the node with id = to
            GraphNode node2 = GetNode(to);

            // add a directed edge going from node n1 to node n2 
            // (use the AddEdge method defined in the class GraphNode)
            node1.AddEdge(node2);
        }

        public bool IsEmptyGraph()
        {
            // Check if the number of elements within the list of nodes is equal to 0
            // If it is, return true; otherwise, return false
            return nodes.Count == 0;
        }

        public int NumberOfNodes()
        {
            // Return the number of nodes in the graph
            return nodes.Count;
        }

        public List<string> DisplayAdjNodes(string inputID)
        {
            // Define a list where we are going to store the adjacency list of the node
            LinkedList<string> friends = new LinkedList<string>();

            // Get the GraphNode of the node with id = inputID
            // and store it in the variable n
            GraphNode n = GetNode(inputID);

            // Get and store in friends the adjacency list of the node n
            friends = n.GetAdjList();

            // Create a list to store the node IDs
            List<string> nodeIds = new List<string>();

            // Add the IDs of all nodes that are in the adjacency list to nodeIds list
            foreach (string ni in friends)
            {
                nodeIds.Add(ni);
            }

            // Return the nodeIds list
            return nodeIds;
        }

        // Return true only if the node with the specific ID (passed as an argument) is present in the graph
        public bool ContainsGraph(string ID)
        {
            foreach (GraphNode n in nodes)
            {
                // Check if the ID of node "n" is equal to the ID passed as an input argument
                // If they are equal, return true
                if (n.ID.CompareTo(ID) == 0)
                    return true;
            }

            // The foreach loop completed, but the node has not been found, so return false
            return false;
        }


        // Method to display the graph
        public List<string> DisplayGraph()
        {
            // Create a list to store the node IDs
            List<string> nodeIds = new List<string>();

            // Iterate over each node in the graph
            foreach (GraphNode n in nodes)
            {
                // Add the ID of the current node to the nodeIds list
                nodeIds.Add(n.ID);
            }

            // Return the list of node IDs
            return nodeIds;
        }
    }
}
