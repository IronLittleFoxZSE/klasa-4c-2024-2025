﻿namespace BindingMauiApp
{
    public partial class MainPage : ContentPage
    {
        public string Message { get; set; }

        private string returnMessage;
        public string ReturnMessage
        {
            get { return returnMessage; }
            set 
            { 
                returnMessage = value;
                //OnPropertyChanged("ReturnMessage");
                //OnPropertyChanged(nameof(ReturnMessage));
                OnPropertyChanged();
            }
        }


        public MainPage()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            rotationLabel.Rotation = rotationSlider.Value;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ReturnMessage = "Wartość z entry " + Message;
            //OnPropertyChanged("ReturnMessage");
            //OnPropertyChanged(nameof(ReturnMessage));
        }
    }

}
