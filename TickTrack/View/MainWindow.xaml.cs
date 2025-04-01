using System.Data;
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
    List<TaskEntryModel> taskList = new List<TaskEntryModel>();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnStart_Click(object sender, RoutedEventArgs e)
    {
        DisplayHelper displayHelper = new DisplayHelper(this);
        taskList = buttonActions.AddTask(txbTitle.Text, txbTaskNo.Text, txbDescription.Text);

        displayHelper.DisplayTasks(taskList);

        CLearInputs();
    }

    private void CLearInputs()
    {
        txbEntryNo.Clear();
        txbTitle.Clear();
        txbTitle.Focus();
        txbTaskNo.Clear();
        txbDescription.Clear();
        txbTimeSpent.Clear();
    }

    private void dgvTaskEntries_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        DisplayHelper displayHelper = new DisplayHelper(this);

        if (dgvTaskEntries.SelectedItem != null)
        {
            if(dgvTaskEntries.SelectedItem is DataRowView data)
            {
                int entryId = Convert.ToInt32(data["EntryNo"]);
                displayHelper.PopulateSelectedTaskDataIOnDGV(taskList, entryId-1);

            }


        }
    }
}