using System.Collections.Generic;
using UnityEngine;

public class Graph<TNodeType>
{
    public Graph()
    {
        Nodes = new List<Node<TNodeType>>();
           
    }

   
    public List<Node<TNodeType>> Nodes { get; private set; }
   
    
}

public class Node<TNodeType>
{

    public TNodeType nodeValue { get; set; }

}


