// Copyright 2009 the Sputnik authors.  All rights reserved.
/**
 * Check If Statement for automatic semicolon insertion
 *
 * @path ch07/7.9/S7.9_A11_T2.js
 * @description Use if (false) \n x = 1 and check x
 */

//CHECK#1
var x = 0;
if (false)
x = 1
if (x !== 0) {
  $ERROR('#1: Check If Statement for automatic semicolon insertion');
}

