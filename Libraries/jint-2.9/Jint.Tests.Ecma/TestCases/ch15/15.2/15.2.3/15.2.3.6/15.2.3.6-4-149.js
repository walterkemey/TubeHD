/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.6/15.2.3.6-4-149.js
 * @description Object.defineProperty - 'O' is an Array, 'name' is the length property of 'O', test the [[Value]] field of 'desc' is an Object which has an own toString and valueOf method (15.4.5.1 step 3.c)
 */


function testcase() {

        var arrObj = [];
        var toStringAccessed = false;
        var valueOfAccessed = false;

        Object.defineProperty(arrObj, "length", {
            value: {
                toString: function () {
                    toStringAccessed = true;
                    return '2';
                },

                valueOf: function () {
                    valueOfAccessed = true;
                    return 3;
                }
            }
        });
        return arrObj.length === 3 && !toStringAccessed && valueOfAccessed;

    }
runTestCase(testcase);
