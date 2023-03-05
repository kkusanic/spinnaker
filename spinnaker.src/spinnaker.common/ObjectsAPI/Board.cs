using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spinnaker.common
{
    public class Board
    {
        public int BoardId { get; set; }
        public string? BoardName { get; set; }
        public string? BoardURL { get; set; }
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectKey { get; set; }
        public string? BoardType { get; set; }

    }
}