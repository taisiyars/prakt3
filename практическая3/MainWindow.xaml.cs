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
using Пример_таблицы_WPF;
using LibMas;
using Lib_3;

namespace практическая3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void info_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дана матрица размера M × N. Для каждой строки матрицы найти сумму ее элементов.");
        }

        private void clear_click(object sender, RoutedEventArgs e)
        {
            tbRowCount.Clear();
            tbColumnCount.Clear();
            tbRez.Clear();
            dataGrid.ItemsSource = null;
            MasFunction.ClearMas(ref mas);
        }

        int[,] mas;
        private void fill_click(object sender, RoutedEventArgs e)
        {
            int value1, value2;
            bool f, c;
            
            f = Int32.TryParse(tbColumnCount.Text, out value1);
            c = Int32.TryParse(tbRowCount.Text, out value2);
            if (f && c == true)
            {
                mas = new int[value2, value1];
                Random random = new Random();
                MasFunction.InitMas(out mas, value2, value2);
                dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;  
                tbColumnCount.Clear();
                tbRowCount.Clear();
                tbRez.Clear();
            }
            else MessageBox.Show("введите корректные значения");
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            if (grid != null)
            {
                int rowIndex = e.Row.GetIndex();
                int columnIndex = e.Column.DisplayIndex;

                TextBox editedTextbox = e.EditingElement as TextBox;
                if (editedTextbox != null)
                {
                    int newValue;
                    if (int.TryParse(editedTextbox.Text, out newValue))
                    {
                        // Обновляем значение в матрице matr
                        mas[rowIndex, columnIndex] = newValue;
                    }
                    else
                    {
                        MessageBox.Show("Введите корректное числовое значение.");
                        // Возвращаем предыдущее значение в ячейку
                        editedTextbox.Text = mas[rowIndex, columnIndex].ToString();
                    }
                }
            }
        }

        private void create_click(object sender, RoutedEventArgs e)
        {
            int value, value1;
            bool f, b;
            f = Int32.TryParse(tbColumnCount.Text, out value);
            b = Int32.TryParse(tbRowCount.Text, out value1);
            if (f && b == true)
            {
                mas = new int[value1, value];
                dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
            else MessageBox.Show("введите корректные значения");
            tbColumnCount.Clear();
            tbRowCount.Clear();
        }

        private void calc_click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.ItemsSource != null)
            {
                
               tbRez.Text = Convert.ToString(Podschet.CalcSum(mas));
            }
            else MessageBox.Show("создайте таблицу");
        }
        private void exit_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void save_click(object sender, RoutedEventArgs e)
        {
            MasFunction.SaveMas(mas);
        }

        private void open_click(object sender, RoutedEventArgs e)
        {
            MasFunction.OpenMas(ref mas);
            dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
        }
    }
}