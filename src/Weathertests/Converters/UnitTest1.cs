using System;
using System.Globalization;
using System.Reflection;
using Weather.Converters;
using Weather.Models;
using Xunit;
using FluentAssertions;
using Xunit.Abstractions;

namespace Weatherests.Converters
{
    public class ImageByStateConverterTests : IDisposable
    {
        private readonly ImageByStateConverter _converter;
        private readonly ITestOutputHelper _output;

        // 构造函数注入 ITestOutputHelper
        public ImageByStateConverterTests(ITestOutputHelper output)
        {
            _converter = new ImageByStateConverter();
            _output = output;
        }

        /// <summary>
        /// 使用反射设置 FlyoutItem 的只读 IsChecked 属性。
        /// </summary>
        /// <param name="flyoutItem">FlyoutItem 实例。</param>
        /// <param name="isChecked">要设置的 IsChecked 值。</param>
        private void SetIsChecked(FlyoutItem flyoutItem, bool isChecked)
        {
            // 获取 IsChecked 属性的 PropertyInfo
            var property = typeof(FlyoutItem).GetProperty("IsChecked", BindingFlags.Public | BindingFlags.Instance);
            if (property == null)
            {
                throw new InvalidOperationException("FlyoutItem 类中不存在 IsChecked 属性。");
            }

            // 检查属性是否有 setter
            if (property.CanWrite)
            {
                property.SetValue(flyoutItem, isChecked);
                _output.WriteLine($"Set IsChecked to {isChecked} via setter.");
                return;
            }

            // 如果没有 setter，尝试设置 backing field（假设为 <IsChecked>k__BackingField）
            var field = typeof(FlyoutItem).GetField("<IsChecked>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance);
            if (field != null)
            {
                field.SetValue(flyoutItem, isChecked);
                _output.WriteLine($"Set IsChecked to {isChecked} via backing field.");
            }
            else
            {
                throw new InvalidOperationException("无法通过反射设置 FlyoutItem 的 IsChecked 属性。");
            }
        }

        [Fact]
        public void Convert_IsCheckedTrue_WithTwoParams_ReturnsSelectedImage()
        {
            // Arrange
            var flyoutItem = new FlyoutItem();
            SetIsChecked(flyoutItem, true);
            string parameter = "normal.png;selected.png";
            var culture = CultureInfo.InvariantCulture;

            _output.WriteLine($"Testing Convert with IsChecked=true and parameter='{parameter}'.");

            // Act
            var result = _converter.Convert(flyoutItem, typeof(string), parameter, culture);

            // Assert
            result.Should().Be("selected.png");
            _output.WriteLine($"Expected: 'selected.png', Actual: '{result}'");
        }

        [Fact]
        public void Convert_IsCheckedFalse_WithTwoParams_ReturnsNormalImage()
        {
            // Arrange
            var flyoutItem = new FlyoutItem();
            SetIsChecked(flyoutItem, false);
            string parameter = "normal.png;selected.png";
            var culture = CultureInfo.InvariantCulture;

            _output.WriteLine($"Testing Convert with IsChecked=false and parameter='{parameter}'.");

            // Act
            var result = _converter.Convert(flyoutItem, typeof(string), parameter, culture);

            // Assert
            result.Should().Be("normal.png");
            _output.WriteLine($"Expected: 'normal.png', Actual: '{result}'");
        }

        [Fact]
        public void Convert_IsCheckedTrue_WithSingleParam_ReturnsNormalImage()
        {
            // Arrange
            var flyoutItem = new FlyoutItem();
            SetIsChecked(flyoutItem, true);
            string parameter = "normal.png";
            var culture = CultureInfo.InvariantCulture;

            _output.WriteLine($"Testing Convert with IsChecked=true and single parameter='{parameter}'.");

            // Act
            var result = _converter.Convert(flyoutItem, typeof(string), parameter, culture);

            // Assert
            result.Should().Be("normal.png");
            _output.WriteLine($"Expected: 'normal.png', Actual: '{result}'");
        }

        [Fact]
        public void Convert_IsCheckedFalse_WithSingleParam_ReturnsNormalImage()
        {
            // Arrange
            var flyoutItem = new FlyoutItem();
            SetIsChecked(flyoutItem, false);
            string parameter = "normal.png";
            var culture = CultureInfo.InvariantCulture;

            _output.WriteLine($"Testing Convert with IsChecked=false and single parameter='{parameter}'.");

            // Act
            var result = _converter.Convert(flyoutItem, typeof(string), parameter, culture);

            // Assert
            result.Should().Be("normal.png");
            _output.WriteLine($"Expected: 'normal.png', Actual: '{result}'");
        }

        [Fact]
        public void Convert_ValueIsNull_ThrowsInvalidCastException()
        {
            // Arrange
            FlyoutItem flyoutItem = null;
            string parameter = "normal.png;selected.png";
            var culture = CultureInfo.InvariantCulture;

            _output.WriteLine($"Testing Convert with value=null and parameter='{parameter}'.");

            // Act
            Action act = () => _converter.Convert(flyoutItem, typeof(string), parameter, culture);

            // Assert
            act.Should().Throw<InvalidCastException>()
               .WithMessage("*cannot be cast*"); // 根据实际异常消息调整
            _output.WriteLine($"Expected exception: InvalidCastException");
        }

        [Fact]
        public void Convert_ParameterIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var flyoutItem = new FlyoutItem();
            SetIsChecked(flyoutItem, true);
            string parameter = null;
            var culture = CultureInfo.InvariantCulture;

            _output.WriteLine($"Testing Convert with IsChecked=true and parameter=null.");

            // Act
            Action act = () => _converter.Convert(flyoutItem, typeof(string), parameter, culture);

            // Assert
            act.Should().Throw<ArgumentNullException>()
               .WithMessage("*parameter*"); // 根据实际异常消息调整
            _output.WriteLine($"Expected exception: ArgumentNullException");
        }

