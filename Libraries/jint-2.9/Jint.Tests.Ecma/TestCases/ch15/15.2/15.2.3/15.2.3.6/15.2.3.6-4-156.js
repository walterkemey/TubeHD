/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.6/15.2.3.6-4-156.js
 * @description Object.defineProperty - 'O' is an Array, 'name' is the length property of 'O', test RangeError is thrown when the [[Value]] field of 'desc' is boundary value 2^32 (15.4.5.1 step 3.c)
 */


function testcase() {

        var arrObj = [];

        try {
            Object.defineProperty(arrObj, "length", {
                value: 4294967296
            });
            return false;
        } catch (e) {
            return e instanceof RangeError;
        }

    }
runTestCase(testcase);
