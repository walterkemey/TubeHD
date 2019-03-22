/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.3/15.3.4/15.3.4.5.2/15.3.4.5.2-4-10.js
 * @description [[Construct]] - length of parameters of 'target' is 1, length of 'boundArgs' is 0, length of 'ExtraArgs' is 1
 */


function testcase() {
        var func = function (x) {
            return new Boolean(arguments.length === 1 && x === 1 && arguments[0] === 1);
        };

        var NewFunc = Function.prototype.bind.call(func, {});

        var newInstance = new NewFunc(1);

        return newInstance.valueOf() === true;
    }
runTestCase(testcase);
