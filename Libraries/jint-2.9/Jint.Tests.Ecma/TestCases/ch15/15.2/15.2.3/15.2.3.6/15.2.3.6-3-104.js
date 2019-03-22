/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.6/15.2.3.6-3-104.js
 * @description Object.defineProperty - 'configurable' property in 'Attributes' is +0 (8.10.5 step 4.b)
 */


function testcase() {
        var obj = {};

        Object.defineProperty(obj, "property", { configurable: +0 });

        var beforeDeleted = obj.hasOwnProperty("property");

        delete obj.property;

        var afterDeleted = obj.hasOwnProperty("property") && typeof (obj.property) === "undefined";

        return beforeDeleted === true && afterDeleted === true;
    }
runTestCase(testcase);
