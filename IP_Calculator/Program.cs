namespace IP_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test
            //IP_Address ip = new IP_Address("192.168.20.100");
            //Mask mask = new Mask("255.255.255.240");
            //Mask mask1 = new Mask(27);
            //Network network = new Network(ip, mask1);
            Menu menu = new Menu();
            menu.MainLoop();
        }
    }
}
