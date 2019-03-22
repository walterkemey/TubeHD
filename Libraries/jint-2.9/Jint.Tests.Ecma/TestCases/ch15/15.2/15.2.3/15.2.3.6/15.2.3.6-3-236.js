/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.6/15.2.3.6-3-236.js
 * @description Object.defineProperty - 'set' property in 'Attributes' is not present (8.10.5 step 8)
 */


function testcase() {
        var obj = {};

        Object.defineProperty(obj, "property", {
            get: function () {
                return 11;
            }
        });

        obj.property = 14;
        var desc = Object.getOwnPropertyDescriptor(obj, "property");
        return obj.hasOwnProperty("property") && obj.property === 11 && typeof desc.set === "undefined";
    }
runTestCase(testcase);
