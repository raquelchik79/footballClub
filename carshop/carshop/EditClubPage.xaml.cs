using footballClub;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace footballClub
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditClubPage : ContentPage
    {
        //public ObservableCollection<Position> Positions { get; set; }
        public Club Club1 { get; set; }
        //public Position Position { get; set; }
        public DB DB { get; set; }
        public EditClubPage(Club Club, DB db)
        {
            InitializeComponent();
            Club1 = Club;
            DB = db;
            //Positions = db.GetPositions();
            BindingContext = this;
        }

        
        private void SaveClub(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Club1.Name) || string.IsNullOrEmpty(Club1.Info))
                DisplayAlert("Ошибка", "Не все поля заполнены", "ОК");
            else
            {
                DB.EditClub(Club1);
                Navigation.PopModalAsync();
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}