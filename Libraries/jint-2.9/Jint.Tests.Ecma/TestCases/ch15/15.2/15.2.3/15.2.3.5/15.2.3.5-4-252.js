/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.5/15.2.3.5-4-252.js
 * @description Object.create - one property in 'Properties' is the JSON object that uses Object's [[Get]] method to access the 'get' property (8.10.5 step 7.a)
 */


function testcase() {
        JSON.get = function () {
            return "VerifyJSONObject";
        };

        try {
            var newObj = Object.create({}, {
                prop: JSON 
            });

            return newObj.prop === "VerifyJSONObject";
        } finally {
            delete JSON.get;
        }
    }
runTestCase(testcase);
