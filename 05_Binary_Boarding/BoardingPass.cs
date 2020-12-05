using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Binary_Boarding
{
    public class BoardingPass
    {
        public string PositionString { get; init; }

        private int row = -1;
        public int Row
        {
            get
            {
                if (row <= 0)
                {
                    int result = 0;
                    string rowPart = PositionString.Substring(0, 7);
                    for (int pos = 64, i = 0; i < rowPart.Length; pos /= 2, i++)
                    {
                        if (rowPart[i] == 'B')
                        {
                            result += pos;
                        }
                    }
                    row = result;
                }

                return row;
            }
        }

        private int column = -1;
        public int Column
        {
            get
            {
                if (column <= 0)
                {
                    int result = 0;
                    string columnPart = PositionString.Substring(7, 3);
                    for (int pos = 4, i = 0; i < columnPart.Length; pos /= 2, i++)
                    {
                        if (columnPart[i] == 'R')
                        {
                            result += pos;
                        }
                    }
                    column = result;
                }

                return column;
            }
        }

        public int SeatId => Row * 8 + Column;
    }
}
