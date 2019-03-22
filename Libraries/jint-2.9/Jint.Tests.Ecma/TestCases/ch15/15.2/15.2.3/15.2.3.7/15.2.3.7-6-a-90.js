/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.7/15.2.3.7-6-a-90.js
 * @description Object.defineProperties will not throw TypeError when P.configurable is false, both properties.[[Get]] and P.[[Get]] are two objects which refer to the same object (8.12.9 step 11.a.ii)
 */


function testcase() {

        var obj = {};

        function set_func(value) {
            obj.setVerifyHelpProp = value;
        }
        function get_func() {
            return 10;
        }

        Object.defineProperty(obj, "foo", {
            get: get_func,
            set: set_func,
            enumerable: false,
            configurable: false
        });

        Object.defineProperties(obj, {
            foo: {
                get: get_func
            }
        });
        return accessorPropertyAttributesAreCorrect(obj, "foo", get_func, set_func, "setVerifyHelpProp", false, false);
    }
runTestCase(testcase);
