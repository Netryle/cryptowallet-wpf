using CryptoWalletWPF.Utility;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoWalletWPF.Models
{
    internal class TransactionsModel
    {
        private SharedDataModel _sharedDataModel;
        private string _accountAddress;
        private Web3 _web3;

        private List<Transaction> _transactions;
        private int _blockRange;

        public List<Transaction> Transactions 
        { get => _transactions; private set => _transactions = value; }
        public int BlockRange { get; set; }

        public TransactionsModel(SharedDataModel sharedDataModel)
        {
            _sharedDataModel = sharedDataModel;
            _web3 = _sharedDataModel.Web3;
            _accountAddress = _sharedDataModel.Account.Address;
        }

        public async Task GetTransactionHistory()
        {
            _transactions = new List<Transaction>();

            var blockNumber = (await _web3.Eth.Blocks.GetBlockNumber.SendRequestAsync()).Value;
            if (BlockRange > blockNumber)
            {
                BlockRange = int.Parse(blockNumber.ToString());
            }

            for (var i = blockNumber; i >= blockNumber - BlockRange; i--)
            {
                var block = await _web3.Eth.Blocks.GetBlockWithTransactionsHashesByNumber.SendRequestAsync(new HexBigInteger(i));

                foreach (var txHash in block.TransactionHashes)
                {
                    var receipt = await _web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(txHash);
                    var transaction = await _web3.Eth.Transactions.GetTransactionByHash.SendRequestAsync(txHash);

                    if (transaction.From.ToLower() == _accountAddress.ToLower() || 
                        (transaction.To != null && transaction.To.ToLower() == _accountAddress.ToLower()))
                    {
                        _transactions.Add
                            (
                             new Transaction
                             (
                                 transaction.From,
                                 transaction.To,
                                 Web3.Convert.FromWei(transaction.Value).ToString(),
                                 transaction.Gas.Value.ToString(),
                                 transaction.BlockHash,
                                 transaction.TransactionHash,
                                 transaction.Input,
                                 receipt.Status.Value == 1 ? "Completed" : "Incompleted"
                             )
                            );
                    }
                }
            }
        }
    }
}
