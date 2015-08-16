using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Tools
{
    public class LRC
    {
        /// <summary>
        /// Longitudinal Redundancy Check (LRC) calculator for a byte array. 
        /// This was proved from the LRC Logic of Edwards TurboPump Controller SCU-1600.
        /// ex) DATA (hex 6 bytes): 02 30 30 31 23 03
        ///     LRC  (hex 1 byte ): 47        
        /// </summary>
        public static byte CalculateLRC(byte[] bytes)
        {
            byte LRC = 0x00;
            for (int i = 0; i < bytes.Length; i++)
            {
                LRC = (byte)((LRC + bytes[i]) & 0xFF);
            }
            return (byte)(((LRC ^ 0xFF) + 1) & 0xFF);
        }
    }
}
