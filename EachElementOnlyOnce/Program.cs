using System;
using System.Collections.Generic;
using System.Linq;
namespace EachElementOnlyOnce
{
  class Program
  {
    static void Main(string[] args)
    {
      SinglyLinkedList<int> test;
      Random randomNumber = new Random();
      int maxNumbers = randomNumber.Next(6,34);
     
      int min = 1;
      int max = 100;
      IEnumerable<int> numbers = Enumerable.Repeat(0, maxNumbers).Select( number => randomNumber.Next(min,max)).ToList();

      Console.Write("A singly linked list of the following numbers: ");
      Console.WriteLine(String.Join(",", numbers));
      test = new SinglyLinkedList<int>(numbers);
      for (int position = 1; position <= 5; position++)
      {
        Console.WriteLine(String.Format("Has the value {1} at position {0} from the end of the colleciton", position,
          test.GetItemFromEnd(position)));
      }
      Console.ReadKey();

      Console.WriteLine();

      SinglyLinkedList<string> testString;
      string[] stringTest = new string[] { "Simon", "Shannon", "Sam", "Stephen", "Shirley", "Sharon", "Sandy", "Scott" };
      Console.Write("A singly linked list of the following strings: ");
      Console.WriteLine(String.Join(",", stringTest));
      testString = new SinglyLinkedList<string>(stringTest);

      for (int position = 1; position <= 5; position++)
      {
        Console.WriteLine(String.Format("Has this value {1} at position {0} from the end of the colleciton", position,
          testString.GetItemFromEnd(position)));
      }
      Console.ReadKey();
    }
  }
}
