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
     * 类 名 称:       DropDownListExtension
     * 机器名称:       LUMIA800
     * 命名空间:       WebControlLibrary
     * 文 件 名:       DropDownListExtension
     * 创建时间:       2013/1/10 14:34:54
     * 作    者:       常伟华 Changweihua
	 * 版    权:	   DropDownListExtension说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2013
     * 签    名:       To be or not, it is not a problem !
     * 网    站:       http://www.cmono.net
     * 邮    箱:       changweihua@outlook.com  
     * 唯一标识：	   e8743c60-ba40-4c58-9c40-5504e7fcea48  
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
    public static class DropDownListExtension
    {
        /// <summary>
        /// 拓展方法，实现DropDownList绑定List数据源功能
        /// </summary>
        /// <typeparam name="T">模型类</typeparam>
        /// <param name="ddl">需要绑定数据的控件</param>
        /// <param name="list">数据列表</param>
        /// <param name="valueField">值</param>
        /// <param name="textField">文本</param>
        public static void BindList<T>(this DropDownList ddl, IList<T> list, string valueField, string textField)
        {
            BindList<T>(ddl, list, valueField, textField, false);
        }

        /// <summary>
        /// 拓展方法，实现DropDownList绑定List数据源功能
        /// </summary>
        /// <typeparam name="T">模型类</typeparam>
        /// <param name="ddl">需要绑定数据的控件</param>
        /// <param name="list">数据列表</param>
        /// <param name="valueField">值</param>
        /// <param name="textField">文本</param>
        /// <param name="isInsertBlank">是否插入空白项</param>
        public static void BindList<T>(this DropDownList ddl, IList<T> list, string valueField, string textField, bool isInsertBlank)
        {
            ddl.DataSource = list;
            ddl.DataValueField = valueField;
            ddl.DataTextField = textField;

            if (isInsertBlank)
            {
                ddl.Items.Add(new ListItem("请选择", "-1"));
            }

            ddl.DataBind();
        }

    }
}
