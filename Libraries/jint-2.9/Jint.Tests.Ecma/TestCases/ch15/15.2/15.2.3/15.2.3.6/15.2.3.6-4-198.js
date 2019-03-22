/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.6/15.2.3.6-4-198.js
 * @description Object.defineProperty - 'O' is an Array, 'name' is an array index named property, 'name' property doesn't exist in 'O', test TypeError is thrown when 'O' is not extensible (15.4.5.1 step 4.c)
 */


function testcase() {
        var arrObj = [];
        Object.preventExtensions(arrObj);

        try {
            var desc = { value: 1 };
            Object.defineProperty(arrObj, "0", desc);
            return false;
        } catch (e) {
            return e instanceof TypeError && (arrObj.hasOwnProperty("0") === false);
        }
    }
runTestCase(testcase);
