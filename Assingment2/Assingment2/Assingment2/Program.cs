using System;
using System.Collections.Generic;
using System.Text;
namespace Assignment_2
{
    public class Stock
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal Holdings { get; set; }
        public decimal CurrentPrice { get; set; }

        // default constructor
        public Stock()
        {
            Symbol = "NA";
            Name = "Invalid";
            Holdings = 0;
            CurrentPrice = -99;
        }

        // Constructor for initialization
        public Stock(string symbol, string name, decimal holdings, decimal currentPrice)
        {
            Symbol = symbol;
            Name = name;
            Holdings = holdings;
            CurrentPrice = currentPrice;
        }

        // overridden ToString method to customize the return value
        public override string ToString()
        {
            return Symbol + ", " + Name + ", " + Holdings + ", " + CurrentPrice;
        }
    }
    public class StockNode
    {
        public Stock StockHolding;
        public StockNode Next;

        // default constructor
        public StockNode()
        {
            StockHolding = null;
            Next = null;
        }

        //constructor to initialize the variables of object
        public StockNode(Stock stockHolding)
        {
            StockHolding = stockHolding;
            Next = null;
        }
    }
    public partial class StockList
    {
        private StockNode head;

        //Constructor for initialization
        public StockList()
        {
            this.head = null;
        }
        public void AddFirst(Stock stock)
        {
            StockNode nodeToAdd = new StockNode(stock);
            nodeToAdd.Next = head;
            head = nodeToAdd;
        }
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
        // FOR STUDENTS

        //param        : NA
        //summary      : Sort the list by descending number of holdings
        //return       : NA
        //return type  : NA
        public void SortByValue()
        {
            // write your implementation here

        }

    }
}
