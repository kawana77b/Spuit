using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Spuit.Core;
using System.Windows;

namespace Spuit.WPF
{
    internal class MainViewModel : ObservableObject
    {
        private readonly CursorInfo _cursorInfo = CursorInfo.Instance;

        private readonly UiTimer _timer = UiTimer.Instance;

        public MainViewModel()
        {
            _cursorInfo.Updated += OnCursorUpdated;
            UpdateCursor();

            _timer.Tick += OnTimerTick;
        }

        private void OnCursorUpdated(object? sender, EventArgs e)
        {
            var position = _cursorInfo.Position;
            CursorX = position.X;
            CursorY = position.Y;

            var colorInfo = _cursorInfo.Color.ToColorInfo();
            ColorHex = colorInfo.Hex;
            ColorRGB = colorInfo.Rgba.ToString(false);
            ColorHSL = colorInfo.Hsl.ToString();
        }

        private void OnTimerTick(object? sender, EventArgs e)
        {
            UpdateCursor();
        }

        private void UpdateCursor()
        {
            _cursorInfo.Update();
        }

        private bool _enableSpuit = false;

        public bool EnableSpuit
        {
            get => _enableSpuit;
            set
            {
                SetProperty(ref _enableSpuit, value);
                if (value)
                    _timer.Start();
                else
                    _timer.Stop();
            }
        }

        private int _cursorX = 0;

        public int CursorX
        {
            get => _cursorX;
            set => SetProperty(ref _cursorX, value);
        }

        private int _cursorY = 0;

        public int CursorY
        {
            get => _cursorY;
            set => SetProperty(ref _cursorY, value);
        }

        private string _colorHex = "#FFFFFF";

        public string ColorHex
        {
            get => _colorHex;
            set => SetProperty(ref _colorHex, value);
        }

        private string _colorRGB = "255, 255, 255";

        public string ColorRGB
        {
            get => _colorRGB;
            set => SetProperty(ref _colorRGB, value);
        }

        private string _colorHSL = "0, 0, 100";

        public string ColorHSL
        {
            get => _colorHSL;
            set => SetProperty(ref _colorHSL, value);
        }

        public RelayCommand SpuitToggleCommand => new(() =>
        {
            EnableSpuit = !EnableSpuit;
        });

        public RelayCommand CopyHexCommand => new(() =>
        {
            var css = ColorHex;
            Clipboard.SetDataObject(css);
        });

        public RelayCommand CopyCursorCommand => new(() =>
        {
            var pos = $"{CursorX},{CursorY}";
            Clipboard.SetDataObject(pos);
        });

        public RelayCommand CopyRgbCommand => new(() =>
        {
            var css = _cursorInfo.Color.ToColorInfo().Rgba.CSS();
            Clipboard.SetDataObject(css);
        });

        public RelayCommand CopyHslCommand => new(() =>
        {
            var css = _cursorInfo.Color.ToColorInfo().Hsl.CSS();
            Clipboard.SetDataObject(css);
        });

        public RelayCommand CopyJsonCommand => new(() =>
        {
            var json = _cursorInfo.ToPixel().ToJson();
            Clipboard.SetDataObject(json);
        });
    }
}