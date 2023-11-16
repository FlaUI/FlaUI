using System.Threading.Tasks;
using System;

namespace FlaUI.WebDriver
{
    public static class Wait
    {
        public static async Task<bool> Until(Func<bool> until, TimeSpan timeout)
        {
            return await Until(until, result => result, timeout);
        }

        public static async Task<T> Until<T>(Func<T> selector, Func<T, bool> until, TimeSpan timeout)
        {
            var timeSpent = TimeSpan.Zero;
            T result;
            while (!until(result = selector()))
            {
                if (timeSpent > timeout)
                {
                    return result;
                }

                var delay = TimeSpan.FromMilliseconds(100);
                await Task.Delay(delay);
                timeSpent += delay;
            }

            return result;
        }
    }
}
