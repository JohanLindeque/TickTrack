using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TickTrack.Models;

namespace TickTrack.Business_logic
{
    class ButtonActions
    {
        List<TaskEntryModel> taskList = new List<TaskEntryModel>();
        
        public List<TaskEntryModel> AddTask(string taskTitle, string taskNo, string description)
        {

            TimeSpan spentTime = new TimeSpan(0,1,3,20); // d,h,m,s
            int entryNo = taskList.Count + 1;

            TaskEntryModel task = new TaskEntryModel
            {
                entryId = entryNo,
                title = taskTitle,
                taskNo = taskNo,
                description = description,
                timeSpent = spentTime
            };

            taskList.Add(task);
            return taskList;
            
            

        }
    }
}
