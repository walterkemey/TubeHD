/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.3/15.4.3.2/15.4.3.2-1-5.js
 * @description Array.isArray applied to string primitive
 */


function testcase() {

        return !Array.isArray("abc");
    }
runTestCase(testcase);
