using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SinglyLinkedList;

namespace ProcessList
{
  public class ProcessList<T>
  {
    public static  T GetElementFromEndAt(SinglyLinkedList<T> list, int position = 5)
    {
      Node<T> currentNode = list.Start;
      Node<T> nFromEnd = list.Start;
      int count = 1;
      if (currentNode is null) throw new ArgumentException("Empty list provided!!");
      while (!(currentNode.Next is null))
      {
        currentNode = currentNode.Next;
        if (count >= position)
        {
          nFromEnd = nFromEnd.Next;
        }
        count++;
      }
      if (count < position) throw new ArgumentException("List had less items than seek position");
      return nFromEnd.Value;
    } 
  }
}
