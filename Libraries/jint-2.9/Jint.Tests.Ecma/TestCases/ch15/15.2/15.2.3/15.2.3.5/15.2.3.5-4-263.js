/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.5/15.2.3.5-4-263.js
 * @description Object.create - 'get' property of one property in 'Properties' is a function (8.10.5 step 7.b)
 */


function testcase() {
        var newObj = Object.create({}, {
            prop: {
                get: function () { }
            }
        });

        return newObj.hasOwnProperty("prop") && typeof newObj.prop === "undefined";
    }
runTestCase(testcase);
