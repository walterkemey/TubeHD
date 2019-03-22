/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.17/15.4.4.17-7-b-10.js
 * @description Array.prototype.some - deleting property of prototype causes prototype index property not to be visited on an Array-like Object
 */


function testcase() {
        var accessed = false;
        function callbackfn(val, idx, obj) {
            accessed = true;
            return idx === 1;
        }
        var arr = { 2: 2, length: 20 };

        Object.defineProperty(arr, "0", {
            get: function () {
                delete Object.prototype[1];
                return 0;
            },
            configurable: true
        });

        try {
            Object.prototype[1] = 1;
            return !Array.prototype.some.call(arr, callbackfn) && accessed;
        } finally {
            delete Object.prototype[1];
        }
    }
runTestCase(testcase);
