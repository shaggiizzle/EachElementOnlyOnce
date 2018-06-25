using System;
using System.Collections.Generic;


namespace SinglyLinkedList
{
  public class Node<T>
  {
    public Node<T> Next { get; internal set; }

    public T Value { get; set; }

    public Node(T value)
    {
      Value = value;
      Next = null;
    }
  }

  public class SinglyLinkedList<T>
  {
    public Node<T> Start { get; private set; }
    public Node<T> End { get; private set; }

    public SinglyLinkedList()
    {
      Start = End = null;
    }

    public void Add(T value)
    {
      Node<T> newNode = new Node<T>(value);
      if (End is null)
      {
        Start = End = newNode;
      }
      else
      {
        End.Next = newNode;
        End = newNode;
      }
    }
  }
}
