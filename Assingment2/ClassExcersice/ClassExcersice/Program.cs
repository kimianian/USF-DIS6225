using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
namespace ClassExcersice
{
    public class Stock
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal Holdings { get; set; }
        public decimal CurrentPrice { get; set; }
        public Stock()
        {
            Symbol = "NA";
            Name = "Invalid";
            Holdings = 0;
            CurrentPrice = -99;
        }
        public Stock(string symbol, string name, decimal holdings, decimal currentPrice)
        {
            Symbol = symbol;
            Name = name;
            Holdings = holdings;
            CurrentPrice = currentPrice;
        }
        public override string ToString()
        {
            return Symbol + ", " + Name + ", " + Holdings + ", " + CurrentPrice;
        }
    }
    public class StockNode
    {
        public Stock StockHolding;
        public StockNode Next;
        public StockNode()
        {
            StockHolding = null;
            Next = null;
        }
        public StockNode(Stock stockHolding)
        {
            StockHolding = stockHolding;
            Next = null;
        }
    }
    public partial class StockList
    {
        private StockNode head;
        public StockList()
        {
            this.head = null;
        }
        public bool ISEmpty()
        {
            if (this.head == null)
            {
                return true;
            }
            return false;
        }
        public void AddFirst(Stock stock)
        {
            StockNode nodeToAdd = new StockNode(stock);
            nodeToAdd.Next = head;
            head = nodeToAdd;
        }
        public void AddLast(Stock stock)
        {
            if(this.ISEmpty())
            {
                AddFirst(stock);
            }
            else
            {
                StockNode current = this.head;
                while(current.Next!=null)
                {
                    current = current.Next;
                }
                StockNode nodeToAdd = new StockNode(stock);
                    current.Next = nodeToAdd;
            }
        }
        public void AddStock (Stock stock)
        {
            if (this.ISEmpty())
                AddFirst(stock);
            else
            {
                string nameOfStockToAdd = stock.Name;
                string headNodeData = (this.head.StockHolding).Name;
                if (headNodeData.CompareTo(nameOfStockToAdd) > 0)
                    AddFirst(stock);
                else
                {
                    StockNode current = this.head;
                    StockNode previous = null;
                    string currentstockname = (current.StockHolding).Name;
                    while(current.Next!=null && currentstockname.CompareTo(nameOfStockToAdd)<0)
                    {
                        previous = current;
                        current = current.Next;
                        currentstockname= (current.StockHolding).Name;

                    }
                    if(current.Next!=null)
                    {
                        if(currentstockname.CompareTo(nameOfStockToAdd) == 0)
                        {
                            decimal holdings = (current.StockHolding).Holdings + stock.Holdings;
                            current.StockHolding.Holdings = holdings;
                        }
                        else if (currentstockname.CompareTo(nameOfStockToAdd) > 0)
                        {
                         
                            StockNode newNode = new StockNode(stock);
                            newNode.Next = current;
                            previous.Next = newNode;
                        }
                        else
                        {
                     
                            AddLast(stock);
                        }
                    }
                }
                
            }
        }
        public void Sort()
        {
            StockNode current = null;
            StockNode previous = this.head;
            StockNode temp=null;
            while(current.Next!=null)
            {
                decimal currentHolding = current.StockHolding.Holdings;
                decimal previousHolding= previous.StockHolding.Holdings;
                if (currentHolding < previousHolding)
                    {
                    temp= previous;
                    previous = current;
                    current = temp;
                }
                current = current.Next;
            }
                
        }
        public void sortByName()

        {
            StockNode currentNode = null;
            StockNode previousNode = this.head;
            StockNode temp = null;
            string currentName = currentNode.StockHolding.Name;
            string previousName = previousNode.StockHolding.Name;
            while (currentNode.Next != null)
            {
                if(currentName.CompareTo(previousName) < 0)
                {
                    temp = previousNode;
                    previousNode = currentNode;
                    currentNode = temp;
                }
            }
            currentNode = currentNode.Next;
        }
        // I used https://stackoverflow.com/questions/4488054/merge-two-or-more-lists-into-one-in-c-sharp-net web site to solve this problem
        public StockList MergeList(StockList listToMerge)
        {
            StockList resultList = new StockList();
            StockList A = new StockList();
            StockList B = new StockList();
            StockNode current = null;
            A.head = current;
            while (current.Next!=null)
            {
                current.Next = current;
            }
            if(current==null)
            {

            }

            return resultList;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Stock stockOne = new Stock("GOOG", "Google", 1.2m, 6.27m);
            Stock stockTwo = new Stock("MSFT", "Microsoft", 5m, 111.2m);
            Stock stockThree = new Stock("AAPL", "Apple", 6m, 222.7m);
            Stock stockFour = new Stock("AMZN", "Amazon", 1.2m, 198.7m);
            Stock stockFive = new Stock("Z", "Zillow", 2.4m, 207.6m);
            Stock stockSix = new Stock("B", "Barnes ", 2.2m, 68.7m);
            Stock stockSeven = new Stock("GOOG", "Google", 3.6m, 115.3m);
            Stock stockEight = new Stock("AAPL", "Apple", 5m, 147.6m);
            Stock stockNine = new Stock("GOOG", "Google", 1.2m, 6.27m);


       
        }
    }
}
