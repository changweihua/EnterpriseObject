using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtersionLibrary
{
    #region 作者和版权
    /*************************************************************************************
     * CLR 版本:       4.0.30319.17929
     * 类 名 称:       ArrayExtension
     * 机器名称:       LUMIA800
     * 命名空间:       ExtersionLibrary
     * 文 件 名:       ArrayExtension
     * 创建时间:       2013/1/10 14:46:00
     * 作    者:       常伟华 Changweihua
	 * 版    权:	   ArrayExtension说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2013
     * 签    名:       To be or not, it is not a problem !
     * 网    站:       http://www.cmono.net
     * 邮    箱:       changweihua@outlook.com  
     * 唯一标识：	   5d71c794-bb50-42fc-b18d-ed164219e423  
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
    /// 摘要
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// 拓展方法，实现数组转成字符串
        /// </summary>
        /// <param name="array">需要转换的数组</param>
        /// <param name="separator">分隔符</param>
        /// <returns>字符串</returns>
        public static string Join(this Array array, string separator)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in array)
            {
                sb.Append(item + separator);
            }

            string result = sb.ToString().Substring(0, sb.ToString().Length - 1);

            return result;
        }
    }
}
