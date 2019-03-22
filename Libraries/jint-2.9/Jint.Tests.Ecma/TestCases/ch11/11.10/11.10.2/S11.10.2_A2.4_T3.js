// Copyright 2009 the Sputnik authors.  All rights reserved.
/**
 * First expression is evaluated first, and then second expression
 *
 * @path ch11/11.10/11.10.2/S11.10.2_A2.4_T3.js
 * @description Checking with undeclarated variables
 * @noStrict
 */

//CHECK#1
try {
  x ^ (x = 1);
  $ERROR('#1.1: x ^ (x = 1) throw ReferenceError. Actual: ' + (x ^ (x = 1)));
}
catch (e) {
  if ((e instanceof ReferenceError) !== true) {
    $ERROR('#1.2: x ^ (x = 1) throw ReferenceError. Actual: ' + (e));
  }
}

//CHECK#2
if (((y = 1) ^ y) !== 0) {
  $ERROR('#2: ((y = 1) ^ y) === 0. Actual: ' + (((y = 1) ^ y)));
}



