using System;
using System.Collections.Generic;


namespace EachElementOnlyOnce
{
  public class Node<T>
  {
    public Node<T> Next { get; set; }

    public T Value { get; }

    public Node(T value)
    {
      Value = value;
    }
  }

  public class SinglyLinkedList<T>
  {
    private readonly int bufferSize;
    private readonly T[] circularBuffer;
    private readonly int currentBufferIndex;

    public Node<T> Start { get; }
    public int Count { get; }

    public SinglyLinkedList(IEnumerable<T> collection, int bufferSize = 5)
    {
      this.bufferSize = bufferSize;
      circularBuffer = new T[bufferSize];
      IEnumerator<T> enumerator = collection.GetEnumerator();
      if (enumerator.MoveNext())
      {
        Count = 1;

        Start = new Node<T>(enumerator.Current);
        circularBuffer[1] = Start.Value;
        Node<T> lastLinked = Start;
        while (enumerator.MoveNext())
        {
          Node<T> currentNode = new Node<T>(enumerator.Current);
          currentBufferIndex = Count++ % bufferSize;
          circularBuffer[currentBufferIndex] = currentNode.Value;

          lastLinked.Next = currentNode;
          lastLinked = currentNode;
        }
      }
    }

    

    public T GetItemFromEnd(int position = 5)
    {
      if (position > Count || position > bufferSize || position <= 0)
      {
        int sizeThreshold = Count > bufferSize ? bufferSize : Count;
        throw new ArgumentOutOfRangeException(String.Format("Position requested must be between 1 and {0}", sizeThreshold));
      }
      if ((currentBufferIndex + 1 - position) >= 0)
      {
        return circularBuffer[currentBufferIndex + 1 - position];
      }
      return circularBuffer[bufferSize + (currentBufferIndex - position) + 1];
    }
  }
}
