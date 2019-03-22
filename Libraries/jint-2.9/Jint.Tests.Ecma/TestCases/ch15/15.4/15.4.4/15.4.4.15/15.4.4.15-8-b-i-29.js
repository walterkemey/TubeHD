/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.15/15.4.4.15-8-b-i-29.js
 * @description Array.prototype.lastIndexOf - side-effects are visible in subsequent iterations on an Array-like object
 */


function testcase() {

        var preIterVisible = false;
        var obj = { length: 3 };

        Object.defineProperty(obj, "2", {
            get: function () {
                preIterVisible = true;
                return false;
            },
            configurable: true
        });

        Object.defineProperty(obj, "1", {
            get: function () {
                if (preIterVisible) {
                    return true;
                } else {
                    return false;
                }
            },
            configurable: true
        });

        return Array.prototype.lastIndexOf.call(obj, true) === 1;
    }
runTestCase(testcase);
