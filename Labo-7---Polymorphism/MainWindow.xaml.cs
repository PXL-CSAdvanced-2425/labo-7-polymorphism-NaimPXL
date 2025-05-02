using Labo_7___Polymorphism.Data;
using Labo_7___Polymorphism.Entities;
using Microsoft.Win32;
using System.IO;
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


namespace Labo_7___Polymorphism;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Store<Machine> _datastore = new Store<Machine>();

    public MainWindow()
    {
        InitializeComponent();

        //Entities.Machine = new Entities.Machine();
    }

    private void ImportButton_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog ofd = new OpenFileDialog();
        if (ofd.ShowDialog() == true)
        {
            using (StreamReader sr = new StreamReader(ofd.FileName))
            {
                sr.ReadLine();
                string[] data = sr.ReadLine().Split(',');

                //LaserCutter laserCutter;
                //Router router;
                //General general;
                Machine machine = null;

				while (!sr.EndOfStream) {
                    switch (data[0])
                    {
                        case "L":
                            machine = new LaserCutter(data[1]
                                ,double.Parse(data[2])
                                ,double.Parse(data[3])
                                ,double.Parse(data[4])
                                ,double.Parse(data[5]) );
                            break;
                        case "R":
                            machine = new Router(data[1]
                                , double.Parse(data[2])
                                , double.Parse(data[3])
                                , double.Parse(data[4]));
							break;
                        case "G":
                            machine = new General(data[1]);
                            break;

                        default:
                            machine = null;
                            break;
                    }

                    if (machine != null)
                    {
                        _datastore.AddItem(machine);
                    }

                    data = sr.ReadLine().Split(',');
                }
            }
        }

        UpdateListBox();

        clearButton.IsEnabled = true;
        sortButton.IsEnabled = true;
        filterButton.IsEnabled = true;

    }

    private void RemoveButton_Click(object sender, RoutedEventArgs e)
    {
        _datastore.RemoveItem((Machine)itemsListBox.SelectedItem);
        UpdateListBox();
        removeButton.IsEnabled = false;
    }

    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
        _datastore.ClearAllItems();
        UpdateListBox();
        clearButton.IsEnabled = false;
    }

    private void UseButton_Click(object sender, RoutedEventArgs e)
    {
       int.TryParse(inputTextBox.Text, out int minutes);
        if (minutes > 0)
        {
            ((Machine)itemsListBox.SelectedItem).Use(minutes);
            UpdateListBox();
            useButton.IsEnabled = false;
        }

    }

    private void SortButton_Click(object sender, RoutedEventArgs e)
    {
		_datastore.SortItems((x, y) => string.Compare(x.Name, y.Name));
        UpdateListBox();
	}

	private void FilterButton_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void itemsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (itemsListBox.SelectedItem != null)
        {
            useButton.IsEnabled = !((Machine)itemsListBox.SelectedItem).OutOfUse;
            removeButton.IsEnabled = true;
        }
    }

    private void UpdateListBox()
    {
        itemsListBox.Items.Clear();

        foreach (var machine in _datastore.GetAllItems())
        {
            itemsListBox.Items.Add(machine);
        }
    }
}