#region #usings
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DevExpress.Xpf.Charts;
// ...
#endregion #usings

namespace ToolTipsExample {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
        }

        #region #code
        const double toolTipOffset = 10.0;

        void chart_MouseMove(object sender, MouseEventArgs e) {
            Point position = e.GetPosition(chart);
            ChartHitInfo hitInfo = chart.CalcHitInfo(position);
            if (hitInfo != null && hitInfo.SeriesPoint != null) {
                ttContent.Text = string.Format("Year = {0}\nState = {1}\nGSP = {2}",
                    hitInfo.SeriesPoint.Series.DisplayName, hitInfo.SeriesPoint.Argument, 
                    Math.Round(hitInfo.SeriesPoint.NonAnimatedValue, 2));
                pointTooltip.HorizontalOffset = position.X + toolTipOffset;
                pointTooltip.VerticalOffset = position.Y + toolTipOffset;
                pointTooltip.IsOpen = true;
                Cursor = Cursors.Hand;
            }
            else {
                pointTooltip.IsOpen = false;
                Cursor = Cursors.Arrow;
            }
        }

        void chart_MouseLeave(object sender, MouseEventArgs e) {
            pointTooltip.IsOpen = false;
        }
        #endregion #code

    }
}
