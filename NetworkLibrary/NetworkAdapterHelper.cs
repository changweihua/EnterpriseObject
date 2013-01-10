using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace NetworkLibrary
{
    #region 作者和版权
    /*************************************************************************************
     * CLR 版本:       4.0.30319.17929
     * 类 名 称:       NetworkAdapterHelper
     * 机器名称:       LUMIA800
     * 命名空间:       NetworkLibrary
     * 文 件 名:       NetworkAdapterHelper
     * 创建时间:       2013/1/10 14:58:07
     * 作    者:       常伟华 Changweihua
	 * 版    权:	   NetworkAdapterHelper说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2013
     * 签    名:       To be or not, it is not a problem !
     * 网    站:       http://www.cmono.net
     * 邮    箱:       changweihua@outlook.com  
     * 唯一标识：	   b603ea4d-e37f-4cf1-ab89-6793b45bc2da  
	 *
	 * 登录用户:       Changweihua
	 * 所 属 域:       Lumia800

	 * 创建年份:       2013
     * 修改时间:
     * 修 改 人:
     * 
     ************************************************************************************/
    #endregion

    /// <summary>
    /// 获取
    /// </summary>
    public class NetworkAdapterHelper
    {
        /// <summary>
        /// 获取网络适配器信息
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static List<Adapter> GetAllAdapter(out int count)
        {
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();//获取本地计算机上网络接口的对象
            List<Adapter> adapters = new List<Adapter>();
           
            foreach (var item in networkInterfaces)
            {
                // 格式化显示MAC地址                
                PhysicalAddress pa = item.GetPhysicalAddress();//获取适配器的媒体访问（MAC）地址
                byte[] bytes = pa.GetAddressBytes();//返回当前实例的地址
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("X2"));//以十六进制格式化
                    if (i != bytes.Length - 1)
                    {
                        sb.Append("-");
                    }
                }

                adapters.Add(new Adapter
                {
                    Description = item.Description,
                    HexPhysicalAddress = sb.ToString(),
                    Id = item.Id,
                    Name = item.Name,
                    NetworkInterfaceType = item.NetworkInterfaceType.ToString(),
                    OperationalStatus = item.OperationalStatus.ToString(),
                    PhysicalAddress = item.GetPhysicalAddress().ToString(),
                    Speed = item.Speed * 0.001 * 0.001 + "M"
                });

            }

            count = networkInterfaces.Length;
            return adapters;
        }
    }

    public class Adapter
    {
        /// <summary>
        /// 标识符
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string NetworkInterfaceType { get; set; }
        /// <summary>
        /// 速率
        /// </summary>
        public string Speed { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string OperationalStatus { get; set; }
        /// <summary>
        /// Mac
        /// </summary>
        public string PhysicalAddress { get; set; }
        /// <summary>
        /// MAC 十六进制表示
        /// </summary>
        public string HexPhysicalAddress { get; set; }
    }

}
