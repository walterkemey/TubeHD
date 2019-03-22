// Copyright 2009 the Sputnik authors.  All rights reserved.
/**
 * The Date.prototype property "setMinutes" has { DontEnum } attributes
 *
 * @path ch15/15.9/15.9.5/15.9.5.32/S15.9.5.32_A1_T2.js
 * @description Checking absence of DontDelete attribute
 */

if (delete Date.prototype.setMinutes  === false) {
  $ERROR('#1: The Date.prototype.setMinutes property has not the attributes DontDelete');
}

if (Date.prototype.hasOwnProperty('setMinutes')) {
  $FAIL('#2: The Date.prototype.setMinutes property has not the attributes DontDelete');
}


