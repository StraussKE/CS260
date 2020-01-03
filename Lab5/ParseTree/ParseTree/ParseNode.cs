
namespace ParseTreeClasses
{
    public class ParseNode
    {
        public char value;
        public ParseNode left;
        public ParseNode right;
        public ParseNode(char value) { this.value = value; left = right = null; }
    }
}
