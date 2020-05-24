using Coursework.Targets;
using Coursework.Weapons;
using System;

namespace Coursework
{
    class Program
    {
        static void Main(string[] args)
        {
            Rifleman gunner = new Rifleman();
            while (gunner.MakeChoice()) { }
        }
    }
}
