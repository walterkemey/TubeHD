/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.19/15.4.4.19-8-c-ii-4.js
 * @description Array.prototype.map - k values are passed in acending numeric order
 */


function testcase() {

        var arr = [0, 1, 2, 3, 4, 5];
        var lastIdx = 0;
        var called = 0;
        var result = true;
        function callbackfn(val, idx, o) {
            called++;
            if (lastIdx !== idx) {
                result = false;
            } else {
                lastIdx++;
            }
        }

        arr.map(callbackfn);
        return result && arr.length === called;
    }
runTestCase(testcase);
