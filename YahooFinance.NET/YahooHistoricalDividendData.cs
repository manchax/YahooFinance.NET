using System;

namespace YahooFinance.NET
{
	[Serializable]
	public class YahooHistoricalDividendData
	{
		public DateTime Date { get; set; }
		public decimal Dividend { get; set; }
	}
}
