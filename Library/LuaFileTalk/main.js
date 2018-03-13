class LuaFileTalk {
    constructor(fileDir, mainDir, refreshRate = 100) {
        // Parse string values into actual type
        this.autoParse = true;
        // Set file directory
        this.fileDir = fileDir;
        lua.setVar('luaServerPath', '"' + fileDir.replace(/\\/g, '\\\\') + '"');
        this.mainDir = mainDir;

        // Add main class
        lua.execute(engineIO.fileReadText(this.mainDir + 'main.lua'));

        if (refreshRate > 0) {
            // Check for JS requests from Lua
            setInterval(this.checkForJS, refreshRate, this.fileDir);
        }
    }

    execute(luaCode) {
        lua.execute('returnValue([[' + luaCode + ']])')
        if (!this.autoParse)
            return engineIO.fileReadText(this.fileDir + 'result.txt');
        else
            return this.parseVar(engineIO.fileReadText(this.fileDir + 'result.txt'));
    }

    getVar(luaVar) {
        return this.execute('return ' + luaVar);
    }

    parseVar(luaVarStr) {
        if (luaVarStr.toLowerCase() == 'nil') return null;
        // Array
        if (luaVarStr.startsWith('{') && luaVarStr.endsWith('}')) {
            // Remove { } and put [ ]
            return window.eval('[' + luaVarStr.slice(1, -1) + ']');
        }

        // Any other value
        return window.eval(luaVarStr);
    }

    checkForJS(fileDir) {
        if (lua.bool('requestedJS')) {
            // Avoid duplicate calls
            lua.setVar('requestedJS', 'false');
            // Execute the JavaScript
            console.info('Recieved JavaScript request from Lua.');
            window.eval(engineIO.fileReadText(fileDir + 'javascript.txt'));
            return true;
        }
        return false;
    }

}
