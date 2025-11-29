using System.Collections.Generic;

namespace Edp.RegExprTests
{
    public class SerializableModel
    {
        public List<string> IncludedPatterns { get; set; } = new List<string>();
        public List<string> ExcludedPatterns { get; set; } = new List<string>();
    }
}