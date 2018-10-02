using System;
using System.Collections.Generic;
using System.Text;

namespace AssingmentTWo
{
    public partial class StockList
    {
        //param        : NA
        //summary      : Calculate the value of each node by multiplying holdings with price, and returns the total value
        //return       : total value
        //return type  : decimal
        public decimal Value()
        {
            decimal value = 0.0m;

            // write your implementation here
            StockNode stocknode = this.head;
            while (stocknode != null)
            {
                value+=(stocknode.StockHolding.Holdings* stocknode.StockHolding.CurrentPrice);
                stocknode = stocknode.Next;
            }
            return value;
        }

        //param  (StockList) listToCompare     : StockList which has to comared for similarity index
        //summary      : finds the similar number of nodes between two lists
        //return       : similarty index
        //return type  : int
        public int Similarity(StockList listToCompare)
        {
            int similarityIndex = 0;

            // write your implementation here

            // Similarity

            StockNode stocknode = this.head;
            StockNode stocknode2 = listToCompare.head;

            while (stocknode != null)
            {
                while (stocknode2 != null)
                {
                    if (stocknode.StockHolding.Symbol == stocknode2.StockHolding.Symbol)
                    {
                        if (stocknode.Next == null || stocknode2.Next == null)
                        {
                            similarityIndex = similarityIndex + 1;
                        }
                        else if (stocknode.StockHolding.Symbol == stocknode.Next.StockHolding.Symbol || stocknode2.StockHolding.Symbol == stocknode2.Next.StockHolding.Symbol)
                        {
                            similarityIndex = similarityIndex + 0;
                        }
                        else
                        {
                            similarityIndex = similarityIndex + 1;
                        }
                    }
                    stocknode2 = stocknode2.Next;
                }
                stocknode2 = listToCompare.head;
                stocknode = stocknode.Next;
            }

            return similarityIndex;
        }

        //param        : NA
        //summary      : Print all the nodes present in the list
        //return       : NA
        //return type  : NA
        public void Print()
        {
            StockNode current = this.head;
            while (current != null)
            {
                Console.WriteLine(current.StockHolding.Symbol + " , " +  current.StockHolding.Name + " , " + current.StockHolding.Holdings+ " , "+ current.StockHolding.CurrentPrice+ "\n" );
                current = current.Next;
            }

        }
    }
}
