public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next =null) {
        this.val = val;
        this.next = next;
    }
 }

public class LinkedListSolution {
    public ListNode RemoveZeroSumSublists(ListNode head){
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode cur = dummy;
        while (cur != null){
            int sum = 0;
            ListNode cur2 = cur.next;
            while (cur2 != null){
                sum += cur2.val;
                if (sum == 0){
                    cur.next = cur2.next;
                }
                cur2 = cur2.next;
            }
            cur = cur.next;
        }
        return dummy.next;
    }
}

public class SquaresOfASortedArray {
    public int[] SortedSqaures(int[] nums){

        for (int i = 0; i < nums.Length; i++){
            nums[i] = nums[i] * nums[i];
        }

        bool swapRequired;
        for (int i = 0; i < nums.Length - 1; i++) 
        {
            swapRequired = false;
            for (int j = 0; j < nums.Length - i - 1; j++)
                if (nums[j] > nums[j + 1])
                {
                    var tempVar = nums[j];
                    nums[j] = nums[j + 1];
                    nums[j + 1] = tempVar;
                    swapRequired = true;
                }
            if (swapRequired == false)
                break;
        }
        
        return nums;
    }
}

public class PowerOfTwo {
    public bool IsPowerOfTwo(int n) {
        return n > 0 && (n & (n - 1)) == 0;
    }
}

public class PoweOfThree {
    public bool IsPowerOfThree(int n) {
        return n > 0 && Math.Pow(3, 19) % n == 0;
    }
}

public class Program {
    public static void Main() {
        ListNode head = new ListNode(1);
        head.next = new ListNode(2);
        head.next.next = new ListNode(3);
        head.next.next.next = new ListNode(-3);
        head.next.next.next.next = new ListNode(1);
        LinkedListSolution sol = new LinkedListSolution();
        ListNode res = sol.RemoveZeroSumSublists(head);
        while (res != null){
            Console.Write(res.val + " ");
            res = res.next;
        }

       SquaresOfASortedArray sol1 = new SquaresOfASortedArray();
       int[] numbers = { -4, -1, 0, 3, 10 };
       numbers = sol1.SortedSqaures(numbers); 
       System.Console.WriteLine();

       foreach (int num in numbers){
           Console.Write(num + " ");
       }

       PowerOfTwo sol2 = new PowerOfTwo();
       System.Console.WriteLine();
       System.Console.WriteLine(sol2.IsPowerOfTwo(16));
       System.Console.WriteLine(sol2.IsPowerOfTwo(-16));

       PoweOfThree sol3 = new PoweOfThree();
       System.Console.WriteLine();
       System.Console.WriteLine(sol3.IsPowerOfThree(27));
       System.Console.WriteLine(sol3.IsPowerOfThree(243));
    }
}