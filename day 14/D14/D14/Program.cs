using D14ModelLib;

namespace D14
{
    internal class Program
    {
        /// <summary>
        /// Print the list of nodes in the LinkedList
        /// </summary>
        /// <param name="head"></param>
        public static void PrintList(ListNode head)
        {
            var current = head;
            while (current != null)
            {
                Console.WriteLine(current.val);
                current = current.next;
            }
        }

        /// <summary>
        /// Generates a List with/without cycle
        /// </summary>
        /// <param name="withCycle">Boolean value that decides whether the list is going to contain a cycle or not</param>
        /// <returns>Head of the list</returns>
        public static ListNode GenerateList(bool withCycle)
        {
            var head = new ListNode(10);
            head.next = new ListNode(12);
            head.next.next = new ListNode(13);
            head.next.next.next = new ListNode(14);

            if (withCycle)
            {
                head.next.next = head.next;
            }

            return head;
        }



        /// <summary>
        /// Generate a Tree
        /// </summary>
        /// <returns>A Tree with depth of 3</returns>
        public static TreeNode GenerateTreeNodes()
        {
            TreeNode root = new TreeNode();
            root.left = new TreeNode();
            root.right = new TreeNode();
            root.left.left = new TreeNode();
            root.right.left = new TreeNode();
            root.left.right = new TreeNode();
            root.right.right = new TreeNode();
            return root;
        }

        /// <summary>
        /// Given the HEAD of a LinkedList, this will return if the list contains a CYCLE
        /// </summary>
        /// <param name="head">The head of the LinkedList</param>
        /// <returns>The List contains a cycle or not</returns>
        public static bool HasCycle(ListNode head)
        {

            var fast = head;
            var slow = head;

            while (fast != null && fast.next != null && slow != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (fast == slow)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Given the root of the tree, this will return the minimum depth.
        /// </summary>
        /// <param name="root">The ROOT of the tree</param>
        /// <returns>the depth of the Tree</returns>
        public static int MinDepth(TreeNode root)
        {
            if (root == null) return 0;

            if (root.left == null && root.right == null) return 1;

            int l = int.MaxValue, r = int.MaxValue;

            if (root.left != null)
                l = MinDepth(root.left);

            if (root.right != null)
                r = MinDepth(root.right);

            return 1 + int.Min(l, r);
        }

        /// <summary>
        /// Given an integer columnNumber, return its corresponding column title as it appears in an Excel sheet. 
        /// </summary>
        /// <param name="columnNumber">the column number</param>
        /// <returns></returns>
        public static string ConvertToTitle(int columnNumber)
        {
            string res = "";

            while (columnNumber > 0)
            {
                int offset = (columnNumber - 1) % 26;

                res += (char)('A' + offset);

                columnNumber = (columnNumber - 1) / 26;
            }
            var arr = res.ToCharArray();

            Array.Reverse(arr);

            return arr.ToString();
        }

        static void Main(string[] args)
        {

            //Console.WriteLine(ConvertToTitle(2));
            //Console.WriteLine(HasCycle(GenerateList(withCycle: false)));
            //Console.WriteLine(MinDepth(GenerateTreeNodes()));
        }
    }
}
