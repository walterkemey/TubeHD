/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.14/15.4.4.14-9-a-10.js
 * @description Array.prototype.indexOf - properties can be added to prototype after current position are visited on an Array
 */


function testcase() {

        var arr = [0, , 2];

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

        try {
            return arr.indexOf(6.99) === 1;
        } finally {
            delete Array.prototype[1];
        }
    }
runTestCase(testcase);
