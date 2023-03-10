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
using System.Windows.Shapes;
using Getting_Real.ViewModel;

namespace Getting_Real
{
    /// <summary>
    /// Interaction logic for CreateCompanyDialog.xaml
    /// </summary>
    public partial class CreateCompanyDialog : Window
    {
        public string[] Field { get; set; }

        string savedPhoneNumber;
        string savedEmail;

        CompanyController companyController;

        CompanyViewModel cvm = new CompanyViewModel();


        public CreateCompanyDialog()
        {
            InitializeComponent();
            companyController = new CompanyController();
            

            //Field = new string[] { "Efterskoler", "Fitnesscentre", "Gymnasier", "Hotel og Kroer", "Højskoler", "Kommuner"};
            DataContext = cvm;
        }

        private void SetButton()
        {
            btnRegisterCompany.IsEnabled = (tbCompanyName.Text != "") && (tbPhoneNumber.Text != "" || rBtnPhoneNumber.IsChecked == true) && (tbEmail.Text != "" || rBtnEmail.IsChecked == true) && (cbField.SelectedItem != null) && (tbCVRNumber.Text != "");
        }

        private void btnRegisterCompany_Click(object sender, RoutedEventArgs e)
        {
            bool noPhoneNumber = rBtnPhoneNumber.IsChecked.Value;
            bool noEmail = rBtnEmail.IsChecked.Value;
            if(noPhoneNumber == true && noEmail == true)
            {
                companyController.CreateCompany(tbCompanyName.Text, cbField.Text, tbCVRNumber.Text);
            }
            else if (noPhoneNumber == true)
            {
                companyController.CreateCompany(tbCompanyName.Text, cbField.Text, tbCVRNumber.Text, tbEmail.Text);
            }
            else if (noEmail == true)
            {
                companyController.CreateCompany(tbCompanyName.Text, cbField.Text, tbCVRNumber.Text, tbPhoneNumber.Text);
            }
            else
            {
                companyController.CreateCompany(tbCompanyName.Text, cbField.Text, tbCVRNumber.Text, tbPhoneNumber.Text, tbEmail.Text);
            }

            this.DialogResult = true;
        }


        private void tbCompanyName_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void tbPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
            rBtnPhoneNumber.IsChecked = false;
        }

        private void tbEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
            rBtnEmail.IsChecked = false;
        }

        private void cbField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetButton();
        }

        private void rBtnPhoneNumber_checked(object sender, RoutedEventArgs e)
        {
            SetButton();
            if (tbPhoneNumber.Text != "")
            {
                savedPhoneNumber = tbPhoneNumber.Text;
                tbPhoneNumber.Text = "";
            }
            rBtnPhoneNumber.IsChecked = true;
        }

        private void rBtnEmail_checked(object sender, RoutedEventArgs e)
        {
            SetButton();
            if (tbEmail.Text != "")
            {
                savedEmail = tbEmail.Text;
                tbEmail.Text = "";
            }
            rBtnEmail.IsChecked = true;
        }

        private void rBtnPhoneNumber_unchecked(object sender, RoutedEventArgs e)
        {
            SetButton();
        }

        private void rBtnEmail_unchecked(object sender, RoutedEventArgs e)
        {
            SetButton();
        }

        private void tbPhoneNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            if(savedPhoneNumber != "")
            {
                tbPhoneNumber.Text = savedPhoneNumber;
                rBtnPhoneNumber.IsChecked = false;
            }
        }

        private void tbEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (savedPhoneNumber != "")
            {
                tbEmail.Text = savedEmail;
                rBtnEmail.IsChecked = false;
            }
        }
    }
}
