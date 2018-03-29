/*
 * Date: 03/28/2018
 * Author: Mohamed Sheikh
 * Description: Enigma machine
 */

using System;
using System.Linq;

namespace Enigma
{
    class Enigma
    {
        static private double key;
        static private double incr; 
        static private double staticKey;
        
        private const int DEBUG = 0;
        private const int BLOCK = 64;
        private const int MIN_BIT = 32;
        private const int MAX_BIT = 4096;
        private const double E = 2.71828;
        private const double PI = 3.1416f;
        static private double BaseNumber = Math.Pow(MAX_BIT, MIN_BIT);
        private const string CHARS = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
               
        static private void SetInitialKey(double _key, double _incr)
        {
            key = (PI * (_key + _incr)) + Math.Log10(MAX_BIT * BLOCK) + Math.Log(MAX_BIT * MIN_BIT);
            staticKey = key;
            incr = _incr;           

            if (DEBUG == 1)
            {
                Console.Beep();
                Console.WriteLine($"\nInitialKey: {key}");
            }
        }

        static private char ShiftRight(char item)
        {
            int newIndex; 
            GenerateNewKey();

            if (DEBUG == 1)
            {
                Console.WriteLine($"RightShift\nKey: {key}\n");
            }
           
            if (!CHARS.Contains(item))
            {
                return item;
            } 
            else
            {
                newIndex = CHARS.IndexOf(item);
            }

            for (int n=0; n<key; n++)
            {
                newIndex = (newIndex < CHARS.Length-1) ? newIndex + 1 : 0;
            }

            return CHARS[newIndex];
        }

        static private char ShiftLeft(char item)
        {
            int newIndex;
            GenerateNewKey();

            if (DEBUG == 1)
            {
                Console.WriteLine($"LeftShift\nKey: {key}\n");
            }
           
            if (!CHARS.Contains(item))
            {
                return item;
            }
            else
            {
                newIndex = CHARS.IndexOf(item);
            }

            for (int n=0; n<key; n++)
            {
                newIndex = (newIndex == 0) ? CHARS.Length-1 : newIndex - 1;
            }

            return CHARS[newIndex];
        }

        static private void GenerateNewKey()
        {
            key = Math.Truncate(BaseNumber % ((Math.Sqrt(staticKey) + E) + (key + incr)));
        }  
        
        static public string Encrypt(string msg, double key, double incr)
        {
            string _msg_ = "";
            bool shift = true;
            SetInitialKey(key, incr);
            char[] _msg = new char[msg.Length];

            for(int n=0; n<msg.Length; n++)
            {
               _msg[n] = (shift == true) ? ShiftRight(msg[n]) : ShiftLeft(msg[n]);
               shift = !shift;
            }

            foreach(var n in _msg)
            {
                _msg_ += n;
            }
            return _msg_;
        }

        static public string Decrypt(string msg, double key, double incr)
        {           
            string _msg_ = "";
            bool shift = false;
            SetInitialKey(key, incr);        
            char[] _msg = new char[msg.Length];

            for (int n = 0; n < msg.Length; n++)
            {
                _msg[n] = (shift == true) ? ShiftRight(msg[n]) : ShiftLeft(msg[n]);
                shift = !shift;
            }

            foreach (var n in _msg)
            {
                _msg_ += n;
            }
            return _msg_;
        }
    }
}