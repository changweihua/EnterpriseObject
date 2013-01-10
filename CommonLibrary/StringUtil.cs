using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary
{
    #region 作者和版权
    /*************************************************************************************
     * CLR 版本:       4.0.30319.17929
     * 类 名 称:       StringUtil
     * 机器名称:       LUMIA800
     * 命名空间:       CommonLibrary
     * 文 件 名:       StringUtil
     * 创建时间:       2013/1/10 14:22:00
     * 作    者:       常伟华 Changweihua
	 * 版    权:	   StringUtil说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2013
     * 签    名:       To be or not, it is not a problem !
     * 网    站:       http://www.cmono.net
     * 邮    箱:       changweihua@outlook.com  
     * 唯一标识：	   f051a038-89cd-403d-8d41-8fab18e553e7  
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
    public class StringUtil
    {
        /// <summary>
        /// 截取字符串，不足添加指定字符
        /// </summary>
        /// <param name="str">需要截取的字符串</param>
        /// <param name="length">截取长度</param>
        /// <param name="defValue">长度不够，默认添加的值</param>
        /// <returns></returns>
        public static string GetSubString(string str, int length, string defValue)
        {
            int strLength = str.Length;
            StringBuilder sb = new StringBuilder(str);

            if (length >= strLength)
            {
                for (int i = 0; i < length - strLength; i++)
                {
                    sb.Append(defValue);
                }
            }

            return sb.ToString();
        }
    }
}
