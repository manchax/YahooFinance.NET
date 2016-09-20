﻿using System;
using System.Collections.Generic;
using Xunit;

namespace YahooFinance.NET.Tests
{
	public class YahooFinanceClientTests
	{
		/**********************************************************
		 * NOTE: These unit tests use the API
		**********************************************************/

		[Fact]
		public void ReadMeExample()
		{
			string exchange = "ASX";
			string symbol = "AFI";

			YahooFinanceClient yahooFinance = new YahooFinanceClient();
			string yahooStockCode = yahooFinance.GetYahooStockCode(exchange, symbol);
			List<YahooHistoricalPriceData> yahooPriceHistory = yahooFinance.GetDailyHistoricalPriceData(yahooStockCode);
			List<YahooHistoricalDividendData> yahooDividendHistory = yahooFinance.GetHistoricalDividendData(yahooStockCode);
		}

		[Fact]
		public void TestDailyPriceHistoy()
		{
			var exchange = "ASX";
			var symbol = "AFI";

			var yahooFinance = new YahooFinanceClient();
			var yahooStockCode = yahooFinance.GetYahooStockCode(exchange, symbol);
			var yahooPriceHistory = yahooFinance.GetDailyHistoricalPriceData(yahooStockCode, new DateTime(2016, 7, 1), new DateTime(2016, 7, 30));

			Assert.Equal(21, yahooPriceHistory.Count);
		}

		[Fact]
		public void TestWeeklyPriceHistoy()
		{
			var exchange = "ASX";
			var symbol = "AFI";

			var yahooFinance = new YahooFinanceClient();
			var yahooStockCode = yahooFinance.GetYahooStockCode(exchange, symbol);
			var yahooPriceHistory = yahooFinance.GetWeeklyHistoricalPriceData(yahooStockCode, new DateTime(2016, 7, 1), new DateTime(2016, 7, 30));

			Assert.Equal(5, yahooPriceHistory.Count);
		}

		[Fact]
		public void TestMonthlyPriceHistoy()
		{
			var exchange = "ASX";
			var symbol = "AFI";

			var yahooFinance = new YahooFinanceClient();
			var yahooStockCode = yahooFinance.GetYahooStockCode(exchange, symbol);
			var yahooPriceHistory = yahooFinance.GetMonthlyHistoricalPriceData(yahooStockCode, new DateTime(2016, 7, 1), new DateTime(2016, 7, 30));

			Assert.Equal(1, yahooPriceHistory.Count);
		}

		[Fact]
		public void TestDividendHistory()
		{
			var exchange = "ASX";
			var symbol = "ANN";

			var yahooFinance = new YahooFinanceClient();
			var yahooStockCode = yahooFinance.GetYahooStockCode(exchange, symbol);
			var yahooDividendHistory = yahooFinance.GetHistoricalDividendData(yahooStockCode, new DateTime(2016, 1, 1), new DateTime(2016, 7, 30));

			Assert.Equal(1, yahooDividendHistory.Count);
		}
	}
}
