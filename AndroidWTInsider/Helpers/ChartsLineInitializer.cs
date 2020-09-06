using Android.Graphics;
using Com.Syncfusion.Charts;

namespace AndroidWTInsider.Helpers
{
    class ChartsLineInitializer
    {
        public void ChartLineInit(SfChart chartView, IDataGenerator chartsData, string chartTask)
        {
            chartView.Series.Clear();
            chartView.SetBackgroundColor(Color.White);
            chartView.ColorModel.ColorPalette = ChartColorPalette.Natural;

            //Trackball initialization
            ChartTrackballBehavior trackballBehavior = new ChartTrackballBehavior();
            trackballBehavior.ShowLabel = true;
            trackballBehavior.ShowLine = true;
            trackballBehavior.ActivationMode = ChartTrackballActivationMode.TouchMove;
            chartView.Behaviors.Add(trackballBehavior);

            //Chart legend initialization
            chartView.Legend.Visibility = Visibility.Visible;
            chartView.Legend.DockPosition = ChartDock.Top;
            chartView.Legend.IconHeight = 14;
            chartView.Legend.IconWidth = 14;
            chartView.Legend.ToggleSeriesVisibility = true;

            //Horizontal axis (X)
            CategoryAxis categoryaxis = new CategoryAxis();
            categoryaxis.LabelPlacement = LabelPlacement.BetweenTicks;
            categoryaxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            categoryaxis.ShowMajorGridLines = false;
            categoryaxis.AxisLineOffset = 10;
            categoryaxis.PlotOffset = 10;
            categoryaxis.MajorTickStyle.TickSize = 10;
            chartView.PrimaryAxis = categoryaxis;

            //Vertical axis (Y)
            MinMaxValue minMaxValue = new MinMaxValue();
            double maximum = minMaxValue.MaximumYValue(chartsData, chartTask);
            double minimum = minMaxValue.MinimumYValue(chartsData, chartTask);

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Minimum = minimum;
            numericalaxis.Maximum = maximum;
            numericalaxis.Interval = (maximum - minimum) / 5;
            numericalaxis.LineStyle.StrokeWidth = 0;
            numericalaxis.MajorTickStyle.TickSize = 0;
            //numericalaxis.LabelStyle.LabelFormat = "'$'#";
            chartView.SecondaryAxis = numericalaxis;

            #region Nations

            LineSeries lineUsa = new LineSeries();
            lineUsa.ItemsSource = chartsData.GetLineDataPoint("USA", chartTask);
            lineUsa.XBindingPath = "XValue";
            lineUsa.YBindingPath = "YValue";
            lineUsa.Label = "USA";
            lineUsa.Color = Color.ParseColor("#64b5f6");
            lineUsa.StrokeWidth = 2;
            lineUsa.DataMarker.ShowMarker = true;
            lineUsa.DataMarker.MarkerColor = Color.ParseColor("#64b5f6");
            lineUsa.DataMarker.MarkerWidth = 4;
            lineUsa.DataMarker.MarkerHeight = 4;

            LineSeries lineGermany = new LineSeries();
            lineGermany.ItemsSource = chartsData.GetLineDataPoint("Germany", chartTask);
            lineGermany.XBindingPath = "XValue";
            lineGermany.YBindingPath = "YValue";
            lineGermany.Label = "Germany";
            lineGermany.Visibility = Visibility.Gone;
            lineGermany.Color = Color.ParseColor("#455a64");
            lineGermany.StrokeWidth = 2;
            lineGermany.DataMarker.ShowMarker = true;
            lineGermany.DataMarker.MarkerColor = Color.ParseColor("#455a64");
            lineGermany.DataMarker.MarkerWidth = 4;
            lineGermany.DataMarker.MarkerHeight = 4;

            LineSeries lineUSSR = new LineSeries();
            lineUSSR.ItemsSource = chartsData.GetLineDataPoint("USSR", chartTask);
            lineUSSR.XBindingPath = "XValue";
            lineUSSR.YBindingPath = "YValue";
            lineUSSR.Label = "USSR";
            lineUSSR.Color = Color.ParseColor("#d50000");
            lineUSSR.StrokeWidth = 2;
            lineUSSR.DataMarker.ShowMarker = true;
            lineUSSR.DataMarker.MarkerColor = Color.ParseColor("#d50000");
            lineUSSR.DataMarker.MarkerWidth = 4;
            lineUSSR.DataMarker.MarkerHeight = 4;

            LineSeries lineBritain = new LineSeries();
            lineBritain.ItemsSource = chartsData.GetLineDataPoint("Britain", chartTask);
            lineBritain.XBindingPath = "XValue";
            lineBritain.YBindingPath = "YValue";
            lineBritain.Label = "Britain";
            lineBritain.Visibility = Visibility.Gone;
            lineBritain.Color = Color.ParseColor("#8e24aa");
            lineBritain.StrokeWidth = 2;
            lineBritain.DataMarker.ShowMarker = true;
            lineBritain.DataMarker.MarkerColor = Color.ParseColor("#8e24aa");
            lineBritain.DataMarker.MarkerWidth = 4;
            lineBritain.DataMarker.MarkerHeight = 4;

            LineSeries lineJapan = new LineSeries();
            lineJapan.ItemsSource = chartsData.GetLineDataPoint("Japan", chartTask);
            lineJapan.XBindingPath = "XValue";
            lineJapan.YBindingPath = "YValue";
            lineJapan.Label = "Japan";
            lineJapan.Visibility = Visibility.Gone;
            lineJapan.Color = Color.ParseColor("#f06292");
            lineJapan.StrokeWidth = 2;
            lineJapan.DataMarker.ShowMarker = true;
            lineJapan.DataMarker.MarkerColor = Color.ParseColor("#f06292");
            lineJapan.DataMarker.MarkerWidth = 4;
            lineJapan.DataMarker.MarkerHeight = 4;

            LineSeries lineItaly = new LineSeries();
            lineItaly.ItemsSource = chartsData.GetLineDataPoint("Italy", chartTask);
            lineItaly.XBindingPath = "XValue";
            lineItaly.YBindingPath = "YValue";
            lineItaly.Label = "Italy";
            lineItaly.Visibility = Visibility.Gone;
            lineItaly.Color = Color.ParseColor("#7cb342");
            lineItaly.StrokeWidth = 2;
            lineItaly.DataMarker.ShowMarker = true;
            lineItaly.DataMarker.MarkerColor = Color.ParseColor("#7cb342");
            lineItaly.DataMarker.MarkerWidth = 4;
            lineItaly.DataMarker.MarkerHeight = 4;

            LineSeries lineFrance = new LineSeries();
            lineFrance.ItemsSource = chartsData.GetLineDataPoint("France", chartTask);
            lineFrance.XBindingPath = "XValue";
            lineFrance.YBindingPath = "YValue";
            lineFrance.Label = "France";
            lineFrance.Visibility = Visibility.Gone;
            lineFrance.Color = Color.ParseColor("#3f51b5");
            lineFrance.StrokeWidth = 2;
            lineFrance.DataMarker.ShowMarker = true;
            lineFrance.DataMarker.MarkerColor = Color.ParseColor("#3f51b5");
            lineFrance.DataMarker.MarkerWidth = 4;
            lineFrance.DataMarker.MarkerHeight = 4;

            LineSeries lineChina = new LineSeries();
            lineChina.ItemsSource = chartsData.GetLineDataPoint("China", chartTask);
            lineChina.XBindingPath = "XValue";
            lineChina.YBindingPath = "YValue";
            lineChina.Label = "China";
            lineChina.Visibility = Visibility.Gone;
            lineChina.Color = Color.ParseColor("#f57c00");
            lineChina.StrokeWidth = 2;
            lineChina.DataMarker.ShowMarker = true;
            lineChina.DataMarker.MarkerColor = Color.ParseColor("#f57c00");
            lineChina.DataMarker.MarkerWidth = 4;
            lineChina.DataMarker.MarkerHeight = 4;

            LineSeries lineSweden = new LineSeries();
            lineSweden.ItemsSource = chartsData.GetLineDataPoint("Sweden", chartTask);
            lineSweden.XBindingPath = "XValue";
            lineSweden.YBindingPath = "YValue";
            lineSweden.Label = "Sweden";
            lineSweden.Visibility = Visibility.Gone;
            lineSweden.Color = Color.ParseColor("#ffeb3b");
            lineSweden.StrokeWidth = 2;
            lineSweden.DataMarker.ShowMarker = true;
            lineSweden.DataMarker.MarkerColor = Color.ParseColor("#ffeb3b");
            lineSweden.DataMarker.MarkerWidth = 4;
            lineSweden.DataMarker.MarkerHeight = 4;
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
            chartView.Series.Add(lineUsa);
            chartView.Series.Add(lineGermany);
            chartView.Series.Add(lineUSSR);
            chartView.Series.Add(lineBritain);
            chartView.Series.Add(lineJapan);
            chartView.Series.Add(lineItaly);
            chartView.Series.Add(lineFrance);
            chartView.Series.Add(lineChina);
            chartView.Series.Add(lineSweden);
        }
    }
}