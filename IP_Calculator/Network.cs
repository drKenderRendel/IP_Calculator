namespace IP_Calculator
{
    class Network
    {
        IP_Address netAdd;
        Mask mask;
        IP_Address broadAdd;
        byte maskSimple;
        public Network(IP_Address IP, Mask mask)
        {
            netAdd = DetermineNetworkAddress(IP, mask);
            maskSimple = ConvertMask(mask);
            this.mask = mask;
            broadAdd = DetermineBroadcastAddress(IP, maskSimple);
        }
        public Network(IP_Address IP, byte mask)
        {
            maskSimple = mask;
            this.mask = ConvertMask(mask);
            netAdd = DetermineNetworkAddress(IP, this.mask);
            broadAdd = DetermineBroadcastAddress(IP, mask);
        }

        IP_Address DetermineNetworkAddress(IP_Address ip, IP_Address mask)
        {
            bool[] bin_output = new bool[32];
            for (int i = 0; i < bin_output.Length; i++)
            {
                bin_output[i] = ip.BinaryIP[i] && mask.BinaryIP[i];
            }

            return new IP_Address(bin_output);
        }
        byte ConvertMask(IP_Address mask)
        {
            byte count = 0;
            foreach (bool b in mask.BinaryIP)
            {
                count += (byte)(b ? 1 : 0);
            }

            return count;
        }
        Mask ConvertMask(byte mask)
        {
            bool[] binary = new bool[32];
            int i = 0;
            while (i < binary.Length && mask > 0)
            {
                binary[i++] = mask > 0 ? true : false;
                mask--;
            }

            return new Mask(binary);
        }
        IP_Address DetermineBroadcastAddress(IP_Address ip, byte maskSimple)
        {
            bool[] helper = new bool[32];

            for (int i = 0; i < maskSimple; i++)
            {
                helper[i] = ip.BinaryIP[i];
            }

            for (int i = maskSimple; i < helper.Length; i++)
            {
                helper[i] = true;
            }

            return new IP_Address(helper);
        }
        public string NetworkFullDetails()
        {
            return $"Network:\t\t{ToString()}\n\nNetwork Address:\t{netAdd}\t\t{netAdd.BinaryString()}\nBroadcast Address:\t{broadAdd}\t\t{broadAdd.BinaryString()}\nMask:\t\t\t{mask}\t\t{mask.BinaryString()}";
        }
        public override string ToString()
        {
            return $"{netAdd}/{maskSimple}";
        }
    }
}
