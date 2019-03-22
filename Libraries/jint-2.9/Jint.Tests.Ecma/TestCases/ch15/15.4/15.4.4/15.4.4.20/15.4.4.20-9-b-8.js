/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.20/15.4.4.20-9-b-8.js
 * @description Array.prototype.filter - deleting own property causes index property not to be visited on an Array-like object
 */


function testcase() {
        var accessed = false;
        var obj = { length: 2 };

        function callbackfn(val, idx, o) {
            accessed = true;
            return true;
        }

        Object.defineProperty(obj, "1", {
            get: function () {
                return 6.99;
            },
            configurable: true
        });

        Object.defineProperty(obj, "0", {
            get: function () {
                delete obj[1];
                return 0;
            },
            configurable: true
        });

        var newArr = Array.prototype.filter.call(obj, callbackfn);

        return newArr.length === 1 && newArr[0] === 0;
    }
runTestCase(testcase);
