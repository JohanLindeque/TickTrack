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
            int entryNo = taskList.Count;

            TaskEntryModel task = new TaskEntryModel(entryNo, taskTitle, taskNo, description, spentTime);

            taskList.Add(task);
            return taskList;            

        }

        public List<TaskEntryModel> UpdateTask(int entryNo, string taskTitle, string taskNo, string description, TimeSpan timeSpent)
        {
            taskList[entryNo].Title = taskTitle;
            taskList[entryNo].TaskNo = taskNo;
            taskList[entryNo].Description = description;
            taskList[entryNo].TimeSpent = timeSpent;

            return taskList;

        }

        public List<TaskEntryModel> DeleteTask(int entryNo)
        {
            taskList.RemoveAt(entryNo);
            return taskList;

        }



    } 
}
