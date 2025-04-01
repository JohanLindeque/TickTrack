using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TickTrack.Models;
using TickTrack;
using System.Data;

namespace TickTrack.Business_logic
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

            //mainWindow.dgvTaskEntries.Items.Clear();

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
                row["EntryNo"] = task.entryId.ToString();
                row["Title"] = task.title;
                row["TaskNo"] = task.taskNo;
                row["Description"] = task.description;
                row["TimeSpent"] = task.timeSpent.ToString();
                data.Rows.Add(row);

            }

            return data;
        }

        public void PopulateSelectedTaskDataIOnDGV(List<TaskEntryModel> tasks, int entryId)
        {
            if (entryId < tasks.Count())
            {
                TaskEntryModel selectedTask = tasks[entryId];

                mainWindow.txbEntryNo.Text = selectedTask.entryId.ToString();
                mainWindow.txbTitle.Text = selectedTask.title;
                mainWindow.txbTaskNo.Text = selectedTask.taskNo;
                mainWindow.txbDescription.Text = selectedTask.description;
                mainWindow.txbTimeSpent.Text = selectedTask.timeSpent.ToString();
            }
            
        }
    }
}
