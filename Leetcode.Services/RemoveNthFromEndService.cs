using Leetcode.Services.Models;

namespace Leetcode.Services;

public class RemoveNthFromEndService
{
    /* Given the head of a linked list,
    remove the nth node from the end of the list and return its head. 

    Examples
    Input: head = [1,2,3,4,5], n = 2
    Output: [1,2,3,5]

    Input: head = [1], n = 1
    Output: []

    Input: head = [1,2], n = 1
    Output: [1] */
    public static int[] Do(ListNode head, int n)
    {
        HashSet<(int, ListNode)> st = new(); // number of node, node value
        int j = 0;
        GetListNodeItems(st, head, j);

        var newHead = DeleteListNodeItem(st.Count, n, head);

        if (newHead == null)
        {
            return Array.Empty<int>();
        }

        List<int> l = new();
        ToArray(l, newHead);

        return l.ToArray();
    }

    public static void GetListNodeItems(HashSet<(int, ListNode)> st, ListNode head, int j)
    {
        j++;
        st.Add((j, head));
        if (head.next != null)
        {
            GetListNodeItems(st, head.next, j);
        }
    }

    public static void ToArray(List<int> l, ListNode head)
    {
        l.Add(head.val);
        if (head.next != null)
        {
            ToArray(l, head.next);
        }
    }

    public static ListNode DeleteListNodeItem(int length, int k, ListNode head)
    {
        int nodeFromBeginning = length - k + 1;
        ListNode prev = null;
        ListNode temp = head;
        for (int i = 1; i < nodeFromBeginning; i++)
        {
            prev = temp;
            temp = temp.next;
        }

        if (prev == null)
        {
            head = head.next;
            return head;
        }
        else
        {
            prev.next = prev.next.next;
            return head;
        }
    }
}