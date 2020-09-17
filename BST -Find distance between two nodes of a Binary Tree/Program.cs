using System;

namespace BST__Find_distance_between_two_nodes_of_a_Binary_Tree
{
    class Program
    {
        class Node
        {
            public int value;
            public Node left, right;

            public Node(int value)
            {
                this.value = value;
                left = right = null;
            }
        }
        static void Main(string[] args)
        {
            Node root = new Node(5);
            root.left = new Node(2);
            root.right = new Node(12);
            root.left.left = new Node(1);
            root.left.right = new Node(3);
            root.right.left = new Node(9);
            root.right.right = new Node(21);
            root.right.right.left = new Node(19);
            root.right.right.right = new Node(25);

            Console.WriteLine("Dist(3, 25) = " + NodeDistance(root, 3, 25));
        }

        static Node LCAIteretive(Node root, int a, int b)
        {
            if (root == null) return null;

            while (root != null)
            {
                if (root.value > a && root.value > b)
                    root = root.left;

                else if (root.value < a && root.value < b)
                    root = root.right;
                else
                    break;
            }
            return root;
        }

        static int NodeDistance(Node root, int a, int b)
        {
            // Find the LCA
            // find distance from LCA to a + find distance from LCA to b
            Node lca = LCAIteretive(root, a, b);
            int dist1 = FindLevel(lca, a, 0);
            int dist2 = FindLevel(lca, b, 0);

            return dist1 + dist2;
        }

        static int FindLevel(Node root, int a, int level)
        {
            if (root == null) return -1;
            if (root.value == a) return level;
            int i = FindLevel(root.left, a, level + 1);
            if (i == -1)
                return FindLevel(root.right, a, level + 1);

            return i;
        }
    }
}
