using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTrack.Models
{
    internal class TaskEntryModel
    {
        public int EntryId{ get; set; }
        public string Title { get; set; }
        public string? TaskNo { get; set; }
        public string? Description { get; set; }
        public TimeSpan TimeSpent { get; set; }

        public TaskEntryModel(int entryId, string title, string? taskNo, string? description, TimeSpan timeSpent)
        {
            this.EntryId = entryId;
            this.Title = title;
            this.TaskNo = taskNo;
            this.Description = description;
            this.TimeSpent = timeSpent;
        }

        public TaskEntryModel()
        {
            
        }


    }
}
