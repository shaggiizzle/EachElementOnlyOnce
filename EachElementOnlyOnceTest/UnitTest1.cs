using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EachElementOnlyOnce;

namespace EachElementOnlyOnceTest
{
  [TestClass]
  public class EachElementOnlyOnceNumberTest
  {

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestWithEmpty()
    {
      int[] input = new int[] { };
      SinglyLinkedList<int> testList = new SinglyLinkedList<int>(input);
      int elementAt5 = testList.GetItemFromEnd();
    }

    [TestMethod]
    public void TestWithOrderedNumbers()
    {
      int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
      SinglyLinkedList<int> testList = new SinglyLinkedList<int>(input);
      int elementAt5 = testList.GetItemFromEnd();
      Assert.AreEqual(input[input.Length - 5], elementAt5);
    }

    [TestMethod]
    public void TestWithFullBuffer_OrderedNumbersGetAt3()
    {
      int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
      SinglyLinkedList<int> testList = new SinglyLinkedList<int>(input,6);
      int elementAt3 = testList.GetItemFromEnd(3);
      Assert.AreEqual(input[input.Length - 3], elementAt3);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestWithInvalidGetPosition()
    {
      int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
      SinglyLinkedList<int> testList = new SinglyLinkedList<int>(input);
      int elementAt3 = testList.GetItemFromEnd(0);
    }


    [TestMethod]
    public void TestWithFullBuffer_OrderedNumbersGetAt1()
    {
      int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
      SinglyLinkedList<int> testList = new SinglyLinkedList<int>(input);
      int elementAt3 = testList.GetItemFromEnd(1);
      Assert.AreEqual(input[input.Length - 1], elementAt3);
    }

    [TestMethod]
    public void TestWithUnorderedNumbers()
    {
      int[] input = new int[] { 1, 7, 9, 0, 15, 2, 4, 5, 2, 1, 1, 9, 13, 23, 17, 19, 25 };
      SinglyLinkedList<int> testList = new SinglyLinkedList<int>(input);
      int elementAt5 = testList.GetItemFromEnd();
      Assert.AreEqual(input[input.Length - 5], elementAt5);
    }
  }
}
