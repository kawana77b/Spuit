using System.Windows;
using System.Windows.Controls;

namespace Spuit.WPF.Controls
{
    /// <summary>
    /// PaletteCard.xaml の相互作用ロジック
    /// </summary>
    public partial class PaletteCard : UserControl
    {
        public PaletteCard()
        {
            InitializeComponent();
        }

        public bool EnableSpuit
        {
            get { return (bool)GetValue(EnableSpuitProperty); }
            set { SetValue(EnableSpuitProperty, value); }
        }

        public static readonly DependencyProperty EnableSpuitProperty =
            DependencyProperty.Register("EnableSpuit", typeof(bool), typeof(PaletteCard), new PropertyMetadata(false));

        public string Color
        {
            get { return (string)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(string), typeof(PaletteCard), new PropertyMetadata("#FFFFFF"));

        public int XValue
        {
            get { return (int)GetValue(XValueProperty); }
            set { SetValue(XValueProperty, value); }
        }

        public static readonly DependencyProperty XValueProperty =
            DependencyProperty.Register("XValue", typeof(int), typeof(PaletteCard), new PropertyMetadata(200));

        public int YValue
        {
            get { return (int)GetValue(YValueProperty); }
            set { SetValue(YValueProperty, value); }
        }

        public static readonly DependencyProperty YValueProperty =
            DependencyProperty.Register("YValue", typeof(int), typeof(PaletteCard), new PropertyMetadata(200));
    }
}