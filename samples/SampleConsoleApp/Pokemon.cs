using System.Collections.Generic;

namespace SampleConsoleApp
{
    public class Pokemon
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public IEnumerable<string> Type { get; set; }
        public Base Base { get; set; }
    }
}