        [Fact]
        public void Convert_ValueNotFlyoutItem_ThrowsInvalidCastException()
        {
            // Arrange
            object flyoutItem = "NotFlyoutItem";
            string parameter = "normal.png;selected.png";
            var culture = CultureInfo.InvariantCulture;

            _output.WriteLine($"Testing Convert with value of type string and parameter='{parameter}'.");

            // Act
            Action act = () => _converter.Convert(flyoutItem, typeof(string), parameter, culture);

            // Assert
            act.Should().Throw<InvalidCastException>()
               .WithMessage("*FlyoutItem*"); // 根据实际异常消息调整
            _output.WriteLine($"Expected exception: InvalidCastException");
        }

        [Fact]
        public void Convert_ParameterWithoutSemicolon_ReturnsNormalImage()
        {
            // Arrange
            var flyoutItem = new FlyoutItem();
            SetIsChecked(flyoutItem, true);
            string parameter = "normal.png";
            var culture = CultureInfo.InvariantCulture;

            _output.WriteLine($"Testing Convert with IsChecked=true and parameter without semicolon='{parameter}'.");

            // Act
            var result = _converter.Convert(flyoutItem, typeof(string), parameter, culture);

            // Assert
            result.Should().Be("normal.png");
            _output.WriteLine($"Expected: 'normal.png', Actual: '{result}'");
        }

        [Fact]
        public void Convert_ParameterWithMultipleSemicolons_ReturnsSecondParam()
        {
            // Arrange
            var flyoutItem = new FlyoutItem();
            SetIsChecked(flyoutItem, true);
            string parameter = "normal.png;selected.png;extra.png";
            var culture = CultureInfo.InvariantCulture;

            _output.WriteLine($"Testing Convert with IsChecked=true and parameter with multiple semicolons='{parameter}'.");

            // Act
            var result = _converter.Convert(flyoutItem, typeof(string), parameter, culture);

            // Assert
            result.Should().Be("selected.png");
            _output.WriteLine($"Expected: 'selected.png', Actual: '{result}'");
        }

        [Fact]
        public void Convert_IsCheckedTrue_WithTrailingSemicolon_ReturnsEmptyString()
        {
            // Arrange
            var flyoutItem = new FlyoutItem();
            SetIsChecked(flyoutItem, true);
            string parameter = "normal.png;";
            var culture = CultureInfo.InvariantCulture;

            _output.WriteLine($"Testing Convert with IsChecked=true and parameter with trailing semicolon='{parameter}'.");

            // Act
            var result = _converter.Convert(flyoutItem, typeof(string), parameter, culture);

            // Assert
            result.Should().Be("");
            _output.WriteLine($"Expected: '', Actual: '{result}'");
        }

        #region ConvertBack 方法测试

        [Fact]
        public void ConvertBack_ValidString_ReturnsSameString()
        {
            // Arrange
            string value = "selected.png";
            var culture = CultureInfo.InvariantCulture;

            _output.WriteLine($"Testing ConvertBack with value='{value}'.");

            // Act
            var result = _converter.ConvertBack(value, typeof(string), null, culture);

            // Assert
            result.Should().Be("selected.png");
            _output.WriteLine($"Expected: 'selected.png', Actual: '{result}'");
        }

