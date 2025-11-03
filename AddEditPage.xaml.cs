using Microsoft.Win32;
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

namespace MasterPolSalimgareeva
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        Partners _currentPartner = new Partners();
        public AddEditPage(Partners _selectedPartner)
        {
            InitializeComponent();

            PartnerTypeCB.ItemsSource = SalimgareevaMasterPolEntities.GetContext().PartnerType.ToList();
            PartnerTypeCB.SelectedIndex = 0;


            if ( _selectedPartner != null)
            {
                _currentPartner = _selectedPartner;
                PartnerTypeCB.SelectedItem = _selectedPartner.PartnerType;
            }

            DataContext = _currentPartner;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentPartner.PartnerCompanyName))
                errors.AppendLine("Введите название компании");
            if (string.IsNullOrWhiteSpace(RatingTextBox.Text))
                errors.AppendLine("Введите рейтинг");
            if (string.IsNullOrWhiteSpace(_currentPartner.PartnerLegalAddress))
                errors.AppendLine("Введите адрес");
            if (string.IsNullOrWhiteSpace(_currentPartner.PartnerDirectorFullname))
                errors.AppendLine("Введите ФИО директора");
            if (string.IsNullOrWhiteSpace(_currentPartner.PartnerPhoneNumber))
                errors.AppendLine("Введите телефон");
            if (string.IsNullOrWhiteSpace(_currentPartner.PartnerEmail))
                errors.AppendLine("Введите E-mail");
            if (string.IsNullOrWhiteSpace(_currentPartner.PartnerINN))
                errors.AppendLine("Введите ИНН");
            


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _currentPartner.PartnerTypeID = ((PartnerType) PartnerTypeCB.SelectedItem).PartnerTypeID;

            if (_currentPartner.PartnerID == 0)
                SalimgareevaMasterPolEntities.GetContext().Partners.Add(_currentPartner);

            try
            {
                SalimgareevaMasterPolEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string _rating = "";
            foreach (char c in RatingTextBox.Text)
            {
                if ("0123456789".Contains(c))
                    _rating = _rating + c;
            }
            RatingTextBox.Text = _rating;
        }

        private void INNTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (INNTextBox.Text.Length > 10)
            {
                string INN = "";
                for (int i = 0; i < 10; i++)
                {
                    INN += INNTextBox.Text[i];
                }
                INNTextBox.Text = INN;
                MessageBox.Show("ИНН не должен превышать 10 символов");
            }
        }
    }
}
