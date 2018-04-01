using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeViewDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TreeNode tovarNode = new TreeNode("Товары");
            //Добавляем новый дочерний узел к TovarNode
            var tablet = tovarNode.Nodes.Add(new TreeNode("Планшеты"));
            tovarNode.Nodes[tablet].Nodes.Add("iPad 2018");
            //Добавляем tovarNode вместе с дочернимы узлами в treeView
            treeView1.Nodes.Add(tovarNode);
            //Добавим второй дочерний узел к первому узлу treeView
            treeView1.Nodes[0].Nodes.Add("Смартфоны");
            //удаление у первого узла второго дочернего подузла
            treeView1.Nodes[0].Nodes.RemoveAt(1);
            //удаления узла tovarNode и всех его дочерних элементов
            treeView1.Nodes.Remove(tovarNode);


        }
    }
}
