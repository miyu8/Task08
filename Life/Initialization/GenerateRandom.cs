using System;

namespace Life
{
    public class GenerateRandom
    {
        private Random random = new Random((int)DateTime.Now.Ticks);

        public int RandomString(int quantity)//quantity=5
        {
            return Convert.ToInt32(Math.Floor(quantity * random.NextDouble()));// + 48));
        }
    }
}
