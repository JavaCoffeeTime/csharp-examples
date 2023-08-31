/* C# program to determine class, Network
 and Host ID of an IPv4 address*/
using System;
 
class NetworkId
{
    static string FindClass(string str)
    {
        // Calculating first occurrence of '.' in str
        int index = str.IndexOf('.');
        // First octate in str in decimal form
        string ipsub = str.Substring(0, index);
        int ip = int.Parse(ipsub);
        // Class A
        if (ip >= 1 && ip <= 126)
            return "A";
        // Class B
        else if (ip >= 128 && ip <= 191)
            return "B";
        // Class C
        else if (ip >= 192 && ip < 223)
            return "C";
        // Class D
        else if (ip >= 224 && ip <= 239)
            return "D";
        // Class E
        else
            return "E";
    }
 
    static void Separate(string str, string ipClass)
    {
        // Initializing network and host empty
        string network = "", host = "";
 
        if (ipClass == "A")
        {
            int index = str.IndexOf('.');
            network = str.Substring(0, index);
            host = str.Substring(index + 1, str.Length - index - 1);
        }
        else if (ipClass == "B")
        {
            //Position of breaking network and HOST id
            int index = -1;
            int dot = 2;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '.')
                {
                    dot--;
                    if (dot == 0)
                    {
                        index = i;
                        break;
                    }
                }
            }
            network = str.Substring(0, index);
            host = str.Substring(index + 1, str.Length - index - 1);
        }
        else if (ipClass == "C")
        {
            //Position of breaking network and HOST id
            int index = -1;
            int dot = 3;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '.')
                {
                    dot--;
                    if (dot == 0)
                    {
                        index = i;
                        break;
                    }
                }
            }
            network = str.Substring(0, index);
            host = str.Substring(index + 1, str.Length - index - 1);
        }
        else if (ipClass == "D" || ipClass == "E")
        {
            Console.WriteLine("In this Class, IP address is not divided into Network and Host IDs");
            return;
        }
        Console.WriteLine("Network ID is " + network);
        Console.WriteLine("Host ID is " + host);
    }
 
    static void Main(string[] args)
    {
        string str = "192.226.12.11";
        string ipClass = FindClass(str);
        Console.WriteLine("Given IP address belongs to Class " + ipClass);
        Separate(str, ipClass);
    }
}
