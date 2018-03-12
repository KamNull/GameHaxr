class LuaFileTalk {
    constructor(fileDir, mainDir) {
        this.fileDir = fileDir;
        lua.setVar('luaServerPath', '"' + fileDir.replace(/\\/g, '\\\\') + '"');
        this.mainDir = mainDir;

        // Add main class
        lua.execute(engineIO.fileReadText(this.mainDir + 'main.lua'));
    }

    execute(luaCode) {
        lua.execute('returnValue([[ ' + luaCode + ' ]])')
        return engineIO.fileReadText(this.fileDir + 'result.txt');
    }

    getVar(luaVar) {
        return this.execute('return ' + luaVar);
    }

}
