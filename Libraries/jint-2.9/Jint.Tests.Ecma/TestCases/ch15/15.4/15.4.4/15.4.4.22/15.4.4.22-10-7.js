/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.22/15.4.4.22-10-7.js
 * @description Array.prototype.reduceRight - subclassed array when length to 1 and initialvalue provided
 */


function testcase() {
  foo.prototype = [1];
  function foo() {}
  var f = new foo();
  
  function cb(prevVal, curVal, idx, obj){return prevVal + curVal;}
  if(f.reduceRight(cb,"4") === "41")
    return true;
 }
runTestCase(testcase);
