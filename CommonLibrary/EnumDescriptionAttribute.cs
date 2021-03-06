﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary
{
    #region 作者和版权
    /*************************************************************************************
     * CLR 版本:       4.0.30319.17929
     * 类 名 称:       EnumDescriptionAttribute
     * 机器名称:       LUMIA800
     * 命名空间:       CommonLibrary
     * 文 件 名:       EnumDescriptionAttribute
     * 创建时间:       2013/1/10 15:25:56
     * 作    者:       常伟华 Changweihua
	 * 版    权:	   EnumDescriptionAttribute说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2013
     * 签    名:       To be or not, it is not a problem !
     * 网    站:       http://www.cmono.net
     * 邮    箱:       changweihua@outlook.com  
     * 唯一标识：	   23ce5cc7-86dd-47ad-9277-150e82f4ed99  
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
    /// 自定义枚举属性类
    /// </summary>
    /// 
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDescriptionAttribute : Attribute
    {
        private string text;

        public string Text
        {
            get
            {
                return this.text;
            }
        }

        public EnumDescriptionAttribute(string t)
        {
            this.text = t;
        }

    }
}
