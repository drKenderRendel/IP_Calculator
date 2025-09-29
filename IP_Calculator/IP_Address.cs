using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IP_Calculator
{
    class IP_Address
    {
        protected IPv4_Byte[] address;
        protected bool[] binary_IP;
        public IPv4_Byte[] Address { get { return address; } }
        public bool[] BinaryIP { get { return binary_IP; } }
        public IP_Address(string input)
        {
            // input example == 192.168.0.100
            if (input.Split('.').Length != 4)
                throw new FormatException("Invalid format! Expected format: 192.168.1.100");
            address = new IPv4_Byte[4];
            int i = 0;
            foreach (string elem in input.Split("."))
            {
                address[i++] = new IPv4_Byte(byte.Parse(elem));
            }

            binary_IP = new bool[32];
            for (i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    binary_IP[(i * 8) + j] = address[i].Binary_IP[j];
                }
            }
        }
        public IP_Address(bool[] binary_Add)
        {
            binary_IP = new bool[32];
            bool[] binOne = new bool[8];
            bool[] binTwo = new bool[8];
            bool[] binThree = new bool[8];
            bool[] binFour = new bool[8];

            for (int i = 0; i < binOne.Length; i++)
            {
                binOne[i] = binary_Add[i];
                binary_IP[i] = binOne[i];
            }
            for (int i = 0; i < binTwo.Length; i++)
            {
                binTwo[i] = binary_Add[8 + i];
                binary_IP[8 + i] = binTwo[i];
            }
            for (int i = 0; i < binThree.Length; i++)
            {
                binThree[i] = binary_Add[16 + i];
                binary_IP[16 + i] = binThree[i];
            }
            for (int i = 0; i < binFour.Length; i++)
            {
                binFour[i] = binary_Add[24 + i];
                binary_IP[24 + i] = binFour[i];
            }

            address = new IPv4_Byte[4];
            address[0] = new IPv4_Byte(IPv4_Byte.BinaryToIP(binOne)) { Binary_IP = binOne};
            address[1] = new IPv4_Byte(IPv4_Byte.BinaryToIP(binTwo)) { Binary_IP = binTwo};
            address[2] = new IPv4_Byte(IPv4_Byte.BinaryToIP(binThree)) { Binary_IP = binThree };
            address[3] = new IPv4_Byte(IPv4_Byte.BinaryToIP(binFour)) { Binary_IP = binFour };
        }
        public IP_Address()
        {
            binary_IP = new bool[32];
        }
        public string BinaryString()
        {
            string output = "";
            for (int i = 0; i < 32; i++)
            {
                output += binary_IP[i] ? "1" : "0";
                if (i == 7 || i == 15 || i == 23)
                    output += ".";
            }

            return output;
        }
        public override string ToString()
        {
            return $"{address[0]}.{address[1]}.{address[2]}.{address[3]}";
        }
    }
    class Mask : IP_Address
    {
        byte maskLength;
        public Mask(string input) : base(input)
        {
            CheckMask(binary_IP);
        }
        public Mask(byte maskLength)
        {
            for (int i = 0; i < maskLength; i++)
            {
                binary_IP[i] = true;
            }

            address = new IPv4_Byte[4];
            for (int i = 0; i < address.Length; i++)
            {
                bool[] temp = new bool[8];
                for (int j = 0; j < temp.Length; j++)
                {
                    temp[j] = binary_IP[(8 * i) + j];
                }
                address[i] = new IPv4_Byte(temp);
            }
        }

        public Mask(bool[] binary_Add) : base(binary_Add)
        {
            CheckMask(binary_Add);
        }

        void CheckMask(bool[] binary)
        {
            int lastIdx = -1;
            int i = 0;
            do
            {
                if (binary[i])
                    lastIdx = i;
                i++;
            } while ((i - lastIdx) == 1 && i < binary.Length);

            while (i < binary.Length)
            {
                if (binary[i++])
                    throw new FormatException("Incorrect mask!");
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
