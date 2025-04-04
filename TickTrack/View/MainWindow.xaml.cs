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
using TickTrack.TaskProcessing;
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
    private Timer _timer = new Timer(1000); // 1 sec
    private TimeSpan _timeOffset = TimeSpan.Zero;


    public MainWindow()
    {
        InitializeComponent();

        _timer.Elapsed += UpdateTimer_Tick;
    }

    private void UpdateTimer_Tick(object? sender, EventArgs e)
    {
        Application.Current.Dispatcher.Invoke(() => txbTimer.Text = GetTotalElapsedTime().ToString(@"hh\:mm\:ss"));
    }


    // Logic for Buttons on click events
    private void btnStart_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(txbTimeSpent.Text))
        {
            _timeOffset = TimeSpan.Zero;
            _stopWatch.Restart();
            _timer.Start();
        }
        else
        {
            if (TimeSpan.TryParse(txbTimeSpent.Text, out TimeSpan timeAlreadySpent))
            {
                _timeOffset = timeAlreadySpent;
                _stopWatch.Restart();
                _timer.Start();
            }
            else
            {
                MessageBox.Show("Invalid time format. Please use hh:mm:ss format.");
                return;
            }
        }
            //txbTimeSpent.Text = GetTotalElapsedTime().ToString(@"hh\:mm\:ss");

    }

    private void btnStop_Click(object sender, RoutedEventArgs e)
    {
        UpdateTaskTimeSpent();
    }

    private void btbnSave_Click(object sender, RoutedEventArgs e)
    {
        DisplayHelper displayHelper = new DisplayHelper(this);

        _stopWatch.Stop();
        _timer.Stop();


        if (string.IsNullOrEmpty(txbEntryNo.Text))
            _taskList = _buttonActions.AddTask(txbTitle.Text, txbTaskNo.Text, txbDescription.Text, GetTotalElapsedTime());
        else 
        {
            TimeSpan.TryParse(txbTimeSpent.Text, out TimeSpan timeAlreadySpent);

            if (GetTotalElapsedTime() == TimeSpan.Zero )
                _taskList = _buttonActions.UpdateTask(int.Parse(txbEntryNo.Text), txbTitle.Text, txbTaskNo.Text, txbDescription.Text, timeAlreadySpent);
            else
            {
                UpdateTaskTimeSpent();
                TimeSpan.TryParse(txbTimeSpent.Text, out TimeSpan updateedTimeSpent);
                _taskList = _buttonActions.UpdateTask(int.Parse(txbEntryNo.Text), txbTitle.Text, txbTaskNo.Text, txbDescription.Text, updateedTimeSpent);
            }
                
        }

        displayHelper.DisplayTasks(_taskList);

        ClearInputs();
    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        DisplayHelper displayHelper = new DisplayHelper(this);

        if (txbEntryNo.Text != "")
        {
            _taskList = _buttonActions.DeleteTask(int.Parse(txbEntryNo.Text));
        }

        displayHelper.DisplayTasks(_taskList);
        ClearInputs();
    }

    private void btnReset_Click(object sender, RoutedEventArgs e)
    {
        string msgHeader = "Do you want to reset the Task List?";
        string msgBody = "You will loose all tasks progress.";

        MessageBoxButton msgButtons = MessageBoxButton.OKCancel;
        MessageBoxResult result = MessageBox.Show(msgHeader, msgBody, msgButtons);

        switch (result)
        {
            case MessageBoxResult.None:
                break;
            case MessageBoxResult.OK:
                ClearAppForm();
                _taskList.Clear();
                break;
            case MessageBoxResult.Cancel:
                break;

        }
    }

    // Helper methods
    private void ClearInputs()
    {
        txbEntryNo.Clear();
        txbTitle.Clear();
        txbTitle.Focus();
        txbTaskNo.Clear();
        txbDescription.Clear();
        txbTimeSpent.Clear();

        _stopWatch.Reset();
        _timer.Stop();
        _timeOffset = TimeSpan.Zero;
        txbTimeSpent.Text = "00:00:00";
        txbTimer.Text = "00:00:00";


    }
    private void ClearAppForm()
    {
        txbEntryNo.Clear();
        txbTitle.Clear();
        txbTitle.Focus();
        txbTaskNo.Clear();
        txbDescription.Clear();
        txbTimeSpent.Clear();

        _stopWatch.Reset();
        _timer.Stop();
        _timeOffset = TimeSpan.Zero;
        txbTimeSpent.Text = "00:00:00";
        txbTimer.Text = "00:00:00";


        dgvTaskEntries.ItemsSource = "";
        MessageBox.Show("Reset done.");
    }

    private void dgvTaskEntries_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        DisplayHelper displayHelper = new DisplayHelper(this);

        ClearInputs();

        if (dgvTaskEntries.SelectedItem != null)
        {
            if(dgvTaskEntries.SelectedItem is DataRowView data)
            {
                int entryId = Convert.ToInt32(data["EntryNo"]);
                displayHelper.PopulateSelectedTaskDataIOnDGV(_taskList, entryId);
            }
        }
    }

    

    private void UpdateTaskTimeSpent()
    {
        _stopWatch.Stop();
        _timer.Stop();
        txbTimeSpent.Text = GetTotalElapsedTime().ToString(@"hh\:mm\:ss");
    }

    private TimeSpan GetTotalElapsedTime()
    {
        return _stopWatch.Elapsed.Add(_timeOffset);
    }

    


}