using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace App4
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
        private IList _ribbonOptions;
        public IList RibbonOptions
        {
            get
            {
                return _ribbonOptions;
            }
            set
            {
                SetProperty(ref _ribbonOptions, value);
            }
        }

        private string _loadURI;
        public string LoadURI
        {
            get
            {
                return _loadURI;
            }
            set
            {
                SetProperty(ref _loadURI, value);
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy == value)
                    return;

                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        private ICommand _optionSelectionChangedCommand;
        public ICommand OptionSelectionChangedCommand
        {
            get
            {
                return _optionSelectionChangedCommand;
            }
            set
            {
                SetProperty(ref _optionSelectionChangedCommand, value);
            }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
           [CallerMemberName]string propertyName = "",
           Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;
            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public HomePageViewModel()
        {
            List<String> lst = new List<String>() { "C# Corner", "Xamarin", "Microsoft" };
            this.RibbonOptions = lst;

            LoadURI = "https://www.c-sharpcorner.com/resources/aboutus.aspx";

            IsBusy = true;

            this.OptionSelectionChangedCommand = new Command((obj) => {
                var selectedItemRibbonIndex = obj.ToString();
                IsBusy = true;
                if (selectedItemRibbonIndex == "0")
                {
                    LoadURI = "https://www.c-sharpcorner.com/resources/aboutus.aspx";
                }
                else if (selectedItemRibbonIndex == "1")
                {
                    LoadURI = "https://docs.microsoft.com/en-us/xamarin/xamarin-forms/";
                }
                else
                {
                    LoadURI = "https://www.microsoft.com/en-in?SilentAuth=1&wa=wsignin1.0";
                }
            });
        }
    }
}
