using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            var query = NetworkLibrary.NetworkAdapterHelper.GetAllAdapter(out count);
            foreach (var adapter in query)
            {
                Console.WriteLine("描述：" + adapter.Description);
                Console.WriteLine("标识符：" + adapter.Id);
                Console.WriteLine("名称：" + adapter.Name);
                Console.WriteLine("类型：" + adapter.NetworkInterfaceType);
                Console.WriteLine("速度：" + adapter.Speed );
                Console.WriteLine("操作状态：" + adapter.OperationalStatus);
                Console.WriteLine("MAC 地址：" + adapter.HexPhysicalAddress);
                Console.WriteLine("\n");
            }

            
            Console.WriteLine("\n\n\n\n");

            Console.WriteLine(CommonLibrary.EnumHelper.GetEnumDescription<NetworkLibrary.NetStatus>(NetworkLibrary.NetworkStatusChecker.GetConnectionStatus("www.baidu.com")));

            Console.ReadKey();
        }
    }
}
