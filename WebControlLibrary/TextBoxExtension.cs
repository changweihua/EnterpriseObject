using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace WebControlLibrary
{
    #region 作者和版权
    /*************************************************************************************
     * CLR 版本:       4.0.30319.17929
     * 类 名 称:       TextBoxExtension
     * 机器名称:       LUMIA800
     * 命名空间:       WebControlLibrary
     * 文 件 名:       TextBoxExtension
     * 创建时间:       2013/1/10 14:29:09
     * 作    者:       常伟华 Changweihua
	 * 版    权:	   TextBoxExtension说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2013
     * 签    名:       To be or not, it is not a problem !
     * 网    站:       http://www.cmono.net
     * 邮    箱:       changweihua@outlook.com  
     * 唯一标识：	   ceecf439-19a2-41c4-a978-8a2c19336471  
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
    public static class TextBoxExtension
    {
        /// <summary>
        /// 泛型
        /// 获取指定类型的值
        /// </summary>
        /// <typeparam name="T">指定的值类型</typeparam>
        /// <param name="textBox"></param>
        /// <returns></returns>
        public static T GetValueAsT<T>(this TextBox textBox)
        {
            Type type = typeof(T);
            object obj = null;

            if (string.IsNullOrEmpty(textBox.Text))
            {
                return default(T);
            }

            switch (type.Name)
            {
                case "Int32":
                    obj = Convert.ToInt32(textBox.Text);
                    break;
                case "DateTime":
                    obj = Convert.ToDateTime(textBox.Text);
                    break;
                case "Double":
                    obj = Convert.ToDouble(textBox.Text);
                    break;
                default:
                    break;
            }

            return (T)obj;
        }
    }
}
