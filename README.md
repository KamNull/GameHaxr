NOTE: This does not contain major source code, as it is intended just for documentation and learning how to use WebGameHaxr in JavaScript etc.

# WebGameHaxr
A memory-based and automation hacking "engine" specifically optimized for browser games, allowing you to easily make your own scripts with UIs using JavaScript and HTML by exposing the WebGameHaxr C# .NET classes directly to the browser.

The easy way to make advanced hacks and trainers (UIs) for your favorite browser games.  
Thanks to Cheat Engine's Lua and AutoHotKey, you can also integrate Lua and AutoHotKey into your Javascript, or even code just with them, for more advanced usage.

# Interfaces For Your Hacks
You can use a regular HTML document with any framework, such as Bootstrap, to make beautiful interfaces for your hack.

# What WebGameHaxr Exposes To JavaScript
Currently, you get 3 major classes from WebGameHaxr to use in JavaScript:
- `engine` | The core class for important variables and functions, including browser-specific ones.
- `lua`    | Access to Cheat Engine Lua. Premade Lua functions and properties for JavaScript, raw Lua execution etc.
- `ahk`    | Access to AutoHotKey. Premade AutoHotKey functions and properties for JavaScript, raw AutoHotKey execution etc.

# Usage & Examples
To use WebGameHaxr, and hacks developed with it, you need to download it.  
(Not out yet, still in major development)
```js
// init is automatically ran when loaded
async function init() {
     // "Server" environment name. Must be unique to avoid conflicts.
     // Should be the first thing set
     engine.serverName = 'WebGameHaxr_Example';
     
     // Initalize everything needed here
     // ...
}
```
