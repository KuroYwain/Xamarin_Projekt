using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Xamarin_Projekt
{
    public class MyCompass
    {
        public event EventHandler<string> GetCompassValue;
        public MyCompass()
        {
            Start();
            Compass.ReadingChanged += Compas_ReadingChanged;
        }

        private void Compas_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            double value = e.Reading.HeadingMagneticNorth;
            string valueFormated = String.Format("{0} {1} {2}",value.ToString("0"),CalculateDirection(value),"\u00b0");
            GetCompassValue?.Invoke(this,valueFormated);
        }

        public void Start()
        {
            try
            {
                Compass.Start(SensorSpeed.UI);

            }
            catch(FeatureNotSupportedException fnsEx)
            {
                Console.WriteLine(fnsEx.Message);
            }
            catch(Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
        }
        private string CalculateDirection(double degree)
        {
            if (degree < 22)
            {
                return "North";
            }
            else if (degree < 67)
            {
                return "North East";
            }
            else if (degree < 112)
            {
                return "East";
            }
            else if (degree < 157)
            {
                return "South East";
            }
            else if (degree < 202)
            {
                return "South";
            }
            else if (degree < 247)
            {
                return "South West";
            }
            else if (degree < 292)
            {
                return "West";
            }
            else if (degree < 337)
            {
                return "North West";
            }
            else
            {
                return "North";
            }
        }
    }
}
