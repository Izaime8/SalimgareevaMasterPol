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
    /// Логика взаимодействия для HistotyPage.xaml
    /// </summary>
    public partial class HistotyPage : Page
    {
        public HistotyPage(Partners selectedPartner)
        {
            InitializeComponent();

            HistoryListView.ItemsSource = SalimgareevaMasterPolEntities.GetContext().Orders.Where(o => o.PartnerID == selectedPartner.PartnerID).OrderBy(o => o.OrderSaleDate).ToList();
            PartnerNameTB.Text = selectedPartner.PartnerCompanyName;
            PartnerTypeNameTB.Text = selectedPartner.PartnerType.PartnerTypeName;
        }
    }
}
