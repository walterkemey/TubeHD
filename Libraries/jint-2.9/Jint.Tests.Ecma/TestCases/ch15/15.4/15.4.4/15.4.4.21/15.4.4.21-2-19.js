/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.21/15.4.4.21-2-19.js
 * @description Array.prototype.reduce applied to Function object, which implements its own property get method
 */


function testcase() {

        function callbackfn(prevVal, curVal, idx, obj) {
            return (obj.length === 2);
        }

        var fun = function (a, b) {
            return a + b;
        };
        fun[0] = 12;
        fun[1] = 11;
        fun[2] = 9;

        return Array.prototype.reduce.call(fun, callbackfn, 1) === true;
    }
runTestCase(testcase);
