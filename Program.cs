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
        // Dictionary<char, int> dict = new Dictionary<char, int>();

        // if (s.Length != t.Length){
        //     return false;
        // }

        // foreach (char c in s){
        //     if (dict.ContainsKey(c)){
        //         dict[c]++;
        //     } else {
        //         dict.Add(c, 1);
        //     }
        // }

        // return dict.Keys.All(c => t.Count(x => x == c) == dict[c]);

        Dictionary<char, int> dictS = new Dictionary<char, int>();
        Dictionary<char, int> dictT = new Dictionary<char, int>();
        
        if (s.Length != t.Length){
            return false;
        }
        
        foreach (char c in s){
            if (dictS.ContainsKey(c)){
                dictS[c]++;
            } else {
                dictS.Add(c, 1);
            }
        }
        
        foreach (char c in t){
            if (dictT.ContainsKey(c)){
                dictT[c]++;
            } else {
                dictT.Add(c, 1);
            }
        }
        
        return dictS.Count == dictT.Count && dictS.Keys.All(c => dictT.ContainsKey(c) && dictT[c] == dictS[c]);
    }
}

public class ElementAppearingMoreThen25PerCentSolution {
    public int FindSpecialInteger(int[] arr) {
        // int n = arr.Length / 4;
        // Dictionary<int, int> dict = new Dictionary<int, int>();

        // foreach (int num in arr){
        //     if (!dict.ContainsKey(num)){
        //         dict[num] = 1;
        //     } else {
        //         dict[num]++;
        //     }

        //     if (dict[num] > n) {
        //         return num;
        //     }
        // }

        // return -1;

        int n = arr.Length / 4;
        
            for (int i = 0; i < arr.Length - n; i++) {
                if (arr[i] == arr[i + n]) {
                    return arr[i];
                }
            }
        
            return -1;
    }
}

public class TransposeMatrixSolution {
    public int[][] Transpose(int[][] matrix) {
        int rows = matrix.Length;
        int cols = matrix[0].Length;

        int[][] transposedMatrix = new int[cols][];
        for (int i = 0; i < cols; i++)
        {
            transposedMatrix[i] = new int[rows];
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                transposedMatrix[j][i] = matrix[i][j];
            }
        }

        matrix = null;

        return transposedMatrix;
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class ConstructStringFromBinaryTreeSolution {
    public string Tree2str(TreeNode root) {
        // if (root == null) {
        //     return "";
        // }

        // string result = root.val.ToString();

        // if (root.left != null || root.right != null) {
        //     result += "(" + Tree2str(root.left) + ")";
        // }

        // if (root.right != null) {
        //     result += "(" + Tree2str(root.right) + ")";
        // }

        // return result;

        if (root == null)
            {
                return "";
            }
        
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            Tree2strHelper(root, sb);
        
            return sb.ToString();
    }

    private void Tree2strHelper(TreeNode node, System.Text.StringBuilder sb) {
        if (node == null)
            {
                return;
            }
        
            sb.Append(node.val);
        
            if (node.left != null || node.right != null)
            {
                sb.Append("(");
                Tree2strHelper(node.left, sb);
                sb.Append(")");
            }
        
            if (node.right != null)
            {
                sb.Append("(");
                Tree2strHelper(node.right, sb);
                sb.Append(")");
            }
    }
}

public class CalculateMoneyInLeetCodeBankSolution {
    public int CalculateMoney(int n) {
        int sum = 0;
        int prev = 1;
        
        if (n == 1) {
            return 1;
        }

        for (int i = 1; i <= n; i++) {
            sum += prev + (i - 1) % 7;
            if (i % 7 == 0) {
                prev++;
            }
        }
        return sum;
    }
}

public class Program {
    public static void Main() {
        LinkedListSolution sol0 = new LinkedListSolution();

        ListNode head = new ListNode(1);
        head.next = new ListNode(2);
        head.next.next = new ListNode(3);
        head.next.next.next = new ListNode(-3);
        head.next.next.next.next = new ListNode(1);
        
        ListNode res = sol0.RemoveZeroSumSublists(head);
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
        System.Console.WriteLine();
        int[][] image1 = { new int[] { 100, 200, 100 }, new int[] { 200, 50, 200 }, new int[] { 100, 200, 100 } };
        int[][] updatedImage1 = sol8.ImageSmoother(image1);
        foreach (int[] row in updatedImage1){
            foreach (int num in row){
                Console.Write(num + " ");
            }
        }

        ValidAnagramSolution sol9 = new ValidAnagramSolution();
        System.Console.WriteLine(); 
        System.Console.WriteLine(sol9.IsAnagram("anagram", "nagaram"));
        System.Console.WriteLine(sol9.IsAnagram("rat", "car"));
        System.Console.WriteLine(sol9.IsAnagram("a", "ab"));

        ElementAppearingMoreThen25PerCentSolution sol10 = new ElementAppearingMoreThen25PerCentSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol10.FindSpecialInteger(new int[] { 1, 1, 1, 2, 2, 3 }));
        System.Console.WriteLine(sol10.FindSpecialInteger(new int[] { 1,2,2,6,6,6,6,7,10 }));

        TransposeMatrixSolution sol11 = new TransposeMatrixSolution();
        //System.Console.WriteLine();
        int[][] matrix = { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };
        int[][] result = sol11.Transpose(matrix);
        /*for (int i = 0; i < result.GetLength(0); i++){
            for (int j = 0; j < result.GetLength(1); j++){
                System.Console.Write(result[i][j] + " ");
            }
        }*/

        ConstructStringFromBinaryTreeSolution sol12 = new ConstructStringFromBinaryTreeSolution();
        System.Console.WriteLine();

        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);
        root.left.left = new TreeNode(4);

        System.Console.WriteLine(sol12.Tree2str(root));

        CalculateMoneyInLeetCodeBankSolution sol13 = new CalculateMoneyInLeetCodeBankSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol13.CalculateMoney(4));
        System.Console.WriteLine(sol13.CalculateMoney(10));
    }
}