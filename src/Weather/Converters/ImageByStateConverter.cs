using System.Globalization;

namespace Weather.Converters
{
    public class ImageByStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var target = (FlyoutItem)value;
            var allParams = ((string)parameter).Split((';')); // 0=normal, 1=selected

            if (target.IsChecked && allParams.Length > 1)
                return allParams[1];
            else
                return allParams[0];
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)value;
        }
    }
    public class DataProcessor
    {
        /// <summary>
        /// Processes an array of integers by doubling each element and calculating the sum.
        /// </summary>
        /// <param name="data">The array of integers to process.</param>
        /// <returns>The total sum of processed integers.</returns>
        public int ProcessData(int[] data)
        {
            // 修复缺陷 1：添加 null 检查，防止 NullReferenceException
            if (data == null)
                throw new ArgumentNullException(nameof(data), "输入数据不能为空。");

            int sum = 0;

            // 修复缺陷 2：修改循环条件，避免 IndexOutOfRangeException
            for (int i = 0; i < data.Length; i++)
            {
                sum += data[i] * 2;
            }

            // 修复缺陷 3：修正返回值，确保返回正确的总和
            return sum;
        }
    }
}