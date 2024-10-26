using System.Collections.Concurrent;
using System.Text;

/// <summary>
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

/// <summary>
/// Represents a solution for finding the maximum length of a contiguous subarray with equal number of 0s and 1s.
/// </summary>
public class ContiguousArraySolution {
    /// <summary>
    /// Finds the maximum length of a contiguous subarray with equal number of 0s and 1s.
    /// </summary>
    /// <param name="nums">The input array of integers.</param>
    /// <returns>The maximum length of a contiguous subarray with equal number of 0s and 1s.</returns>
    public int FindMaxLength (int[] nums) {
        Dictionary<int, int> map = new Dictionary<int, int>(){
            {0, -1}
        };
        int count = 0;
        int maxLength = 0;
        
        for (int i = 0; i < nums.Length; i++) {
            count = count + (nums[i] == 1 ? 1 : -1);

            if (map.ContainsKey(count)) {
                maxLength = Math.Max(maxLength, i - map[count]);
            } else {
                map.Add(count, i);
            }
        }

        return maxLength;
    }
}

/// <summary>
/// Represents a solution for finding the mode(s) in a binary search tree.
/// </summary>
public class FindModeInBinarySearchTreeSolution {
    private int currVal;
    private int currCount = 0;
    private int maxCount = 0;
    private int modeCount = 0;

    private int[] modes;

    /// <summary>
    /// Finds the mode(s) in the given binary search tree.
    /// </summary>
    /// <param name="root">The root node of the binary search tree.</param>
    /// <returns>An array containing the mode(s) in the binary search tree.</returns>
    public int[] FindMode(TreeNode root) {
        Inorder(root);
        modes = new int[modeCount];
        currCount = 0;
        modeCount = 0;
        Inorder(root);
        return modes;
    }

    /// <summary>
    /// Handles the given value and updates the current value, count, and mode count.
    /// </summary>
    /// <param name="val">The value to be handled.</param>
    private void HandleValue(int val) {
        if (val != currVal) {
            currVal = val;
            currCount = 0;
        }
        currCount++;
        if (currCount > maxCount) {
            maxCount = currCount;
            modeCount = 1;
        } else if (currCount == maxCount) {
            if (modes != null) {
                modes[modeCount] = currVal;
            }
            modeCount++;
        }
    }

    /// <summary>
    /// Performs an inorder traversal of a binary tree rooted at the specified node.
    /// </summary>
    /// <param name="node">The root node of the binary tree.</param>
    private void Inorder(TreeNode node) {
        if (node == null) return;
        Inorder(node.left);
        HandleValue(node.val);
        Inorder(node.right);
    }
}

/// <summary>
/// Represents a solution for sorting integers by the number of 1 bits.
/// </summary>
public class SortIntegersByTheNumberOf1BitsSolution {
    /// <summary>
    /// Sorts the given array of integers by the number of 1 bits in each integer.
    /// </summary>
    /// <param name="arr">The array of integers to be sorted.</param>
    /// <returns>The sorted array of integers.</returns>
    public int[] SortByBits (int[] arr) {
        Array.Sort (arr, (a, b) => BitCount (a) == BitCount (b) ? a - b : BitCount (a) - BitCount (b));
        return arr;
    }

    /// <summary>
    /// Calculates the number of 1 bits in the given integer.
    /// </summary>
    /// <param name="n">The integer for which to calculate the number of 1 bits.</param>
    /// <returns>The number of 1 bits in the given integer.</returns>
    private int BitCount (int n) {
        int count = 0;
        while (n != 0) {
            n &= (n - 1);
            count++;
        }
        return count;
    }
}

/// <summary>
/// Represents a solution for finding words that can be formed by characters.
/// </summary>
public class FindWordsThatCanBeFormedByCharactersSolution {
    /// <summary>
    /// Counts the total length of words that can be formed using the given characters.
    /// </summary>
    /// <param name="words">An array of words to check.</param>
    /// <param name="chars">A string of characters to form the words.</param>
    /// <returns>The total length of words that can be formed.</returns>
    public int CountCharacters (string[] words, string chars) {
        int[] charCount = new int[26];
        foreach (char c in chars) {
            charCount[c - 'a']++;
        }

        int totalLength = 0;
        int[] wordCount = new int[26];
        foreach (string word in words) {
            Array.Clear(wordCount, 0, 26);
            bool canForm = true;
            foreach (char c in word) {
                wordCount[c - 'a']++;
                if (wordCount[c - 'a'] > charCount[c - 'a']) {
                    canForm = false;
                    break;
                }
            }
            if (canForm) {
                totalLength += word.Length;
            }
        }
        return totalLength;
    }
}

