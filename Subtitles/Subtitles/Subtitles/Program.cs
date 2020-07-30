using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Subtitles
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Reader reader = new Reader();
            reader.ReadText();

        }
    }
}