/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.16/15.4.4.16-7-c-ii-8.js
 * @description Array.prototype.every - element changed by callbackfn on previous iterations is observed
 */


function testcase() {

        var obj = { 0: 11, 1: 12, length: 2 };

        function callbackfn(val, idx, o) {
            if (idx === 0) {
                obj[idx + 1] = 8;
            }
            return val > 10;
        }

       

        return !Array.prototype.every.call(obj, callbackfn);
    }
runTestCase(testcase);
