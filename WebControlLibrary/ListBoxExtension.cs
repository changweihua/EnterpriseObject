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
     * 类 名 称:       ListBoxExtension
     * 机器名称:       LUMIA800
     * 命名空间:       WebControlLibrary
     * 文 件 名:       ListBoxExtension
     * 创建时间:       2013/1/10 14:47:43
     * 作    者:       常伟华 Changweihua
	 * 版    权:	   ListBoxExtension说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2013
     * 签    名:       To be or not, it is not a problem !
     * 网    站:       http://www.cmono.net
     * 邮    箱:       changweihua@outlook.com  
     * 唯一标识：	   a600631b-a877-4f71-bc44-9716eb9bb59a  
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
    public static class ListBoxExtension
    {
        /// <summary>
        /// 拓展方法，实现绑定IList数据源
        /// </summary>
        /// <typeparam name="T">数据集合类型</typeparam>
        /// <param name="listBox">待绑定的控件</param>
        /// <param name="list">数据</param>
        /// <param name="textField">文本域</param>
        /// <param name="valueField">值域</param>
        public static void BindListBox<T>(this ListBox listBox, IList<T> list, string textField, string valueField)
        {
            listBox.DataSource = list;
            listBox.DataTextField = textField;
            listBox.DataValueField = valueField;
            listBox.DataBind();
        }
    }
}
