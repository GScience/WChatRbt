using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WChatRbtLib
{
    public class WChat
    {
        static QRCode QRCodeWindow;

        private static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }
        public static string GetUUID()
        {
            byte[] getUUIDJS = HTTP.SendGetRequest("https://login.wx.qq.com/jslogin?appid=wx782c26e4c19acffb&fun=new&lang=zh_CN&_=" + GetTimeStamp());

            string getUUIDJSString = Encoding.Default.GetString(getUUIDJS);

            return getUUIDJSString.Substring(50, 12);
        }
        public static void GetLoginQRCode(string UUID)
        {
            QRCodeWindow = new QRCode(HTTP.SendGetRequest("https://login.weixin.qq.com/qrcode/" + UUID + "?t=webwx&_=" + GetTimeStamp()));

            QRCodeWindow.Show();
            QRCodeWindow.Refresh();
        }
        public static string WaitForLoginAndGetCookie(string UUID)
        {
            //未扫码
            bool hasScanQRCode = false;
            bool hasScanQRCodeAndConfirm = false;

            string getCookieURL = "";

            while (!hasScanQRCode)
            {
                byte[] getScanCodeJS = HTTP.SendGetRequest("https://login.weixin.qq.com/cgi-bin/mmwebwx-bin/login?tip=1&uuid=" + UUID + "&_=" + GetTimeStamp());
                string getScanCodeString = Encoding.Default.GetString(getScanCodeJS);

                string state = getScanCodeString.Substring(12, 3);

                if (state == "200")
                {
                    hasScanQRCode = true;
                    hasScanQRCodeAndConfirm = true;

                    getCookieURL = getScanCodeString.Substring(37, getScanCodeString.Length - 37);
                }

                if (state == "201")
                    hasScanQRCode = true;
            }

            //扫码
            QRCodeWindow.LoginState.Text = "等待用户确认...";
            QRCodeWindow.Refresh();

            while (!hasScanQRCodeAndConfirm)
            {
                byte[] getScanCodeJS = HTTP.SendGetRequest("https://login.weixin.qq.com/cgi-bin/mmwebwx-bin/login?tip=0&uuid=" + UUID + "&_=" + GetTimeStamp());
                string getScanCodeString = Encoding.Default.GetString(getScanCodeJS);

                string state = getScanCodeString.Substring(12, 3);

                if (state == "200")
                {
                    hasScanQRCodeAndConfirm = true;

                    getCookieURL = getScanCodeString.Substring(38, getScanCodeString.Length - 40);
                }
            }
            QRCodeWindow.LoginState.Text = "扫码成功...";
            QRCodeWindow.Refresh();

            QRCodeWindow.Close();
            return getCookieURL;
        }
        public static void login(string cookieURL)
        {
            //get login xml data
            byte[] getLoginJS = HTTP.SendGetRequest(cookieURL + "&fun=new");
            string getLoginString = Encoding.Default.GetString(getLoginJS);

            XmlDocument loginXML = new XmlDocument();
            loginXML.LoadXml(getLoginString);

            XmlNode getMainElement = loginXML.DocumentElement;

            string skey = getMainElement.SelectNodes("/error/skey").Item(0).FirstChild.Value;
            string wxsid = getMainElement.SelectNodes("/error/wxsid").Item(0).FirstChild.Value;
            string wxuin = getMainElement.SelectNodes("/error/wxuin").Item(0).FirstChild.Value;
            string passTicket = getMainElement.SelectNodes("/error/pass_ticket").Item(0).FirstChild.Value;

            byte[] getWChatInitJS = HTTP.SendPostRequest("https://wx2.qq.com/cgi-bin/mmwebwx-bin/webwxinit", 
                "{ BaseRequest: { Uin: " + wxuin + ", Sid: " + wxsid + ", Skey: " + skey + ", DeviceID: e160730445852638, }}");

            string getWChatInitString = Encoding.Default.GetString(getWChatInitJS);
        }
    }
}
