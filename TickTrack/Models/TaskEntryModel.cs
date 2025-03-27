using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTrack.Models
{
    class TaskEntryModel
    {
        public int entryId{ get; set; }
        public string title { get; set; }
        public string? taskNo { get; set; }
        public string? description { get; set; }
        public TimeSpan timeSpent { get; set; }

    }
}
