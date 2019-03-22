/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.20/15.4.4.20-9-b-7.js
 * @description Array.prototype.filter - properties can be added to prototype after current position are visited on an Array
 */


function testcase() {
        function callbackfn(val, idx, obj) {
            return true;
        }
        var arr = [0, , 2];

        try {
            Object.defineProperty(arr, "0", {
                get: function () {
                    Object.defineProperty(Array.prototype, "1", {
                        get: function () {
                            return 6.99;
                        },
                        configurable: true
                    });
                    return 0;
                },
                configurable: true
            });

            var newArr = arr.filter(callbackfn);

            return newArr.length === 3 && newArr[1] === 6.99;
        } finally {
            delete Array.prototype[1];
        }
    }
runTestCase(testcase);
