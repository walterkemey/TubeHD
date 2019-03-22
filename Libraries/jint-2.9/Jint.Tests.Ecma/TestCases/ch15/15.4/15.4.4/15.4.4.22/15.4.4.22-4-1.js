/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.4/15.4.4/15.4.4.22/15.4.4.22-4-1.js
 * @description Array.prototype.reduceRight throws TypeError if callbackfn is undefined
 */


function testcase() {

  var arr = new Array(10);
  try {
    arr.reduceRight();    
  }
  catch(e) {
    if(e instanceof TypeError)
      return true;  
  }

 }
runTestCase(testcase);
