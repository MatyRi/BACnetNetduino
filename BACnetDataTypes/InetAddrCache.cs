using System.Collections;
using System.Net;

namespace BACnetDataTypes
{
    class InetAddrCache
    {
        private static readonly Hashtable socketCache = new Hashtable();

        public static IPEndPoint get(string host, int port)
        {
            return get(IPAddress.Parse(host), port);
        }

        /**
         * InetSocketAddress cache, because instantiation can take up to 10 seconds on Android.
         * ??? Should there be a means of purging this?
         * 
         * @param addr
         * @param port
         * @return
         */
        public static IPEndPoint get(IPAddress addr, int port)
        {//Map<Integer, InetSocketAddress>
            Hashtable ports = (Hashtable) socketCache[addr];
            if (ports == null)
            {
                //synchronized(socketCache) {
                    ports = (Hashtable) socketCache[addr];
                    if (ports == null)
                    {
                        ports = new Hashtable();
                        socketCache[addr] = ports;
                    }
                //}
            }

            IPEndPoint socket = (IPEndPoint) ports[port];
            if (socket == null)
            {
                //synchronized(ports) {
                    socket = (IPEndPoint) ports[port];
                    if (socket == null)
                    {
                        socket = new IPEndPoint(addr, port);
                        ports[port] = socket;
                    }
                //}
            }

            return socket;
        }
    }
}
