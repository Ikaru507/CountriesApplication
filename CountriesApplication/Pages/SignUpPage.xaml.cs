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
using Service;
using Model;
using System.Dynamic;



namespace CountriesAppliction
{
    public partial class SignUpPage : Page
    {
        ApiService apiService = new ApiService();
        List<UserDetails> userDetails = new List<UserDetails>();
        public SignUpPage()
        {
            InitializeComponent();
        }
        public async void GetAllUserDetails()
        {
            
            userDetails = await apiService.GetAllUserDetails();
        }

        public async void InsertUserDetails()
        {
            if (EmailBox.Text != ConfirmEmailBox.Text)
            {
                MessageBox.Show("Emails do not match ❌");
                return;
            }
            UserDetails u = new UserDetails()
            {
                UserName = UserNameBox.Text,

                Email = EmailBox.Text,
                Password = PasswordBox.Password

            };
            int x = await apiService.InsertUserDetails(u);
            if (x > 0)
            {
                MessageBox.Show("Account created successfully ✅");
            }
            else
            {
                MessageBox.Show("Error creating account ❌");
            }
        }
        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
               InsertUserDetails();
            
          
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
