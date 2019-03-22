/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.17/15.4.4.17-3-18.js
 * @description Array.prototype.some - value of 'length' is a string that can't convert to a number
 */


function testcase() {

        var accessed = false;

        function callbackfn(val, idx, obj) {
            accessed = true;
            return val > 10;
        }

        var obj = { 0: 11, 1: 21, length: "two" };

        return !Array.prototype.some.call(obj, callbackfn) && !accessed;
    }
runTestCase(testcase);
