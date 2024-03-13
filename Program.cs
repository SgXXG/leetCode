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

public class SquaresOfASortedArraySolution {
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

public class PowerOfTwoSolution {
    public bool IsPowerOfTwo(int n) {
        return n > 0 && (n & (n - 1)) == 0;
    }
}

public class PoweOfThreeSolution {
    public bool IsPowerOfThree(int n) {
        return n > 0 && Math.Pow(3, 19) % n == 0;
    }
}

public class ClimbingStairsSolution {
    public int ClimbStairs(int n) {
        // if (n == 1) {
        //     return 1;
        // }

        // if (n == 2) {
        //     return 2;
        // }

        // int[] dp = new int[n + 1];
        // dp[1] = 1;
        // dp[2] = 2;
        // for (int i = 3; i <= n; i++) {
        //     dp[i] = dp[i - 1] + dp[i - 2];
        // }

        // return dp[n];

        if (n <= 1)
        {
            return n;
        }

        int a = 0;
        int b = 1;
        int temp = 0;

        for (int i = 1; i <= n; i++)
        {
            temp = a + b;
            a = b;
            b = temp;
        }

        return b;
    }
}

public class DecodeWaysSolution {
    public int NumDecodings(string s) {
        if (s[0] == '0') {
            return 0;
        }
        int n = s.Length;
        int[] dp = new int[n + 1];
        dp[0] = 1;
        dp[1] = s[0] == '0' ? 0 : 1;
        for (int i = 2; i <= n; i++) {
            int oneDigit = int.Parse(s.Substring(i-1, 1));
            int twoDigits = int.Parse(s.Substring(i-2, 2));
            if (oneDigit >= 1) {
                dp[i] += dp[i-1];
            }
            if (twoDigits >= 10 && twoDigits <= 26) {
                dp[i] += dp[i-2];
            }
        }
        return dp[n];
    }
}

public class PathCrossingSolution {
    public bool IsPathCrossing(string path) {
        var visited = new HashSet<string>();
        int x = 0, y = 0;
        visited.Add($"{x},{y}");

        foreach (char direction in path){
            switch (direction) {
                case 'N': y++; break;
                case 'S': y--; break;
                case 'E': x++; break;
                case 'W': x--; break;
            }

            string currentPoint = $"{x},{y}";
            if(visited.Contains(currentPoint)){
                return true;
            }

            visited.Add(currentPoint);
        }

        return false;
    }
}

public class BuyTwoChocolatesSolution {
    public int BuyChoco (int[] prices, int money){
        Array.Sort(prices);
        if (prices[0] + prices[1] > money){
            return money;
        }

        return money - prices[0] - prices[1];
    }
}

public class ImageSmootherSolution {
    public int[][] ImageSmoother(int[][] img) {
        int m = img.Length;
        int n = img[0].Length;

        int[][] res = new int[m][];
        for (int i = 0; i < m; i++){
            res[i] = new int[n];
            for (int j = 0; j < n; j++){
                int count = 0;
                for (int x = i - 1; x <= i + 1; x++){
                    for (int y = j - 1; y <= j + 1; y++){
                        if (x >= 0 && x < m && y >= 0 && y < n){
                            res[i][j] += img[x][y];
                            count++;
                        }
                    }
                }
                res[i][j] = res[i][j] / count;
            }
        }
        return res;
    }
}

public class ValidAnagramSolution {
    public bool IsAnagram(string s, string t) {
        
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

        SquaresOfASortedArraySolution sol1 = new SquaresOfASortedArraySolution();
        int[] numbers = { -4, -1, 0, 3, 10 };
        numbers = sol1.SortedSqaures(numbers); 
        System.Console.WriteLine();
        foreach (int num in numbers){
            Console.Write(num + " ");
        }

        PowerOfTwoSolution sol2 = new PowerOfTwoSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol2.IsPowerOfTwo(16));
        System.Console.WriteLine(sol2.IsPowerOfTwo(-16));

        PoweOfThreeSolution sol3 = new PoweOfThreeSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol3.IsPowerOfThree(27));
        System.Console.WriteLine(sol3.IsPowerOfThree(243));

        ClimbingStairsSolution sol4 = new ClimbingStairsSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol4.ClimbStairs(3));
        System.Console.WriteLine(sol4.ClimbStairs(45));

        DecodeWaysSolution sol5 = new DecodeWaysSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol5.NumDecodings("226"));
        System.Console.WriteLine(sol5.NumDecodings("006"));
        System.Console.WriteLine(sol5.NumDecodings("12"));

        PathCrossingSolution sol6 = new PathCrossingSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol6.IsPathCrossing("N"));
        System.Console.WriteLine(sol6.IsPathCrossing("nESWWW"));
        System.Console.WriteLine(sol6.IsPathCrossing("NES"));

        BuyTwoChocolatesSolution sol7 = new BuyTwoChocolatesSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol7.BuyChoco(new int[] { 1, 2, 2, 1, 0 }, 4));
        System.Console.WriteLine(sol7.BuyChoco(new int[] { 1, 2, 2 }, 3));
        System.Console.WriteLine(sol7.BuyChoco(new int[] { 3, 2, 3 }, 3));

        ImageSmootherSolution sol8 = new ImageSmootherSolution();
        System.Console.WriteLine();
        int[][] image = { new int[] { 1, 1, 1 }, new int[] { 1, 0, 1 }, new int[] { 1, 1, 1 } };
        int[][] updatedImage = sol8.ImageSmoother(image);
        foreach (int[] row in updatedImage){
            foreach (int num in row){
                Console.Write(num + " ");
            }
            }
            int[][] image1 = { new int[] { 100, 200, 100 }, new int[] { 200, 50, 200 }, new int[] { 100, 200, 100 } };
            int[][] updatedImage1 = sol8.ImageSmoother(image1);
            foreach (int[] row in updatedImage1){
                foreach (int num in row){
                    Console.Write(num + " ");
                }
            }
    }
}