/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.3/15.2.3.3-4-3.js
 * @description Object.getOwnPropertyDescriptor returns an object representing an accessor desc for valid accessor properties
 */


function testcase() {
    var o = {};

    // dummy getter
    var getter = function () { return 1; }
    var d = { get: getter };

    Object.defineProperty(o, "foo", d);

    var desc = Object.getOwnPropertyDescriptor(o, "foo");
    if (desc.get === getter &&
        desc.set === undefined &&
        desc.enumerable === false &&
        desc.configurable === false) {
      return true;
    }
 }
runTestCase(testcase);
