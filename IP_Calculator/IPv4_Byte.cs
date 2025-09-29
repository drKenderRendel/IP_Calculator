namespace IP_Calculator
{
    class IPv4_Byte
    {
        bool[] bin_IP;
        byte IP;
        public bool[] Binary_IP { get { return bin_IP; } set { bin_IP = value; } }
        public byte IP_Byte { get { return IP; } }

        public IPv4_Byte(byte IP)
        {
            this.IP = IP;
            bin_IP = DecimalToBinary(IP);
        }
        public IPv4_Byte(bool[] binary)
        {
            bin_IP = binary;
            IP = BinaryToIP(binary);
        }
        public IPv4_Byte(string stringIP)
        {
            bin_IP = StringToBinary(stringIP);
            IP = BinaryToIP(bin_IP);
        }

        public bool[] DecimalToBinary(byte dec)
        {
            bool[] output = new bool[8];

            int n = output.Length - 1;
            int i = 0;
            while (dec > 0)
            {
                if (dec >= Math.Pow(2, n))
                {
                    dec -= (byte)Math.Pow(2, n);
                    output[i] = true;
                }
                n--;
                i++;
            }

            return output;
        }

        public static byte BinaryToIP(bool[] binary_IP)
        {
            byte output = 0;
            int power = binary_IP.Length - 1;
            for (int i = 0; i < binary_IP.Length; i++)
            {
                output += (byte)((binary_IP[i] ? 1 : 0) * (byte)Math.Pow(2, power--));
            }

            return output;
        }

        public bool[] StringToBinary(string binary_IP)
        {
            if (binary_IP.Length == 8)
            {
                bool[] bin = new bool[8];
                for (int i = 0; i < binary_IP.Length; i++)
                {
                    if (binary_IP[i] == '1')
                        bin[i] = true;
                }

                return bin;
            }

            throw new Exception("Invalid input: Not an 8-bit binary input!");
        }
        public override string ToString()
        {
            return IP.ToString();
        }
    }
}
