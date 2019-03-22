/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.22/15.4.4.22-9-c-i-18.js
 * @description Array.prototype.reduceRight - element to be retrieved is own accessor property without a get function on an Array
 */


function testcase() {

        var testResult = false;
        function callbackfn(prevVal, curVal, idx, obj) {
            if (idx === 1) {
                testResult = (typeof curVal === "undefined");
            }
        }

        var arr = [0, , 2];

        Object.defineProperty(arr, "1", {
            set: function () { },
            configurable: true
        });

        arr.reduceRight(callbackfn, "initialValue");
        return testResult;
         
    }
runTestCase(testcase);
