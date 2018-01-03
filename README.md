NOTE: This does not contain major source code, as it is intended just for [documentation](https://github.com/KamNull/GameHaxr/wiki) and learning how to use GameHaxr in JavaScript etc.

# GameHaxr
A memory-based and automation hacking "engine", allowing you to easily make your own hack or macro scripts with UIs using JavaScript and HTML by exposing the GameHaxr C# .NET classes directly to the browser.

The easy way to make advanced hacks and trainers (UIs) for your favorite desktop or browser games.  
Thanks to Cheat Engine's Lua and AutoHotKey, you can also integrate Lua and AutoHotKey into your Javascript, or even code just with them, for more advanced usage.

# Interfaces For Your Hacks
You can use a regular HTML document with any framework, such as Bootstrap, to make beautiful interfaces for your hack.

# What GameHaxr Exposes To JavaScript
Currently, you get 4 major classes from GameHaxr to use in JavaScript:
- `engine`  | The core class for important variables and functions.
- `lua`     | Access to Cheat Engine Lua. Premade Lua functions and properties for JavaScript, raw Lua execution etc.
- `ahk`     | Access to AutoHotKey. Premade AutoHotKey functions and properties for JavaScript, raw AutoHotKey execution etc.
- `browser` | Useful for hacking browser games. Direct key and mouse input to browser, screenshot browser etc.

# Usage & Examples
To use GameHaxr, and hacks developed with it, you need to download it.  
(Not out yet, still in major development)

For a quick execution and look over available functions and properties, you can use the Developer Tool's Console.
```javascript
// init is automatically ran when loaded
function init() {
     // "Server" environment name. Must be unique to avoid conflicts.
     // Should be the first thing set
     engine.serverName = 'GameHaxr_Example_InfHealth';
     
     // Initalize everything needed
     // ...
     
     getHealthFromAob();
}

function getHealthFromAob() {
     // Returns amount of results found, and puts them in the Lua variable 'healthAob'
     let healthAobLength = lua.scanAob('healthAob', '00 00 00');
     
     if(healthAobLength <= 0) {
          // engine.showMsg = MessageBox.Show with params as strings
          engine.showMsg('Unable to find the health value in memory.', 'Could not find health value');

          engine.stopScript();
          return;
     }
     // Store first result in healthAddr
     lua.execute('healthAddr = healthAob[0]');
     
     loop();
}

async function loop() {
     // Only refill if 50 HP
     if(lua.bool('readFloat(healthAddr) <= 50')) {
     
          // use 'return' in lua.execute for returning value to JS
          let healthWrite = lua.execute('return writeFloat(healthAddr, 100)');
          
          if(healthWrite != 1) 
               console.error('An error occured when trying to write to health value.');
          }
          
     }
     
     await sleep(100);
     loop();
}

```

# More Information
[GameHaxr Wiki](https://github.com/KamNull/GameHaxr/wiki)  
[Cheat Engine Lua](http://wiki.cheatengine.org/index.php?title=Lua)  
[AutoHotKey](https://autohotkey.com/docs/AutoHotkey.htm)
