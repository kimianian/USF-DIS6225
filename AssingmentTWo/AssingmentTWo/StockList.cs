using System;
using System.Collections.Generic;
using System.Text;

namespace AssingmentTWo
{
    public partial class StockList
    {
        private StockNode head;

        //Constructor for initialization
        public StockList()
        {
            this.head = null;
        }

        //param        : NA
        //summary      : checks if the list is empty
        //return       : true if list is empty, false otherwise
        //return type  : bool
        public bool IsEmpty()
        {
            if (this.head == null)
            {
                return true;
            }
            return false;
        }

        //param (Stock)stock : stock that is to be added
        //summary      : Add node at first position in list
        //                This is done by creating a new node 
        //                  and pointing it to the current list 
        //return       : NA
        //return type  : NA
        public void AddFirst(Stock stock)
        {
            StockNode nodeToAdd = new StockNode(stock);
            nodeToAdd.Next = head;
            head = nodeToAdd;
        }

        //param (Stock)stock : stock that is to be added
        //summary      : Add mode at last position of list
        //  This is done by traversing the list till we reach the end
        // and pointing the last node to the new node
        // return       :
        // return type  :
        public void AddLast(Stock stock)
        {
            // for an empty list, we add the node at the top of the list
            if (this.IsEmpty())
                AddFirst(stock);
            else
            {
                // traverse the list till the end
                StockNode current = this.head;
                while (current.Next != null)
                    current = current.Next;

                // point the last node to the new node
                StockNode nodeToAdd = new StockNode(stock);
                current.Next = nodeToAdd;
            }
        }

        /// <summary>
        /// Add node in an alphabetically sorted manner, if stock is already present then set holdings to sum of existing and new stock
        ///   We assume that the list is always sorted in alphabetical order
        ///   The stock may be added either at:
        ///     the top of the list (if alphabetically lower than all nodes)
        ///   , middle of the list, in which case, we can either
        ///     Add to existing holdings (if the stock already exists in the list), or
        ///     Insert it at the right location in alphatecial order (if it does not already exist)
        ///   , or end of the list (if alphabetically greater than all existing nodes)
        /// </summary>
        /// <param name="stock">stock that is to be added</param>
        public void AddStock(Stock stock)
        {
            // for an empty list, we add the node at the top of the list
            if (this.IsEmpty())
                AddFirst(stock);
            else
            {
                // if the new node is alphabetically the first, again, we add it at the top of the list
                string nameOfStockToAdd = stock.Name;
                string headNodeData = (this.head.StockHolding).Name;
                if (headNodeData.CompareTo(nameOfStockToAdd) > 0)
                    AddFirst(stock);
                else
                {
                    // traverse the list to locate the stock
                    StockNode current = this.head;
                    StockNode previous = null;
                    string currentStockName = (current.StockHolding).Name;

                    while (current.Next != null && currentStockName.CompareTo(nameOfStockToAdd) < 0)
                    {
                        previous = current;
                        current = current.Next;
                        currentStockName = (current.StockHolding).Name;
                    }

                    // we have now traversed all stocks that are alphabetically less than the stock to be added
                    if (current.Next != null)
                    {
                        // if the stock already exists, add to holdings
                        if (currentStockName.CompareTo(nameOfStockToAdd) == 0)
                        {
                            decimal holdings = (current.StockHolding).Holdings + stock.Holdings;
                            current.StockHolding.Holdings = holdings;
                        }
                        else if (currentStockName.CompareTo(nameOfStockToAdd) > 0)
                        {
                            // insert the stock in the current position. This requires creating a new node,
                            //  pointing the new node to the next node
                            //    and pointing the previous node to the current node
                            //  QUESTION: what would happen if we flipped the sequence of assignments below?
                            StockNode newNode = new StockNode(stock);
                            newNode.Next = current;
                            previous.Next = newNode;
                        }
                    }
                    else
                    {
                        // we are at the end of the list, add the stock at the end
                        //  This is probably not the most efficient way to do it,
                        //  since AddLast traverses the list all over again
                        AddLast(stock);
                    }
                }
            }
        }

        //param  (Stock)stock : stock that is to be checked 
        //summary      : checks if list contains stock passed as parameter
        //                  This involves traversing the list until we find the stock
        //                    return null if we don't
        //return       : Reference of node with matching stock
        //return type  : StockNode if exists, null if not
        public StockNode Contains(Stock stock)
        {
            StockNode nodeReference = null;

            // if the list is empty, return null
            if (this.IsEmpty())
                return nodeReference;
            else
            {
                // traverse the list until we locate the stock,
                //  or, reach the end of the list
                StockNode current = this.head;
                StockNode previous = this.head;
                while (current.Next != null)
                {
                    Stock currentStock = current.StockHolding;

                    // found it! Return the node
                    if (currentStock.Equals(stock))
                    {
                        nodeReference = previous;
                        break;
                    }

                    // else, continue traversing
                    previous = current;
                    current = current.Next;
                }
            }

            return nodeReference;
        }

