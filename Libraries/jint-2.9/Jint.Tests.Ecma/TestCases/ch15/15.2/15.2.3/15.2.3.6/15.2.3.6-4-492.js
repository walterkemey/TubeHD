/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.6/15.2.3.6-4-492.js
 * @description ES5 Attributes - fail to update [[Configurable]] attribute of accessor property ([[Get]] is undefined, [[Set]] is a Function, [[Enumerable]] is false, [[Configurable]] is false) to different value
 */


function testcase() {
        var obj = {};

        var verifySetFunc = "data";
        var setFunc = function (value) {
            verifySetFunc = value;
        };

        Object.defineProperty(obj, "prop", {
            get: undefined,
            set: setFunc,
            enumerable: false,
            configurable: false
        });
        var desc1 = Object.getOwnPropertyDescriptor(obj, "prop");

        try {
            Object.defineProperty(obj, "prop", {
                configurable: true
            });

            return false;
        } catch (e) {
            var desc2 = Object.getOwnPropertyDescriptor(obj, "prop");
            delete obj.prop;

            return desc1.configurable === false && desc2.configurable === false && obj.hasOwnProperty("prop") && e instanceof TypeError;
        }
    }
runTestCase(testcase);
