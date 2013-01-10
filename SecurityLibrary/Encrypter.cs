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
     * 类 名 称:       Encrypter
     * 机器名称:       LUMIA800
     * 命名空间:       SecurityLibrary
     * 文 件 名:       Encrypter
     * 创建时间:        2013/1/10 13:50:35
     * 作    者:       常伟华 Changweihua
	 * 版    权:	      Encrypter说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2013
     * 签    名:       To be or not, it is not a problem !
     * 网    站:       http://www.cmono.net
     * 邮    箱:       changweihua@outlook.com  
     * 唯一标识：	      c4c9fc6e-32b9-4d20-abe9-14054c495ec7  
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
    /// 加密类
    /// </summary>
    public class Encrypter
    {
        #region 私有成员

        /// <summary>
        /// 默认DES密钥向量
        /// </summary>
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        /// <summary>
        /// 默认AES密钥向量
        /// </summary>
        private static byte[] AESKeys = { 0x41, 0x72, 0x65, 0x79, 0x6F, 0x75, 0x6D, 0x79, 0x53, 0x6E, 0x6F, 0x77, 0x6D, 0x61, 0x6E, 0x3F };


        #endregion

        #region DES加密

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥，要求为8位，默认为11001100，若长度大于8，截取前8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回null</returns>
        public static string EncryptDES(string encryptString, string encryptKey = "11001100")
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();

                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return null;
            }

        }

        #endregion

        #region MD5加密

        /// <summary>
        /// MD5 16位加密 加密后代码为大写
        /// </summary>
        /// <param name="cryptString">待加密的字符串</param>
        /// <returns>密文</returns>
        public static string GetMD5StringUpperCase(string cryptString)
        {
            string result = string.Empty;

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                result = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(cryptString)), 4, 8);
                result = result.Replace("-", "");
            }

            return result;
        }

        /// <summary>
        /// MD5 16位加密 加密后代码为小写
        /// </summary>
        /// <param name="cryptString">待加密的字符串</param>
        /// <returns>密文</returns>
        public static string GetMD5StringLowerCase(string cryptString)
        {
            return GetMD5StringUpperCase(cryptString).ToLower();
        }

        /// <summary>
        /// MD5 32位加密
        /// </summary>
        /// <param name="cryptString">明文</param>
        /// <returns>密文</returns>
        public static string GetMD5String(string cryptString)
        {
            string result = string.Empty;

            //实例化一个MD5对象
            using (MD5 md5 = MD5.Create())
            {
                StringBuilder sb = new StringBuilder();
                //加密后是一个字节类型的数组
                byte[] cryptStringArray = md5.ComputeHash(Encoding.UTF8.GetBytes(cryptString));
                //通过循环，将字节类型的数组转换成字符串
                for (int i = 0; i < cryptStringArray.Length; i++)
                {
                    //将得到的字符串使用16进制类型格式
                    sb.Append(cryptStringArray[i].ToString("X"));
                }

                result = sb.ToString();

            }

            return result;
        }


        /// <summary>
        /// MD5
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMD5(string str)
        {
            byte[] b = Encoding.UTF8.GetBytes(str);
            b = new MD5CryptoServiceProvider().ComputeHash(b);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < b.Length; i++)
            {
                sb.Append(b[i].ToString("X").PadLeft(2, '0'));
            }

            return sb.ToString();
        }


        #endregion

        #region AES加密

        /// <summary>
        /// AES 加密
        /// </summary>
        /// <param name="encryptString">待加密字符串</param>
        /// <param name="encryptKey">加密密钥，32位</param>
        /// <returns>加密之后的数据</returns>
        public static string EncryptAES(string encryptString, string encryptKey = "11001100110011001100110011001100")
        {


            encryptKey = StringUtil.GetSubString(encryptKey, 32, "");
            encryptKey = encryptKey.PadRight(32, ' ');

            RijndaelManaged rijndaelProvider = new RijndaelManaged();

            rijndaelProvider.Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32));
            rijndaelProvider.IV = AESKeys;

            ICryptoTransform rijndaelEncrypt = rijndaelProvider.CreateEncryptor();

            byte[] inputData = Encoding.UTF8.GetBytes(encryptString);
            byte[] encryptedData = rijndaelEncrypt.TransformFinalBlock(inputData, 0, inputData.Length);

            return Convert.ToBase64String(encryptedData);

        }

        #endregion
       
    }

    /// <summary>
    /// 加解密类型枚举
    /// </summary>
    public enum EncryptType
    {
        /// <summary>
        /// AES 
        /// </summary>
        AES,
        /// <summary>
        /// MD5 
        /// </summary>
        MD5,
        /// <summary>
        /// DES
        /// </summary>
        DES
    }

}
