/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.22/15.4.4.22-9-c-ii-7.js
 * @description Array.prototype.reduceRight - unhandled exceptions happened in callbackfn terminate iteration
 */


function testcase() {

        var accessed = false;

        function callbackfn(prevVal, curVal, idx, obj) {
            if (idx < 10) {
                accessed = true;
            }
            if (idx === 10) {
                throw new Error("Exception occurred in callbackfn");
            }
        }

        var obj = { 0: 11, 4: 10, 10: 8, length: 20 };

        try {
            Array.prototype.reduceRight.call(obj, callbackfn, 1);
            return false;
        } catch (ex) {
            return !accessed;
        }
    }
runTestCase(testcase);
