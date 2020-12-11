using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Seating_System
{
    public static class Helper
    {
        public static void PrintField<T>(this SeatState[,] field, ILogger<T> logger)
        {
            int width = field.GetLength(0);
            int height = field.GetLength(1);

            var sb = new StringBuilder(width);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    sb.Append(field[x, y] switch
                    {
                        SeatState.Floor => '.',
                        SeatState.Empty => 'L',
                        SeatState.Occupied => '#',
                        _ => throw new NotImplementedException()
                    });
                }
                logger.LogInformation(sb.ToString());
                sb.Clear();
            }
        }
    }
}
