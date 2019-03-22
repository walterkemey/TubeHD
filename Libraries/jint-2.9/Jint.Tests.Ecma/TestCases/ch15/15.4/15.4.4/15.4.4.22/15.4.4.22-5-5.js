/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.22/15.4.4.22-5-5.js
 * @description Array.prototype.reduceRight throws TypeError if 'length' is 0 (subclassed Array, length overridden to '0' (type conversion)), no initVal
 */


function testcase() {
  foo.prototype = new Array(1, 2, 3);
  function foo() {}
  var f = new foo();
  f.length = '0';
  
  function cb(){}
  try {
    f.reduceRight(cb);
  }
  catch (e) {
    if (e instanceof TypeError) {
      return true;
    }
  }
 }
runTestCase(testcase);
