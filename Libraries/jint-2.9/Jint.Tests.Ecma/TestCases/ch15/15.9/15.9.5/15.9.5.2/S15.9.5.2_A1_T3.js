// Copyright 2009 the Sputnik authors.  All rights reserved.
/**
 * The Date.prototype property "toString" has { DontEnum } attributes
 *
 * @path ch15/15.9/15.9.5/15.9.5.2/S15.9.5.2_A1_T3.js
 * @description Checking DontEnum attribute
 */

if (Date.prototype.propertyIsEnumerable('toString')) {
  $ERROR('#1: The Date.prototype.toString property has the attribute DontEnum');
}

for(x in Date.prototype) {
  if(x === "toString") {
    $ERROR('#2: The Date.prototype.toString has the attribute DontEnum');
  }
}