public class CoinSolution {
    public class Coin { 
        public double Probability { get; set; }
    }

    public class Solution {
        private Random random = new Random();

        public Coin FindWonderfullCoin(Coin[] coins, int K) {
            double[] estimates = new double[coins.Length];

            for (int i = 0; i < coins.Length; i++) {
                int tails = 0;
                for (int j = 0; j < K; j++) {
                    if (FlipCoin(coins[i]))
                        tails++;
                }
                estimates[i] = Math.Abs(tails / (double) K - 0.5);
            }

            Array.Sort(estimates, coins);
            return coins.Length >= 4 ? coins[3] : null;
        }

        private bool FlipCoin(Coin coin) {
            return random.NextDouble() < coin.Probability;
        }
    }
}

/// <summary>
/// Represents a solution for finding the duplicate and missing numbers in an array.
/// </summary>
public class SetMismatchSolution {
    /// <summary>
    /// Finds the duplicate and missing numbers in the given array.
    /// </summary>
    /// <param name="nums">The array of numbers.</param>
    /// <returns>An array containing the duplicate and missing numbers.</returns>
    /// </summary>
    public int[] FindErrorNums(int[] nums) {
        int[] freq = new int[nums.Length + 1];
        int dup = -1;
        int missing = -1;

        for (int i = 0; i < nums.Length; i++) {
            freq[nums[i]]++;
        }

        for (int i = 1; i < freq.Length; i++) {
            if (freq [i] == 0) {
                missing = i;
            }
            else if (freq[i] == 2) {
                dup = i;
            }
        }

        return new int[] { dup, missing };
    }
}

/// <summary>
/// Represents a solution for finding the index of the first unique character in a string.
/// </summary>
public class FirstUniqueCharacterInAStringSolution {
    /// <summary>
    /// Finds the index of the first unique character in the given string.
    /// </summary>
    /// <param name="s">The input string.</param>
    /// <returns>The index of the first unique character, or -1 if no unique character is found.</returns>
    /// </summary>
    public int FirstUniqueChar(string s) {
        int[] frequency = new int[26];

        for (int i = 0; i < s.Length; i++) {
            frequency[s[i] - 'a']++;
        }

        for (int i = 0; i < s.Length; i++) {
            if (frequency[s[i] - 'a'] == 1) {
                return i;
            }   
        } 
        return -1;
    }
}

/// <summary>
/// Represents a solution for finding the missing number in an array.
/// </summary>
public class MissingNumberSolution {
    /// <summary>
    /// Finds the missing number in the given array.
    /// </summary>
    /// <param name="nums">The array of numbers.</param>
    /// <returns>The missing number.</returns>
    public int MissingNumber(int[] nums) {
        int expectedSum = 0;
        int actualSum = 0;

        for (int i = 0; i < nums.Length; i++) {
            actualSum += nums[i];
            expectedSum += i + 1;
        }

        return expectedSum - actualSum;
    }
}

/// <summary>
/// Represents a solution for determining if two binary trees are the same.
/// </summary>
public class SameTreeSolution {
    /// <summary>
    /// Determines if two binary trees are the same.
    /// </summary>
    /// <param name="p">The root node of the first binary tree.</param>
    /// <param name="q">The root node of the second binary tree.</param>
    /// <returns>True if the two binary trees are the same, false otherwise.</returns>
    public bool IsSameTree(TreeNode p, TreeNode q) {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(p);
        queue.Enqueue(q);

        while (queue.Count > 0){
            p = queue.Dequeue();
            q = queue.Dequeue();

            if (p == null && q == null) continue;
            if (p == null || q == null) return false;
            if (p.val != q.val) return false;

            queue.Enqueue(p.left);
            queue.Enqueue(q.left);

            queue.Enqueue(p.right);
            queue.Enqueue(q.right);
        }

        return true;
    }
}

