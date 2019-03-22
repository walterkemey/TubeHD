/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.11/15.2.3.11-4-15.js
 * @description Object.isSealed returns false for all built-in objects (Date)
 */


function testcase() {
  var b = Object.isSealed(Date);
  if (b === false) {
    return true;
  }
  }
runTestCase(testcase);
