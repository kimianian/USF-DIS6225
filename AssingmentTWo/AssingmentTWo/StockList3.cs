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
            StockNode current = this.head;
            while (current != null)
            {
                value+=(current.StockHolding.Holdings*current.StockHolding.CurrentPrice);
                current = current.Next;
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