/// <summary>
/// Represents a solution for calculating the perimeter of an island in a grid.
/// </summary>
public class IslandPerimeterSolution {
    /// <summary>
    /// Calculates the perimeter of an island in the given grid.
    /// </summary>
    /// <param name="grid">The grid representing the island.</param>
    /// <returns>The perimeter of the island.</returns>
    public int IslandPerimeter(int[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int perimeter = 0;

        for (int i = 0; i< rows; i++) {
            for (int j = 0; j < cols; j++) {
                if (grid[i][j] == 1) {
                    perimeter += 4;

                    if (i < rows - 1 && grid[i + 1][j] == 1) {
                        perimeter -= 2;
                    }

                    if (j < cols - 1 && grid[i][j + 1] == 1) {
                        perimeter -= 2;
                    }
                }
            }
        }

        return perimeter;
    }
}

/// <summary>
/// Represents a solution for counting the number of islands in a grid.
/// </summary>
public class NumberOfIslandsSolution {
    /// <summary>
    /// Represents an array of directions.
    /// </summary>
    private int[][] directions = new int[][] { 
        new int[] { 1, 0 }, 
        new int[] { -1, 0 }, 
        new int[] { 0, 1 }, 
        new int[] { 0, -1 } 
    };

    /// <summary>
    /// Counts the number of islands in the given grid.
    /// </summary>
    /// <param name="grid">The grid representing the land and water.</param>
    /// <returns>The number of islands in the grid.</returns>
    public int NumIslands(char[][] grid) {
        if (grid == null || grid.Length == 0) {
            return 0;
        }

        int numIslands = 0;

        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[0].Length; j++) {
                if (grid[i][j] == '1') {
                    numIslands++;
                    DFS(grid, i, j);
                }
            }
        }

        return numIslands;
    }

    /// <summary>
    /// Performs a depth-first search (DFS) on the given grid starting from the specified position (i, j).
    /// </summary>
    /// <param name="grid">The grid to perform the DFS on.</param>
    /// <param name="i">The row index of the starting position.</param>
    /// <param name="j">The column index of the starting position.</param>
    private void DFS (char[][] grid, int i, int j) {
        if (i < 0 || 
        i >= grid.Length || 
        j < 0 || 
        j >= grid[0].Length || 
        grid[i][j] == '0') {
            return;
        }

        grid[i][j] = '0';

        foreach (var direction in directions) {
            DFS(grid, i + direction[0], j + direction[1]);
        }
    }
}

/// <summary>
/// Represents a solution for finding the length of the last word in a string.
/// </summary>
public class LengthOfLastWordSolution {
    /// <summary>
    /// Calculates the length of the last word in the given string.
    /// </summary>
    /// <param name="s">The input string.</param>
    /// <returns>The length of the last word.</returns>
    private int lengthOfLastWord(string s){
        int i = s.Length - 1;

        while (s[i] == ' '){
            i--;
        }

        int count = 0;

        while (i >= 0 && s[i] != ' '){
            i--;
            count++;
        }

        return count;
    }
} 

/// <summary>
/// Represents a solution for finding the Nth Tribonacci number.
/// </summary>
public class NthTribonacciNumberSolution {
    private int Tribonacci (int n){
        if (n == 0) return 0;
        if (n == 1 || n == 2) return 1;

        int[] tribonacci = new int[n + 1];
        tribonacci[0] = 0;
        tribonacci[1] = 1;
        tribonacci[2] = 1;

        for (int i = 3; i <= n; i++) {
            tribonacci[i] = tribonacci[i - 1] + tribonacci[i - 2] + tribonacci[i - 3];
        }

        return tribonacci[n];
    }
}

/// <summary>
/// Represents a solution for finding the length of the longest palindrome in a given string.
/// </summary>
public class LongestPalindromeSolution {
    /// <summary>
    /// Finds the length of the longest palindrome in the given string.
    /// </summary>
    /// <param name="s">The input string.</param>
    /// <returns>The length of the longest palindrome.</returns>
    public int LongestPalindrome(string s) {
        HashSet<char> oddChars = new HashSet<char>();
        
        foreach (char c in s) {
            if (oddChars.Contains(c)) {
                oddChars.Remove(c);
            } else {
                oddChars.Add(c);
            }
        }

        int oddCount = oddChars.Count;
        return s.Length - oddCount + (oddCount > 0 ? 1 : 0);
    }
}

