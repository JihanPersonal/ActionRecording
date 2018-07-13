using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SikuliSharp;
using System.Windows.Forms;
namespace SikuliTest
{
    public enum Keys
    {
        Enter,
        Down,
        Up
    }
    public class SikuliRunner
    {
        private static ISikuliSession _session=null;
        private static ISikuliSession Session
        {
            get
            {
                if (SessionInitialized)
                    return _session;
                else
                {
                    InitializeSession();
                    return _session;
                }
            }
        }
        public static bool SessionInitialized = false;
        /// <summary>
        /// Initialzie the sessions for the Runner
        /// </summary>
        public static void InitializeSession()
        {
            _session = Sikuli.CreateSession();
            SessionInitialized = true;
        }
        /// <summary>
        /// Type the Input string
        /// </summary>
        /// <param name="input"></param>
        public static void Type(string input)
        {
            Session.Type(input);
        }
        /// <summary>
        /// Click the Pattern Found on screen
        /// </summary>
        /// <param name="pattern"></param>
        public static void Click(IPattern pattern)
        {
            Session.Click(pattern);
        }
        /// <summary>
        /// Wait till found the Pattern or Timeout
        /// </summary>
        /// <param name="pattern"></param>
        public static void Wait(IPattern pattern)
        {
            Session.Wait(pattern);
        }
        /// <summary>
        /// Wait till Found or return false if Timeout;
        /// </summary>
        /// <param name="pattern"></param>
        public static bool Wait(IPattern pattern, double timeout)
        {
            try
            {
                Session.Wait(pattern, (float)timeout);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Searching the screen for Pattern. Scroll Down if cannot find it till Timeout.
        /// </summary>
        /// <param name="pattern">Pattern to search</param>
        /// <param name="timeout">Timeout in Seconds</param>
        /// <returns></returns>
        public static bool SearchDown(IPattern pattern, double timeout)
        {
            DateTime start = DateTime.Now;
            while (!Wait(pattern, (float)0.5))
            {
                PressKey(Keys.Down);
                TimeSpan usedtime = DateTime.Now - start;
                if (usedtime.TotalSeconds > timeout)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Simulate Press Keyboard Keys
        /// </summary>
        /// <param name="key"></param>
        public static void PressKey(Keys key)
        {
            string keystring = Getkeystring(key);
            int SendCounts = 1;

            if (key == Keys.Down)
                SendCounts = 4;

            for (int i = 0; i < SendCounts; i++)
            {
                System.Threading.Thread.Sleep(300);
                SendKeys.SendWait(keystring);
            }
        }

        private static string Getkeystring(Keys key)
        {
            string keystring = string.Empty;
            switch (key)
            {
                case Keys.Enter:
                    keystring = "{Enter}";
                    break;
                case Keys.Down:
                    keystring = "{DOWN}";
                    break;
            }
            return keystring;
        }


    }
}
