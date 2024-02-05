using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace footballClub
{
    public partial class
        MainPage : ContentPage, INotifyPropertyChanged
    {
        private ObservableCollection<Player> playerList;
        private ObservableCollection<Club> clubList;
        private ObservableCollection<Position> positionList;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Player> PlayerList { get => playerList; set { playerList = value; SignalChanged(); } }
        public Player SelectedPlayer { get; set; }
        public ObservableCollection<Club> ClubList { get => clubList; set { clubList = value; SignalChanged(); } }
        public Club SelectedClub { get; set; }
        public ObservableCollection<Position> PositionList { get => positionList; set { positionList = value; SignalChanged(); } }
        public Position SelectedPosition { get; set; }
        public DB db { get; set; }
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            db = new DB();
            PlayerList = db.GetPlayers();
            ClubList = db.GetClubs();
            PositionList = db.GetPositions();
            ChangeList();
            ChangeClubList(); 
            ChangePositionList();
            SignalChanged();
        }

        private void AddPlayer(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new EditPage(new Player(), db));
            ChangeList();
        }

        private void EditPlayer(object sender, EventArgs e)
        {
            if (SelectedPlayer == null) return;
            Player player = new Player()
            {
                ID = SelectedPlayer.ID,
                Name = SelectedPlayer.Name,
                Price = SelectedPlayer.Price,
                Info = SelectedPlayer.Info,
                IDClub = SelectedPlayer.IDClub,
                IDPosition = SelectedPlayer.IDPosition
            };
            App.Current.MainPage.Navigation.PushModalAsync(new EditPage(player, db));
            ChangeList();

        }

        private void DeletePlayer(object sender, EventArgs e)
        {
            if (SelectedPlayer != null)
            {
                db.DeletePlayer(SelectedPlayer.ID);
                ChangeList();
            }
            else
                DisplayAlert("Ошибка", "Игрок не выбран", "ОК");
        }

        private void AddClub(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new EditClubPage(new Club(), db));
            ChangeClubList();
        }

        private void EditClub(object sender, EventArgs e)
        {

            if (SelectedClub == null) return;
            Club club = new Club()
            {
                ID = SelectedClub.ID,
                Name = SelectedClub.Name,
                Price = SelectedClub.Price,
                Info = SelectedClub.Info,
            };

            App.Current.MainPage.Navigation.PushModalAsync(new EditClubPage(club, db));
            ChangeClubList();
        }

        private void DeleteClub(object sender, EventArgs e)
        {
            if (SelectedClub != null)
            {
                db.DeleteClub(SelectedClub.ID);
                ChangeClubList();
            }
            else
                DisplayAlert("Ошибка", "Клуб не выбран", "ОК");
        }

        private void AddPosition(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new EditPositionPage(new Position(), db));
            ChangePositionList();
        }

        private void EditPosition(object sender, EventArgs e)
        {

            if (SelectedPosition == null) return;
            Position position = new Position()
            {
                ID = SelectedPosition.ID,
                Name = SelectedPosition.Name,
            };

            App.Current.MainPage.Navigation.PushModalAsync(new EditPositionPage(position, db));
            ChangePositionList();
        }

        private void DeletePosition(object sender, EventArgs e)
        {
            if (SelectedPosition != null)
            {
                db.DeletePosition(SelectedPosition.ID);
                ChangePositionList();
            }
            else
                DisplayAlert("Ошибка", "Позиция не выбрана", "ОК");
        }

        public void ChangePositionList()
        {
            PositionList = new ObservableCollection<Position>();
            PositionList = db.GetPositions();
        }

        public void ChangeClubList()
        {
            ClubList = new ObservableCollection<Club>();
            ClubList = db.GetClubs();
        }

        public void ChangeList()
        {
            PlayerList = new ObservableCollection<Player>();
            PlayerList = db.GetPlayers();
        }

        public void SignalChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
