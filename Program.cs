﻿/// <summary>
/// Represents a node in a linked list.
/// </summary>
public class ListNode {
    public int val;
    public ListNode next;

    /// <summary>
    /// Initializes a new instance of the <see cref="ListNode"/> class.
    /// </summary>
    /// <param name="val">The value of the node.</param>
    /// <param name="next">The next node in the linked list.</param>
    public ListNode(int val = 0, ListNode next = null) {
        this.val = val;
        this.next = next;
    }
}

/// <summary>
/// Represents a solution for removing zero-sum sublists from a linked list.
/// </summary>
public class LinkedListSolution {
    /// <summary>
    /// Removes zero-sum sublists from the given linked list.
    /// </summary>
    /// <param name="head">The head node of the linked list.</param>
    /// <returns>The head node of the modified linked list.</returns>
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

/// <summary>
/// Represents a solution for sorting the squares of an array in ascending order.
/// </summary>
public class SquaresOfASortedArraySolution {
    /// <summary>
    /// Sorts the squares of the given array in ascending order.
    /// </summary>
    /// <param name="nums">The array of integers.</param>
    /// <returns>The sorted array of squared integers.</returns>
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

/// <summary>
/// Represents a solution for determining if a given number is a power of two.
/// </summary>
public class PowerOfTwoSolution {
    /// <summary>
    /// Determines whether the given number is a power of two.
    /// </summary>
    /// <param name="n">The number to check.</param>
    /// <returns>True if the number is a power of two, otherwise false.</returns>
    public bool IsPowerOfTwo(int n) {
        return n > 0 && (n & (n - 1)) == 0;
    }
}

/// <summary>
/// Represents a solution for determining if a number is a power of three.
/// </summary>
public class PoweOfThreeSolution {
    /// <summary>
    /// Determines whether the given number is a power of three.
    /// </summary>
    /// <param name="n">The number to check.</param>
    /// <returns>True if the number is a power of three; otherwise, false.</returns>
    public bool IsPowerOfThree(int n) {
        return n > 0 && Math.Pow(3, 19) % n == 0;
    }
}

/// <summary>
/// Represents a solution for the climbing stairs problem.
/// </summary>
public class ClimbingStairsSolution {
    /// <summary>
    /// Calculates the number of distinct ways to climb to the top of the stairs.
    /// </summary>
    /// <param name="n">The number of stairs.</param>
    /// <returns>The number of distinct ways to climb to the top of the stairs.</returns>
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

/// <summary>
/// Represents a solution for decoding ways problem.
/// </summary>
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

/// <summary>
/// Represents a solution for determining if a path crosses itself.
/// </summary>
public class PathCrossingSolution {
    /// <summary>
    /// Determines if the given path crosses itself.
    /// </summary>
    /// <param name="path">The path to check.</param>
    /// <returns>True if the path crosses itself, false otherwise.</returns>
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

/// <summary>
/// Represents a solution for buying two chocolates.
/// </summary>
public class BuyTwoChocolatesSolution {
    /// <summary>
    /// Calculates the amount of money left after buying two chocolates.
    /// </summary>
    /// <param name="prices">An array of chocolate prices.</param>
    /// <param name="money">The amount of money available.</param>
    /// <returns>The amount of money left after buying two chocolates.</returns>
    public int BuyChoco(int[] prices, int money) {
        Array.Sort(prices);
        if (prices[0] + prices[1] > money) {
            return money;
        }

        return money - prices[0] - prices[1];
    }
}

/// <summary>
/// Represents a solution for smoothing an image.
/// </summary>
public class ImageSmootherSolution {
    /// <summary>
    /// Smooths the given image by averaging the pixel values of each cell with its neighboring cells.
    /// </summary>
    /// <param name="img">The image represented as a 2D array of integers.</param>
    /// <returns>A new 2D array representing the smoothed image.</returns>
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

/// <summary>
/// Represents a solution for determining if two strings are anagrams of each other.
/// </summary>
public class ValidAnagramSolution {
    /// <summary>
    /// Determines if two strings are anagrams of each other.
    /// </summary>
    /// <param name="s">The first string.</param>
    /// <param name="t">The second string.</param>
    /// <returns>True if the strings are anagrams, false otherwise.</returns>
    public bool IsAnagram(string s, string t) {
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

/// <summary>
/// Represents a solution for finding the element appearing more than 25% of the time in an array.
/// </summary>
public class ElementAppearingMoreThen25PerCentSolution {
    /// <summary>
    /// Finds the element appearing more than 25% of the time in the given array.
    /// </summary>
    /// <param name="arr">The array of integers.</param>
    /// <returns>The element appearing more than 25% of the time, or -1 if no such element exists.</returns>
    public int FindSpecialInteger(int[] arr) {
        int n = arr.Length / 4;
        
        for (int i = 0; i < arr.Length - n; i++) {
            if (arr[i] == arr[i + n]) {
                return arr[i];
            }
        }
        
        return -1;
    }
}

/// <summary>
/// Represents a solution for transposing a matrix.
/// </summary>
public class TransposeMatrixSolution {
    /// <summary>
    /// Transposes the given matrix.
    /// </summary>
    /// <param name="matrix">The matrix to be transposed.</param>
    /// <returns>The transposed matrix.</returns>
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

/// <summary>
/// Represents a node in a binary tree.
/// </summary>
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

/// <summary>
/// Represents a solution for constructing a string from a binary tree.
/// </summary>
public class ConstructStringFromBinaryTreeSolution {
    /// <summary>
    /// Converts a binary tree to a string representation.
    /// </summary>
    /// <param name="root">The root node of the binary tree.</param>
    /// <returns>A string representation of the binary tree.</returns>
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

    /// <summary>
    /// Helper method to convert a binary tree to a string representation.
    /// </summary>
    /// <param name="node">The current node being processed.</param>
    /// <param name="sb">The StringBuilder used to build the string representation.</param>
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

/// <summary>
/// Represents a solution for calculating the amount of money in the LeetCode bank.
/// </summary>
public class CalculateMoneyInLeetCodeBankSolution {
    /// <summary>
    /// Calculates the amount of money in the LeetCode bank after n days.
    /// </summary>
    /// <param name="n">The number of days.</param>
    /// <returns>The amount of money in the LeetCode bank.</returns>
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

/// <summary>
/// Represents a solution for counting the number of 1 bits in an unsigned integer.
/// </summary>
public class NumberOf1BitsSolution {
    public int HammingWeight(uint n) {
        // int count = 0;
        // foreach (char c in n.ToString()){
        //     if (c == '1'){
        //         count++;
        //     }
        // }

        // return count;

        int count = 0;
        while (n > 0){
            count += (int)(n & 1);
            n >>= 1;
        }

        return count;
    }
}

/// <summary>
/// Represents a solution for finding the pivot integer in a sequence of integers.
/// </summary>
public class FindThePivotIntegerSolution {
    /// <summary>
    /// Finds the pivot integer in a sequence of integers.
    /// </summary>
    /// <param name="n">The number of integers in the sequence.</param>
    /// <returns>The pivot integer, or -1 if no pivot integer is found.</returns>
    public int PivotInteger(int n) {
        int totalSum = n * (n + 1) / 2;
        int leftSum = 0;
    
        for (int i = 1; i <= n; i++)
        {
            leftSum += i;
            int rightSum = totalSum - leftSum + i;
    
            if (leftSum == rightSum)
            {
                return i;
            }
        }
    
        return -1;
    }
}

/// <summary>
/// Represents a solution for determining if a number is a power of four.
/// </summary>
public class PowerOfFourSolution {
    /// <summary>
    /// Determines whether the given number is a power of four.
    /// </summary>
    /// <param name="n">The number to check.</param>
    /// <returns>True if the number is a power of four, otherwise false.</returns>
    public bool IsPowerOfFour(int n) {
        return n > 0 && (n & (n - 1)) == 0 && (n & 0xAAAAAAAA) == 0;
    }
}

/// <summary>
/// Class to check if two string arrays are equivalent.
/// </summary>
public class CheckIsTwoStringArraysAreEquivalent {
    /// <summary>
    /// Checks if two string arrays are equivalent by joining the strings in each array and comparing them.
    /// </summary>
    /// <param name="word1">The first string array.</param>
    /// <param name="word2">The second string array.</param>
    /// <returns>True if the string arrays are equivalent, false otherwise.</returns>
    public bool ArrayStringsAreEqual(string[] word1, string[] word2) {
        return string.Join("", word1) == string.Join("", word2);
    }
}

/// <summary>
/// Represents a solution for finding the largest odd number in a string.
/// </summary>
public class LargestOddNumberInStringSolution {
    /// <summary>
    /// Finds the largest odd number in the given string.
    /// </summary>
    /// <param name="num">The input string.</param>
    /// <returns>The largest odd number found in the string.</returns>
    public string LargestOddNumber(string num) {
        for (int i = num.Length - 1; i >= 0; i--) {
            if ((num[i] - '0') % 2 == 1) {
                return num.Substring(0, i + 1);
            }
        }
        return "";
    }
}

/// <summary>
/// Represents a solution for finding the minimum number of changes required to make a string alternating.
/// </summary>
public class MinimumChangesToMakeAlternatingStringSolution {
    /// <summary>
    /// Calculates the minimum number of operations required to make the given string alternating.
    /// </summary>
    /// <param name="s">The input string.</param>
    /// <returns>The minimum number of operations.</returns>
    public int MinOperations(string s) {
        int[] count = new int[2];
        for (int i = 0; i < s.Length; i++) {
            count[i % 2 ^ s[i] - '0']++;
        }
        return Math.Min(count[0], count[1]);
    }
}

/// <summary>
/// Represents a solution for comparing two strings with backspace characters.
/// </summary>
public class BackspaceStringCompareSolution {
    /// <summary>
    /// Compares two strings with backspace characters and returns whether they are equal.
    /// </summary>
    /// <param name="s">The first string to compare.</param>
    /// <param name="t">The second string to compare.</param>
    /// <returns>True if the strings are equal, false otherwise.</returns>
    public bool BackspaceCompare(string s, string t) {
        int i = s.Length - 1, j = t.Length - 1;
        int skipS = 0, skipT = 0;
    
        while (i >= 0 || j >= 0) {
            i = GetNextValidCharIndex(s, i, ref skipS);
            j = GetNextValidCharIndex(t, j, ref skipT);
    
            if (i >= 0 && j >= 0 && s[i] != t[j]) {
                return false;
            }
            if ((i >= 0) != (j >= 0)) {
                return false;
            }
            i--;
            j--;
        }
        return true;
    }

    /// <summary>
    /// Gets the index of the next valid character in the string, considering the skip count.
    /// </summary>
    /// <param name="str">The input string.</param>
    /// <param name="index">The current index.</param>
    /// <param name="skipCount">The number of characters to skip.</param>
    /// <returns>The index of the next valid character.</returns>
    private int GetNextValidCharIndex(string str, int index, ref int skipCount) {
        while (index >= 0) {
            if (str[index] == '#') {
                skipCount++;
                index--;
            } else if (skipCount > 0) {
                skipCount--;
                index--;
            } else {
                break;
            }
        }
        return index;
    }
}

/// <summary>
/// Determines if the two halves of a string are alike based on the number of vowels.
/// </summary>
public class DetermineIfStringHalvesAreAlikeSolution {
    /// <summary>
    /// Checks if the two halves of the given string are alike in terms of the number of vowels.
    /// </summary>
    /// <param name="s">The input string.</param>
    /// <returns>True if the two halves are alike, false otherwise.</returns>
    public bool HalvesAreAlike(string s) {
        HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        int halfLength = s.Length / 2;
        int countVowels = 0;
        for (int i = 0; i < halfLength; i++) {
            if (vowels.Contains(s[i])) {
                countVowels++;
            }
        }
        for (int i = halfLength; i < s.Length; i++) {
            if (vowels.Contains(s[i])) {
                countVowels--;
            }
        }
        return countVowels == 0;
    }
}

/// <summary>
/// Class that calculates the product of an array except for the current element.
/// </summary>
public class ProductOfArrayExceptSelfSolution {
    /// <summary>
    /// Calculates the product of an array except for the current element.
    /// </summary>
    /// <param name="nums">The input array.</param>
    /// <returns>An array where each element is the product of all elements in the input array except for the current element.</returns>
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length;
        int[] result = new int[n];

        int leftProduct = 1;
        for (int i = 0; i < n; i++) {
            result[i] = leftProduct;
            leftProduct *= nums[i];
        }

        int rightProduct = 1;
        for (int i = n - 1; i >= 0; i--) {
            result[i] *= rightProduct;
            rightProduct *= nums[i];
        }

        return result;
    }
}

/// <summary>
/// Represents a solution for finding the intersection of two arrays.
/// </summary>
public class IntersectionOfTwoArraysSolution {
    /// <summary>
    /// Finds the intersection of two arrays.
    /// </summary>
    /// <param name="nums1">The first array.</param>
    /// <param name="nums2">The second array.</param>
    /// <returns>An array containing the intersection of the two input arrays.</returns>
    public int[] Intersection(int[] nums1, int[] nums2) {
        HashSet<int> set1 = new HashSet<int>(nums1);
        HashSet<int> set2 = new HashSet<int>(nums2);
        set1.IntersectWith(set2);
        return set1.ToArray();
    }
}

/// <summary>
/// Represents a solution for finding the minimum common value between two arrays.
/// </summary>
public class MinimumCommonValueSolution {
    /// <summary>
    /// Finds the minimum common value between two arrays.
    /// </summary>
    /// <param name="nums1">The first array.</param>
    /// <param name="nums2">The second array.</param>
    /// <returns>The minimum common value, or -1 if there is no common value.</returns>
    public int GetCommon (int[] nums1, int[] nums2) {
        int i = 0, j = 0;
        while (i < nums1.Length && j < nums2.Length) {
            if (nums1[i] < nums2[j]) {
                i++;
            } else if (nums1[i] > nums2[j]) {
                j++;
            } else {
                return nums1[i];
            }
        }
        return -1;
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

        PoweOfThreeSolution sol3 = new PoweOfThreeSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol3.IsPowerOfThree(27));

        ClimbingStairsSolution sol4 = new ClimbingStairsSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol4.ClimbStairs(3));

        DecodeWaysSolution sol5 = new DecodeWaysSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol5.NumDecodings("226"));

        PathCrossingSolution sol6 = new PathCrossingSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol6.IsPathCrossing("N"));

        BuyTwoChocolatesSolution sol7 = new BuyTwoChocolatesSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol7.BuyChoco(new int[] { 1, 2, 2, 1, 0 }, 4));

