using CryptoWalletWPF.Utility;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Util;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Nethereum.Hex.HexConvertors;
using System.Windows.Input;

namespace CryptoWalletWPF.Models
{
    internal class SendTransactionModel
    {
        public static async Task<bool> SendTransactionAsync(TransactionInfo transactionInfo, SharedDataModel sharedDataModel)
        {
            var web3 = sharedDataModel.Web3;
            var gasPrice = Web3.Convert.ToWei(transactionInfo.GasPrice, UnitConversion.EthUnit.Gwei).ToHexBigInteger();
            var gasLimit = BigInteger.Parse(transactionInfo.GasLimit).ToHexBigInteger();

            var amount = transactionInfo.Amount.Replace('.', ',');
            var value = Web3.Convert.ToWei(amount, UnitConversion.EthUnit.Ether).ToHexBigInteger();

            var transactionInput = new TransactionInput
            {
                From = sharedDataModel.Account.Address,
                GasPrice = gasPrice,               
                To = transactionInfo.ToAddress,
                Value = value,
                Nonce = null,
                Gas = gasLimit
            };

            var transactionHash = await web3.Eth.TransactionManager
                .SendTransactionAsync(transactionInput);
            var receipt = await web3.Eth.Transactions.GetTransactionReceipt
                .SendRequestAsync(transactionHash);

            if (receipt != null && receipt.Status.Value == 1)
            {
                return true;
            }

            return false;
        }

        public static bool IsBalanceEnoughForSending(string balance, string amountToSend)
        {
            if ( decimal.Parse(balance) >= (decimal.Parse(amountToSend.Replace('.', ','))) )
            {
                return true;
            }

            return false;
        }

        public static async Task<string> GetRecommendedGasLimitAsync(SharedDataModel sharedDataModel)
        {
            var web3 = sharedDataModel.Web3;
            var blockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
            var block = await web3.Eth.Blocks.GetBlockWithTransactionsHashesByNumber.SendRequestAsync(blockNumber);
            var gasLimit = block.GasLimit;

            return gasLimit.Value.ToString();
        }

        public static async Task<string> GetRecommendedGasPriceAsync(SharedDataModel sharedDataModel)
        {
            var web3 = sharedDataModel.Web3;
            var gasPrice = await web3.Eth.GasPrice.SendRequestAsync();
            var gasPriceInGwei = Web3.Convert.FromWei(gasPrice, UnitConversion.EthUnit.Gwei);

            return gasPriceInGwei.ToString();
        }
    }
}
