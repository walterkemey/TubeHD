/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.3/15.2.3.3-2-36.js
 * @description Object.getOwnPropertyDescriptor - argument 'P' is applied to string '123���¦�cd' 
 */


function testcase() {
        var obj = { "123���¦�cd": 1 };

        var desc = Object.getOwnPropertyDescriptor(obj, "123���¦�cd");

        return desc.value === 1;
    }
runTestCase(testcase);
