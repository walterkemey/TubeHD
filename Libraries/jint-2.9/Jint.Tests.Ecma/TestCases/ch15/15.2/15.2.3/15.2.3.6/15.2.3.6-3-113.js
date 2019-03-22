/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.6/15.2.3.6-3-113.js
 * @description Object.defineProperty - 'configurable' property in 'Attributes' is a String object (8.10.5 step 4.b)
 */


function testcase() {
        var obj = {};

        Object.defineProperty(obj, "property", { configurable: new String("bbq") });

        var beforeDeleted = obj.hasOwnProperty("property");

        delete obj.property;

        var afterDeleted = obj.hasOwnProperty("property");

        return beforeDeleted === true && afterDeleted === false;
    }
runTestCase(testcase);
