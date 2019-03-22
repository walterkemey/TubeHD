/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.7/15.2.3.7-6-a-302.js
 * @description Object.defineProperties - 'O' is an Arguments object, 'P' is generic property, and 'desc' is data descriptor, test 'P' is defined in 'O' with all correct attribute values (10.6 [[DefineOwnProperty]] step 4)
 */


function testcase() {
        var arg = (function () {
            return arguments;
        }(1, 2, 3));

        Object.defineProperties(arg, {
            "genericProperty": {
                value: 1001,
                writable: true,
                enumerable: true,
                configurable: true
            }
        });

        return dataPropertyAttributesAreCorrect(arg, "genericProperty", 1001, true, true, true);
    }
runTestCase(testcase);
