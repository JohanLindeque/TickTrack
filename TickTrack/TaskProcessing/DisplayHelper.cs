using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TickTrack.Models;
using TickTrack;
using System.Data;

namespace TickTrack.TaskProcessing
{
    class DisplayHelper
    {
        MainWindow mainWindow;
        public DisplayHelper(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void DisplayTasks(List<TaskEntryModel> tasks)
        {
            DataTable data = new DataTable();
            data = CreateDataTableFromTaskList(tasks);

            mainWindow.dgvTaskEntries.ItemsSource = data.DefaultView;

        }

        private DataTable CreateDataTableFromTaskList(List<TaskEntryModel> tasks)
        {
            DataTable data = new DataTable();
            data.Columns.Add("EntryNo");
            data.Columns.Add("Title");
            data.Columns.Add("TaskNo");
            data.Columns.Add("Description");
            data.Columns.Add("TimeSpent");


            foreach (var task in tasks)
            {
                var row = data.NewRow();
                row["EntryNo"] = task.EntryId.ToString();
                row["Title"] = task.Title;
                row["TaskNo"] = task.TaskNo;
                row["Description"] = task.Description;
                row["TimeSpent"] = task.TimeSpent.ToString(@"hh\:mm\:ss");
                data.Rows.Add(row);

            }

            return data;
        }

        public void PopulateSelectedTaskDataIOnDGV(List<TaskEntryModel> tasks, int entryId)
        {
            if (entryId < tasks.Count())
            {
                TaskEntryModel selectedTask = tasks[entryId];

                mainWindow.txbEntryNo.Text = selectedTask.EntryId.ToString();
                mainWindow.txbTitle.Text = selectedTask.Title;
                mainWindow.txbTaskNo.Text = selectedTask.TaskNo;
                mainWindow.txbDescription.Text = selectedTask.Description;
                mainWindow.txbTimeSpent.Text = selectedTask.TimeSpent.ToString(@"hh\:mm\:ss");
            }
            
        }
    }
}
