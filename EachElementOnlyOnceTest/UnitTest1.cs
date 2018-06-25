using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SinglyLinkedList;
using ProcessList;

namespace EachElementOnlyOnceTest
{
  [TestClass]
  public class SinglyLinkedListTests
  {

    [TestMethod]
    public void TestWithEmpty()
    {
      SinglyLinkedList<int> testList = new SinglyLinkedList<int>();
      Assert.IsTrue(ReferenceEquals(testList.Start, testList.End));
    }

    [TestMethod]
    public void TestAdd1stITem()
    {
      SinglyLinkedList<int> testList = new SinglyLinkedList<int>();

      testList.Add(1);

      Assert.AreEqual(1, testList.Start.Value);
      Assert.IsTrue(ReferenceEquals(testList.Start, testList.End));
    }

    [TestMethod]
    public void TestAddMultipleItems()
    {
      SinglyLinkedList<int> testList = new SinglyLinkedList<int>();

      testList.Add(1);
      testList.Add(2);
      testList.Add(3);
      testList.Add(4);
      testList.Add(5);
      testList.Add(6);
      Assert.AreEqual(1, testList.Start.Value);
      Assert.AreEqual(2, testList.Start.Next.Value);
      Assert.AreEqual(6, testList.End.Value);
      Assert.IsFalse(ReferenceEquals(testList.Start, testList.End));
    }

  }

  [TestClass]
  public class ProcessListTests
  {
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestProcessEmptyList()
    {
      SinglyLinkedList<int> emptyList = new SinglyLinkedList<int>();
      int value = ProcessList<int>.GetElementFromEndAt(emptyList);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestProcessShortList()
    {
      SinglyLinkedList<int> shortList = new SinglyLinkedList<int>();
      shortList.Add(1);
      shortList.Add(2);
      int value = ProcessList<int>.GetElementFromEndAt(shortList);
    }

    [TestMethod]
    public void TestProcessLargeList()
    {
      SinglyLinkedList<int> largerList = new SinglyLinkedList<int>();
      for (int i=0; i < 33; i++)
      {
        largerList.Add(i);
      }
      int value = ProcessList<int>.GetElementFromEndAt(largerList);
      Assert.AreEqual(33 - 5, value);
    }

    [TestMethod]
    public void TestProcessGetLastNumber()
    {
      SinglyLinkedList<int> largerList = new SinglyLinkedList<int>();
      for (int i = 0; i <= 12; i++)
      {
        largerList.Add(i);
      }
      int value = ProcessList<int>.GetElementFromEndAt(largerList,1);
      Assert.AreEqual(12, value);
    }
  }
}
