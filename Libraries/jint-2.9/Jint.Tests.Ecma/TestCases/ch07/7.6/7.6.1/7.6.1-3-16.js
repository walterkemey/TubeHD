/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch07/7.6/7.6.1/7.6.1-3-16.js
 * @description Allow reserved words as property names by index assignment,verified with hasOwnProperty: undefined, NaN, Infinity
 */


function testcase() {
        var tokenCodes  = {};
        tokenCodes['undefined'] = 0;
        tokenCodes['NaN'] = 1;
        tokenCodes['Infinity'] = 2;
        var arr = [
            'undefined',
            'NaN',
            'Infinity'
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
