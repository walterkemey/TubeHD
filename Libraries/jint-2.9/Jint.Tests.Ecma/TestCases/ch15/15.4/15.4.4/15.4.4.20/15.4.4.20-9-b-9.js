/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.20/15.4.4.20-9-b-9.js
 * @description Array.prototype.filter - deleting own property causes index property not to be visited on an Array
 */


function testcase() {

        function callbackfn(val, idx, obj) {
            return true;
        }
        var arr = [1, 2];

        Object.defineProperty(arr, "1", {
            get: function () {
                return "6.99";
            },
            configurable: true
        });

        Object.defineProperty(arr, "0", {
            get: function () {
                delete arr[1];
                return 0;
            },
            configurable: true
        });

        var newArr = arr.filter(callbackfn);

        return newArr.length === 1 && newArr[0] === 0;
    }
runTestCase(testcase);
