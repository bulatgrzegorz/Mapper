using System;
using System.Collections.Generic;

namespace Mapper
{
    public class SampleEntity
    {
        public int int12 { get; set; } = 5;

        public string string123 { get; set; } = "12";

        public Type type12 { get; set; } = typeof(int);

        public SampleEntity2 sapmple { get; set; }
    }

    public class SampleEntity2
    {
        public int int13 { get; set; } = 6;

        public string string13 { get; set; } = "13";

        public int int15 = 1;

        public SampleEntity3 sample3 { get; set; }
    }

    public class SampleEntity3
    {
        public Type typ14 { get; set; } = typeof(bool);

        public List<string> lista { get; set; } = new List<string> { "dead", "deadddd" };
    }
}
