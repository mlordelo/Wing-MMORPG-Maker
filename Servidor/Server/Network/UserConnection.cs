using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ACESERVER
{
    class UserConnection
    {
        public static bool isConnected(int clientid)
        {
            try
            {
                bool Connected;
                Connected = true;

                // Detect if client disconnected
                if (WinsockAsync.Clients[clientid].Async.Poll(1000, SelectMode.SelectRead))
                {
                    byte[] buff = new byte[1];
                    if (WinsockAsync.Clients[clientid].Async.Receive(buff, SocketFlags.Peek) == 0)
                    {
                        // Client disconnected
                        Connected = false;
                    }
                }

                return Connected;
            }
            catch { return false; }

        }

        public static bool CheckIndex(int index)
        {
            for (int i = 0; i < WinsockAsync.Clients.Count; i++)
            {
                if (WinsockAsync.Clients[i].Index == index)
                {
                    return false;
                }
            }
            return true;
        }
        public static int GetIndex(int index)
        {
            for (int i = 0; i < WinsockAsync.Clients.Count; i++)
            {
                if (WinsockAsync.Clients[i].Index == index)
                {
                    if ((i < 0) || (i >= WinsockAsync.Clients.Count())) { return -1; }
                    return i;
                }
            }
            return -1;
        }
    }


}
  