        /// <summary>
        /// swaps the node passed as argument with next node in list
        /// Sorting the list using the simple bubble sort algorithm requires repeatdely traversing
        ///   the list and pushing a node down the list until it falls in place
        ///     Pushing the node is essentially a swap operation, where we take the next node
        ///       and put it in the current position and move the current node to the next position on the list
        /// </summary>
        /// <param name="nodeOne">first node to be swapped</param>
        /// <returns>Reference to current node</returns>
        public StockNode Swap(Stock nodeOne)
        {
            StockNode prevNodeOne = null;
            StockNode currNodeOne = this.head;

            // traverse the list until we reach the node to swap
            while (currNodeOne != null && currNodeOne.StockHolding != nodeOne)
            {
                prevNodeOne = currNodeOne;
                currNodeOne = currNodeOne.Next;
            }

            // maintain references to the nodes to be swapped
            StockNode prevNodeTwo = currNodeOne;
            StockNode currNodeTwo = currNodeOne.Next;

            // handle corner cases, maybe we have reached the end of the list
            if (currNodeOne == null || currNodeTwo == null)
                return null;

            // perhaps the insertion is at the top of the list
            if (prevNodeOne != null)
                prevNodeOne.Next = currNodeTwo;
            else
                this.head = currNodeTwo;

            if (prevNodeTwo != null)
                prevNodeTwo.Next = currNodeOne;
            else
                this.head = currNodeOne;

            // normal case, swap nodes
            StockNode temp = currNodeOne.Next;
            currNodeOne.Next = currNodeTwo.Next;
            currNodeTwo.Next = temp;

            return currNodeTwo;
        }


        // FOR STUDENTS

        //param        : NA
        //summary      : Sort the list by descending number of holdings
        //return       : NA
        //return type  : NA

//In this version, the swap function is used. However, this version is an inefficeint way
        public void Sort_Version1()
        {
            //computing the size of the list
            int size = 0;
            StockNode current = this.head;
            while (current != null)
            {
                size++;
                current = current.Next;
            }
            //we know appply bubble algorithm
            StockNode currNode = this.head;
            int Temp_Counter = -1;
            decimal Temp1 = 0;
            decimal Temp2 = 0;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - i - 1; j++)
                {
                    //find the argument in the list 
                    currNode = this.head;
                    Temp_Counter = -1;
                    while (Temp_Counter!= j)
                    {
                        Temp_Counter++;
                        if(Temp_Counter != 0)
                        currNode = currNode.Next;
                    }
                    Temp1 = currNode.StockHolding.Holdings;
                    Temp2 = currNode.Next.StockHolding.Holdings;
                    if (Temp1 < Temp2) { 
                        Swap(currNode.StockHolding);
                    }
                }

            }
        }

        //In this version, the swap function is NOT used.
        public void Sort_Version2()
        {
            //computing the size of the list
            int size = 0;
            StockNode current = this.head;
            while (current != null)
            {
                size++;
                current = current.Next;
            }
            //we know appply bubble algorithm
            StockNode nextNode = null;
            StockNode currNode = this.head;
            StockNode preNode = null;
            int Temp_Counter = -1;
            decimal Temp1 = 0;
            decimal Temp2 = 0;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - i - 1; j++)
                {
                    //find the argument in the list 
                    currNode = this.head;
                    preNode = null;
                    Temp_Counter = -1;
                    while (Temp_Counter != j)
                    {
                        Temp_Counter++;
                        if (Temp_Counter != 0)
                        {
                            preNode = currNode;
                            currNode = currNode.Next;
                        }
                    }
                    Temp1 = currNode.StockHolding.Holdings;
                    Temp2 = currNode.Next.StockHolding.Holdings;
                    if (Temp1 < Temp2)
                    {
                        //Swapping will happen HERE
                        nextNode = currNode.Next;
                        if (j == 0)
                        {
                            currNode.Next = nextNode.Next;
                            nextNode.Next = currNode;
                            this.head = nextNode;
                        }
                        else {
                            currNode.Next = nextNode.Next;
                            nextNode.Next = currNode;
                            preNode.Next = nextNode;
                        }
                   }
                }

            }
        }

        //param        : NA
        //summary      : Sort the list alphabatically
        //return       : NA
        //return type  : NA
        public void sortByName()

        {
            
            int size = 0;
            StockNode current = this.head;
            while (current != null)
            {
                size++;
                current = current.Next;
            }
            //we know appply bubble algorithm
            StockNode nextNode = null;
            StockNode currNode = this.head;
            StockNode preNode = null;
            int Temp_Counter = -1;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - i - 1; j++)
                {
                    
                    currNode = this.head;
                    preNode = null;
                    Temp_Counter = -1;
                    while (Temp_Counter != j)
                    {
                        Temp_Counter++;
                        if (Temp_Counter != 0)
                        {
                            preNode = currNode;
                            currNode = currNode.Next;
                        }
                    }
                    if (currNode.StockHolding.Name.CompareTo(currNode.Next.StockHolding.Name)>0)
                    {
                        nextNode = currNode.Next;
                        if (j == 0)
                        {
                            currNode.Next = nextNode.Next;
                            nextNode.Next = currNode;
                            this.head = nextNode;
                        }
                        else
                        {
                            currNode.Next = nextNode.Next;
                            nextNode.Next = currNode;
                            preNode.Next = nextNode;
                        }
                    }
                }

            }
        }
    }
}
