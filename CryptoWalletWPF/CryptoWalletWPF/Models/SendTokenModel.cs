﻿using CryptoWalletWPF.Utility;
using Nethereum.Util;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace CryptoWalletWPF.Models
{
    internal class SendTokenModel
    {
        public static async Task<bool> SendTokenAsync(TransactionInfo transactionInfo, SharedDataModel sharedDataModel)
        {
            var web3 = sharedDataModel.Web3;

            var contractAddress = transactionInfo.ContractAddress;
            var toAddress = transactionInfo.ToAddress;

            var amount = transactionInfo.Amount.Replace('.', ',');
            var value = Web3.Convert.ToWei(amount, UnitConversion.EthUnit.Ether);

            var transfer = new TransferFunction()
            {
                To = toAddress,
                TokenAmount = value
            };

            var transferHandler = web3.Eth.GetContractTransactionHandler<TransferFunction>();
            var transactionReceipt = await transferHandler.SendRequestAndWaitForReceiptAsync(contractAddress, transfer);

            if (transactionReceipt != null && transactionReceipt.Status.Value == 1)
            {
                return true;
            }

            return false;
        }

        public static async Task<decimal> GetTokenBalanceAsync(SharedDataModel sharedDataModel, string contractAddress)
        {
            var web3 = sharedDataModel.Web3;
            var addressToCheck = sharedDataModel.Account.Address;

            var balanceOfFunctionMessage = new BalanceOfFunction()
            {
                Owner = addressToCheck,
            };
            var balanceHandler = web3.Eth.GetContractQueryHandler<BalanceOfFunction>();
            var balance = await balanceHandler.QueryAsync<BigInteger>(contractAddress, balanceOfFunctionMessage);

            decimal balanceDecimal = (decimal)balance / (decimal)Math.Pow(10, 18);

            return balanceDecimal;
        }

        public static bool IsTokenBalanceEnough(string balance, string amountToSend)
        {
            if (decimal.Parse(balance) >= (decimal.Parse(amountToSend.Replace('.', ','))))
            {
                return true;
            }

            return false;
        }

        [Function("balanceOf", "uint256")]
        private class BalanceOfFunction : FunctionMessage
        {
            [Parameter("address", "_owner", 1)]
            public string Owner { get; set; }
        }

        [Function("transfer", "bool")]
        private class TransferFunction : FunctionMessage
        {
            [Parameter("address", "_to", 1)]
            public string To { get; set; }

            [Parameter("uint256", "_value", 2)]
            public BigInteger TokenAmount { get; set; }
        }
    }
}
