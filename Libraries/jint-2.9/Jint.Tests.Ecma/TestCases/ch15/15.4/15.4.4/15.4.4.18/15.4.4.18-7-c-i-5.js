/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.18/15.4.4.18-7-c-i-5.js
 * @description Array.prototype.forEach - element to be retrieved is own data property that overrides an inherited accessor property on an Array-like object
 */


function testcase() {

        var testResult = false;

        function callbackfn(val, idx, obj) {
            if (idx === 0) {
                testResult = (val === 11);
            }
        }

        var proto = {};

        Object.defineProperty(proto, "0", {
            get: function () {
                return 5;
            },
            configurable: true
        });

        var Con = function () { };
        Con.prototype = proto;

        var child = new Con();
        child.length = 2;
        Object.defineProperty(child, "0", {
            value: 11,
            configurable: true
        });

        Array.prototype.forEach.call(child, callbackfn);

        return testResult;
    }
runTestCase(testcase);
