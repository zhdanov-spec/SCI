using Igroland.GameZone.MifareInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZPSoft.GameZone.SCI.Classes;
using ZPSoft.GameZone.SGZServiceInterfaces;

namespace ZPSoft.GameZone.SCI.ClientLogic.MifareClasses
{
    internal class MifareSender
    {
        CancellationToken token;
        public void SendCommand(Constants.CommandImage type, string ipAddress,Int32 idDevice, MifareServer mifareServer, IConfirmationPayment confirmationPayment, CancellationToken token, int? timeDTR)
        {
            this.token = token;
            switch (type)
            {
                case Constants.CommandImage.PaydOk:
                    if (Sleep(500)) return;
                    byte[] byteArray1 = StringToByteArray((timeDTR.Value / 10).ToString("X").PadLeft(4, '0'));
                    byte[] logotypeOk = new byte[89600];
                    logotypeOk = GetSmallImageByte(GetImageFromByte(Classes.GlobalVariable.PointInfo.NodePoints[0].ImageOk));
                    if (Sleep(2000)) return;
                    mifareServer.SendParameters(ipAddress, new byte[8] { 33, 15, 154, 0, 0, 1, 63, 16 });
                    if (Sleep(100)) return;
                    mifareServer.SendParameters(ipAddress, logotypeOk);
                    if (Sleep(2000)) return;
                    mifareServer.SendParameters(ipAddress, new byte[6] { 50, 4, 40, 40, byteArray1[0], byteArray1[1] });
                    break;
                case Constants.CommandImage.PaydFalse:
                    if (Sleep(500)) return;
                    byte[] logotypeDenid = new byte[89600];
                    logotypeDenid = GetSmallImageByte(GetImageFromByte(Classes.GlobalVariable.PointInfo.NodePoints[0].ImageDeny)); ;
                    if (Sleep(2000)) return;
                    mifareServer.SendParameters(ipAddress, new byte[8] { 33, 15, 154, 0, 0, 1, 63, 16 });
                    if (Sleep(100)) return;
                    mifareServer.SendParameters(ipAddress, logotypeDenid);
                    if (Sleep(2000)) return;
                    mifareServer.SendParameters(ipAddress, new byte[4] { 49, 2, 40, 40 });
                    break;
                case Constants.CommandImage.Screen2:
                    if (Sleep(500)) return;
                    mifareServer.SendParameters(ipAddress, new byte[8] { 33, 15, 154, 0, 0, 1, 63, 16 });
                    if (Sleep(100)) return;
                    byte[] logotypeGameStart = new byte[89600];
                    logotypeGameStart = GetSmallImageByte(GetImageFromByte(Classes.GlobalVariable.PointInfo.NodePoints[0].ImageScreen2));
                    mifareServer.SendParameters(ipAddress, logotypeGameStart);
                    break;
                case Constants.CommandImage.SendPrice:
                    if (Sleep(500)) return;
                    string price = confirmationPayment.GetDevicePrice(idDevice).ToString();
                    Bitmap s2;
                    Bitmap s1;
                    s2 = new Bitmap(CreateBitmapImageBigFont("Ціна:" + price));
                    s1 = GetImageFromByte(Classes.GlobalVariable.PointInfo.NodePoints[0].ImageBlank);
                    Bitmap mergeImage = MergeImage(s1, s2, false);
                    mifareServer.SendParameters(ipAddress, new byte[8] { 33, 15, 154, 0, 0, 1, 63, 16 });
                    if (Sleep(100)) return;
                    mifareServer.SendParameters(ipAddress, GetSmallImageByte(mergeImage));
                    break;
                case Constants.CommandImage.Screen1:
                    if (Sleep(500)) return;
                    byte[] logotypeGetCard = new byte[89600];
                    logotypeGetCard = GetSmallImageByte(GetImageFromByte(Classes.GlobalVariable.PointInfo.NodePoints[0].ImageScreen1));
                    mifareServer.SendParameters(ipAddress, new byte[8] { 33, 15, 154, 0, 0, 1, 63, 16 });
                    if (Sleep(100)) return;
                    mifareServer.SendParameters(ipAddress, logotypeGetCard);
                    break;
                case Constants.CommandImage.SendLogo:
                    byte[] imageGeneralBlank = new byte[153600];
                    imageGeneralBlank = GetBigImageByte(GetImageFromByte(Classes.GlobalVariable.PointInfo.NodePoints[0].ImageGeneralBlank));
                    mifareServer.SendParameters(ipAddress, new byte[8] { 48, 2, 9, 1, 1, 0, 9, 50 });
                    if (Sleep(100)) return;
                    mifareServer.SendParameters(ipAddress, new byte[8] { 33, 0, 239, 0, 0, 1, 63, 36 });
                    if (Sleep(100)) return;
                    mifareServer.SendParameters(ipAddress, imageGeneralBlank);
                    if (Sleep(100)) return;
                    break;
            }
        }
        private bool Sleep(int time)
        {
            DateTime dateTime = DateTime.Now + new TimeSpan(0, 0, 0, 0, time);
            while (DateTime.Now < dateTime)
            {
                if (this.token.IsCancellationRequested)
                {
                    return true;
                }
                Thread.Sleep(50);
            }
            return false;
        }
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length).Where<int>((Func<int, bool>)(x => x % 2 == 0)).Select<int, byte>((Func<int, byte>)(x => Convert.ToByte(hex.Substring(x, 2), 16))).ToArray<byte>();
        }
        private Bitmap MergeImage(Bitmap s1, Bitmap s2, bool isPacket)
        {

            s1.SetResolution(100f, 100f);
            s2.SetResolution(100f, 100f);

            Bitmap bitmap = new Bitmap(140, 320);
            bitmap.SetResolution(100f, 100f);
            using (Graphics graphics = Graphics.FromImage((Image)bitmap))
            {
                graphics.DrawImage((Image)s1, new Point());
                if (!isPacket)
                    graphics.DrawImage((Image)s2, new Point(40, 25));
                else
                    graphics.DrawImage((Image)s2, new Point(5, 40));
            }
            return bitmap;
        }
        private byte[] GetSmallImageByte(Bitmap img)
        {
            Bitmap bitmap = img;
            bitmap.SetResolution(100f, 100f);
            int index1 = 0;
            byte[] numArray = new byte[89600];
            for (int y = 0; y < 320; ++y)
            {
                for (int x = 0; x < 140; ++x)
                {
                    try
                    {
                        Color pixel = bitmap.GetPixel(x, y);
                        byte num1 = (byte)(pixel.R & 248U);
                        byte num2 = (byte)((uint)pixel.B >> 3);
                        byte num3 = (byte)((uint)pixel.G >> 5);
                        byte num4 = (byte)(num1 | (uint)num3);
                        byte num5 = (byte)((uint)(byte)((uint)pixel.G & 24U) << 3);
                        byte num6 = (byte)(num2 | num5);
                        byte num7 = (byte)(num4 ^ byte.MaxValue);
                        byte num8 = (byte)(num6 ^ byte.MaxValue);
                        numArray[index1] = num7;
                        ++index1;
                        numArray[index1] = num8;
                        ++index1;
                    }
                    catch
                    {
                    }
                }
            }
            for (int index2 = 0; index2 < 89600; ++index2)
                numArray[index2] = SwapByte(numArray[index2]);
            return numArray;
        }

        private byte[] GetBigImageByte(Bitmap img)
        {

            int index1 = 0;
            byte[] numArray = new byte[img.Height * img.Width * 2];
            for (int y = 0; y < img.Height; ++y)
            {
                for (int x = 0; x < img.Width; ++x)
                {
                    try
                    {
                        Color pixel = img.GetPixel(x, y);
                        byte num1 = (byte)(pixel.R & 248U);
                        byte num2 = (byte)((uint)pixel.B >> 3);
                        byte num3 = (byte)((uint)pixel.G >> 5);
                        byte num4 = (byte)(num1 | num3);
                        byte num5 = (byte)((uint)(byte)(pixel.G & 24U) << 3);
                        byte num6 = (byte)(num2 | num5);
                        byte num7 = (byte)(num4 ^ byte.MaxValue);
                        byte num8 = (byte)(num6 ^ byte.MaxValue);
                        numArray[index1] = num7;
                        ++index1;
                        numArray[index1] = num8;
                        ++index1;
                    }
                    catch
                    {
                    }
                }
            }
            for (int index2 = 0; index2 < img.Height * img.Width * 2; ++index2)
                numArray[index2] = SwapByte(numArray[index2]);
            return numArray;

        }

        private Bitmap GetImageFromByte(byte[] vs)
        {
            Bitmap bmp;
            using (var ms = new MemoryStream(vs))
            {
                bmp = new Bitmap(ms);
            }
            return bmp;
        }
        private byte SwapByte(byte b)
        {
            byte num = 0;
            if ((b & 128) > 0)
                num |= 1;
            if ((b & 64) > 0)
                num |= 2;
            if ((b & 32) > 0)
                num |= 4;
            if ((b & 16) > 0)
                num |= 8;
            if ((b & 8) > 0)
                num |= 16;
            if ((b & 4) > 0)
                num |= 32;
            if ((b & 2) > 0)
                num |= 64;
            if ((b & 1) > 0)
                num |= 128;
            return num;
        }
        private Bitmap CreateBitmapImageBigFont(string sImageText)
        {

            Bitmap bitmap1 = new Bitmap(140, 320);
            Font font = new Font("Arial", 45f, FontStyle.Bold, GraphicsUnit.Pixel);
            Graphics graphics1 = Graphics.FromImage(bitmap1);
            int width = (int)graphics1.MeasureString(sImageText, font).Width;
            int height = (int)graphics1.MeasureString(sImageText, font).Height;
            Bitmap bitmap2 = new Bitmap(bitmap1, new Size(width, height));
            Graphics graphics2 = Graphics.FromImage(bitmap2);
            graphics2.Clear(Color.White);
            graphics2.DrawString(sImageText, font, new SolidBrush(Color.Black), 0.0f, 0.0f);
            graphics2.Flush();
            bitmap2.RotateFlip(RotateFlipType.Rotate90FlipNone);
            return bitmap2;
        }
        private Bitmap CreateBitmapImageSmallFont(string sImageText)
        {
            Bitmap bitmap1 = new Bitmap(140, 320);
            Font font = new Font("Arial", 30f, FontStyle.Bold, GraphicsUnit.Pixel);
            Graphics graphics1 = Graphics.FromImage((Image)bitmap1);
            int width = (int)graphics1.MeasureString(sImageText, font).Width;
            int height = (int)graphics1.MeasureString(sImageText, font).Height;
            Bitmap bitmap2 = new Bitmap(bitmap1, new Size(width, height));
            Graphics graphics2 = Graphics.FromImage(bitmap2);
            graphics2.Clear(Color.White);
            graphics2.DrawString(sImageText, font, new SolidBrush(Color.Black), 0.0f, 0.0f);
            graphics2.Flush();
            bitmap2.RotateFlip(RotateFlipType.Rotate90FlipNone);
            return bitmap2;
        }

    }
}
