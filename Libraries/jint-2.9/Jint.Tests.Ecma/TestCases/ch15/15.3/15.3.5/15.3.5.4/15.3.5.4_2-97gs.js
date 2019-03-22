/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.3/15.3.5/15.3.5.4/15.3.5.4_2-97gs.js
 * @description Strict mode - checking access to strict function caller from bound non-strict function (FunctionDeclaration includes strict directive prologue)
 * @noStrict
 * @negative TypeError
 */

var gNonStrict = gNonStrictBindee.bind(null);

function f() {
    "use strict";
    return gNonStrict();
}
f();


function gNonStrictBindee() {
    return gNonStrictBindee.caller || gNonStrictBindee.caller.throwTypeError;
}

