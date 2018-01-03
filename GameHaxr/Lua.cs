using System;

namespace WebGameHaxr
{
    // [Source]
    class Lua
    {
        LuaCore luaCore = new LuaCore();

        public int Execute(string luaCode)
        {
            return luaCore.Execute(luaCode);
        }

        public bool Bool(string luaConditons)
        {
            return luaCore.Bool(luaConditons);
        }

        #region Lua functions for JS

        public void ShowMsg(string luaMessage)
        {
            luaCore.Execute("showMessage(\"" + luaMessage + "\")");
        }

        public int ScanAob(string luaVarAOB, string aob)
        {
            luaCore.Execute(luaVarAOB + " = AOBScan(\"" + aob + "\")");

            if (luaCore.Bool(luaVarAOB + " == Nil"))
                return 0;

            return luaCore.Execute("return " + luaVarAOB + ".Count");
        }

        public int ReplaceAobResults(string luaVarAOB, string replaceWith, string writeFunc)
        {
            if (luaCore.Bool(luaVarAOB + " == Nil"))
            {
                return 0;
            }

            luaCore.Execute("for i=0," + luaVarAOB + ".Count-1 do " +
                            writeFunc + "(" + luaVarAOB + "[i], " + replaceWith + ") " +
                        "end");

            return luaCore.Execute("return " + luaVarAOB + ".Count");
        }

        #endregion

    }
}
