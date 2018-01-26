using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace GameHaxr
{
    public class Engine
    {
    
        #region Public properties
        // Environment name for Lua or AutoHotkey
        // Must be unique to avoid conflicts
        public string ServerName
        {
            get { return GlobalVar.ServerName; }
            set { GlobalVar.ServerName = value; }
        }

        // Allows files read and write in that directory
        // Asks user to allow or unalllow this before set
        public string ScriptDir
        {
            get { return GlobalVar.ScriptDir; }
            set { GlobalVar.ScriptDir = value; }
        }

        // Where libraries are stored, such as ones for specific games
        public string LibraryPath
        {
            get { return Path.Combine(Environment.CurrentDirectory, GlobalVar.LibraryPath); }
        }
        #endregion
        
        
        #region Load special
        public void LoadLibrary(string name) {
            // Execute library file contents to make the class accessable
        }  
        
        public void LoadTrainer(string title = "", string path = "index.html", int width = 500, int height = 500) {
            // Opens a new window that loads the HTML file for the trainer interface
            // This window can still use all classes WebGameHaxr gives to main browser
        }
        #endregion
        
        
        #region String functions
        // [Source]
        public byte[] StrToByte(string str) {
            return Encoding.ASCII.GetBytes(str);
        }
        // [Source]
        public string StrToHex(string str)
        {
            string aobStr = "";
            foreach (char c in str.ToCharArray())
                aobStr += String.Format("{0:X}", Convert.ToInt32(c)) + " ";

            return aobStr.Substring(0, aobStr.Length - 1);
        }
        
        // normal '\n' in JS has issues with C# file functions
        public string StrNewLine
        {
            get { return Environment.NewLine; }
        }
        #endregion
        
        
        #region Additonal 'standard' functions
        // Deprecated. Use "await sleep(ms)" instead
        // [Source]
        public void ThreadSleep(int sleepMS) {
            Thread.Sleep(sleepMS);
        }
        
        public void ShowMsg(string msg, string title = "", string buttons = "OK", string icon = "None", string defaultButton = "Button1")
        {
            // C# .NET MessageBox
            // MessageBox.Show( ... );
        }
        
        public void ExecuteJS(string js)
        {
            // Execute JavaScript in main browser on WebGameHaxr thread
        }
        
        
        #region Console log functions
        // [Source]
        private string FormatForJs(string text)
        {
            string textFormatted = text.Replace("\\", "\\\\").Replace(Environment.NewLine, "\\n").Replace("'", "\\'");
            return textFormatted;
        }
        #endregion
        
        #endregion
            
        
        // Change top-bar text on window
        public string TitleText
        {
            get { return browserHolder.Text; }
            set
            {
                try
                {
                    Action action = () => browserHolder.Text = value + " | GameHaxr";
                    browserHolder.BeginInvoke(action);

                }
                catch (Exception ex) { ConsoleError(ex); }
            }
        }
        
    }
}
