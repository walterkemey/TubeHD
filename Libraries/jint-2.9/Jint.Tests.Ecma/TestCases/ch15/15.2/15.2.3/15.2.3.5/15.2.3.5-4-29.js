/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.5/15.2.3.5-4-29.js
 * @description Object.create - 'Properties' is an Array object that uses Object's [[Get]] method to access own enumerable property (15.2.3.7 step 5.a)
 */


function testcase() {

        var props = [];
        props.prop = {
            value: {},
            enumerable: true
        };
        var newObj = Object.create({}, props);
        return newObj.hasOwnProperty("prop");
    }
runTestCase(testcase);
