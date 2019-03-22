// Copyright 2009 the Sputnik authors.  All rights reserved.
/**
 * If x is -0, Math.round(x) is -0
 *
 * @path ch15/15.8/15.8.2/15.8.2.15/S15.8.2.15_A3.js
 * @description Checking if Math.round(x) equals to -0, where x is -0
 */

// CHECK#1
var x = -0;
if (Math.round(x) !== -0)
{
	$ERROR("#1: 'var x=-0; Math.round(x) !== -0'");
}

