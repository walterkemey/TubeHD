/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch10/10.4/10.4.3/10.4.3-1-16gs.js
 * @description Strict - checking 'this' from a global scope (New'ed Function constructor includes strict directive prologue)
 * @onlyStrict
 */

var f = new Function("\"use strict\";\nreturn typeof this;");
if (f() !== "undefined") {
    throw "'this' had incorrect value!";
}