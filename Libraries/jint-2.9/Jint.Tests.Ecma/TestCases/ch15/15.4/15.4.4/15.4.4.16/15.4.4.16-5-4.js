/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.16/15.4.4.16-5-4.js
 * @description Array.prototype.every - thisArg is object from object template(prototype)
 */


function testcase() {
  var res = false;
  function callbackfn(val, idx, obj)
  {
    return this.res;
  }
  
  function foo(){}
  foo.prototype.res = true;
  var f = new foo();
  var arr = [1];

    if(arr.every(callbackfn,f) === true)
      return true;    

 }
runTestCase(testcase);
