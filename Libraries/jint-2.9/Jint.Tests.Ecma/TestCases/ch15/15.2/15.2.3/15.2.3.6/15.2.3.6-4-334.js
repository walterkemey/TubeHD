/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.6/15.2.3.6-4-334.js
 * @description ES5 Attributes - property ([[Writable]] is true, [[Enumerable]] is true, [[Configurable]] is false) is enumerable
 */


function testcase() {
        var obj = {};

        Object.defineProperty(obj, "prop", {
            value: 2010,
            writable: true,
            enumerable: true,
            configurable: false
        });
        var propertyDefineCorrect = obj.hasOwnProperty("prop");
        var desc = Object.getOwnPropertyDescriptor(obj, "prop");
        for (var p in obj) {
            if (p === "prop") {
                return propertyDefineCorrect && desc.enumerable === true;
            }
        }
        return false;
    }
runTestCase(testcase);
