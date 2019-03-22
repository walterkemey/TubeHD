/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.6/15.2.3.6-3-215.js
 * @description Object.defineProperty - 'get' property in 'Attributes' is own accessor property without a get function (8.10.5 step 7.a)
 */


function testcase() {
        var obj = {};

        var attributes = {};
        Object.defineProperty(attributes, "get", {
            set: function () { }
        });

        Object.defineProperty(obj, "property", attributes);

        return typeof obj.property === "undefined" && obj.hasOwnProperty("property");
    }
runTestCase(testcase);
