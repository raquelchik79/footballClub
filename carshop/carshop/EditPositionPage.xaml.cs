using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace footballClub
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPositionPage : ContentPage
    {
        public Position Position1 { get; set; }
        public DB DB { get; set; }
        public EditPositionPage(Position position, DB db)
        {
            InitializeComponent();
            Position1 = position;
            DB = db;
            BindingContext = this;
        }

        
        private void SavePosition(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Position1.Name))
                DisplayAlert("Ошибка", "Не все поля заполнены", "ОК");
            else
            {
                DB.EditPosition(Position1);
                Navigation.PopModalAsync();
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}