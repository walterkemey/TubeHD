/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.7/15.2.3.7-5-b-173.js
 * @description Object.defineProperties - value of 'writable' property of 'descObj' is negative number (8.10.5 step 6.b)
 */


function testcase() {
        var obj = {};

        Object.defineProperties(obj, {
            property: {
                writable: -123
            }
        });

        obj.property = "isWritable";

        return obj.property === "isWritable";
    }
runTestCase(testcase);
