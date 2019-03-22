/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.6/15.2.3.6-3-222.js
 * @description Object.defineProperty - 'Attributes' is a Number object that uses Object's [[Get]] method to access the 'get' property (8.10.5 step 7.a)
 */


function testcase() {
        var obj = {};

        var numObj = new Number(-2);

        numObj.get = function () {
            return "numberGetProperty";
        };

        Object.defineProperty(obj, "property", numObj);

        return obj.property === "numberGetProperty";
    }
runTestCase(testcase);
