/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.20/15.4.4.20-5-17.js
 * @description Array.prototype.filter - the JSON object can be used as thisArg
 */


function testcase() {
        var accessed = false;

        function callbackfn(val, idx, obj) {
            accessed = true;
            return this === JSON;
        }

        var newArr = [11].filter(callbackfn, JSON);

        return newArr[0] === 11 && accessed;
    }
runTestCase(testcase);
