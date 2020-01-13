using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocationMaster_FE.Helpers
{

   
    public class ChatClient : IDisposable
    {

        #region static methods

        
        private static readonly Dictionary<string, ChatClient> _clients = new Dictionary<string, ChatClient>();


      
        [JSInvokable]
        public static void ReceiveMessage(string key, string method, string username, string message)
        {
            if (_clients.ContainsKey(key))
            {
                var client = _clients[key];
                switch (method)
                {
                    case "ReceiveMessage":
                        client.HandleReceiveMessage(username, message);
                        return;

                    default:
                        throw new NotImplementedException(method);
                }
            }
            else
            {
                // unable to match the message to a client
                Console.WriteLine($"ReceiveMessage: unable to find {key}");
            }
        }

        #endregion

       
        public ChatClient(string username, IJSRuntime JSRuntime)
        {
            _JSruntime = JSRuntime;

            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException(nameof(username));
            _username = username;

            _key = Guid.NewGuid().ToString();

            _clients.Add(_key, this);
        }



        const string HUBURL = "/chathub";

      
        private readonly string _key;

        private readonly string _username;

        private bool _started = false;

        private readonly IJSRuntime _JSruntime;

        public async Task Start()
        {
            if (!_started)
            {
                const string assembly = "BlazorChatSample.Client";
                const string method = "ReceiveMessage";

                Console.WriteLine("ChatClient: calling Start()");
                var _ = await _JSruntime.InvokeAsync<object>("ChatClient.Start", _key, HUBURL, assembly, method);
                Console.WriteLine("ChatClient: Start returned");
                _started = true;

                await _JSruntime.InvokeAsync<object>("ChatClient.Register", _key, _username);
            }
        }

        private void HandleReceiveMessage(string username, string message)
        {
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(username, message));
        }

        public event MessageReceivedEventHandler MessageReceived;

        public async Task Send(string message)
        {
            if (!_started)
                throw new InvalidOperationException("Client not started");
            await _JSruntime.InvokeAsync<object>("ChatClient.Send", _key, _username, message);
        }

        public async Task Stop()
        {
            if (_started)
            {
                await _JSruntime.InvokeAsync<object>("ChatClient.Stop", _key);
                _started = false;
            }
        }

        public void Dispose()
        {
            Console.WriteLine("ChatClient: Disposing");
            if (_started)
            {
                Task.Run(async () =>
                {
                    await Stop();
                }).Wait();
            }

            if (_clients.ContainsKey(_key))
                _clients.Remove(_key);
        }
    }

    public delegate void MessageReceivedEventHandler(object sender, MessageReceivedEventArgs e);

    public class MessageReceivedEventArgs : EventArgs
    {
        public MessageReceivedEventArgs(string username, string message)
        {
            Username = username;
            Message = message;
        }

        public string Username { get; set; }

        public string Message { get; set; }

    }

}

