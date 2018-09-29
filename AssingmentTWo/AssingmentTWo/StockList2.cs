using System;
using System.Collections.Generic;
using System.Text;

namespace AssingmentTWo
{
    public partial class StockList
    {
        //param   (StockList)listToMerge : second list to be merged 
        //summary      : merge two different list into a single result list
        //return       : merged list
        //return type  : StockList
        public StockList MergeList(StockList listToMerge)
        {
            StockList resultList = new StockList();
            

            return resultList;
        }

        //param        : NA
        //summary      : finds the stock with most number of holdings
        //return       : stock with most shares
        //return type  : Stock
        public Stock MostShares()
        {
            Stock mostShareStock = null;

            // write your implementation here
            this.Sort_Version2();
            mostShareStock = this.head.StockHolding;
            return mostShareStock;
        }

        //param        : NA
        //summary      : finds the number of nodes present in the list
        //return       : length of list
        //return type  : int
        public int Length()
        {
            // write your implementation here
            int length = 0;
            StockNode current = this.head;
            while (current != null)
            {
                length++;
                current = current.Next;
            }
           return length;
        }
    }
}
