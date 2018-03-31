/*
 * Date: 03/28/2018
 * Author: Mohamed Sheikh
 * Description: Enigma machine
 */

using System;

namespace Enigma
{
    class Program
    {
        static void Main(string[] args)
        {                        
            while (true)
            {
                try
                {
                    Console.Write("[-] Enter your message: ");
                    string msg = Console.ReadLine();

                    Console.Write("[-] Enter a secure key: ");
                    double key = GetKey(Console.ReadLine());                   

                    Console.Write("[-] Enter a secure pin: ");
                    double incr = GetKey(Console.ReadLine());

                    Console.Write("\n\n(E)ncrypt\n(D)ecrypt\n[-] Enter an option: ");
                    string option = Console.ReadLine();

                    string output = (option.ToUpper().StartsWith("E")) ? Enigma.Encrypt(msg, key, incr) :
                        (option.ToUpper().StartsWith("D")) ? Enigma.Decrypt(msg, key, incr) : " ";

                    Console.WriteLine($"\n[+] Output: {output}");
                    Console.WriteLine("\nPress Enter to Continue");
                    Console.ReadLine();
                    Console.WriteLine("+-----------------------+");
                } 
                catch { continue; }
            }
        }  

        static private double GetKey(string input)
        {
            int key = 0;
            
            foreach(var item in input)
                key += GetIndex(item);

            return Convert.ToDouble(key);
        } 
       
        static private int GetIndex(char item)
        {
            return Enigma.CHARS.IndexOf(item);             
        }                
    }
}