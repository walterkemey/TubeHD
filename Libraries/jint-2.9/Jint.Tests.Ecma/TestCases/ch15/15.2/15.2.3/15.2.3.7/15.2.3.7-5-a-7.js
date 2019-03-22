/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.7/15.2.3.7-5-a-7.js
 * @description Object.defineProperties - 'Properties' is a Function object which implements its own [[Get]] method to get enumerable own property
 */


function testcase() {

        var obj = {};
        var props = function () { };

        Object.defineProperty(props, "prop", {
            value: {
                value: 7
            },
            enumerable: true
        });

        Object.defineProperties(obj, props);

        return obj.hasOwnProperty("prop") && obj.prop === 7;
    }
runTestCase(testcase);
