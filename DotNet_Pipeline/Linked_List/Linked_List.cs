namespace DotNet_Pipeline.Linked_List;

public record LinkedListNode
{
    public LinkedListNode(string data)
    {
        this.Data = data;
    }
    public string? Data { get; set; }
    public LinkedListNode? Next { get; set; }
}

public class Simple_Linked_List
{
    private LinkedListNode RootNode { get; set; }
    public Simple_Linked_List(string root_data)
    {
        this.RootNode = new LinkedListNode(root_data);
    }

    public void DeleteFirstNode()
    {
        if (this.RootNode != null)
        {
            this.RootNode = this.RootNode.Next!;
        }
    }

    public void DeleteLastNode()
    {
        if (this.RootNode == null)
        {
            return;
        }

        if (this.RootNode.Next == null)
        {
            this.RootNode = null!;
            return;
        }

        var current = this.RootNode;
        while (current.Next!.Next is not null)
        {
            current = current.Next;
        }

        current.Next = null;
    }

    public void InsertNewNodeInBeginning(string value)
    {
        this.RootNode = new LinkedListNode(value)
        {
            Next = this.RootNode
        };
    }

    public List<string> GetList()
    {
        var traverser = this.RootNode;
        var list = new List<string>();
        while (traverser is not null)
        {
            list.Add(traverser.Data!);
            traverser = traverser.Next;
        }
        return list;
    }

/* public void Traverse()
    {
        var traverser = this.RootNode;
        Console.WriteLine("***Linked List***");
        while (traverser is not null)
        {
            Console.Write($"{traverser.Data} ");
            traverser = traverser.Next;
        }
        Console.WriteLine("");
    }*/

    public void InsertNodeAtEnding(string value)
    {
        var new_node = new LinkedListNode(value);
        var traverser = this.RootNode;
        while (traverser.Next is not null)
        {
            traverser = traverser.Next;
        }
        traverser.Next = new_node;
    }

    public void InsertNodeAfter(string target, string value)
    {
        var traverser = this.RootNode;
        while (traverser is not null)
        {
            if (traverser.Data == target)
            {
                traverser.Next = new LinkedListNode(value)
                {
                    Next = traverser.Next
                };
                return;
            }
            traverser = traverser.Next;
        }
    }

}
