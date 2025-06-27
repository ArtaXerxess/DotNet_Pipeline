using DotNet_Pipeline.Linked_List;

namespace DotNet_Pipeline.Tests;

public class LinkedListTests
{
    [Fact]
    public void InsertNewNodeInBeginning_ShouldAddNodeAtStart()
    {
        var list = new Simple_Linked_List("Apple");
        list.InsertNewNodeInBeginning("Ball");
        list.InsertNewNodeInBeginning("Cat");

        var result = list.GetList();

        Assert.Equal(new[] { "Cat", "Ball", "Apple" }, result);
    }

    [Fact]
    public void InsertNodeAtEnding_ShouldAddNodeAtEnd()
    {
        var list = new Simple_Linked_List("Apple");
        list.InsertNewNodeInBeginning("Ball"); 
        list.InsertNodeAtEnding("Dog");         

        var result = list.GetList();

        Assert.Equal(new[] { "Ball", "Apple", "Dog" }, result);
    }

    [Fact]
    public void InsertNodeAfter_ShouldInsertAfterTargetNode()
    {
        var list = new Simple_Linked_List("Apple");
        list.InsertNewNodeInBeginning("Ball"); 
        list.InsertNodeAfter("Ball", "Cat");   

        var result = list.GetList();

        Assert.Equal(new[] { "Ball", "Cat", "Apple" }, result);
    }

    [Fact]
    public void InsertNodeAfter_ShouldDoNothingIfTargetNotFound()
    {
        var list = new Simple_Linked_List("Apple");
        list.InsertNodeAfter("NonExistent", "Cat");
        var result = list.GetList();
        Assert.Equal(new[] { "Apple" }, result);
    }

    [Fact]
    public void GetList_ShouldReturnAllValuesInOrder()
    {
        var list = new Simple_Linked_List("One");
        list.InsertNodeAtEnding("Two");
        list.InsertNodeAtEnding("Three");

        var result = list.GetList();

        Assert.Equal(new[] { "One", "Two", "Three" }, result);
    }

    [Fact]
    public void DeleteFirstNode_ShouldRemoveFirstNode()
    {
        var list = new Simple_Linked_List("First");
        list.InsertNodeAtEnding("Second");
        list.InsertNodeAtEnding("Third");

        list.DeleteFirstNode();

        var result = list.GetList();
        Assert.Equal(new[] { "Second", "Third" }, result);
    }

    [Fact]
    public void DeleteLastNode_ShouldRemoveLastNode()
    {
        var list = new Simple_Linked_List("One");
        list.InsertNodeAtEnding("Two");
        list.InsertNodeAtEnding("Three");

        list.DeleteLastNode();
    
        var result = list.GetList();
        Assert.Equal(new[] { "One", "Two" }, result);
    }


}
