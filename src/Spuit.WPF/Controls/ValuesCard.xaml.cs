using System.Windows;
using System.Windows.Controls;

namespace Spuit.WPF.Controls
{
    /// <summary>
    /// ValuesCard.xaml の相互作用ロジック
    /// </summary>
    public partial class ValuesCard : UserControl
    {
        public ValuesCard()
        {
            InitializeComponent();
        }

        public string Hex
        {
            get { return (string)GetValue(HexProperty); }
            set { SetValue(HexProperty, value); }
        }

        public static readonly DependencyProperty HexProperty =
            DependencyProperty.Register("Hex", typeof(string), typeof(ValuesCard), new PropertyMetadata(string.Empty));

        public string RGB
        {
            get { return (string)GetValue(RGBProperty); }
            set { SetValue(RGBProperty, value); }
        }

        public static readonly DependencyProperty RGBProperty =
            DependencyProperty.Register("RGB", typeof(string), typeof(ValuesCard), new PropertyMetadata(string.Empty));

        public string HSL
        {
            get { return (string)GetValue(HSLProperty); }
            set { SetValue(HSLProperty, value); }
        }

        public static readonly DependencyProperty HSLProperty =
            DependencyProperty.Register("HSL", typeof(string), typeof(ValuesCard), new PropertyMetadata(string.Empty));
    }
}