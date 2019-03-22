// Copyright 2009 the Sputnik authors.  All rights reserved.
/**
 * If x is -0, Math.tan(x) is -0
 *
 * @path ch15/15.8/15.8.2/15.8.2.18/S15.8.2.18_A3.js
 * @description Checking if Math.tan(-0) equals to -0
 */

// CHECK#1
var x = -0;
if (Math.tan(x) !== -0)
{
	$ERROR("#1: 'var x=-0; Math.tan(x) !== -0'");
}

