using System;

namespace Life
{
    public class GenerateRandom
    {
        private Random random = new Random((int)DateTime.Now.Ticks);

        public char RandomString()
        {
            char ch;
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(3 * random.NextDouble() + 48)));
            if (ch == '0') ch = '1';
            else ch = '0';
            return ch;
        }
    }
}
