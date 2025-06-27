using System;

namespace DotNet_Pipeline.Self_Balancing_Trees;

public record AVL_Node
{
    public int data;
    public int height;
    public AVL_Node left;
    public AVL_Node right;
    public AVL_Node(int value)
    {
        this.data = value;
        this.left = null;
        this.right = null;
        this.height = 1;
    }

}

public class Self_Balancing_AVL_Tree
{
    private AVL_Node root;

    private int GetHeight(AVL_Node node)
    {
        if (node == null) return 0;
        return node.height;
    }

    private int GetBalance(AVL_Node node)
    {
        if (node == null) return 0;
        return GetHeight(node.left) - GetHeight(node.right);
    }

    private AVL_Node RightRotate(AVL_Node y)
    {
        AVL_Node x = y.left;
        AVL_Node T2 = x.right;

        // Perform rotation
        x.right = y;
        y.left = T2;

        // Update heights
        y.height = Math.Max(GetHeight(y.left), GetHeight(y.right)) + 1;
        x.height = Math.Max(GetHeight(x.left), GetHeight(x.right)) + 1;

        // Return new root
        return x;
    }

    private AVL_Node LeftRotate(AVL_Node x)
    {
        AVL_Node y = x.right;
        AVL_Node T2 = y.left;

        // Perform rotation
        y.left = x;
        x.right = T2;

        // Update heights
        x.height = Math.Max(GetHeight(x.left), GetHeight(x.right)) + 1;
        y.height = Math.Max(GetHeight(y.left), GetHeight(y.right)) + 1;

        // Return new root
        return y;
    }

    public void Insert(int key)
    {
        root = Insert(root, key);
    }

    private AVL_Node Insert(AVL_Node node, int key)
    {
        if (node == null)
            return new AVL_Node(key);

        if (key < node.data)
            node.left = Insert(node.left, key);
        else if (key > node.data)
            node.right = Insert(node.right, key);
        else // duplicate keys not allowed
            return node;

        // Update height of this ancestor node
        node.height = 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));

        // Get balance factor to check if this node became unbalanced
        int balance = GetBalance(node);

        // If node is unbalanced, there are 4 cases

        // Left Left Case
        if (balance > 1 && key < node.left.data)
            return RightRotate(node);

        // Right Right Case
        if (balance < -1 && key > node.right.data)
            return LeftRotate(node);

        // Left Right Case
        if (balance > 1 && key > node.left.data)
        {
            node.left = LeftRotate(node.left);
            return RightRotate(node);
        }

        // Right Left Case
        if (balance < -1 && key < node.right.data)
        {
            node.right = RightRotate(node.right);
            return LeftRotate(node);
        }


        return node;
    }
}
