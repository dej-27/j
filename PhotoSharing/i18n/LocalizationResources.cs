using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PhotoSharing.i18n
{
    public class LocalizationResources
    {
        private i18n _i18n = new i18n();
        public i18n i18n
        {
            get
            {
                return _i18n;
            }
        }
    }
}
