using Leetcode.Services.Models;

namespace Leetcode.Services;

public class MergeTwoListsService
{
    /*You are given the heads of two sorted linked lists list1 and list2.
    Merge the two lists in a one sorted list. The list should be made by splicing together the nodes of the first two lists.
    Return the head of the merged linked list.

    Example 1:    
         Input: list1 = [1,2,4], list2 = [1,3,4]
    Output: [1,1,2,3,4,4]
    
    Example 2:
    Input: list1 = [], list2 = []
    Output: []
    
    Example 3:
    Input: list1 = [], list2 = [0]
    Output: [0]    */
    private static readonly Func<ListNode, ListNode, bool> checkIfFirstMore = (first, second) =>
     {
         if (first == null)
             return false;

         if (second == null)
             return true;

         return first.val > second.val;
     };

    public static int[] MergeTwoLists(ListNode list1, ListNode list2)
    {
        var merged = new ListNode(-1);
        MergeTwoListsRecursion(list1, list2, merged);

        List<int> l = new();
        ToArray(l, merged.next);
        return l.ToArray(); // merged
    }

    public static void MergeTwoListsRecursion(ListNode next1, ListNode next2, ListNode merged)
    {
        if (next1 != null || next2 != null)
        {
            var isFirstMore = checkIfFirstMore(next1, next2);
            var currentValue = isFirstMore ? next2?.val : next1?.val;

            if (!currentValue.HasValue)
            {
                currentValue = next1?.val ?? next2?.val;
                isFirstMore = next2 != null;
            }

            merged.next = new ListNode(currentValue.Value);

            // делаем получение минимального следующего элемента
            if (isFirstMore)
            {
                next2 = next2.next;
            }
            else
            {
                next1 = next1.next;
            }

            MergeTwoListsRecursion(next1, next2, merged.next);
        }
    }

    public static int[] MergeTwoListsv1(ListNode list1, ListNode list2)
    {
        var next1 = list1;
        var next2 = list2;

        Func<ListNode, ListNode, bool> checkIfFirstMore = (first, second) => first.val > second.val;

        var isFirstMore = false;
        var merged = new ListNode(-1);
        var tmp = new ListNode(-1);

        while (next1?.next != null || next2?.next != null)
        {
            isFirstMore = checkIfFirstMore(next1, next2);

            var currentValue = isFirstMore ? next2.val : next1.val;

            merged = tmp;
            merged.next = new ListNode(currentValue);

            tmp = merged; // временно храним последнее состояние.

            // делаем получение минимального следующего элемента
            if (isFirstMore && next2 != null)
            {
                next2 = next2.next;
            }
            else if (next1 != null)
            {
                next1 = next1.next;
            }

            MergeTwoLists(next1, next2);
        }

        List<int> l = new();
        ToArray(l, merged);
        return l.ToArray(); // merged
    }

    public static void ToArray(List<int> l, ListNode head)
    {
        if (head == null)
            return;

        l.Add(head.val);
        if (head.next != null)
        {
            ToArray(l, head.next);
        }
    }
}
