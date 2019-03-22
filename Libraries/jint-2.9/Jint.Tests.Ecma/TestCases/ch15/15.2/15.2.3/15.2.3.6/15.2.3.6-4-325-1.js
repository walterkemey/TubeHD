/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.6/15.2.3.6-4-325-1.js
 * @description Object.defineProperty - 'O' is an Arguments object which created with function take formal parameters, 'name' is own property of [[ParameterMap]] of 'O', test 'name' is deleted if 'name' is configurable and 'desc' is accessor descriptor (10.6 [[DefineOwnProperty]] step 5.a.i)
 */


function testcase() {
        var argObj = (function (a, b, c) { return arguments; })(1, 2, 3);
        var accessed = false;

        Object.defineProperty(argObj, 0, {
            get: function () {
                accessed = true;
                return 12;
            }
        });

        return argObj[0] === 12 && accessed;
    }
runTestCase(testcase);
