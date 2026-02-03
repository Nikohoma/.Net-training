using System;

class OrderProcessor
{
    static void Main()
    {
        int[] orders = { 101, -1, 103 };

        // TODO:
        // 1. Process each order
        // 2. Throw exception for invalid order ID
        // 3. Ensure one failure does not stop processing

        foreach(var order in orders)
        {
            try
            {
                if (order < 0)
                {
                    throw new Exception();
                }
                else
                {
                    Console.WriteLine("Order Processed Succesfully.");
                }
            }
            catch (Exception ex) { Console.WriteLine("Error Encountered : "+ex.Message); }
        }
    }
}