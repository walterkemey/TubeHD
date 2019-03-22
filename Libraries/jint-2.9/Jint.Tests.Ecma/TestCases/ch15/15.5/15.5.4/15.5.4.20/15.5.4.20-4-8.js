/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.5/15.5.4/15.5.4.20/15.5.4.20-4-8.js
 * @description String.prototype.trim handles whitepace and lineterminators (\u00A0abc)
 */


function testcase() {
  if ("\u00A0abc".trim() === "abc") {
    return true;
  }
 }
runTestCase(testcase);
