using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Xamarin_Projekt
{
    public class Acc : INotifyPropertyChanged
    {
        SensorSpeed speed = SensorSpeed.UI;

        private string errorString;
        private string reading;
        public event PropertyChangedEventHandler PropertyChanged;
        public string ErrorString
        {
            get { return errorString; }
            set
            {
                errorString = value;
                OnPropertyChanged(nameof(ErrorString));
            }
        }
        public string Reading
        {
            get { return reading; }
            set
            {
                reading = value;
                OnPropertyChanged(nameof(Reading));
            }
        }
        public Acc()
        {
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            AccToggle();
            ErrorString = "";
            Reading = "Odczyt";
        }

        void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var data = e.Reading;
            Reading = $"Odczyt Twojej lokalizacji w osi:\n X: {data.Acceleration.X}\n + Y: {data.Acceleration.Y}\n + Z: {data.Acceleration.Z}\n";
        }

        public void AccToggle()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                    Accelerometer.Stop();
                else
                    Accelerometer.Start(speed);
            }
            catch (FeatureNotSupportedException)
            {
                ErrorString = "Feature not supported";
            }
            catch (Exception ex)
            {
                ErrorString = ex.Message;
            }

        }
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
