namespace MauiApp3;

public partial class Dlugosci : ContentPage
{
	public Dlugosci()
	{
		InitializeComponent();
	}
    private void OnConvertButtonClicked(object sender, EventArgs e)
    {
        if (double.TryParse(LengthEntry.Text, out double length))
        {
            double result = ConvertLength(length, SourceUnitPicker.SelectedIndex, TargetUnitPicker.SelectedIndex);
            ResultLabel.Text = $"{result:F2}";
        }
        else
        {
            ResultLabel.Text = "WprowadŸ poprawn¹ d³ugoœæ.";
        }
    }

    private double ConvertLength(double length, int sourceUnitIndex, int targetUnitIndex)
    {
        double factor = GetConversionFactor(sourceUnitIndex, targetUnitIndex);
        return length * factor;
    }

    private double GetConversionFactor(int sourceUnitIndex, int targetUnitIndex)
    {
        double[] conversionFactors = { 1, 0.01, 0.001, 1000 };

        return conversionFactors[sourceUnitIndex] / conversionFactors[targetUnitIndex];
    }
}