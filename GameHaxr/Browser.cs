using System;

namespace WebGameHaxr
{
    public class Browser
    {
    
        public void ScreenshotBrowser(string filename = "BrowserScreenshot.png")
        {
            Bitmap bitmap = ControlSnapshot.Snapshot(GlobalVar.Browser);
            bitmap.Save(filename);
        }
        
        #region Input to browser
        
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
        
        #endregion
        
    }
}
