/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.17/15.4.4.17-1-11.js
 * @description Array.prototype.some applied to Date object
 */


function testcase() {
        function callbackfn(val, idx, obj) {
            return obj instanceof Date;
        }

        var obj = new Date();
        obj.length = 2;
        obj[0] = 11;
        obj[1] = 9;

        return Array.prototype.some.call(obj, callbackfn);
    }
runTestCase(testcase);
