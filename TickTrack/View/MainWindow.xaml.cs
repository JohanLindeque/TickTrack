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
using System.Timers;
using Timer = System.Timers.Timer;

namespace TickTrack;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private ButtonActions _buttonActions = new ButtonActions();
    private List<TaskEntryModel> _taskList = new List<TaskEntryModel>();
    private Stopwatch _stopWatch = new Stopwatch();
    private Timer _timer = new Timer(1000);


    public MainWindow()
    {
        InitializeComponent();

        _timer.Elapsed += UpdateTimer_Tick;
    }

    private void UpdateTimer_Tick(object? sender, EventArgs e)
    {
        Application.Current.Dispatcher.Invoke(() => txbTimer.Text = _stopWatch.Elapsed.ToString(@"hh\:mm\:ss"));
    }

    private void btnStart_Click(object sender, RoutedEventArgs e)
    {
        DisplayHelper displayHelper = new DisplayHelper(this);
        _taskList = _buttonActions.AddTask(txbTitle.Text, txbTaskNo.Text, txbDescription.Text);

        displayHelper.DisplayTasks(_taskList);

        _stopWatch.Start();
        _timer.Start();

        
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
                displayHelper.PopulateSelectedTaskDataIOnDGV(_taskList, entryId);
            }


        }
    }

    private void btbnSave_Click(object sender, RoutedEventArgs e)
    {
        DisplayHelper displayHelper = new DisplayHelper(this);

        if (txbEntryNo.Text == "")
            _taskList = _buttonActions.AddTask(txbTitle.Text, txbTaskNo.Text, txbDescription.Text);
        else
        {
            TimeSpan time = new TimeSpan(1, 3, 20); // h,m,s
            _taskList = _buttonActions.UpdateTask(int.Parse(txbEntryNo.Text), txbTitle.Text, txbTaskNo.Text, txbDescription.Text, time);
        }

        displayHelper.DisplayTasks(_taskList);

        CLearInputs();
    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        DisplayHelper displayHelper = new DisplayHelper(this);

        if (txbEntryNo.Text != "")
        {
            _taskList = _buttonActions.DeleteTask(int.Parse(txbEntryNo.Text));
        }

        displayHelper.DisplayTasks(_taskList);
        CLearInputs();
    }

    private void btnStop_Click(object sender, RoutedEventArgs e)
    {
        _stopWatch.Stop();
        _timer.Stop();
    }

    private void btnReset_Click(object sender, RoutedEventArgs e)
    {
        string msgHeader = "Do you want to reset the Task List?";
        string msgBody = "You will loose all tasks progress.";


        CLearInputs();
    }
}