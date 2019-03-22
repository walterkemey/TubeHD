/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.21/15.4.4.21-3-17.js
 * @description Array.prototype.reduce - 'length' is a string containing a number with leading zeros
 */


function testcase() {

        function callbackfn(prevVal, curVal, idx, obj) {
            return (curVal === 11 && idx === 1);
        }

        var obj = { 1: 11, 2: 9, length: "0002.00" };

        return Array.prototype.reduce.call(obj, callbackfn, 1) === true;
    }
runTestCase(testcase);
