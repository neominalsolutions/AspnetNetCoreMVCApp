using System;
using System.Collections.Generic;

namespace AspnetNetCoreMVCApp.Entities
{
    public partial class Fragmentationview
    {
        public string Schema { get; set; } = null!;
        public string Table { get; set; } = null!;
        public string? Index { get; set; }
        public double? Fragmentation { get; set; }
        public long? PageCount { get; set; }
    }
}
