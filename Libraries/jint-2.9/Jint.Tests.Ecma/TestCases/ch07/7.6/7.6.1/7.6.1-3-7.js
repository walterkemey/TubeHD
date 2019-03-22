/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch07/7.6/7.6.1/7.6.1-3-7.js
 * @description Allow reserved words as property names by index assignment,verified with hasOwnProperty: while, debugger, function
 */


function testcase() {
        var tokenCodes  = {};
        tokenCodes['while'] = 0;
        tokenCodes['debugger'] = 1;
        tokenCodes['function'] = 2; 
        var arr = [
            'while',
            'debugger',
            'function'
            ];
        for(var p in tokenCodes) {       
            for(var p1 in arr) {                
                if(arr[p1] === p) {
                    if(!tokenCodes.hasOwnProperty(arr[p1])) {
                        return false;
                    };
                }
            }
        }
        return true;
    }
runTestCase(testcase);