/// <summary>
/// Represents a solution for sorting an array based on the relative order of elements in another array.
/// </summary>
public class RelativeSortArraySolution {
    /// <summary>
    /// Sorts the given array <paramref name="arr1"/> based on the relative order of elements in <paramref name="arr2"/>.
    /// </summary>
    /// <param name="arr1">The array to be sorted.</param>
    /// <param name="arr2">The array that defines the relative order of elements.</param>
    /// <returns>The sorted array.</returns>
    public int[] RelativeSortArray(int[] arr1, int[] arr2) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        for (int i = 0; i < arr2.Length; i++) {
            map[arr2[i]] = i;
        }

        Array.Sort(arr1, (a, b) => {
            if (map.ContainsKey(a) && map.ContainsKey(b)) {
                return map[a] - map[b];
            } else if (map.ContainsKey(a)) {
                return -1;
            } else if (map.ContainsKey(b)) {
                return 1;
            } else {
                return a - b;
            }
        });

        return arr1;
    }
}

/// <summary>
/// Represents a solution for finding the intersection of two arrays.
/// </summary>
public class IntersectionOfTwoArraysTheSecondSolution {
    /// <summary>
    /// Finds the intersection of two arrays.
    /// </summary>
    /// <param name="nums1">The first array.</param>
    /// <param name="nums2">The second array.</param>
    /// <returns>An array containing the intersection of the two input arrays.</returns>
    public int[] Intersection(int[] nums1, int[] nums2) {
        Dictionary<int, int> count = new Dictionary<int, int>();
        List<int> result = new List<int>();

        foreach (int num in nums1) {
            if (count.ContainsKey(num)) {
                count[num]++;
            } else {
                count[num] = 1;;
            }
        }

        foreach (int num in nums2) {
            if (count.ContainsKey(num) && count[num] > 0) {
                result.Add(num);
                count[num]--;
            }
        }

        return result.ToArray();
    }
}

/// <summary>
/// Represents a solution for replacing words in a sentence based on a given dictionary.
/// </summary>
public class ReplaceWordsSolution {
    /// <summary>
    /// Replaces words in the given sentence based on the shortest root found in the dictionary.
    /// </summary>
    /// <param name="dictionary">The list of words in the dictionary.</param>
    /// <param name="sentence">The sentence to be processed.</param>
    /// <returns>The sentence with replaced words.</returns>
    public string ReplaceWords(IList<string> dictionary, string sentence) {
        SortedSet<string> rootSet = new SortedSet<string>(dictionary);
        string[] words = sentence.Split(' ');

        for (int i = 0; i < words.Length; i++) {
            words[i] = GetShortestRoot(words[i], rootSet);
        }

        return string.Join(" ", words);
    }

    /// <summary>
    /// Finds the shortest root in a given word from a sorted set of roots.
    /// </summary>
    /// <param name="word">The word to find the shortest root in.</param>
    /// <param name="rootSet">The sorted set of roots to search in.</param>
    /// <returns>The shortest root found in the word, or the word itself if no root is found.</returns>
    private string GetShortestRoot(string word, SortedSet<string> rootSet) {
        foreach (string root in rootSet) {
            if (word.StartsWith(root)) {
                return root;
            }
        }

        return word;
    }
}

/// <summary>
/// Represents a solution for the height checker problem.
/// </summary>
public class HeightCheckerSolution {
    /// <summary>
    /// Calculates the number of elements in the given array that are out of order when compared to the sorted version of the array.
    /// </summary>
    /// <param name="heights">The array of heights to check.</param>
    /// <returns>The number of elements that are out of order.</returns>
    public int HeightChecker(int[] heights) {
        /*int[] expected = (int[])heights.Clone();
        Array.Sort(expected);

        int count = 0;
        for (int i = 0; i < heights.Length; i++) {
            if (heights[i] != expected[i]) {
                count++;
            }
        }
        return count;
        */

        int maxHeight = 0;
        foreach (int height in heights) {
            if (height > maxHeight) {
                maxHeight = height;
            }
        }

        int[] count = new int[maxHeight + 1];
        foreach (int height in heights) {
            count[height]++;
        }

        int[] expected = new int[heights.Length];
        int index = 0;
        for (int height = 0; height <= maxHeight; height++) {
            while (count[height] > 0) {
                expected[index++] = height;
                count[height]--;
            }
        }

        int mismatchCount = 0;
        for (int i = 0; i < heights.Length; i++) {
            if (heights[i] != expected[i]) {
                mismatchCount++;
            }
        }

        return mismatchCount;
    }
}

