/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch11/11.2/11.2.3/11.2.3-3_2.js
 * @description Call arguments are evaluated before the check is made to see if the object is actually callable (FunctionExpression)
 */


function testcase() {
    var fooCalled = false;
    var foo = function (){ fooCalled = true; } 
    
    var o = { }; 
    try {
        o.bar( foo() );
        throw new Exception("o.bar does not exist!");
    } catch(e) {
        return (e instanceof TypeError) && (fooCalled===true);
    }
}
runTestCase(testcase);
