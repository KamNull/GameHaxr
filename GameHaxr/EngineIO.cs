using CefSharp;
using System;
using System.Collections.Generic;
using System.IO;

namespace GameHaxr
{
    // [Source]
    class EngineIO
    {
        public string ScriptDir
        {
            get { return GlobalVar.ScriptDir; }
            set { GlobalVar.ScriptDir = value; }
        }


        #region File IO
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

        #region Folder IO
        public string[] FolderList(string dir, bool safeName = false)
        {
            try
            {
                switch (dir)
                {
                    case "|user-hacks|":
                        dir = Path.Combine(Environment.CurrentDirectory, "Hacks");
                        break;

                    default:
                        dir = ScriptPath(dir);
                        break;
                }

                if (!safeName)
                    return Directory.GetDirectories(dir);

                List<string> dirList = new List<string>();
                foreach (string dirPath in Directory.GetDirectories(dir))
                {
                    dirList.Add(Path.GetFileName(dirPath));
                }
                return dirList.ToArray();
            }
            catch (Exception ex)
            {
                ConsoleError(ex);
                return new string[] { "|error|", ex.Message };
            }
        }
        #endregion

    }
}
