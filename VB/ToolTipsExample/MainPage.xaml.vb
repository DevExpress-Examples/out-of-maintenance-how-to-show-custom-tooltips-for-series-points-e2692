Imports Microsoft.VisualBasic
#Region "#usings"
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input
Imports DevExpress.Xpf.Charts
' ...
#End Region ' #usings

Namespace ToolTipsExample
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
		End Sub

		#Region "#code"
		Private Const toolTipOffset As Double = 10.0

		Private Sub chart_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim position As Point = e.GetPosition(chart)
			Dim hitInfo As ChartHitInfo = chart.CalcHitInfo(position)
			If hitInfo IsNot Nothing AndAlso hitInfo.SeriesPoint IsNot Nothing Then
				ttContent.Text = _ 
	String.Format("Year = {0}" & Constants.vbLf & "State = {1}" & Constants.vbLf & "GSP = {2}", _ 
	hitInfo.SeriesPoint.Series.DisplayName, hitInfo.SeriesPoint.Argument, Math.Round(hitInfo.SeriesPoint.NonAnimatedValue, 2))
				pointTooltip.HorizontalOffset = position.X + toolTipOffset
				pointTooltip.VerticalOffset = position.Y + toolTipOffset
				pointTooltip.IsOpen = True
				Cursor = Cursors.Hand
			Else
				pointTooltip.IsOpen = False
				Cursor = Cursors.Arrow
			End If
		End Sub

		Private Sub chart_MouseLeave(ByVal sender As Object, ByVal e As MouseEventArgs)
			pointTooltip.IsOpen = False
		End Sub
		#End Region ' #code

	End Class
End Namespace
