using AutoHotkey.Interop;

namespace WebGameHaxr
{
    // [Source]
    class AHK
    {
        AutoHotkeyEngine ahk = AutoHotkeyEngine.Instance;

        public void Execute(string ahkCode)
        {
            ahk.ExecRaw(ahkCode);
        }

        public void SetVar(string varName, string varValue)
        {
            ahk.SetVar(varName, varValue);
        }
        public string GetVar(string varName)
        {
            return ahk.GetVar(varName);
        }

        public string Eval(string ahkCode)
        {
            return ahk.Eval(ahkCode);
        }

        public void ExecFunc(string funcName, string param1 = null, string param2 = null, string param3 = null, string param4 = null, string param5 = null, string param6 = null, string param7 = null, string param8 = null, string param9 = null, string param10 = null)
        {
            ahk.ExecFunction(funcName, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);
        }

        public void ExecLabel(string labelName)
        {
            ahk.ExecLabel(labelName);
        }


        public void LoadFile(string filePath)
        {
            ahk.LoadFile(filePath);
        }

    }
}
