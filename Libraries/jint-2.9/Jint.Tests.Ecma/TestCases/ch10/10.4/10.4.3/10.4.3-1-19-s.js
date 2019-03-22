/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch10/10.4/10.4.3/10.4.3-1-19-s.js
 * @description Strict Mode - checking 'this' (indirect eval used within strict mode)
 * @onlyStrict
 */
    
function testcase() {
"use strict";
var my_eval = eval;
return my_eval("this") === fnGlobalObject();
}
runTestCase(testcase);