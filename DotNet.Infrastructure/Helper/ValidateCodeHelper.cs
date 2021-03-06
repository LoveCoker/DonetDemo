﻿using System;
using System.DrawingCore;
using System.DrawingCore.Drawing2D;
using System.DrawingCore.Imaging;
using System.IO;

//using System.Drawing;

namespace DotNet.Infrastructure.Helper
{
    public class ValidateCodeHelper
    {
        // 验证码的最大长度
        private int _maxLength = 10;
        // 验证码的最小长度
        private int _minLength = 1;
        // 验证码高度
        private int _height = 40;
        /// <summary>
        /// 验证码的高度
        /// </summary>
        public int Height {
            get => _height;
            set => _height = value;
        }
        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="length">指定验证码的长度</param>
        /// <returns></returns>
        public string CreateValidateCode(int length)
        {
            length = length > _maxLength ? _maxLength : length < _minLength ? _minLength : length;

            int[] randMembers = new int[length];
            int[] validateNums = new int[length];
            string validateNumberStr = "";
            //生成起始序列值
            int seekSeek = unchecked((int)DateTime.Now.Ticks);
            Random seekRand = new Random(seekSeek);
            int beginSeek = (int)seekRand.Next(0, Int32.MaxValue - length * 10000);
            int[] seeks = new int[length];
            for (int i = 0; i < length; i++)
            {
                beginSeek += 10000;
                seeks[i] = beginSeek;
            }
            //生成随机数字
            for (int i = 0; i < length; i++)
            {
                Random rand = new Random(seeks[i]);
                int pownum = 1 * (int)Math.Pow(10, length);
                randMembers[i] = rand.Next(pownum, Int32.MaxValue);
            }
            //抽取随机数字
            for (int i = 0; i < length; i++)
            {
                string numStr = randMembers[i].ToString();
                int numLength = numStr.Length;
                Random rand = new Random();
                int numPosition = rand.Next(0, numLength - 1);
                validateNums[i] = Int32.Parse(numStr.Substring(numPosition, 1));
            }
            //生成验证码
            for (int i = 0; i < length; i++)
            {
                validateNumberStr += validateNums[i].ToString();
            }
            return validateNumberStr;
        }

        /// <summary>
        /// 得到验证码图片的长度
        /// </summary>
        /// <param name="validateNumLength">验证码的长度</param>
        /// <returns></returns>
        private static int GetImageWidth(int validateNumLength)
        {
            return (int)(validateNumLength * 18.0);
        }
        /// <summary>
        /// 创建验证码的图片
        /// </summary>
        public byte[] CreateValidateGraphic(string validateCode)
        {
            Bitmap image = new Bitmap((int)Math.Ceiling(validateCode.Length * 12.0), 22);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器
                Random random = new Random();
                //清空图片背景色
                g.Clear(Color.White);
                //画图片的干扰线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
                    Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateCode, font, brush, 3, 2);
                //画图片的前景干扰点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                //保存图片数据
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                //输出图片流
                return stream.ToArray();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
        /// <summary>
        /// 创建验证码的图片2
        /// </summary>
        public byte[] CreateValidateGraphic2(string checkCode)
        {
            Bitmap image = new Bitmap(GetImageWidth(checkCode.Length), _height);
            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);
            try
            {
                //定义颜色集合
                Color[] c =
                {
                    Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Chocolate, Color.Brown,
                    Color.DarkCyan, Color.Purple
                };
                //定义字体集合
                string[] font = { "Arial", "Verdana", "Microsoft Sans Serif", "Comic Sans MS" };
                Random rand = new Random();
                //随机输出噪点
                for (int i = 0; i < 50; i++)
                {
                    int x = rand.Next(image.Width);
                    int y = rand.Next(image.Height);
                    g.DrawRectangle(new Pen(Color.LightGray, 0), x, y, 1, 1);
                }

                //输出不同字体和颜色的验证码字符
                for (int i = 0; i < checkCode.Length; i++)
                {
                    int cindex = rand.Next(7);
                    int findex = rand.Next(4);

                    Font f = new Font(font[findex], 16, FontStyle.Bold);
                    Brush b = new SolidBrush(c[cindex]);
                    g.DrawString(checkCode.Substring(i, 1), f, b, 1 + (i * 14), 8);
                }
                //画一个边框(在此设置边框颜色为绿色)
                g.DrawRectangle(new Pen(Color.Green, 0), 0, 0, image.Width - 1, image.Height - 1);
                //输出到浏览器
                MemoryStream ms = new MemoryStream();
                image.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
    }

}