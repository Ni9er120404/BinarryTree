using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace BinarryTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void TextBox1_TextChanged(object sender, EventArgs e) { }
        private void TextBox2_TextChanged(object sender, EventArgs e) { }
        private void Button13_Click(object sender, EventArgs e)
        {
            Answer answer = new Answer(n: textBox1.Text);
            textBox2.AppendText(text: $"{answer.Ans_1}\t{answer.Ans_2}\t{answer.Ans_3}");
        }
        private void Button12_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(text: "9");
        }
        private void Button11_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(text: "8");
        }
        private void Button10_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(text: "7");
        }
        private void Button9_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(text: "6");
        }
        private void Button8_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(text: "5");
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(text: "4");
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(text: "3");
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(text: "2");
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(text: "1");
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(text: " ");
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(text: "0");
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(text: "-");
        }
    }
    internal class Node<T> : IComparable, IComparable<T>
        where T : IComparable, IComparable<T>
    {
        public T Data { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; private set; }

        public Node(T data)
        {
            Data = data;
        }

        public Node(T data, Node<T> left, Node<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (node.Data.CompareTo(Data) == -1)
            {
                if (Left == null)
                {
                    Left = node;
                }

                else
                {
                    Left.Add(data);
                }
            }

            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Add(data);
                }
            }
        }

        public int CompareTo(object obj)
        {
            return obj is Node<T> item ? Data.CompareTo(obj: item) : throw new Exception(message: "Не совпадает тип");
        }

        public int CompareTo(T other)
        {
            return Data.CompareTo(other as Node<T>);
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }

    internal class Tree<T>
        where T : IComparable, IComparable<T>
    {
        public Node<T> Root { get; private set; }

        public int Count { get; private set; }

        public void Add(T data)
        {
            if (Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return;
            }
            Root.Add(data);
            Count++;
        }

        private List<T> Preorder(Node<T> node)
        {
            List<T> list = new List<T>();
            if (node != null)
            {
                list.Add(node.Data);
                if (node.Left != null)
                {
                    list.AddRange(Preorder(node.Left));
                }
                if (node.Right != null)
                {
                    list.AddRange(Preorder(node.Right));
                }
            }
            return list;
        }

        public List<T> Preorder()
        {
            if (Root == null)
            {
                return new List<T>();
            }
            return Preorder(Root);
        }

        private List<T> Postorder(Node<T> node)
        {
            List<T> list = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(Postorder(node.Left));
                }
                if (node.Right != null)
                {
                    list.AddRange(Postorder(node.Right));
                }
                list.Add(node.Data);
            }
            return list;
        }

        public List<T> Postorder()
        {
            if (Root == null)
            {
                return new List<T>();
            }
            return Postorder(Root);
        }
        private List<T> Inorder(Node<T> node)
        {
            List<T> list = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(Inorder(node.Left));
                }
                list.Add(node.Data);
                if (node.Right != null)
                {
                    list.AddRange(Inorder(node.Right));
                }

            }
            return list;
        }

        public List<T> Inorder()
        {
            if (Root == null)
            {
                return new List<T>();
            }
            return Inorder(Root);
        }
    }
    internal class Answer
    {
        public string Ans_1 { get; set; }
        public string Ans_2 { get; set; }
        public string Ans_3 { get; set; }
        public Answer(string n)
        {
            string[] num = n.Split(' ');
            Tree<int> tree = new Tree<int>();
            for (int i = 0; i < num.Length; i++)
            {
                tree.Add(Convert.ToInt32(num[i]));
            }
            foreach (int item in tree.Preorder())
            {
                Ans_1 += $"{item}, ";
            }

            foreach (int item in tree.Postorder())
            {
                Ans_2 += $"{item}, ";
            }

            foreach (int item in tree.Inorder())
            {
                Ans_3 += $"{item}, ";
            }
        }
    }
}