        [Fact]
        public void ConvertBack_Null_ReturnsNull()
        {
            // Arrange
            string value = null;
            var culture = CultureInfo.InvariantCulture;

            _output.WriteLine($"Testing ConvertBack with value=null.");

            // Act
            var result = _converter.ConvertBack(value, typeof(string), null, culture);

            // Assert
            result.Should().BeNull();
            _output.WriteLine($"Expected: null, Actual: '{result}'");
        }

        [Fact]
        public void ConvertBack_NonStringInput_ReturnsStringRepresentation()
        {
            // Arrange
            object value = 456.78;
            var culture = CultureInfo.InvariantCulture;

            _output.WriteLine($"Testing ConvertBack with non-string value='{value}' of type '{value.GetType()}'.");

            // Act
            var result = _converter.ConvertBack(value, typeof(string), null, culture);

            // Assert
            result.Should().Be("456.78");
            _output.WriteLine($"Expected: '456.78', Actual: '{result}'");
        }

        [Fact]
        public void ConvertBack_EmptyString_ReturnsEmptyString()
        {
            // Arrange
            string value = "";
            var culture = CultureInfo.InvariantCulture;

            _output.WriteLine($"Testing ConvertBack with empty string.");

            // Act
            var result = _converter.ConvertBack(value, typeof(string), null, culture);

            // Assert
            result.Should().Be("");
            _output.WriteLine($"Expected: '', Actual: '{result}'");
        }

        [Fact]
        public void ConvertBack_SpecialCharacters_ReturnsSameString()
        {
            // Arrange
            string value = "sel@ected.png";
            var culture = CultureInfo.InvariantCulture;

            _output.WriteLine($"Testing ConvertBack with special characters value='{value}'.");

            // Act
            var result = _converter.ConvertBack(value, typeof(string), null, culture);

            // Assert
            result.Should().Be("sel@ected.png");
            _output.WriteLine($"Expected: 'sel@ected.png', Actual: '{result}'");
        }

        [Fact]
        public void ConvertBack_MultilingualCharacters_ReturnsSameString()
        {
            // Arrange
            string value = "sélectéd.png";
            var culture = CultureInfo.InvariantCulture;

            _output.WriteLine($"Testing ConvertBack with multilingual characters value='{value}'.");

            // Act
            var result = _converter.ConvertBack(value, typeof(string), null, culture);

            // Assert
            result.Should().Be("sélectéd.png");
            _output.WriteLine($"Expected: 'sélectéd.png', Actual: '{result}'");
        }

        [Fact]
        public void ConvertBack_LongString_ReturnsSameLongString()
        {
            // Arrange
            string value = new string('a', 1000);
            var culture = CultureInfo.InvariantCulture;

            _output.WriteLine($"Testing ConvertBack with long string of length {value.Length}.");

            // Act
            var result = _converter.ConvertBack(value, typeof(string), null, culture);

            // Assert
            result.Should().Be(new string('a', 1000));
            _output.WriteLine($"Expected: '{new string('a', 1000)}', Actual: '{result}'");
        }

        [Fact]
        public void ConvertBack_StringWithSemicolon_ReturnsSameString()
        {
            // Arrange
            string value = "normal.png;selected.png";
            var culture = CultureInfo.InvariantCulture;

            _output.WriteLine($"Testing ConvertBack with string containing semicolons value='{value}'.");

            // Act
            var result = _converter.ConvertBack(value, typeof(string), null, culture);

            // Assert
            result.Should().Be("normal.png;selected.png");
            _output.WriteLine($"Expected: 'normal.png;selected.png', Actual: '{result}'");
        }

        [Fact]
        public void ConvertBack_NumericInputAsString_ReturnsSameString()
        {
            // Arrange
            object value = 789;
            var culture = CultureInfo.InvariantCulture;

            _output.WriteLine($"Testing ConvertBack with numeric input value='{value}' of type '{value.GetType()}'.");

            // Act
            var result = _converter.ConvertBack(value, typeof(string), null, culture);

            // Assert
            result.Should().Be("789");
            _output.WriteLine($"Expected: '789', Actual: '{result}'");
        }

        [Fact]
        public void ConvertBack_BooleanInputAsString_ReturnsSameString()
        {
            // Arrange
            object value = true;
            var culture = CultureInfo.InvariantCulture;

            _output.WriteLine($"Testing ConvertBack with boolean input value='{value}' of type '{value.GetType()}'.");

            // Act
            var result = _converter.ConvertBack(value, typeof(string), null, culture);

            // Assert
            result.Should().Be("True");
            _output.WriteLine($"Expected: 'True', Actual: '{result}'");
        }

        #endregion

        // 如果需要清理资源，可以实现 IDisposable
        public void Dispose()
        {
            // 清理代码（如果需要）
        }
    }
}