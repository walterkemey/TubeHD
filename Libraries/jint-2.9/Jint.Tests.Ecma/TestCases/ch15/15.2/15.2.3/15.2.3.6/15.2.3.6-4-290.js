/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.6/15.2.3.6-4-290.js
 * @description Object.defineProperty - 'O' is an Arguments object, 'name' is own property of 'O', and is deleted afterwards, and 'desc' is accessor descriptor, test 'name' is redefined in 'O' with all correct attribute values (10.6 [[DefineOwnProperty]] step 3)
 */


function testcase() {
        return (function () { 
            delete arguments[0];
            function getFunc() {
                return 10;
            }
            function setFunc(value) {
                this.setVerifyHelpProp = value;
            }
            Object.defineProperty(arguments, "0", {
                get: getFunc,
                set: setFunc,
                enumerable: true,
                configurable: true
            });
            return accessorPropertyAttributesAreCorrect(arguments, "0", getFunc, setFunc, "setVerifyHelpProp", true, true);
        }(0, 1, 2));    
    }
runTestCase(testcase);