/// <summary>
/// Represents a solution for finding three consecutive odd numbers in an array.
/// </summary>
public class ThreeConsecutiveOddsSolution {
    /// <summary>
    /// Determines whether there are three consecutive odd numbers in the given array.
    /// </summary>
    /// <param name="arr">The array of integers.</param>
    /// <returns>True if there are three consecutive odd numbers, otherwise false.</returns>
    public bool ThreeConsecutiveOdds(int[] arr) {
        for (int i = 0; i < arr.Length - 2; i++) {
            if ((arr[i] & 1) == 1 && (arr[i + 1] & 1) == 1 && (arr[i + 2] & 1) == 1) {
                return true;
            }
        }
        return false;
    }
}

/// <summary>
/// Represents a solution for finding the majority element in an array.
/// </summary>
public class MajorityElementSolution {
    /// <summary>
    /// Finds the majority element in the given array.
    /// </summary>
    /// <param name="nums">The array of integers.</param>
    /// <returns>The majority element, or 0 if there is no majority element.</returns>
    public int MajorityElement(int[] nums) {
        int count = 0;
        int candidate = 0;

        foreach (int num in nums) {
            if (count == 0) {
                candidate = num;
            }
            count += (num == candidate) ? 1 : -1;
        }

        count = 0;
        foreach (int num in nums) {
            if (num == candidate) {
                count++;
            }
        }

        if (count > nums.Length / 2) {
            return candidate;
        }

        return 0;
    }
}

/// <summary>
/// Represents a class that finds the first palindromic string in an array of words.
/// </summary>
public class FindFirstPalindromicStringInTheArray {
    /// <summary>
    /// Finds the first palindromic string in the given array of words.
    /// </summary>
    /// <param name="words">The array of words to search.</param>
    /// <returns>The first palindromic string found, or an empty string if no palindromic string is found.</returns>
    public string FirstPalindrome (string[] words) {
        foreach (string word in words) {
            if (IsPalindrome(word)) {
                return word;
            }
        }
        return "";
    }

    /// <summary>
    /// Determines whether a given word is a palindrome.
    /// </summary>
    /// <param name="word">The word to check.</param>
    /// <returns>True if the word is a palindrome, false otherwise.</returns>
    private bool IsPalindrome (string word) {
        int left = 0;
        int right = word.Length - 1;

        while (left < right) {
            if (word[left] != word[right]) {
                return false;
            }
            left++;
            right--;
        }

        return true;
    }
}

/// <summary>
/// Represents a solution for finding the town judge.
/// </summary>
public class FindTheTownJudgeSolution {
    /// <summary>
    /// Finds the town judge based on the given trust relationships.
    /// </summary>
    /// <param name="n">The number of people in the town.</param>
    /// <param name="trust">The trust relationships represented as an array of integer arrays.</param>
    /// <returns>The town judge's label if found, otherwise -1.</returns>
    public int FindJudge(int n, int[][] trust) {
        if (n == 1) return 1;

        int[] trustCount = new int[n + 1];

        foreach (var tr in trust) {
            int a = tr[0];
            int b = tr[1];

            trustCount[a]--;
            trustCount[b]++;
        }

        for (int i =1; i <= n; i++) {
            if (trustCount[i] == n - 1) {
                return i;
            }
        }

        return -1;
    }
}

/// <summary>
/// Represents a solution for finding the maximum odd binary number.
/// </summary>
public class MaximumOddBinaryNumberSolution {
    /// <summary>
    /// Finds the maximum odd binary number based on the given string.
    /// </summary>
    /// <param name="s">The input string.</param>
    /// <returns>The maximum odd binary number.</returns>
    public string MaximumOddBinaryNumber (string s) {
        int ones = 0;
        int zeros = 0;

        foreach (char c in s) {
            if (c == '1') {
                ones++;
            } else {
                zeros++;
            }
        }

        return new string('1', ones - 1) + new string ('0', zeros) + 1;
    }
}

