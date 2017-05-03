using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace IntraTek.Model
{
    public class UriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string relativepath = value as string;
            if (value != null && (relativepath != null))
            {
                BitmapImage bi = new BitmapImage();
                bi.UriSource = new Uri(relativepath);
                return bi.UriSource;
            }
            return new BitmapImage(new Uri("ms-appx://IntraTek/Assets/no_picture.png", UriKind.Absolute));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
