using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CommonLibrary
{
    #region 作者和版权
    /*************************************************************************************
     * CLR 版本:       4.0.30319.17929
     * 类 名 称:       FileHelper
     * 机器名称:       LUMIA800
     * 命名空间:       CommonLibrary
     * 文 件 名:       FileHelper
     * 创建时间:       2013/1/10 15:34:16
     * 作    者:       常伟华 Changweihua
	 * 版    权:	   FileHelper说明：本代码版权归常伟华所有，使用时必须带上常伟华网站地址 All Rights Reserved (C) 2013 - 2013
     * 签    名:       To be or not, it is not a problem !
     * 网    站:       http://www.cmono.net
     * 邮    箱:       changweihua@outlook.com  
     * 唯一标识：	   4645066f-6ae0-48f7-821a-6468522a180c  
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
    /// 文件帮助类
    /// </summary>
    /// 
    public class FileHelper
    {
        #region 文件夹操作方法

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool DeleteFile(string filePath)
        {
            bool flag = false;

            if (File.Exists(filePath))
            {
                if (File.GetAttributes(filePath) == FileAttributes.Normal)
                {
                    try
                    {
                        File.Delete(filePath);
                        flag = true;
                    }
                    catch
                    {
                        flag = false;
                    }
                }
                else
                {
                    try
                    {
                        File.SetAttributes(filePath, FileAttributes.Normal);
                        File.Delete(filePath);
                        flag = true;
                    }
                    catch
                    {
                        flag = false;
                    }
                }
            }
            else
            {
                flag = false;
            }

            return flag;
        }


        /// <summary>
        /// 获取文件名
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFileName(string filePath)
        {
            if (File.Exists(filePath))
            {
                FileInfo file = new FileInfo(filePath);
                return file.Name;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获取文件名
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="includeExtension">是否包含拓展名</param>
        /// <returns></returns>
        public static string GetFileName(string filePath, bool includeExtension)
        {
            if (File.Exists(filePath))
            {
                FileInfo file = new FileInfo(filePath);
                if (includeExtension)
                {
                    return file.Name;
                }
                else
                {
                    return file.Name.Replace(file.Extension, "");
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="sourceFolder">原文件夹</param>
        /// <param name="targetFolder">目的文件夹</param>
        /// <returns></returns>
        public static bool RemoveFile(string fileName, string sourceFolder, string targetFolder)
        {
            bool flag = false;

            string source = string.Format(@"{0}\{1}.mono", sourceFolder, fileName);
            string target = string.Format(@"{0}\{1}.mono", targetFolder, fileName);

            if (File.Exists(source))
            {
                try
                {
                    File.Move(source, target);
                    flag = true;
                }
                catch
                {
                    flag = false;
                }
            }
            else
            {
                flag = false;
            }

            return flag;
        }


        /// <summary>
        /// 获取文件拓展名
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string GetFileExtension(string filePath)
        {
            if (File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                return fileInfo.Extension;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool OpenFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                System.Diagnostics.Process.Start(filePath);
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 检查文件是否存在
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool CheckFile(string filePath)
        {
            bool flag = false;
            if (File.Exists(filePath))
            {
                flag = true;
            }
            return flag;
        }


        /// <summary>
        /// 得到文件的大小
        /// </summary>
        /// <param name="fileFullPath">文件全路径</param>
        /// <returns>string</returns>
        public string GetFileLength(string fileFullPath)
        {
            if (File.Exists(fileFullPath))
            {
                FileInfo fileInfo = new FileInfo(fileFullPath);
                long f = fileInfo.Length;
                //KB MB GB TB
                if (f > 1024 * 1024 * 1024)//GB
                {
                    return Convert.ToString(Math.Round((f + 0.00) / (1024 * 1024 * 1024), 2)) + "GB";
                }
                if (f > 1024 * 1024) //MB
                {
                    return Convert.ToString(Math.Round((f + 0.00) / (1024 * 1024), 2)) + "MB";
                }
                else
                {
                    return Convert.ToString(Math.Round((f + 0.00) / 1024, 2)) + "KB";
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 文件转换成二进制流
        /// </summary>
        /// <param name="fileFullPath">要转换的文件全路径</param>
        /// <returns> Byte[] </returns>
        /// <remarks></remarks>
        public Byte[] FileToStreamByte(string fileFullPath)
        {
            Byte[] fileData = null;
            if (File.Exists(fileFullPath))
            {
                FileStream fs = new FileStream(fileFullPath, System.IO.FileMode.Open);
                fileData = new Byte[fs.Length];
                fs.Read(fileData, 0, fileData.Length);
                fs.Close();
                return fileData;
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// 从二进制转换成文件
        /// </summary>
        /// <param name="createFileFullPath">要转换的文件全路径</param>
        /// <param name="streamByte">二进制流</param>
        /// <returns>True/False</returns>
        /// <remarks>True/False</remarks>
        public bool ByteSteramToFile(string createFileFullPath, Byte[] streamByte)
        {
            try
            {
                FileStream fs = null;
                if (File.Exists(createFileFullPath)) //如果文件存在，先删除
                {
                    DeleteFile(createFileFullPath);
                }
                fs = File.Create(createFileFullPath);
                fs.Write(streamByte, 0, streamByte.Length);
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 序列化Xml文件
        /// </summary>
        /// <param name="fileFullPath">要序列化的xml文件路径</param>
        /// <returns>True/False</returns>
        public bool SerializeXmlFile(string fileFullPath)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            if (File.Exists(fileFullPath))
            {
                try
                {
                    ds.ReadXml(fileFullPath);
                    FileStream fs = new FileStream(fileFullPath + ".tmp", FileMode.OpenOrCreate);
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter BF = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    BF.Serialize(fs, ds);//序例化ds,并将结果赋给fs
                    fs.Close();
                    DeleteFile(fileFullPath);//删除传入的xml文件
                    File.Move(fileFullPath + ".tmp", fileFullPath);//将序列化后的文件改为原来的Xml文件
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 反序列化Xml
        /// </summary>
        /// <param name="fileFullPath">反序列化的Xml文件路径</param>
        /// <returns>True/False</returns>
        /// <remarks></remarks>
        public bool DescSerializeXmlFile(string fileFullPath)
        {
            if (File.Exists(fileFullPath))
            {
                try
                {
                    System.Data.DataSet ds = new System.Data.DataSet();
                    FileStream fs = new FileStream(fileFullPath, FileMode.Open);//打开xml文件,将内容读入到流中
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter BF = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    object descSeriResult = BF.Deserialize(fs);//反序列化
                    ((System.Data.DataSet)descSeriResult).WriteXml(fs + ".tmp");
                    fs.Close();//关闭流
                    DeleteFile(fileFullPath);//删除传入的xml文件
                    File.Move(fileFullPath + ".tmp", fileFullPath);//将反序列化后的文件改名传入的xml文件
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        #endregion
    }
}
