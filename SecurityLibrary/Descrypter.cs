using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CommonLibrary;

namespace SecurityLibrary
{
    #region 作者和版权
    /*************************************************************************************
     * CLR 版本:       4.0.30319.17929
     * 类 名 称:       Descrypter
     * 机器名称:       LUMIA800
     * 命名空间:       SecurityLibrary
     * 文 件 名:       Descrypter
     * 创建时间:       2013/1/10 14:24:01
     * 作    者:       常伟华 Changweihua
	 * 版    权:	   Descrypter说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2013
     * 签    名:       To be or not, it is not a problem !
     * 网    站:       http://www.cmono.net
     * 邮    箱:       changweihua@outlook.com  
     * 唯一标识：	   fffe56c9-4c6f-4950-a78c-a5850d5c9632  
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
    class Descrypter
    {
        #region DES加密解密字符串

        /// <summary>
        /// 默认密钥向量
        /// </summary>
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };


        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥，要求为8位，和加密密钥相同</param>
        /// <returns>解密成功后返回解密后的字符串，失败返回null</returns>
        public static string DecryptDES(string decryptString, string decryptKey = "11001100")
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();

                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return null;
            }

        }

        #endregion

        #region AES加解密

        /// <summary>
        /// 默认密钥向量
        /// </summary>
        private static byte[] AESKeys = { 0x41, 0x72, 0x65, 0x79, 0x6F, 0x75, 0x6D, 0x79, 0x53, 0x6E, 0x6F, 0x77, 0x6D, 0x61, 0x6E, 0x3F };

        
        /// <summary>
        /// AES 解密
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥，和加密密钥相同</param>
        /// <returns>解密之后的数据</returns>
        public static string DecryptAES(string decryptString, string decryptKey = "11001100110011001100110011001100")
        {
            decryptKey = StringUtil.GetSubString(decryptKey, 32, "");
            decryptKey = decryptKey.PadRight(32, ' ');

            RijndaelManaged rijndaelProvider = new RijndaelManaged();

            rijndaelProvider.Key = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 32));
            rijndaelProvider.IV = AESKeys;

            ICryptoTransform rijndaelDecrypt = rijndaelProvider.CreateDecryptor();

            byte[] inputData = Convert.FromBase64String(decryptString);
            byte[] decryptData = rijndaelDecrypt.TransformFinalBlock(inputData, 0, inputData.Length);

            return Encoding.UTF8.GetString(decryptData);

        }

        #endregion
    }
}
