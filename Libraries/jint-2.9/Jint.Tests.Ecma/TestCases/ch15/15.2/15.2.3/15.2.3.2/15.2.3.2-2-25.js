/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.2/15.2.3.2-2-25.js
 * @description Object.getPrototypeOf returns the [[Prototype]] of its parameter (Date object)
 */


function testcase() {
        var obj = new Date();

        return Object.getPrototypeOf(obj) === Date.prototype;
    }
runTestCase(testcase);
