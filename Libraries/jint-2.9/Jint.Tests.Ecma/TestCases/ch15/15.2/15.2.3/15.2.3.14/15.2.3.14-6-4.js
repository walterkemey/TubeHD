/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.14/15.2.3.14-6-4.js
 * @description Object.keys - the order of elements in returned array is the same with the order of properties in 'O' (Arguments object)
 */


function testcase() {
        var func = function (a, b, c) {
            return arguments;
        };

        var args = func(1, "b", false);

        var tempArray = [];
        for (var p in args) {
            if (args.hasOwnProperty(p)) {
                tempArray.push(p);
            }
        }

        var returnedArray = Object.keys(args);

        for (var index in returnedArray) {
            if (tempArray[index] !== returnedArray[index]) {
                return false;
            }
        }
        return true;
    }
runTestCase(testcase);
