﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace LoadsheddingSystem.Models
{

    public class Sms
    {
        public string S { get; private set; }
        public string S2 { get; private set; }

        public Sms()
        {
            S = String.Empty;
            S2 = String.Empty;
        }

        public Sms(string s, string s2)
        {

            S = s;
            S2 = s2;
        }
        public string MyString { get; set; }

        public string Username;

        public string UserName
        {
            get { return Username = "nduduzodlamini5@gmail.com"; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                Username = "nduduzodlamini5@gmail.com";
            }
        }

        public string Passwords;

        public string Password
        {
            get { return Passwords = "Dut0514"; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                Passwords = "Dut0514";
            }
        }
        public string Message { get; set; }
        public string Number { get; set; }
        public string MailError { get; set; }

        public string ReadHtmlPage(string url)
        {
            try
            {
                var objRequest = WebRequest.Create(url);
                var objResponse = objRequest.GetResponse();
                // ReSharper disable once AssignNullToNotNullAttribute
                StreamReader sr = new StreamReader(stream: objResponse.GetResponseStream());
                var result = sr.ReadToEnd();
                sr.Close();
                return result;
            }
            catch (Exception er)
            {
                string s = er.Message;
                return s;
            }
        }

        public void Send_SMS(string num, string msgz)
        {
            {
                MyString = "http://www.winsms.net/api/batchmessage.asp?User=";
                MyString = MyString + UserName + "&Password=" + Password + "&Delivery=No";
                MyString = MyString + "&Message=" + msgz + "&Numbers=" + num + ";";
                MailError = (ReadHtmlPage(MyString));
                MailError = ("Your message has been sent");
            }
        }
    }
}