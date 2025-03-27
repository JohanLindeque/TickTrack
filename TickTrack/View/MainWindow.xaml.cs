using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TickTrack.Business_logic;
using TickTrack.Models;

namespace TickTrack;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    ButtonActions buttonActions = new ButtonActions();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnStart_Click(object sender, RoutedEventArgs e)
    {
        DisplayHelper displayHelper = new DisplayHelper(this);
        List<TaskEntryModel> taskList = buttonActions.AddTask(txbTitle.Text, txbTaskNo.Text, txbDescription.Text);

        displayHelper.DisplayTasks(taskList);
    }

    private void dgvTaskEntries_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        DisplayHelper displayHelper = new DisplayHelper(this);

        if (dgvTaskEntries.SelectedItem != null)
        {
            // TODO: fix data grid view, al die columns he anders gaan die nie werk
            var selectedTask = (TaskEntryModel)dgvTaskEntries.SelectedItem;

            displayHelper.PopulateSelectedTaskDataIOnDGV(selectedTask);

            //txbEntryNo.Text = selectedTask.entryId.ToString();
            //txbTitle.Text = selectedTask.title;
            //txbTaskNo.Text = selectedTask.taskNo;
            //txbDescription.Text = selectedTask.description;
            //txbTimeSpent.Text = selectedTask.timeSpent.ToString();
        }
    }
}