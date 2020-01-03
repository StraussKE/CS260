using System.Collections.Generic;
using System.Linq;

namespace ParseTreeClasses
{
    public class ParseTree
    {
        // constants for parsing
        private const char PLUS = '+';
        private const char MINUS = '-';
        private const char MULT = '*';
        private const char DIV = '/';
        private const char MOD = '%';
        private const char SPACE = ' ';
        private const char LPAREN = '(';
        private const char RPAREN = ')';

        private ParseNode root;

        public ParseTree(string input)
        {
            if (input == "")
                root = null;
            else
                root = DoParse(input);
        }

        public string PreOrder()
        {
            return RecPreOrder(root);
        }

        public string PostOrder()
        {
            return RecPostOrder(root);
        }

        public string InOrder()
        {
            return RecInOrder(root);
        }

        private string RecPreOrder(ParseNode ptr)
        {
            if (ptr != null)
            {
                string buffer = "";
                buffer += ptr.value;
                buffer += RecPreOrder(ptr.left);
                buffer += RecPreOrder(ptr.right);
                return buffer;
            }
            return "";
        }

        private string RecPostOrder(ParseNode ptr)
        {
            if (ptr != null)
            {
                string buffer = "";
                buffer += RecPostOrder(ptr.left);
                buffer += RecPostOrder(ptr.right);
                buffer += ptr.value;
                return buffer;
            }
            return "";
        }

        private string RecInOrder(ParseNode ptr)
        {
            if (ptr != null)
            {
                string buffer = "";
                if (ptr.left != null)
                    buffer += '(';
                buffer += RecInOrder(ptr.left);
                buffer += ptr.value;
                buffer += RecInOrder(ptr.right);
                if (ptr.right != null)
                    buffer += ')';
                return buffer;
            }
            return "";
        }

        // This assumes the input is a properly formed postFix expression
        // that contains only single letter operands and operators
        private ParseNode DoParse(string input)
        {
            // Get next char
            // if char is letter, Push
            // if char is operator, Pop to right, Pop to left, Push
            Stack<ParseNode> theStack = new Stack<ParseNode>();
            for (int i = 0; i < input.Count(); i++)
            {
                char letter = input[i];

                if (char.IsLetter(letter))
                {
                    theStack.Push(new ParseNode(letter));
                }
                else
                {
                    ParseNode temp = new ParseNode(letter);
                    temp.right = theStack.Peek();
                    theStack.Pop();
                    temp.left = theStack.Peek();
                    theStack.Pop();
                    theStack.Push(temp);
                }
            }
            return theStack.Peek();
        }

        /*
         * helper function
         *    return true for operators
         *    false otherwise
         */
        private bool IsOperator(char value)
        {

            switch (value)
            {
                case PLUS:
                case MINUS:
                case MULT:
                case DIV:
                case MOD:
                    return true;
                default:
                    return false;
            }
        }

        /*
         * helper function
         *    return true for operands
         *    false otherwise
         */
        private bool IsOperand(char value)
        {
            return char.IsLetterOrDigit(value);
        }

        /*
         * helper function
         *
         * return true if operator1 higher precedence than operator2
         *
         */
        private bool HigherPrec(char oper1, char oper2)
        {
            return GetPrec(oper1) > GetPrec(oper2);
        }

        /*
         * helper function for higherPrec
         *
         * return weight of operator
         */
        private int GetPrec(char oper)
        {
            int prec = -1;
            switch (oper)
            {
                case PLUS:
                case MINUS:
                    prec = 1;
                    break;
                case MULT:
                case DIV:
                case MOD:
                    prec = 2;
                    break;
                default:
                    break;
            }
            return prec;
        }

        // converts a proper in order expression to postfix
        private string InOrder2PostOrder(string input)
        {
            Stack<char> theStack = new Stack<char>();
            string buffer = "";

            for (int i = 0; i < input.Count(); i++)
            {
                char next = input[i];

                // skip over white space
                if (next == SPACE)
                {
                    continue;
                }
                // output all operands
                else if (IsOperand(next))
                {
                    buffer += next;
                }
                // push opening parens
                else if (next == LPAREN)
                {
                    theStack.Push(next);
                }
                // closing paren
                // pop and output until matching opening paren
                else if (next == RPAREN)
                {
                    while (theStack.Any())
                    {
                        char value = theStack.Peek();
                        theStack.Pop();
                        if (value == LPAREN)
                        {
                            break;
                        }
                        else
                        {
                            buffer += value;
                        }
                    }
                }
                // operator
                // pop and output anything on stack
                //   until opening paren or higher precedence
                // push this one on stack
                else if (IsOperator(next))
                {
                    while (theStack.Any())
                    {
                        char value = theStack.Peek();
                        theStack.Pop();
                        if (value == LPAREN)
                        {
                            theStack.Push(value);
                            break;
                        }
                        else
                        {
                            if (HigherPrec(next, value))
                            {
                                theStack.Push(value);
                                break;
                            }
                            else
                            {
                                buffer += value;
                            }
                        }
                    }
                    theStack.Push(next);
                }
            }

            // get any remaining operators on stack
            while (theStack.Any())
            {
                buffer += theStack.Peek();
                theStack.Pop();
            }

            // return the result
            return buffer;
        }

        public void ParseInOrder(string input)
        {
            root = DoParse(InOrder2PostOrder(input));
        }
    }
}
