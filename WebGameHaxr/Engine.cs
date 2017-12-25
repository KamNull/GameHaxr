namespace WebGameHaxr
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
        
        
        #region File IO | [Source]
        private string ScriptPath(string path)
        {
            return Path.Combine(ScriptDir, path);
        }

        public string FileReadText(string path)
        {
            try
            {
                return File.ReadAllText(ScriptPath(path));
            }
            catch (Exception ex)
            {
                ConsoleError(ex);
                return null;
            } 
        }
        public byte[] FileReadBytes(string path)
        {
            try
            {
                return File.ReadAllBytes(ScriptPath(path));
            }
            catch (Exception ex)
            {
                ConsoleError(ex);
                return null;
            }
        }

        public void FileWriteText(string path, string contents)
        {
            try
            {
                File.WriteAllText(ScriptPath(path), contents);
            }
            catch (Exception ex)
            {
                ConsoleError(ex);
            }
        }
        public void FileAppendText(string path, string contents)
        {
            try
            {
                File.AppendAllText(ScriptPath(path), contents);
            }
            catch (Exception ex)
            {
                ConsoleError(ex);
            }
        }
        public void FileWriteBytes(string path, byte[] bytes)
        {
            try
            {
                File.WriteAllBytes(ScriptPath(path), bytes);
            }
            catch (Exception ex)
            {
                ConsoleError(ex);
            }
        }
        #endregion
        
        
        #region Browser specific
        // [Source]
        public void ScreenshotBrowser(string filename = "BrowserScreenshot.png")
        {
            Bitmap bitmap = ControlSnapshot.Snapshot(GlobalVar.Browser);
            bitmap.Save(filename);
        }
        #endregion
        
        #region Mouse
        public void MouseDown(int mouseX, int mouseY)
        {
            // Direct mouse input to browser
        }
        public void MouseRightDown(int mouseX, int mouseY)
        {
            // Direct mouse input to browser
        }

        public void MouseUp(int mouseX, int mouseY)
        {
            // Direct mouse input to browser
        }
        public void MouseRightUp(int mouseX, int mouseY)
        {
            // Direct mouse input to browser
        }
        #endregion
        
        
        #region Keys
        private int _keyActive = 0x00;
        public int KeyActive
        {
            get { return _keyActive; }
            set { _keyActive = value; }
        }

        public void KeyDown(string vkCode, bool useActive = false)
        {
            // Direct key input to browser
        }
        public void KeyUp(string vkCode, bool useActive = false)
        {
            // Direct key input to browser
        }
        #endregion
    }
}
