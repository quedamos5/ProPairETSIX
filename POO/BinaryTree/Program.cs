namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BTree bTree = new BTree();
            Node root = bTree.Insert(10, null);
            bTree.Insert(9, root);
            bTree.Insert(19, root);
            bTree.Insert(11, root);
            bTree.Insert(5, root);
            bTree.Insert(1, root);
            bTree.Insert(3, root);
            bTree.Insert(18, root);
            bTree.Insert(22, root);
            bTree.Insert(15, root);
            bTree.Insert(2, root);
            bTree.Insert(7, root);
            bTree.TransversaInO(root);
        }
    }
}