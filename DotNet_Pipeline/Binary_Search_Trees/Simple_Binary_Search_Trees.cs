using System.Reflection.Metadata.Ecma335;

namespace DotNet_Pipeline.Binary_Search_Trees;

public record BST_Node
{
    public int Data;
    public BST_Node? Left;
    public BST_Node? Right;
    public BST_Node(int value)
    {
        this.Data = value;
        this.Left = null;
        this.Right = null;
    }
}

public class Simple_Binary_Search_Trees
{
    public  BST_Node RootNode;

    public Simple_Binary_Search_Trees(int value)
    {
        this.RootNode = new BST_Node(value);
    }

    public BST_Node? InvertBinaryTree(BST_Node? tree)
    {
        if (tree is null) return null;

        var left = InvertBinaryTree(tree.Left);
        var right = InvertBinaryTree(tree.Right);

        tree.Left = right;
        tree.Right = left;

        return tree;
    }


    public BST_Node? IfNodeExists(int value, BST_Node? tree)
    {
        if (tree is null) return null;

        if (tree.Data == value)
        {
            return tree;
        }
        else if (value < tree.Data)
        {
            return IfNodeExists(value, tree.Left);
        }
        else
        {
            return IfNodeExists(value, tree.Right);
        }
    }


    public BST_Node? DeleteNode(BST_Node? root, int value)
    {
        if (root is null) return null;

        if (value < root.Data)
        {
            root.Left = DeleteNode(root.Left, value);
        }
        else if (value > root.Data)
        {
            root.Right = DeleteNode(root.Right, value);
        }
        else
        {
            // Case 1: No children
            if (root.Left is null && root.Right is null)
            {
                return null;
            }
            // Case 2: One child
            else if (root.Left is null)
            {
                return root.Right;
            }
            else if (root.Right is null)
            {
                return root.Left;
            }
            // Case 3: Two children
            else
            {
                var minNode = FindMin(root.Right);
                root.Data = minNode.Data;
                root.Right = DeleteNode(root.Right, minNode.Data);
            }
        }

        return root;
    }

    private BST_Node FindMin(BST_Node node)
    {
        while (node.Left is not null)
        {
            node = node.Left;
        }
        return node;
    }


    public BST_Node Insert(BST_Node tree, int value)
    {
        if (tree is null)
        {
            return new BST_Node(value);
        }
        else
        {
            if (value < tree.Data)
            {
                tree.Left = this.Insert(tree.Left!, value);
            }
            else
            {
                tree.Right = this.Insert(tree.Right!, value);
            }
        }
        return tree;
    }

    public List<BST_Node> GetTree(BST_Node? tree)
    {
        if (tree is null) return new();

        var left = GetTree(tree.Left);
        var right = GetTree(tree.Right);

        left.Add(tree);
        left.AddRange(right);
        return left;
    }

}
