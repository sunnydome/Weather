using NUnit.Framework;
using Weather.Converters;
using System;
using System.Globalization;

namespace Weathertest.Converters
{
    [TestFixture]
    public class TabImageConverterTests
    {
        private TabImageConverter _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new TabImageConverter();
        }

        #region Convert 方法测试

        [Test]
        public void Convert_TabIsHome_TargetIsHome_ReturnsTabHomeOn()
        {
            // Arrange
            string value = "Home";
            string parameter = "Home";
            var culture = CultureInfo.InvariantCulture;

            // Act
            var result = _converter.Convert(value, typeof(string), parameter, culture);

            // Assert
            Assert.AreEqual("tab_home_on.png", result);
        }

        [Test]
        public void Convert_TabIsHome_TargetIsNotHome_ReturnsTabHome()
        {
            // Arrange
            string value = "Settings";
            string parameter = "Home";
            var culture = CultureInfo.InvariantCulture;

            // Act
            var result = _converter.Convert(value, typeof(string), parameter, culture);

            // Assert
            Assert.AreEqual("tab_home.png", result);
        }

        [Test]
        public void Convert_TabIsFavorites_TargetIsFavorites_ReturnsTabFavoritesOn()
        {
            // Arrange
            string value = "Favorites";
            string parameter = "Favorites";
            var culture = CultureInfo.InvariantCulture;

            // Act
            var result = _converter.Convert(value, typeof(string), parameter, culture);

            // Assert
            Assert.AreEqual("tab_favorites_on.png", result);
        }

        [Test]
        public void Convert_TabIsFavorites_TargetIsNotFavorites_ReturnsTabFavorites()
        {
            // Arrange
            string value = "Profile";
            string parameter = "Favorites";
            var culture = CultureInfo.InvariantCulture;

            // Act
            var result = _converter.Convert(value, typeof(string), parameter, culture);

            // Assert
            Assert.AreEqual("tab_favorites.png", result);
        }

        [Test]
        public void Convert_TabIsUnknown_ReturnsDefaultTabHome()
        {
            // Arrange
            string value = "Home";
            string parameter = "Settings"; // 未知的 tab
            var culture = CultureInfo.InvariantCulture;

            // Act
            var result = _converter.Convert(value, typeof(string), parameter, culture);

            // Assert
            Assert.AreEqual("tab_home.png", result);
        }

        [Test]
        public void Convert_EmptyTab_ReturnsDefaultTabHome()
        {
            // Arrange
            string value = "Home";
            string parameter = ""; // 空的 tab
            var culture = CultureInfo.InvariantCulture;

            // Act
            var result = _converter.Convert(value, typeof(string), parameter, culture);

            // Assert
            Assert.AreEqual("tab_home.png", result);
        }

        [Test]
        public void Convert_NullValue_ThrowsInvalidCastException()
        {
            // Arrange
            string value = null;
            string parameter = "Home";
            var culture = CultureInfo.InvariantCulture;

            // Act & Assert
            Assert.Throws<InvalidCastException>(() => _converter.Convert(value, typeof(string), parameter, culture));
        }

        [Test]
        public void Convert_NullParameter_ThrowsInvalidCastException()
        {
            // Arrange
            string value = "Home";
            object parameter = null; // 参数为 null
            var culture = CultureInfo.InvariantCulture;

            // Act & Assert
            Assert.Throws<InvalidCastException>(() => _converter.Convert(value, typeof(string), parameter, culture));
        }

        [Test]
        public void Convert_ValueIsNotString_ThrowsInvalidCastException()
        {
            // Arrange
            object value = 123; // 非字符串类型
            string parameter = "Home";
            var culture = CultureInfo.InvariantCulture;

            // Act & Assert
            Assert.Throws<InvalidCastException>(() => _converter.Convert(value, typeof(string), parameter, culture));
        }

        [Test]
        public void Convert_ParameterIsNotString_ThrowsInvalidCastException()
        {
            // Arrange
            string value = "Home";
            object parameter = 456; // 非字符串类型
            var culture = CultureInfo.InvariantCulture;

            // Act & Assert
            Assert.Throws<InvalidCastException>(() => _converter.Convert(value, typeof(string), parameter, culture));
        }

        #endregion

        #region ConvertBack 方法测试

        [Test]
        public void ConvertBack_ValidString_ReturnsSameString()
        {
            // Arrange
            string value = "tab_home_on.png";
            var culture = CultureInfo.InvariantCulture;

            // Act
            var result = _converter.ConvertBack(value, typeof(string), null, culture);

            // Assert
            Assert.AreEqual("tab_home_on.png", result);
        }

        [Test]
        public void ConvertBack_Null_ReturnsNull()
        {
            // Arrange
            string value = null;
            var culture = CultureInfo.InvariantCulture;

            // Act
            var result = _converter.ConvertBack(value, typeof(string), null, culture);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void ConvertBack_NonStringInput_ReturnsStringRepresentation()
        {
            // Arrange
            object value = 789;
            var culture = CultureInfo.InvariantCulture;

            // Act
            var result = _converter.ConvertBack(value, typeof(string), null, culture);

            // Assert
            Assert.AreEqual("789", result);
        }

        #endregion
    }
}