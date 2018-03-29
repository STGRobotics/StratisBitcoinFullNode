﻿using Stratis.Bitcoin.Utilities;

namespace Stratis.SmartContracts.Core.Backend
{
    /// <summary>
    /// Information about the current state of the blockchain that is passed into the virtual machine.
    /// </summary>
    public sealed class SmartContractExecutionContext : ISmartContractExecutionContext
    {
        /// <inheritdoc/>
        public IBlock Block { get; }

        /// <inheritdoc/>
        public ulong GasPrice { get; }

        /// <inheritdoc/>
        public IMessage Message { get; }

        /// <inheritdoc/>
        public object[] Parameters { get; private set; }

        public SmartContractExecutionContext(IBlock block, IMessage message, ulong gasPrice, object[] methodParameters = null)
        {
            Guard.NotNull(block, nameof(block));
            Guard.NotNull(message, nameof(message));

            this.Block = block;
            this.Message = message;
            this.GasPrice = gasPrice;

            if (methodParameters != null && methodParameters.Length > 0)
                this.Parameters = methodParameters;
        }
    }
}