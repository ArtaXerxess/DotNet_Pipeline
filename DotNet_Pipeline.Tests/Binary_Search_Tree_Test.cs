using DotNet_Pipeline.Binary_Search_Trees;

namespace DotNet_Pipeline.Tests;

public class Binary_Search_Tree_Test
{
    [Fact]
    public void Insert_ShouldInsertNodes_InCorrectOrder()
    {
        var tree = new Simple_Binary_Search_Trees(45);
        var list = new List<int> { 39, 56, 12, 34, 78, 32, 10, 89, 54, 67, 81 };

        foreach (var item in list)
        {
            tree.Insert(tree.RootNode, item);
        }

        var expected = list.Append(45).OrderBy(x => x);
        var actual = tree.GetTree(tree.RootNode).Select(n => n.Data);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void InvertBinaryTree_ShouldGiveMirrorImageOfTree()
    {
        // Arrange
        var tree = new Simple_Binary_Search_Trees(10);
        var values = new List<int> { 5, 15, 3, 7, 12, 18 };
        foreach (var val in values)
        {
            tree.Insert(tree.RootNode, val);
        }

        // Pre-condition check: Original pre-order traversal
        var originalPreOrder = PreOrderTraversal(tree.RootNode);

        // Act: Invert the tree
        tree.InvertBinaryTree(tree.RootNode);

        // Assert: Check if the new pre-order matches the expected mirror
        var invertedPreOrder = PreOrderTraversal(tree.RootNode);

        var expectedMirrorPreOrder = new List<int> { 10, 15, 18, 12, 5, 7, 3 };
        Assert.Equal(expectedMirrorPreOrder, invertedPreOrder);
    }

    private List<int> PreOrderTraversal(BST_Node? node)
    {
        var result = new List<int>();
        void Traverse(BST_Node? n)
        {
            if (n == null) return;
            result.Add(n.Data);
            Traverse(n.Left);
            Traverse(n.Right);
        }
        Traverse(node);
        return result;
    }



    [Fact]
    public void IfNodeExists_ShouldFindNode()
    {
        var tree = new Simple_Binary_Search_Trees(45);
        tree.Insert(tree.RootNode, 39);
        tree.Insert(tree.RootNode, 56);

        var actual = tree.IfNodeExists(56, tree.RootNode);

        Assert.NotNull(actual);
        Assert.Equal(56, actual!.Data);

        actual = tree.IfNodeExists(39, tree.RootNode);

        Assert.NotNull(actual);
        Assert.Equal(39, actual!.Data);

    }

    [Fact]
    public void DeleteNode_ShouldDeleteNodes_Correctly()
    {
        var tree = new Simple_Binary_Search_Trees(50);
        var nodesToInsert = new List<int> { 30, 70, 20, 40, 60, 80 };
        foreach (var val in nodesToInsert)
        {
            tree.Insert(tree.RootNode, val);
        }
        
        tree.RootNode = tree.DeleteNode(tree.RootNode, 20)!;
        Assert.Null(tree.IfNodeExists(20, tree.RootNode));

        tree.RootNode = tree.DeleteNode(tree.RootNode, 30)!;
        Assert.Null(tree.IfNodeExists(30, tree.RootNode));
        Assert.NotNull(tree.IfNodeExists(40, tree.RootNode));

        tree.RootNode = tree.DeleteNode(tree.RootNode, 70)!;
        Assert.Null(tree.IfNodeExists(70, tree.RootNode));
        Assert.NotNull(tree.IfNodeExists(60, tree.RootNode));
        Assert.NotNull(tree.IfNodeExists(80, tree.RootNode));

        tree.RootNode = tree.DeleteNode(tree.RootNode, 50)!;
        Assert.Null(tree.IfNodeExists(50, tree.RootNode));
    }





}
