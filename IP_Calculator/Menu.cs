namespace IP_Calculator
{
    class Menu
    {
        public void MainLoop()
        {
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(5, 0);
                Console.Write("IP/Mask:");
                Console.SetCursorPosition(100, 0);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("E.g. 192.168.1.1/24");
                Console.ResetColor();
                Console.SetCursorPosition(15, 0);

                string input = Console.ReadLine();
                if (input != null && input != "" && input.Contains('/'))
                {
                    byte mask = byte.Parse(input.Split('/')[1]);
                    string ip = input.Split('/')[0];
                    IP_Address address = new IP_Address(ip);
                    Network network = new Network(address, mask);

                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine(network.NetworkFullDetails());
                }
                else if (input == "" || input == null)
                    Environment.Exit(0);
                else
                    throw new FormatException("Invalid format!");

                ConsoleKey key = ConsoleKey.Escape;
                while (key != ConsoleKey.Y)
                {
                    Console.SetCursorPosition(0, 10);
                    Console.Write($"\n\n\tWould you like to continue? (y/n)\t");
                    ValueTuple<int, int> pos = Console.GetCursorPosition();
                    key = Console.ReadKey().Key;
                    if (key == ConsoleKey.N)
                        Environment.Exit(0);
                    else if (key != ConsoleKey.Y)
                    {
                        Console.SetCursorPosition(pos.Item1, pos.Item2);
                        Console.Write(" ");
                        Console.SetCursorPosition(pos.Item1, pos.Item2);
                    }
                }
            }
        }
    }
}
