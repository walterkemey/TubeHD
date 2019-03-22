/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch10/10.4/10.4.3/10.4.3-1-66gs.js
 * @description Strict - checking 'this' from a global scope (strict function declaration called by Function.prototype.apply())
 * @onlyStrict
 */

function f() { "use strict"; return this===undefined;};
if (! f.apply()){
    throw "'this' had incorrect value!";
}