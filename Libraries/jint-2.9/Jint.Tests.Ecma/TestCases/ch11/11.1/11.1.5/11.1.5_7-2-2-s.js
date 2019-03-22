/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch11/11.1/11.1.5/11.1.5_7-2-2-s.js
 * @description Strict Mode - SyntaxError is thrown when an assignment to a reserved word is made in  a strict FunctionBody of a PropertyAssignment
 * @onlyStrict
 */


function testcase() {
        "use strict";

        try {
            eval("var data = \"data\";\
            var obj = {\
                set _11_1_5_7_2_2(value) {\
                    public = 42;\
                    data = value;\
                }\
            };\
            obj._11_1_5_7_2_2 = 1;");
            return false;
        } catch (e) {
            return e instanceof SyntaxError;
        }
    }
runTestCase(testcase);
