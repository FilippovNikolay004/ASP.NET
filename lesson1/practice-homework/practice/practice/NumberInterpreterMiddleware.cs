using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace RequestProcessingPipeline {
    public class NumberInterpreterMiddleware {
        private readonly RequestDelegate _next;

        public NumberInterpreterMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task Invoke(HttpContext context) {
            if (int.TryParse(context.Request.Query["number"], out var number)) {
                if (number < 1 || number > 100000) {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid number range. Must be between 1 and 100000.");
                    return;
                }

                var result = NumberToWords(number);
                await context.Response.WriteAsync(result);
            } else {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Please provide a 'number' query parameter.");
            }
        }

        private string NumberToWords(int number) {
            if (number < 0 || number > 100000)
                return "Number out of valid range";

            if (number == 100000)
                return "one hundred thousand";

            string[] units = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] teens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tens = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] hundreds = { "", "one hundred", "two hundred", "three hundred", "four hundred", "five hundred", "six hundred", "seven hundred", "eight hundred", "nine hundred" };

            string result = "";

            if (number >= 1000) {
                int thousands = number / 1000;
                if (thousands < 10)
                    result += units[thousands] + " thousand ";
                else if (thousands < 20)
                    result += teens[thousands - 10] + " thousand ";
                else {
                    result += tens[thousands / 10] + " " + units[thousands % 10] + " thousand ";
                }
                number %= 1000;
            }

            if (number >= 100) {
                result += hundreds[number / 100] + " ";
                number %= 100;
            }

            if (number >= 10 && number < 20) {
                result += teens[number - 10];
            } else if (number >= 20) {
                result += tens[number / 10] + " ";
                if (number % 10 > 0)
                    result += units[number % 10];
            } else if (number > 0) {
                result += units[number];
            }

            return result.Trim();
        }
    }
}