        ImageSmootherSolution sol8 = new ImageSmootherSolution();
        System.Console.WriteLine();
        int[][] image = { new int[] { 1, 1, 1 }, new int[] { 1, 0, 1 }, new int[] { 1, 1, 1 } };
        int[][] updatedImage = sol8.ImageSmoother(image);
        foreach (int[] row in updatedImage){
            foreach (int num in row){
                Console.Write(num + " ");
            }
        }

        ValidAnagramSolution sol9 = new ValidAnagramSolution();
        System.Console.WriteLine(); 
        System.Console.WriteLine(sol9.IsAnagram("anagram", "nagaram"));

        ElementAppearingMoreThen25PerCentSolution sol10 = new ElementAppearingMoreThen25PerCentSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol10.FindSpecialInteger(new int[] { 1, 1, 1, 2, 2, 3 }));

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

        NumberOf1BitsSolution sol14 = new NumberOf1BitsSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol14.HammingWeight(00000000000000000000000000001011));

        FindThePivotIntegerSolution sol15 = new FindThePivotIntegerSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol15.PivotInteger(1));

        PowerOfFourSolution sol16 = new PowerOfFourSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol16.IsPowerOfFour(16));

        CheckIsTwoStringArraysAreEquivalent sol17 = new CheckIsTwoStringArraysAreEquivalent();
        System.Console.WriteLine();
        System.Console.WriteLine(sol17.ArrayStringsAreEqual(new string[] { "abc", "d", "defg" }, new string[] { "abcddefg" }));

