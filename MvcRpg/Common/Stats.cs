using System;

namespace Common
{
    public class Stats
    {
        [Obsolete("Only needed for init", true)]
        public Stats()
        {

        }

        public Stats(int h, int m, int s)
        {
            this.Health = h;
            this.Mana = m;
            this.Strength = s;
        }


        public int Health { get; set; }
        public int Mana { get; set; }
        public int Strength { get; set; }



    }
}