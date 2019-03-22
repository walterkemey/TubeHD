/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.12/15.2.3.12-1-3.js
 * @description Object.isFrozen - TypeError is thrown when the first param 'O' is a boolean
 */


function testcase() {
        try {
            Object.isFrozen(true);
        } catch (e) {
            return (e instanceof TypeError);
        }
    }
runTestCase(testcase);
