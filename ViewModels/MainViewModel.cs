using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcInfo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        public ViewModelBase CurrentChildView 
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            } 
        }
        public string Caption 
        { 
            get => _caption;
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon 
        { 
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }
        public dynamic ShowHomeViewCommand { get; }
        public dynamic ShowMaterielViewCommand { get; }

        public MainViewModel()
        {
            //Initialisation des commandes
            //ShowHomeViewCommand = new ViewModelBase();

            //Vue par défaut
            ExecuteShowHomeViewCommand(null);
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }
    }
}
