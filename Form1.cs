using stringGraph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Task_B
{
    public partial class Form1 : Form
    {
        Graph names = new Graph();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            // Add a new node to the graph with the name specified in txtName
            names.AddNode(txtName.Text);
            txtName.Clear();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            // Connect two nodes in the graph based on the values in txtFrom and txtTo
            string from = txtFrom.Text;
            string to = txtTo.Text;
            names.AddEdge(from, to);
            txtFrom.Clear();
            txtTo.Clear();
        }

        private void btnSHowUsers_Click(object sender, EventArgs e)
        {
            // Display all the nodes (users) in the graph
            Users.DataSource = null;
            Users.DataSource = names.DisplayGraph();
        }

        private void btnShowFriends_Click(object sender, EventArgs e)
        {
            // Display the friends of a specific user
            string user = txtName.Text;
            Users.DataSource = null;
            Users.DataSource = names.DisplayAdjNodes(user);
        }
    }
}
