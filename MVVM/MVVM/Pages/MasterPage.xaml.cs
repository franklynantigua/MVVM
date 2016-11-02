
using Xamarin.Forms;

namespace MVVM.Pages
{
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();


        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.Navigator = Navigator;
        }

    }
}
