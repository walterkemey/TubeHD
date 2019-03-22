/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.18/15.4.4.18-5-14.js
 * @description Array.prototype.forEach - the Math object can be used as thisArg
 */


function testcase() {

        var result = false;
        function callbackfn(val, idx, obj) {
            result = (this === Math);
        }

        [11].forEach(callbackfn, Math);
        return result;
    }
runTestCase(testcase);
