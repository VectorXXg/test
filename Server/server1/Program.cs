using System;

internal class Program
{
    private static void Main(string[] args)
    {
        //创建服务器对象
        var server = new MyTcpServer();

        server.Log += Console.WriteLine;  //打印服务器内部信息
        server.AddAdapter(new Net.Adapter.SerializeAdapter3());
        server.SyncSceneTime = 1;
        server.Run(6666);     //启动6666端口

        while (true) { Console.ReadLine(); }
    }
}