        LargestOddNumberInStringSolution sol18 = new LargestOddNumberInStringSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol18.LargestOddNumber("52"));

        MinimumChangesToMakeAlternatingStringSolution sol19 = new MinimumChangesToMakeAlternatingStringSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol19.MinOperations("0100"));

        BackspaceStringCompareSolution sol20 = new BackspaceStringCompareSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol20.BackspaceCompare("ab#c", "ad#c"));

        DetermineIfStringHalvesAreAlikeSolution sol21 = new DetermineIfStringHalvesAreAlikeSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol21.HalvesAreAlike("book"));

        ProductOfArrayExceptSelfSolution sol22 = new ProductOfArrayExceptSelfSolution();
        System.Console.WriteLine();
        int[] nums = { 1, 2, 3, 4 };
        int[] resultArray = sol22.ProductExceptSelf(nums);
        foreach (int num in resultArray){
            System.Console.Write(num + " ");
        }
        System.Console.WriteLine();

        IntersectionOfTwoArraysSolution sol23 = new IntersectionOfTwoArraysSolution();
        System.Console.WriteLine();

        int[] nums1 = { 1, 2, 2, 1 };
        int[] nums2 = { 2, 2 };
        
        int[] resultArr = sol23.Intersection(nums1, nums2);
        foreach (int num in resultArr){
            System.Console.Write(num + " ");
        }
        System.Console.WriteLine();

        MinimumCommonValueSolution sol24 = new MinimumCommonValueSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol24.GetCommon(new int[] { 1, 2, 3, 4 }, new int[] { 3, 4, 5, 6 }));
    }
}