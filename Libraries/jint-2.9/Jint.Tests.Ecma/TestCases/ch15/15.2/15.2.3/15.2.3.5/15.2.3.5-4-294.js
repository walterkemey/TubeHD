/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.2/15.2.3/15.2.3.5/15.2.3.5-4-294.js
 * @description Object.create - 'set' property of one property in 'Properties' is a primitive boolean value true (8.10.5 step 8.b)
 */


function testcase() {

        try {
            Object.create({}, {
                prop: {
                    set: true
                } 
            });

            return false;
        } catch (e) {
            return (e instanceof TypeError);
        }
    }
runTestCase(testcase);
