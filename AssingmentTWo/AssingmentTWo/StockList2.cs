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
            StockNode node = head;
            while (node != null)
            {
                resultList.AddStock(node.StockHolding);
                node = node.Next;
            }


            StockNode mergeNode = listToMerge.head;
            //Adding the stock value to the list
            while (mergeNode != null)
            {
                resultList.AddStock(mergeNode.StockHolding);
                mergeNode = mergeNode.Next;
            }



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
            StockNode stocknode = head;
            mostShareStock = stocknode.StockHolding;

            while (stocknode != null)
            {
                if (stocknode.StockHolding.Holdings > mostShareStock.Holdings)
                {
                    mostShareStock.Holdings = stocknode.StockHolding.Holdings;
                    mostShareStock.Name = stocknode.StockHolding.Name;
                    mostShareStock.Symbol = stocknode.StockHolding.Symbol;
                    mostShareStock.CurrentPrice = stocknode.StockHolding.CurrentPrice;
                }
                else
                {
                    mostShareStock.Holdings = mostShareStock.Holdings;
                    mostShareStock.Name = mostShareStock.Name;
                    mostShareStock.Symbol = mostShareStock.Symbol;
                    mostShareStock.CurrentPrice = mostShareStock.CurrentPrice;
                }
                stocknode = stocknode.Next;
            }

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