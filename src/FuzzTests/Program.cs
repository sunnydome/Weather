// 文件: FuzzTests.cs
using System;
using SharpFuzz;
using Xunit;
using FluentAssertions;
using Weather.Converters; // 根据实际命名空间调整

namespace FuzzTests
{
    public class FuzzTests
    {
        /// <summary>
        /// 模糊测试 ActiveTabConverter.ReverseString 方法。
        /// </summary>
        /// <param name="data">随机生成的输入字节数组。</param>
        [Theory]
        [Fuzz(10000)] // 运行 10,000 次模糊测试
        public void ReverseString_Should_Handle_Fuzzed_Input(byte[] data)
        {
            // 将字节数组转换为字符串
            string input = ConvertBytesToString(data);

            try
            {
                // 调用要测试的方法
                string result = ActiveTabConverter.ReverseString(input);

                // 断言结果不为空
                result.Should().NotBeNull();

                // 可选：添加更多断言，根据方法预期行为
            }
            catch (ArgumentNullException ex)
            {
                // 预期的异常，忽略
                if (input != null)
                {
                    throw; // 如果输入不为 null，重新抛出异常
                }
            }
            catch (InvalidOperationException ex)
            {
                // 预期的异常，忽略
                // 输入包含数字，符合函数设计
            }
            catch (Exception ex)
            {
                // 未预期的异常，记录并重新抛出
                Console.WriteLine($"Unexpected exception for input '{input}': {ex}");
                throw;
            }
        }

        /// <summary>
        /// 将字节数组转换为字符串，使用 Base64 编码以确保有效的字符串格式。
        /// </summary>
        /// <param name="data">输入字节数组。</param>
        /// <returns>转换后的字符串。</returns>
        private string ConvertBytesToString(byte[] data)
        {
            // 使用 Base64 编码转换为字符串
            return Convert.ToBase64String(data);
        }
    }
    public class ReproductionTests
    {
        [Fact]
        public void Reproduce_Crash_With_Invalid_Base64_Input()
        {
            // Arrange
            string input = "InvalidBase64===";

            // Act
            Action act = () => ActiveTabConverter.ReverseString(input);

            // Assert
            act.Should().Throw<System.FormatException>();
        }
    }
}