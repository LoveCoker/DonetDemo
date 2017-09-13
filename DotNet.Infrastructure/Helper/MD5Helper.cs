using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DotNet.Infrastructure.Helper
{
    public class MD5Helper
    {
        /// <summary>
        /// 对字符串进行MD5运算,获得Hash描述
        /// </summary>
        /// <param name="str">要进行运算的字符串</param>
        /// <returns>string</returns>
        public static string GetStringMD5(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            else
            {
                MD5 md5 = MD5.Create();
                byte[] bytes = System.Text.Encoding.Default.GetBytes(str);
                byte[] md5Byte = md5.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < md5Byte.Length; i++)
                {
                    sb.Append(md5Byte[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        /// <summary>
        /// 对文件进行MD5运算,获得Hash描述
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>string</returns>
        public static string GetFileMd5(string path)
        {
            MD5 md5 = MD5.Create();
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] md5byte = md5.ComputeHash(fs);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < md5byte.Length; i++)
                {
                    sb.Append(md5byte[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        /// <summary>
        /// 对文件进行MD5运算,获得Hash描述
        /// </summary>
        /// <param name="data">文件流</param>
        /// <returns>string</returns>
        public static string GetFileMd5(byte[] data)
        {
            if (data.Length < 1)
            {
                return "";
            }
            else
            {
                //创建MD5密码服务提供程序
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

                //计算传入的字节数组的哈希值
                byte[] result = md5.ComputeHash(data);

                //释放资源
                md5.Clear();

                //返回MD5值的字符串表示
                return Convert.ToBase64String(result);
            }
        }
        /// <summary>
        /// 计算文件的MD5值
        /// </summary>
        /// <param name="stream">文件流</param>
        /// <returns></returns>
        public static String GetStreamMd5(Stream stream)
        {
            string strResult = "";
            string strHashData = "";
            byte[] arrbytHashValue;
            System.Security.Cryptography.MD5CryptoServiceProvider oMD5Hasher =
                new System.Security.Cryptography.MD5CryptoServiceProvider();
            arrbytHashValue = oMD5Hasher.ComputeHash(stream); //计算指定Stream 对象的哈希值
            //由以连字符分隔的十六进制对构成的String，其中每一对表示value 中对应的元素；例如“F-2C-4A”
            strHashData = System.BitConverter.ToString(arrbytHashValue);
            //替换-
            strHashData = strHashData.Replace("-", "");
            strResult = strHashData;
            return strResult;
        }
    }
}