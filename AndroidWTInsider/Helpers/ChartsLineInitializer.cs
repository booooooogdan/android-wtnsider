using Android.App;
using Android.Content;
using Android.Graphics;
using Com.Syncfusion.Charts;

namespace AndroidWTInsider.Helpers
{
    class ChartsLineInitializer
    {
        public void ChartLineBinding(SfChart chart, ChartsDataPoints chartsDataPoints)
        {
            chart.SetBackgroundColor(Color.White);
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            //Trackball initialization
            ChartTrackballBehavior trackballBehavior = new ChartTrackballBehavior();
            trackballBehavior.ShowLabel = true;
            trackballBehavior.ShowLine = true;
            trackballBehavior.ActivationMode = ChartTrackballActivationMode.TouchMove;
            chart.Behaviors.Add(trackballBehavior);

            //Chart legend initialization
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.Legend.IconHeight = 14;
            chart.Legend.IconWidth = 14;
            chart.Legend.ToggleSeriesVisibility = true;

            //Horizontal axis (X)
            CategoryAxis categoryaxis = new CategoryAxis();
            categoryaxis.LabelPlacement = LabelPlacement.BetweenTicks;
            categoryaxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            categoryaxis.ShowMajorGridLines = false;
            categoryaxis.AxisLineOffset = 10;
            categoryaxis.PlotOffset = 10;
            categoryaxis.MajorTickStyle.TickSize = 10;
            chart.PrimaryAxis = categoryaxis;

            //Vertical axis (Y)
            MinMaxValue minMaxValue = new MinMaxValue();
            double maximum = minMaxValue.MaximumYValue();
            double minimum = minMaxValue.MinimumYValue();

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Minimum = minimum;
            numericalaxis.Maximum = maximum;
            numericalaxis.Interval = (maximum-minimum)/5;
            numericalaxis.LineStyle.StrokeWidth = 0;
            numericalaxis.MajorTickStyle.TickSize = 0;
            //numericalaxis.LabelStyle.LabelFormat = "'$'#";
            chart.SecondaryAxis = numericalaxis;

            #region Nations

            LineSeries lineUsa = new LineSeries();
            lineUsa.ItemsSource = chartsDataPoints.GetLineDataPoint("USA");
            lineUsa.XBindingPath = "XValue";
            lineUsa.YBindingPath = "YValue";
            lineUsa.Label = "USA";
            lineUsa.Color = Color.ParseColor("#64b5f6");
            lineUsa.StrokeWidth = 2;
            lineUsa.TooltipEnabled = true;

            LineSeries lineGermany = new LineSeries();
            lineGermany.ItemsSource = chartsDataPoints.GetLineDataPoint("Germany");
            lineGermany.XBindingPath = "XValue";
            lineGermany.YBindingPath = "YValue";
            lineGermany.Label = "Germany";
            lineGermany.Visibility = Visibility.Gone;
            lineGermany.Color = Color.ParseColor("#455a64");
            lineGermany.StrokeWidth = 2;
            lineGermany.TooltipEnabled = true;

            LineSeries lineUSSR = new LineSeries();
            lineUSSR.ItemsSource = chartsDataPoints.GetLineDataPoint("USSR");
            lineUSSR.XBindingPath = "XValue";
            lineUSSR.YBindingPath = "YValue";
            lineUSSR.Label = "USSR";
            lineUSSR.Color = Color.ParseColor("#d50000");
            lineUSSR.StrokeWidth = 2;
            lineUSSR.TooltipEnabled = true;

            LineSeries lineBritain = new LineSeries();
            lineBritain.ItemsSource = chartsDataPoints.GetLineDataPoint("Britain");
            lineBritain.XBindingPath = "XValue";
            lineBritain.YBindingPath = "YValue";
            lineBritain.Label = "Britain";
            lineBritain.Visibility = Visibility.Gone;
            lineBritain.Color = Color.ParseColor("#8e24aa");
            lineBritain.StrokeWidth = 2;
            lineBritain.TooltipEnabled = true;

            LineSeries lineJapan = new LineSeries();
            lineJapan.ItemsSource = chartsDataPoints.GetLineDataPoint("Japan");
            lineJapan.XBindingPath = "XValue";
            lineJapan.YBindingPath = "YValue";
            lineJapan.Label = "Japan";
            lineJapan.Visibility = Visibility.Gone;
            lineJapan.Color = Color.ParseColor("#f06292");
            lineJapan.StrokeWidth = 2;
            lineJapan.TooltipEnabled = true;

            LineSeries lineItaly = new LineSeries();
            lineItaly.ItemsSource = chartsDataPoints.GetLineDataPoint("Italy");
            lineItaly.XBindingPath = "XValue";
            lineItaly.YBindingPath = "YValue";
            lineItaly.Label = "Italy";
            lineItaly.Visibility = Visibility.Gone;
            lineItaly.Color = Color.ParseColor("#7cb342");
            lineItaly.StrokeWidth = 2;
            lineItaly.TooltipEnabled = true;

            LineSeries lineFrance = new LineSeries();
            lineFrance.ItemsSource = chartsDataPoints.GetLineDataPoint("France");
            lineFrance.XBindingPath = "XValue";
            lineFrance.YBindingPath = "YValue";
            lineFrance.Label = "France";
            lineFrance.Visibility = Visibility.Gone;
            lineFrance.Color = Color.ParseColor("#3f51b5");
            lineFrance.StrokeWidth = 2;
            lineFrance.TooltipEnabled = true;

            LineSeries lineChina = new LineSeries();
            lineChina.ItemsSource = chartsDataPoints.GetLineDataPoint("China");
            lineChina.XBindingPath = "XValue";
            lineChina.YBindingPath = "YValue";
            lineChina.Label = "China";
            lineChina.Visibility = Visibility.Gone;
            lineChina.Color = Color.ParseColor("#f57c00");
            lineChina.StrokeWidth = 2;
            lineChina.TooltipEnabled = true;

            LineSeries lineSweden = new LineSeries();
            lineSweden.ItemsSource = chartsDataPoints.GetLineDataPoint("Sweden");
            lineSweden.XBindingPath = "XValue";
            lineSweden.YBindingPath = "YValue";
            lineSweden.Label = "Sweden";
            lineSweden.Visibility = Visibility.Gone;
            lineSweden.Color = Color.ParseColor("#ffeb3b");
            lineSweden.StrokeWidth = 2;
            lineSweden.TooltipEnabled = true;
            #endregion

            //Turn on animation drawing
            lineUsa.EnableAnimation = true;
            lineGermany.EnableAnimation = true;
            lineUSSR.EnableAnimation = true;
            lineBritain.EnableAnimation = true;
            lineJapan.EnableAnimation = true;
            lineItaly.EnableAnimation = true;
            lineFrance.EnableAnimation = true;
            lineChina.EnableAnimation = true;
            lineSweden.EnableAnimation = true;

            //Add line to chart
            chart.Series.Add(lineUsa);
            chart.Series.Add(lineGermany);
            chart.Series.Add(lineUSSR);
            chart.Series.Add(lineBritain);
            chart.Series.Add(lineJapan);
            chart.Series.Add(lineItaly);
            chart.Series.Add(lineFrance);
            chart.Series.Add(lineChina);
            chart.Series.Add(lineSweden);
        }
    }
}