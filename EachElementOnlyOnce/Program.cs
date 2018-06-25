using System;
using System.Collections.Generic;
using System.Linq;
using SinglyLinkedList;
using ProcessList;

namespace EachElementOnlyOnce
{
  class Program
  {
    static void Main(string[] args) {
      RunNumbersDemo();
      RunStringsDemo();
    }

    static void RunNumbersDemo()
    {
      Random randomNumber = new Random();
      int maxNumbers = randomNumber.Next(6, 34);

      int min = 1;
      int max = 100;
      IEnumerable<int> numbers = Enumerable.Repeat(0, maxNumbers).Select(number => randomNumber.Next(min, max)).ToList();

      RunTypedDemo(numbers, 5);
    }

    static void RunStringsDemo()
    {

      string sample = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis";
      RunTypedDemo(sample.Split(new char[] { ' ','.',',' }, StringSplitOptions.RemoveEmptyEntries), 5);
    }

    static void RunTypedDemo<T> (IEnumerable<T> dataList, int maxFromEnd)
    {
      Console.Write("A singly linked list of the following: ");
      Console.WriteLine(String.Join(",", dataList));

      SinglyLinkedList<T> testData = new SinglyLinkedList<T>();

      dataList.ToList().ForEach(x => testData.Add(x));

      for (int position = 1; position <= maxFromEnd; position++)
      {
        Console.WriteLine(String.Format("Has this value {1} at position {0} from the end of the colleciton", position,
          ProcessList<T>.GetElementFromEndAt(testData, position)));
      }
      Console.ReadKey();

      Console.WriteLine();
    }
  }
}
