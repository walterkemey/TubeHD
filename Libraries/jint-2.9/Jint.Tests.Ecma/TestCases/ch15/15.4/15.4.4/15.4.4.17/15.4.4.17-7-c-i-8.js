/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.17/15.4.4.17-7-c-i-8.js
 * @description Array.prototype.some - element to be retrieved is inherited data property on an Array
 */


function testcase() {

        var kValue = {};

        function callbackfn(val, idx, obj) {
            if (0 === idx) {
                return kValue === val;
            }
            return false;
        }

        try {
            Array.prototype[0] = kValue;

            return [, ].some(callbackfn);
        } finally {
            delete Array.prototype[0];
        }
    }
runTestCase(testcase);
