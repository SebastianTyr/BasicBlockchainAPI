using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace BlockchainAPI
{
    public class Blockchain
    {
        public IList<Block> Chain { get; set; }

        public Blockchain()
        {
            InitializeChain();
            CreateGenesisBlock();
        }

        public void InitializeChain()
        {
            Chain = new List<Block>();
        }

        public Block CreateGenesisBlock()
        {
            return new Block(DateTime.Now, null, "{}");
        }

        public Block GetLatestBlock()
        {
            return Chain[Chain.Count - 1];
        }

        public void AddBlock(Block block)
        {
            Block latestBlock = GetLatestBlock();
            block.Index = latestBlock.Index + 1;
            block.PreviousHash = latestBlock.Hash;
            block.Hash = block.CalculateHash();
            Chain.Add(block);
        }
    }
}
