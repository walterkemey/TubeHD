/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.10/15.2.3.10-1-1.js
 * @description Object.preventExtensions throws TypeError if 'O' is undefined
 */


function testcase() {
        try {
            Object.preventExtensions(undefined);
        } catch (e) {
            return (e instanceof TypeError);
        }
    }
runTestCase(testcase);
