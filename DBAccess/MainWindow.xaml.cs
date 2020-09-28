using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;

namespace DBAccess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Access DBs.accdb");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += read[0].ToString() + " " + read[1].ToString() + " " + read[2].ToString() + "\n";
            }
            AssetsData.Text = data;
            cn.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DBAccess.Access_DBs access_DBs = ((DBAccess.Access_DBs)(this.FindResource("access_DBs")));
            // Load data into the table Assets. You can modify this code as needed.
            DBAccess.Access_DBsTableAdapters.AssetsTableAdapter access_DBsAssetsTableAdapter = new DBAccess.Access_DBsTableAdapters.AssetsTableAdapter();
            access_DBsAssetsTableAdapter.Fill(access_DBs.Assets);
            System.Windows.Data.CollectionViewSource assetsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("assetsViewSource")));
            assetsViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string query = "select * from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += read[0].ToString() + " " + read[1].ToString() + " " + read[2].ToString() + "\n";
            }
            AssetsData.Text = data;
            cn.Close();
        }
    }
}
