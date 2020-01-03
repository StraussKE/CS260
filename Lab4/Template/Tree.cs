using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4TemplateConsoleApp
{
    // definition of class
    // using public variables rather than setters/getters

    template<class T>
    class Node
    {
        public:
        // constructor to build new node
    Node(T value) : left(nullptr), right(nullptr), value(value), present(true) { }

        // public variables for contents
        Node* left;
        Node* right;
        T value;
        bool present;
    };

    class Tree
    {
    }
}
/*
//
//  Tree.h
//  binary_search_tree
//
//  Created by Jim Bailey on 11/1/17.
//  Licensed under a Creative Commons Attribution 4.0 International License.
//

    // definition of class
    // using public variables rather than setters/getters
template <class T>
class Node
{
public:
        // constructor to build new node
    Node(T value) : left(nullptr), right(nullptr), value(value), present(true) {}
    
        // public variables for contents
    Node *left;
    Node *right;
    T value;
    bool present;
};

    // definition of binary search tree
template <class T>
class Tree
{
private:
    Node<T> * root;
    
        // for display function
    static const int SPACE = 8;
    
        // private functions for recursion
    bool recFind(T value, Node<T> *ptr);
    std::string recPreOrder(Node<T> *ptr);
    std::string recInOrder(Node<T> *ptr);
    std::string recPostOrder(Node<T> *ptr);
    
        // recursive method for destructor
    void recDestruct(Node<T> *ptr);
    
        // recursive method for display
    std::string recDisplay(Node<T> *ptr, int level);
    
public:
        // constructor and destructor
    Tree() { root = nullptr; }
    ~Tree() { recDestruct(root); }
    
        // maintenance methods
    void insertItem(T value);
    bool isPresent(T value);
        // delete by marking absent
    bool removeItem(T value);
    
        // traversals
    std::string preOrder();
    std::string inOrder();
    std::string postOrder();
    
        // graphical display
    std::string displayTree();
};

// recursive destructor, does the work
template <class T>
void Tree<T>::recDestruct(Node<T> *ptr)
{
    // if at leaf, nothing to do
    if ( ptr == nullptr )
        return;
    
    // delete children
    recDestruct(ptr->left);
    recDestruct(ptr->right);
    
    // delete self
    delete ptr;
}

// Add a node containing value
template <class T>
void Tree<T>::insertItem(T value)
{
    // special case empty tree
    if ( root == nullptr )
    {
        root = new Node<T>(value);
        return;
    }
    
    // now we start at root
    // find proper leaf location
    // and add it there
    Node<T> * ptr = root;
    while ( true )
    {
        // see if happens to have right value and deleted
        if ( ptr->value == value and !ptr->present )
        {
            ptr->present = true;
            return;
        }
        
        // see if add to the left
        if ( ptr->value > value )
        {
            // nothing there, leaf
            if ( ptr->left == nullptr )
            {
                ptr->left = new Node<T>(value);
                return;
            }
            // need to go down branch further
            else
            {
                ptr = ptr->left;
            }
        }
        // otherwise we are going right
        else
        {
            // nothing there, leaf
            if ( ptr->right == nullptr )
            {
                ptr->right = new Node<T>(value);
                return;
            }
            // need to go down branch further
            else
            {
                ptr = ptr->right;
            }
        }
    }
}

// return true if value is in the tree
template <class T>
bool Tree<T>::isPresent(T value)
{
    return recFind(value, root);
}

// recursive find used to implement isPresent
template <class T>
bool Tree<T>::recFind(T value, Node<T> *ptr)
{
    // base case
    if ( ptr == nullptr )
        return false;
    
    // base, found
    if ( ptr->value == value and ptr->present )
        return true;
    
    // need to go further, check appropriate subtree
    if ( ptr->value > value )
        return recFind(value, ptr->left);
    else
        return recFind(value, ptr->right);
}


// delete by marking absent
// based on non-recursive find
template <class T>
bool Tree<T>::removeItem(T value)
{
    // start at root
    Node<T> * ptr = root;
    
    // until done with path
    while (ptr != nullptr )
    {
        if ( ptr->value == value and ptr->present )
        {
            ptr->present = false;
            return true;
        }
        if ( ptr->value > value )
            ptr = ptr->left;
        else
            ptr = ptr->right;
    }
    return false;
}


// traversals
template <class T>
std::string Tree<T>::preOrder()
{
    return recPreOrder(root);
}
template <class T>
std::string Tree<T>::inOrder()
{
    return recInOrder(root);
}
template <class T>
std::string Tree<T>::postOrder()
{
    return recPostOrder(root);
}


// graphical display
template <class T>
std::string Tree<T>::displayTree()
{
    return recDisplay(root, 0);
}
// recursive methods called by public methods
template <class T>
std::string Tree<T>::recDisplay(Node<T> *ptr, int space)
{
    // base case, quit on leaf
    if ( ptr == nullptr )
        return "";
    
    std::stringstream buffer;
    space += SPACE;
    
    buffer << recDisplay(ptr->right, space);
    buffer << std::endl << std::setw(space-SPACE) << " " << std::setw(4) << ptr->value;
    if ( ptr->present )
        buffer << std::endl;
    else
        buffer << " dele" << std::endl;
    buffer << recDisplay(ptr->left, space);
    
    return buffer.str();
}

// recursive traversals, build string from value
template <class T>
std::string Tree<T>::recPreOrder(Node<T> *ptr)
{
    std::string buffer = "";
    
    // if done with branch, return empty
    if ( ptr == nullptr )
        return buffer;
    
    // get this nodes value
    std::stringstream temp;
    temp << std::setw(5) << ptr->value;
    
    // build buffer in proper order
    buffer += temp.str();
    buffer += recPreOrder(ptr->left);
    buffer += recPreOrder(ptr->right);
    
    return buffer;
}
template <class T>
std::string Tree<T>::recInOrder(Node<T> *ptr)
{
    std::string buffer = "";
    
    // if done with branch, return empty
    if ( ptr == nullptr )
        return buffer;
    
    // get this nodes value
    std::stringstream temp;
    temp << std::setw(5) << ptr->value;
    
    // build buffer in proper order
    buffer += recInOrder(ptr->left);
    buffer += temp.str();
    buffer += recInOrder(ptr->right);
    
    return buffer;
}
template <class T>
std::string Tree<T>::recPostOrder(Node<T> *ptr)
{
    std::string buffer = "";
    
    // if done with branch, return empty
    if ( ptr == nullptr )
        return buffer;
    
    // get this nodes value
    std::stringstream temp;
    temp << std::setw(5) << ptr->value;
    
    // build buffer in proper order
    buffer += recPostOrder(ptr->left);
    buffer += recPostOrder(ptr->right);
    buffer += temp.str();
    
    return buffer;
}


#endif /* Tree_h */