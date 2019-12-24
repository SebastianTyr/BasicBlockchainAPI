using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace BlockchainAPI
{
    public class Block
    {
        public int Index { get; set; }
        public DateTime TimeStamp { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public string Data { get; set; }

        public Block(DateTime timestamp, string previoushash, string data)
        {
            Index = 0;
            TimeStamp = timestamp;
            PreviousHash = previoushash;
            Data = data;
            Hash = CalculateHash();
        }

        public string CalculateHash()
        {
            SHA256 sha256 = SHA256.Create();
            byte[] input = Encoding.ASCII.GetBytes($"{TimeStamp}-{PreviousHash ?? ""}-{Data}");
            byte[] outputBytes = sha256.ComputeHash(input);

            return Convert.ToBase64String(outputBytes);
        }
    }
}