namespace PetStore.Infrastructure.Services
{
    public static class LockService
    {
        private static int counter = 0;
        private static object counterLock = new object();
        private static int counterNoLock = 0;

        static void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(IncreaseCounter).Start();
            }
        }

        //How to use lock
        //You need an object to lock on(any object works, usually a private object).

        static void IncreaseCounter()
        {
            lock (counterLock) // only one thread can enter here at a time
            {
                counter++;
                Console.WriteLine($"Counter: {counter}");
            }
        }

        static void IncreaseCounterNoLock()
        {
            counterNoLock++; // not atomic
        }
    }
}
