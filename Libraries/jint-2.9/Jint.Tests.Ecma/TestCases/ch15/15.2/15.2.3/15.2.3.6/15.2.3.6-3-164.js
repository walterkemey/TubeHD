/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.6/15.2.3.6-3-164.js
 * @description Object.defineProperty - 'writable' property in 'Attributes' is an inherited accessor property without a get function  (8.10.5 step 6.a)
 */


function testcase() {
        var obj = {};

        var proto = {};
        Object.defineProperty(proto, "writable", {
            set: function () { }
        });

        var ConstructFun = function () { };
        ConstructFun.prototype = proto;

        var child = new ConstructFun();

        Object.defineProperty(obj, "property", child);

        var beforeWrite = obj.hasOwnProperty("property");

        obj.property = "isWritable";

        var afterWrite = (typeof (obj.property) === "undefined");

        return beforeWrite === true && afterWrite === true;
    }
runTestCase(testcase);
