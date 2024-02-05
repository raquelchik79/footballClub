using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace footballClub
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPage : ContentPage
    {
        public ObservableCollection<Club> Clubs { get; set; }
        public ObservableCollection<Position> Positions { get; set; }

        public Club Club { get; set; }
        public Position Position { get; set; }
        public Player Player1 { get; set; }
        public DB DB { get; set; }
        public EditPage(Player player, DB db)
        {
            InitializeComponent();
            Player1 = player;
            DB = db;
            Clubs = db.GetClubs();
            Positions = db.GetPositions();
            Club = Clubs.FirstOrDefault(s => s.ID == Player1.IDClub);
            Position = Positions.FirstOrDefault(s => s.ID == Player1.IDPosition);
            BindingContext = this;
        }

        public void SavePlayer(object sender, EventArgs e)
        {
            if (Player1.ID != 0)
            {
                Club = Clubs.FirstOrDefault(s => s.ID == Player1.IDClub);
                Position = Positions.FirstOrDefault(s => s.ID == Player1.IDPosition);
            }

            if (string.IsNullOrWhiteSpace(Player1.Name) || string.IsNullOrWhiteSpace(Player1.Info))
                DisplayAlert("Ошибка", "Не все поля заполнены", "ОК");
            else
            {
                Player1.IDClub = Club.ID;
                Player1.IDPosition = Position.ID;
                DB.EditPlayer(Player1);
                Navigation.PopModalAsync();
            }
        }
        public void Cancel(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

    }
}