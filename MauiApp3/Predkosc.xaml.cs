namespace MauiApp3;

public partial class Predkosc : ContentPage
{
	public Predkosc()
	{
		InitializeComponent();
	}
    private void OnConvertButtonClicked(object sender, EventArgs e)
    {
        if (double.TryParse(SpeedEntry.Text, out double speed))
        {
            double result = ConvertSpeed(speed, SourceUnitPicker.SelectedIndex, TargetUnitPicker.SelectedIndex);
            ResultLabel.Text = $"{result:F2}";
        }
        else
        {
            ResultLabel.Text = "WprowadŸ poprawn¹ prêdkoœæ.";
        }
    }

    private double ConvertSpeed(double speed, int sourceUnitIndex, int targetUnitIndex)
    {
        double factor = GetConversionFactor(sourceUnitIndex, targetUnitIndex);
        return speed * factor;
    }

    private double GetConversionFactor(int sourceUnitIndex, int targetUnitIndex)
    {
        double[][] conversionFactors = {
        new double[] { 1, 1000, 0.277778, 0.621371 }, // km/h
        new double[] { 0.001, 1, 0.000278, 0.000621 }, // m/h
        new double[] { 3.6, 3600, 1, 2.23694 }, // km/s
        new double[] { 1.60934, 1609.34, 0.44704, 1 } // m/s
    };

        return conversionFactors[sourceUnitIndex][targetUnitIndex];
    }

}