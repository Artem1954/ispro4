using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string openDoorImage = "pack://application:,,,/elevator-doors-opened.jpg";
        string closeDoorImage = "pack://application:,,,/elevator-doors-closed.jpg";
        Elevator elevator;
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            this.OpenDoor();
        }

        public void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || e.Key == Key.OemComma|| e.Key == Key.OemMinus||e.Key == Key.OemPeriod)
            {
                e.Handled = true;
            }
        }

       private void CreateElevator(object sender, EventArgs e)
       {
            elevator = new Elevator(int.Parse(TextBoxMaxFloor.Text));
            elevator.OpenEvent += OpenDoor;
            elevator.CloseEvent += CloseDoor;
            elevator.EditFloorEvent += Elevator_EditFloorEvent;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += GoTo;
            btnPanel.Children.Clear();

            for (int i = 0; i < int.Parse(TextBoxMaxFloor.Text); i++)
            {
                Button button = new Button();
                button.Content =  $"{i + 1}";
                button.Click += Button_Click;
                btnPanel.Children.Add(button);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                TargetFoorTextBox.Text = button.Content.ToString();
                StartElevator( sender, e);
            }
        }

        private void Elevator_EditFloorEvent()
        {
            lable_curentFloor.Content = "ЭТАЖ: " + elevator.floorCurrent.ToString();
        }

        private void StartElevator(object sender, EventArgs e)
        {
            if (int.Parse(TargetFoorTextBox.Text.ToString()) != elevator.floorCurrent)
            {
                timer.Start();
                elevator.CloseDoor();
            }
        }

        private void GoTo(object sender, EventArgs e)
        {
            if(elevator.floorCurrent == (int.Parse(TargetFoorTextBox.Text)))
            {
                timer.Stop();
                elevator.OpenDoor();
            }

            if (elevator.floorCurrent < (int.Parse(TargetFoorTextBox.Text)))
            {
                elevator.Up();
            }

            if (elevator.floorCurrent > (int.Parse(TargetFoorTextBox.Text)))
            {
                elevator.Down();
            }
        }

        private void GoUp(object sender, EventArgs e)
        {
            elevator.Up();
            elevator.Down();
        }

       private void OpenDoorClick(object sender, EventArgs e)
       {
            elevator.OpenDoor();
       }

       private void CloseDoorClick(object sender, EventArgs e)
       {
            elevator.CloseDoor();
       }

       private void OpenDoor()
       {
            ImageElveator.Source = new BitmapImage(new Uri(openDoorImage, UriKind.Absolute));
       }

       private void CloseDoor()
       {
            ImageElveator.Source = new BitmapImage(new Uri(closeDoorImage, UriKind.Absolute));
       }
    }
}
