/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.22/15.4.4.22-10-5.js
 * @description Array.prototype.reduceRight reduces array in descending order of indices(initialvalue present)
 */


function testcase() {

  function callbackfn(prevVal, curVal,  idx, obj)
  {
    return prevVal + curVal;
  }
  var srcArr = ['1','2','3','4','5'];
  if(srcArr.reduceRight(callbackfn,'6') === '654321')
  {
    return true;
  }

 }
runTestCase(testcase);
