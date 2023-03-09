using System;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public string Name;
        public Window1(string name)
        {
            Name = name;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=LABSCIFIPC07\LOCALHOST; Initial Catalog=StudentRecords; Integrated Security=True");

            try
            {
                sqlCon.Open();
                string query = " select * from SignUpTable where Username = '" + Name + "'";

                SqlCommand cmd = new SqlCommand(query, sqlCon);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    firstNameblock.Text = reader["First Name"].ToString();
                    lastNameblock.Text = reader["Last Name"].ToString();
                    emailblock.Text = reader["Email"].ToString();
                    passwordBlock.Text = reader["password"].ToString();

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

            finally

            {

                sqlCon.Close();

            }
        }
    }
}
