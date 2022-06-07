using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uwp.Core.Service
{
    public class MessengerService : IMessenger
    {
        public void Cleanup()
        {
            WeakReferenceMessenger.Default.Cleanup();
        }

        public bool IsRegistered<TMessage, TToken>(object recipient, TToken token)
            where TMessage : class
            where TToken : IEquatable<TToken>
        {
            return WeakReferenceMessenger.Default.IsRegistered<TMessage, TToken>(recipient, token);
        }

        public void Register<TRecipient, TMessage, TToken>(TRecipient recipient, TToken token, MessageHandler<TRecipient, TMessage> handler)
            where TRecipient : class
            where TMessage : class
            where TToken : IEquatable<TToken>
        {
            WeakReferenceMessenger.Default.Register(recipient, token, handler);
        }

        public void Reset()
        {
            WeakReferenceMessenger.Default.Reset();
        }

        public TMessage Send<TMessage, TToken>(TMessage message, TToken token)
            where TMessage : class
            where TToken : IEquatable<TToken>
        {
            return WeakReferenceMessenger.Default.Send(message, token);
        }

        public void Unregister<TMessage, TToken>(object recipient, TToken token)
            where TMessage : class
            where TToken : IEquatable<TToken>
        {
            WeakReferenceMessenger.Default.Unregister<TMessage, TToken>(recipient, token);
        }

        public void UnregisterAll(object recipient)
        {
            WeakReferenceMessenger.Default.UnregisterAll(recipient);
        }

        public void UnregisterAll<TToken>(object recipient, TToken token) where TToken : IEquatable<TToken>
        {
            WeakReferenceMessenger.Default.UnregisterAll(recipient, token);
        }
    }
}
