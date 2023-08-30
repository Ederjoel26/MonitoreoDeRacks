using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MonitorRacks.Modelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonitorRacks.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuFlyout : ContentPage
    {
        public ListView ListView;

        public MenuFlyout()
        {
            InitializeComponent();

            BindingContext = new MenuFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class MenuFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MenuFlyoutMenuItem> MenuItems { get; set; }

            public MenuFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MenuFlyoutMenuItem>(new[]
                {
                    new MenuFlyoutMenuItem
                    {
                        Id = 1,
                        Title = "Arana",
                        TargetType = typeof(Site),
                        IconSource = "servidor.png"
                    },
                    new MenuFlyoutMenuItem
                    {
                        Id = 2,
                        Title = "Huertas",
                        TargetType = typeof(Site),
                        IconSource = "servidordos.png"
                    },
                    new MenuFlyoutMenuItem
                    {
                        Id = 3,
                        Title = "Fresas",
                        TargetType = typeof(Site),
                        IconSource = "servidortres.png"
                    },
                    new MenuFlyoutMenuItem
                    {
                        Id = 4,
                        Title = "Servicios",
                        TargetType = typeof(Servicios),
                        IconSource = "ajustes.png"
                    },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}