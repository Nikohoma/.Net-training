using System;

class Controller
{
    static void Main()
    {
        // TODO:
        // Call Service method
        // Handle exception here
        try
        {
            Service.Process();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception from Service : "+e.Message);
        }
    }
}

class Service
{
    public static void Process()
    {
        // TODO:
        // Call Repository method
        // Catch, log and rethrow exception
        try
        {
            Repository.GetData();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception from Repository : "+e.Message);
            throw;
        }
    }
}

class Repository
{
    public static void GetData()
    {
        // TODO:
        // Throw an exception here
        throw new NotImplementedException();
    }
}