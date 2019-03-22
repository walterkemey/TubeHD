/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.21/15.4.4.21-10-2.js
 * @description Array.prototype.reduce reduces the array in ascending order of indices
 */


function testcase() {

  function callbackfn(prevVal, curVal,  idx, obj)
  {
    return prevVal + curVal;
  }
  var srcArr = ['1','2','3','4','5'];
  if(srcArr.reduce(callbackfn) === '12345')
  {
    return true;
  }

 }
runTestCase(testcase);
