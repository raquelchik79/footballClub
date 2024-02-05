using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace footballClub
{
    public class DB
    {
        private ObservableCollection<Player> playerList = new ObservableCollection<Player>();
        private ObservableCollection<Club> clubList = new ObservableCollection<Club>();
        private ObservableCollection<Position> positionList = new ObservableCollection<Position>();
        private int checkidplayer = 0;
        private int checkidclub = 0;
        private int checkidposition = 0;
        public DB()
        {
            Player player1 = new Player()
            {
                ID = ++checkidplayer,
                Name = "Криштиану Роналду",
                Price = 80000,
                Info = "Португалец",
                IDClub = 1,
                IDPosition = 1,
            };
            Player player2 = new Player()
            {
                ID = ++checkidplayer,
                Name = "Лионель Месси",
                Price = 15000,
                Info = "Аргентинец",
                IDClub = 2,
                IDPosition = 2,
            };
            Player player3 = new Player()
            {
                ID = ++checkidplayer,
                Name = "Роберт Левандовски",
                Price = 45000,
                Info = "Поляк",
                IDClub = 3,
                IDPosition = 2,
            };
            playerList.Add(player1);
            playerList.Add(player2);
            playerList.Add(player3);

            Club club1 = new Club()
            {
                ID = ++checkidclub,
                Name = "Аль-Наср",
                Price = 1000,
                Info = "1",
            };
            Club club2 = new Club()
            {
                ID = ++checkidclub,
                Name = "Интер Маями",
                Price = 3000,
                Info = "2",
            };
            Club club3 = new Club()
            {
                ID = ++checkidclub,
                Name = "Барселона",
                Price = 2500,
                Info = "3",
            };
            clubList.Add(club1);
            clubList.Add(club2);
            clubList.Add(club3);

            Position position1 = new Position()
            {
                ID = ++checkidposition,
                Name = "Вратарь",
            };
            Position position2 = new Position()
            {
                ID = ++checkidposition,
                Name = "Защитник",
            };
            Position position3 = new Position()
            {
                ID = ++checkidposition,
                Name = "Полузащитник",
            };
            Position position4 = new Position()
            {
                ID = ++checkidposition,
                Name = "Нападающий",
            };

            positionList.Add(position1);
            positionList.Add(position2);
            positionList.Add(position3);
            positionList.Add(position4);
        }
        public ObservableCollection<Player> GetPlayers()
        {
            return playerList;
        }
        public Player GetPlayer(int id)
        {
            return playerList.FirstOrDefault(x => x.ID == id);
        }

        public ObservableCollection<Club> GetClubs()
        {
            return clubList;
        }
        public Club GetClub(int id)
        {
            return clubList.FirstOrDefault(x => x.ID == id);
        }
        public ObservableCollection<Position> GetPositions()
        {
            return positionList;
        }
        public Position GetPosition(int id)
        {
            return positionList.FirstOrDefault(x => x.ID == id);
        }
        public void DeletePlayer(int id)
        {
            Player player = GetPlayer(id);
            if (player != null)
                playerList.Remove(player);
        }

        public void EditPlayer(Player player)
        {
            if (player.ID == 0)
            {
                player.ID = ++checkidplayer;
                playerList.Add(player);

            }
            else
            {
                Player oldPlayer = GetPlayer(player.ID);
                oldPlayer.Name = player.Name;
                oldPlayer.Price = player.Price;
                oldPlayer.Info = player.Info;
                oldPlayer.IDClub = player.IDClub;
                oldPlayer.IDPosition = player.IDPosition;
                playerList.Add(oldPlayer);
                playerList.Remove(GetPlayer(player.ID));

            }
        }

        public void DeleteClub(int id)
        {
            Club club = GetClub(id);
            if (club != null)
                clubList.Remove(club);
        }

        public void EditClub(Club club)
        {
            if (club.ID == 0)
            {
                club.ID = ++checkidclub;
                clubList.Add(club);

            }
            else
            {
                Club oldClub = GetClub(club.ID);
                oldClub.Name = club.Name;
                oldClub.Price = club.Price;
                oldClub.Info = club.Info;

                clubList.Add(club);
                clubList.Remove(GetClub(club.ID));
            }
        }
        public void DeletePosition(int id)
        {
            Position position = GetPosition(id);
            if (position != null)
                positionList.Remove(position);
        }

        public void EditPosition(Position position)
        {
            if (position.ID == 0)
            {
                position.ID = ++checkidposition;
                positionList.Add(position);
            }
            else
            {
                Position oldPosition = GetPosition(position.ID);
                oldPosition.Name = position.Name;
                positionList.Add(position);
                positionList.Remove(GetPosition(position.ID));
            }
        }
    }
}

