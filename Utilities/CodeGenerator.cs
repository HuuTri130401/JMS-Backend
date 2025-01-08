using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class CodeGenerator
    {
        private static readonly Random random = new Random();

        /// <summary>
        /// Tạo code : Tiền tố + Độ dài
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateCode(string prefix, int length)
        {
            string randomNumber = random.Next((int) Math.Pow(10, length - 1), (int)Math.Pow(10, length)).ToString();
            return $"{prefix}-{randomNumber}";
        }

        public static string GenerateCodeJewelry(string prefix, int count)
        {
            count += 1;
            return $"{prefix}-{count}";
        }
    }
}
