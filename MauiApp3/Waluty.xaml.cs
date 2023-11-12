namespace MauiApp3;

public partial class Waluty : ContentPage
{
	public Waluty()
	{
		InitializeComponent();
	}
    private void OnConvertButtonClicked(object sender, EventArgs e)
    {
        if (double.TryParse(AmountEntry.Text, out double amount))
        {
            string sourceCurrency = SourceCurrencyPicker.SelectedItem.ToString();
            string targetCurrency = TargetCurrencyPicker.SelectedItem.ToString();

            double convertedAmount = ConvertCurrency(amount, sourceCurrency, targetCurrency);

            ResultLabel.Text = $"{convertedAmount:F2} {targetCurrency}";
        }
        else
        {
            ResultLabel.Text = "WprowadŸ poprawn¹ kwotê.";
        }
    }

    private double ConvertCurrency(double amount, string sourceCurrency, string targetCurrency)
    {
        Dictionary<string, double> exchangeRates = new Dictionary<string, double>
        {
        { "PLN", 1.0 },
        { "USD", 0.265 },
        { "EUR", 0.225 },
        { "GBP", 0.192 },
        { "JPY", 29.41 }
        };

        double sourceRate = exchangeRates[sourceCurrency];
        double targetRate = exchangeRates[targetCurrency];

        return (amount / sourceRate) * targetRate;
    }
}