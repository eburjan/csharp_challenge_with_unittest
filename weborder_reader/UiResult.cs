using System;
using System.Globalization;

namespace weborder_reader
{
    public class UiResult
    {
        public UiResult(int IdIn, string CustomerIn, DateTime DateIn, decimal PriceAverageIn, decimal TotalIn)
        {
            numberFormatInfo = new CultureInfo("en-US", false).NumberFormat;
            numberFormatInfo.NumberDecimalSeparator = ",";
            numberFormatInfo.NumberGroupSeparator = ".";

            this.Customer = CustomerIn;
            this.Date = DateIn.ToString(DATE_FORMAT);
            this.Id = IdIn.ToString();
            this.PriceAverage = string.Format(numberFormatInfo, NUMERIC_FORMAT, PriceAverageIn);
            this.Total = string.Format(numberFormatInfo, NUMERIC_FORMAT, TotalIn);
        }

        public readonly string Id;
        public readonly string Customer;
        public readonly string Date;
        public readonly string PriceAverage;
        public readonly string Total;

        private NumberFormatInfo numberFormatInfo;
        private const string DATE_FORMAT = "dd. MMMMM. yyyy";
        private const string NUMERIC_FORMAT = "{0:#,##0.000}";
    }
}