/// <summary>
/// Represents a solution for counting elements with maximum frequency in an array.
/// </summary>
public class CountElementsWithMaximumRequencySolution {
    /// <summary>
    /// Calculates the total count of elements with the maximum frequency in the given array.
    /// </summary>
    /// <param name="nums">The array of integers.</param>
    /// <returns>The total count of elements with the maximum frequency.</returns>
    public int maxFrequencyElements(int[] nums) {
        Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

        foreach (int num in nums) {
            if (frequencyMap.ContainsKey(num)) {
                frequencyMap[num]++;
            }
            else {
                frequencyMap[num] = 1;
            }
        }

        int maxFrequency = 0;
        foreach (int frequency in frequencyMap.Values) {
            maxFrequency = Math.Max(maxFrequency, frequency);
        }

        int total = 0;
        foreach (int frequency in frequencyMap.Values) {
            if (frequency == maxFrequency) {
                total += frequency;
            }
        }

        return total;
    }
}

/// <summary>
/// Represents a solution for the Game of Life problem.
/// </summary>
public class GameOfLifeSolution {
    // __define-ocg__ This method calculates the next generation of the Game of Life
    public string CodingChallenge(string str) {
        // Parse the input string to create the grid
        string[] rows = str.Split('_');
        int n = rows.Length;
        int m = rows[0].Length;
        int[,] grid = new int[n, m];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                grid[i, j] = rows[i][j] - '0';
            }
        }

        // Create a copy of the grid to store the next generation
        int[,] gridCopy = new int[n, m];
        int[] directions = { -1, 0, 1 };

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                int liveNeighbors = 0;
                foreach (int dirI in directions) {
                    foreach (int dirJ in directions) {
                        if (dirI == 0 && dirJ == 0) continue;
                        int nI = i + dirI;
                        int nJ = j + dirJ;
                        if (nI >= 0 && nI < n && nJ >= 0 && nJ < m && grid[nI, nJ] == 1) {
                            liveNeighbors++;
                        }
                    }
                }

                if (grid[i, j] == 1 && (liveNeighbors < 2 || liveNeighbors > 3)) {
                    gridCopy[i, j] = 0; // Death
                } else if (grid[i, j] == 0 && liveNeighbors == 3) {
                    gridCopy[i, j] = 1; // Alive
                } else {
                    gridCopy[i, j] = grid[i, j]; // Same state
                }
            }
        }

        StringBuilder result = new StringBuilder();
        for (int i = 0; i < n; i++) {
            if (i > 0) result.Append('_');
            for (int j = 0; j < m; j++) {
                result.Append(gridCopy[i, j]);
            }
        }

        return result.ToString();
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

        ContiguousArraySolution sol25 = new ContiguousArraySolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol25.FindMaxLength(new int[] { 0, 1 }));

        FindModeInBinarySearchTreeSolution sol26 = new FindModeInBinarySearchTreeSolution();
        /*System.Console.WriteLine();

        TreeNode root = new TreeNode(1);
        root.right = new TreeNode(2);
        root.right.left = new TreeNode(2);

        int[] resultArray1 = sol26.FindMode(root);
        foreach (int num in resultArray1){
            System.Console.Write(num + " ");
        }*/

        SortIntegersByTheNumberOf1BitsSolution sol27 = new SortIntegersByTheNumberOf1BitsSolution();
        System.Console.WriteLine();
        
        int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        
        int[] resultArray2 = sol27.SortByBits(arr);
        foreach (int num in resultArray2){
            System.Console.Write(num + " ");
        }
        System.Console.WriteLine();

        FindWordsThatCanBeFormedByCharactersSolution sol28 = new FindWordsThatCanBeFormedByCharactersSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol28.CountCharacters(new string[] { "cat", "bt", "hat", "tree" }, "atach"));

        SetMismatchSolution sol29 = new SetMismatchSolution();
        System.Console.WriteLine();
        int[] arr1 = { 1, 2, 2, 4 };

        int[] resultArray3 = sol29.FindErrorNums(arr1);
        foreach (int el in resultArray3){
            System.Console.Write(el + " ");
        }
        System.Console.WriteLine();

        FirstUniqueCharacterInAStringSolution sol30 = new FirstUniqueCharacterInAStringSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol30.FirstUniqueChar("loveleetcode"));


        MissingNumberSolution sol31 = new MissingNumberSolution();
        System.Console.WriteLine();
        System.Console.WriteLine(sol31.MissingNumber(new int[] { 3, 0, 1 }));

        GameOfLifeSolution sol = new GameOfLifeSolution();
        string input = "11";
        string varOcg = sol.CodingChallenge(input); // Variable named varOcg
        Console.WriteLine(varOcg); // Output should be "010_010_010"
    }
}