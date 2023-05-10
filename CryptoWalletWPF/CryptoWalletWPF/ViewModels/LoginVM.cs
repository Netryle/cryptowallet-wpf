using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWalletWPF.ViewModels
{
    class LoginVM : INotifyPropertyChanged
    {
        private List<string> networkList 
        {
            get 
            {
                return this.networkList;
            }
            set
            {
                this.networkList = value;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
