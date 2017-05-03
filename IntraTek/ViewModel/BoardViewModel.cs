using IntraTek.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntraTek.ViewModel
{
    public class BoardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        #region Board
        private Board board;
        public Board Board
        {
            get
            {
                if (board == null)
                    board = new Board();
                return board;
            }
            set
            {
                board = value;
                NotifyPropertyChanged("Board");
            }
        }
        #endregion

        public BoardViewModel()
        {

        }

        private void NotifyPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}
