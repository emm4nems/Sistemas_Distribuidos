namespace ChatP2P;

public class Program
{
    public static async Task Main(string[] args)
    {
        int port = 8080;

        if (args.Length > 3 && int.TryParse(args[3], out int parsedPort))
        {
            port = parsedPort;
        }

        var peer = new Peer(port);

        if (args.Length > 0 && args[0] == "connect" 
            && !string.IsNullOrEmpty(args[1])  
            && !string.IsNullOrEmpty(args[2]))
        {
            await peer.ConnectToPeer(args[1], args[2]);
        }
        else
        {
            await peer.StartListening();
        }
    }
}
