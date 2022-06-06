using System;

namespace BookInfo.Details
{
    public static class Status
    {
        private static Random _Random = new Random();
        public static bool Healthy { get; private set; }
        
        static Status()
        {
            Healthy = _Random.Next(0,100) > 50;
        }
    }
}