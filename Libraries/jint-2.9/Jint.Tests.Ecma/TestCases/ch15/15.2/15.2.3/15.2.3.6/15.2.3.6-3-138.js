/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.6/15.2.3.6-3-138.js
 * @description Object.defineProperty - 'value' property in 'Attributes' is an inherited accessor property without a get function  (8.10.5 step 5.a)
 */


function testcase() {
        var obj = { property : 120 };

        var proto = {};
        Object.defineProperty(proto, "value", {
            set: function () { }
        });

        var ConstructFun = function () { };
        ConstructFun.prototype = proto;

        var child = new ConstructFun();

        Object.defineProperty(obj, "property", child);

        return obj.hasOwnProperty("property") && typeof (obj.property) === "undefined";
    }
runTestCase(testcase);
