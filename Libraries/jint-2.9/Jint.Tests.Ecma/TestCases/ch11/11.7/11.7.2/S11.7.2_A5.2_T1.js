// Copyright 2009 the Sputnik authors.  All rights reserved.
/**
 * Operator x >> y uses ToUint32(AdditiveExpression) & 31
 *
 * @path ch11/11.7/11.7.2/S11.7.2_A5.2_T1.js
 * @description Checking distinct points
 */

//CHECK#1
if (2147483647 >> -32.1 !== 2147483647) { 
  $ERROR('#1: 2147483647 >> -32.1 === 2147483647. Actual: ' + (2147483647 >> -32.1)); 
} 

//CHECK#2
if (2147483647 >> -31.1 !== 1073741823) { 
  $ERROR('#2: 2147483647 >> -31.1 === 1073741823. Actual: ' + (2147483647 >> -31.1)); 
} 

//CHECK#3
if (2147483647 >> -30.1 !== 536870911) { 
  $ERROR('#3: 2147483647 >> -30.1 === 536870911. Actual: ' + (2147483647 >> -30.1)); 
} 

//CHECK#4
if (2147483647 >> -29.1 !== 268435455) { 
  $ERROR('#4: 2147483647 >> -29.1 === 268435455. Actual: ' + (2147483647 >> -29.1)); 
} 

//CHECK#5
if (2147483647 >> -28.1 !== 134217727) { 
  $ERROR('#5: 2147483647 >> -28.1 === 134217727. Actual: ' + (2147483647 >> -28.1)); 
} 

//CHECK#6
if (2147483647 >> -27.1 !== 67108863) { 
  $ERROR('#6: 2147483647 >> -27.1 === 67108863. Actual: ' + (2147483647 >> -27.1)); 
} 

//CHECK#7
if (2147483647 >> -26.1 !== 33554431) { 
  $ERROR('#7: 2147483647 >> -26.1 === 33554431. Actual: ' + (2147483647 >> -26.1)); 
} 

//CHECK#8
if (2147483647 >> -25.1 !== 16777215) { 
  $ERROR('#8: 2147483647 >> -25.1 === 16777215. Actual: ' + (2147483647 >> -25.1)); 
} 

//CHECK#9
if (2147483647 >> -24.1 !== 8388607) { 
  $ERROR('#9: 2147483647 >> -24.1 === 8388607. Actual: ' + (2147483647 >> -24.1)); 
} 

//CHECK#10
if (2147483647 >> -23.1 !== 4194303) { 
  $ERROR('#10: 2147483647 >> -23.1 === 4194303. Actual: ' + (2147483647 >> -23.1)); 
} 

//CHECK#11
if (2147483647 >> -22.1 !== 2097151) { 
  $ERROR('#11: 2147483647 >> -22.1 === 2097151. Actual: ' + (2147483647 >> -22.1)); 
} 

//CHECK#12
if (2147483647 >> -21.1 !== 1048575) { 
  $ERROR('#12: 2147483647 >> -21.1 === 1048575. Actual: ' + (2147483647 >> -21.1)); 
} 

//CHECK#13
if (2147483647 >> -20.1 !== 524287) { 
  $ERROR('#13: 2147483647 >> -20.1 === 524287. Actual: ' + (2147483647 >> -20.1)); 
} 

//CHECK#14
if (2147483647 >> -19.1 !== 262143) { 
  $ERROR('#14: 2147483647 >> -19.1 === 262143. Actual: ' + (2147483647 >> -19.1)); 
} 

//CHECK#15
if (2147483647 >> -18.1 !== 131071) { 
  $ERROR('#15: 2147483647 >> -18.1 === 131071. Actual: ' + (2147483647 >> -18.1)); 
} 

//CHECK#16
if (2147483647 >> -17.1 !== 65535) { 
  $ERROR('#16: 2147483647 >> -17.1 === 65535. Actual: ' + (2147483647 >> -17.1)); 
} 

//CHECK#17
if (2147483647 >> -16.1 !== 32767) { 
  $ERROR('#17: 2147483647 >> -16.1 === 32767. Actual: ' + (2147483647 >> -16.1)); 
} 

//CHECK#18
if (2147483647 >> -15.1 !== 16383) { 
  $ERROR('#18: 2147483647 >> -15.1 === 16383. Actual: ' + (2147483647 >> -15.1)); 
} 

//CHECK#19
if (2147483647 >> -14.1 !== 8191) { 
  $ERROR('#19: 2147483647 >> -14.1 === 8191. Actual: ' + (2147483647 >> -14.1)); 
} 

//CHECK#20
if (2147483647 >> -13.1 !== 4095) { 
  $ERROR('#20: 2147483647 >> -13.1 === 4095. Actual: ' + (2147483647 >> -13.1)); 
} 

//CHECK#21
if (2147483647 >> -12.1 !== 2047) { 
  $ERROR('#21: 2147483647 >> -12.1 === 2047. Actual: ' + (2147483647 >> -12.1)); 
} 

//CHECK#22
if (2147483647 >> -11.1 !== 1023) { 
  $ERROR('#22: 2147483647 >> -11.1 === 1023. Actual: ' + (2147483647 >> -11.1)); 
} 

//CHECK#23
if (2147483647 >> -10.1 !== 511) { 
  $ERROR('#23: 2147483647 >> -10.1 === 511. Actual: ' + (2147483647 >> -10.1)); 
} 

//CHECK#24
if (2147483647 >> -9.1 !== 255) { 
  $ERROR('#24: 2147483647 >> -9.1 === 255. Actual: ' + (2147483647 >> -9.1)); 
} 

//CHECK#25
if (2147483647 >> -8.1 !== 127) { 
  $ERROR('#25: 2147483647 >> -8.1 === 127. Actual: ' + (2147483647 >> -8.1)); 
} 

//CHECK#26
if (2147483647 >> -7.1 !== 63) { 
  $ERROR('#26: 2147483647 >> -7.1 === 63. Actual: ' + (2147483647 >> -7.1)); 
} 

//CHECK#27
if (2147483647 >> -6.1 !== 31) { 
  $ERROR('#27: 2147483647 >> -6.1 === 31. Actual: ' + (2147483647 >> -6.1)); 
} 

//CHECK#28
if (2147483647 >> -5.1 !== 15) { 
  $ERROR('#28: 2147483647 >> -5.1 === 15. Actual: ' + (2147483647 >> -5.1)); 
} 

//CHECK#29
if (2147483647 >> -4.1 !== 7) { 
  $ERROR('#29: 2147483647 >> -4.1 === 7. Actual: ' + (2147483647 >> -4.1)); 
} 

//CHECK#30
if (2147483647 >> -3.1 !== 3) { 
  $ERROR('#30: 2147483647 >> -3.1 === 3. Actual: ' + (2147483647 >> -3.1)); 
} 

//CHECK#31
if (2147483647 >> -2.1 !== 1) { 
  $ERROR('#31: 2147483647 >> -2.1 === 1. Actual: ' + (2147483647 >> -2.1)); 
} 

//CHECK#32
if (2147483647 >> -1.1 !== 0) { 
  $ERROR('#32: 2147483647 >> -1.1 === 0. Actual: ' + (2147483647 >> -1.1)); 
} 

//CHECK#33
if (2147483647 >> 32.1 !== 2147483647) { 
  $ERROR('#33: 2147483647 >> 32.1 === 2147483647. Actual: ' + (2147483647 >> 32.1)); 
} 

//CHECK#34
if (2147483647 >> 33.1 !== 1073741823) { 
  $ERROR('#34: 2147483647 >> 33.1 === 1073741823. Actual: ' + (2147483647 >> 33.1)); 
} 

//CHECK#35
if (2147483647 >> 34.1 !== 536870911) { 
  $ERROR('#35: 2147483647 >> 34.1 === 536870911. Actual: ' + (2147483647 >> 34.1)); 
} 

//CHECK#36
if (2147483647 >> 35.1 !== 268435455) { 
  $ERROR('#36: 2147483647 >> 35.1 === 268435455. Actual: ' + (2147483647 >> 35.1)); 
} 

//CHECK#37
if (2147483647 >> 36.1 !== 134217727) { 
  $ERROR('#37: 2147483647 >> 36.1 === 134217727. Actual: ' + (2147483647 >> 36.1)); 
} 

//CHECK#38
if (2147483647 >> 37.1 !== 67108863) { 
  $ERROR('#38: 2147483647 >> 37.1 === 67108863. Actual: ' + (2147483647 >> 37.1)); 
} 

//CHECK#39
if (2147483647 >> 38.1 !== 33554431) { 
  $ERROR('#39: 2147483647 >> 38.1 === 33554431. Actual: ' + (2147483647 >> 38.1)); 
} 

//CHECK#40
if (2147483647 >> 39.1 !== 16777215) { 
  $ERROR('#40: 2147483647 >> 39.1 === 16777215. Actual: ' + (2147483647 >> 39.1)); 
} 

//CHECK#41
if (2147483647 >> 40.1 !== 8388607) { 
  $ERROR('#41: 2147483647 >> 40.1 === 8388607. Actual: ' + (2147483647 >> 40.1)); 
} 

//CHECK#42
if (2147483647 >> 41.1 !== 4194303) { 
  $ERROR('#42: 2147483647 >> 41.1 === 4194303. Actual: ' + (2147483647 >> 41.1)); 
} 

//CHECK#43
if (2147483647 >> 42.1 !== 2097151) { 
  $ERROR('#43: 2147483647 >> 42.1 === 2097151. Actual: ' + (2147483647 >> 42.1)); 
} 

//CHECK#44
if (2147483647 >> 43.1 !== 1048575) { 
  $ERROR('#44: 2147483647 >> 43.1 === 1048575. Actual: ' + (2147483647 >> 43.1)); 
} 

//CHECK#45
if (2147483647 >> 44.1 !== 524287) { 
  $ERROR('#45: 2147483647 >> 44.1 === 524287. Actual: ' + (2147483647 >> 44.1)); 
} 

//CHECK#46
if (2147483647 >> 45.1 !== 262143) { 
  $ERROR('#46: 2147483647 >> 45.1 === 262143. Actual: ' + (2147483647 >> 45.1)); 
} 

//CHECK#47
if (2147483647 >> 46.1 !== 131071) { 
  $ERROR('#47: 2147483647 >> 46.1 === 131071. Actual: ' + (2147483647 >> 46.1)); 
} 

//CHECK#48
if (2147483647 >> 47.1 !== 65535) { 
  $ERROR('#48: 2147483647 >> 47.1 === 65535. Actual: ' + (2147483647 >> 47.1)); 
} 

//CHECK#49
if (2147483647 >> 48.1 !== 32767) { 
  $ERROR('#49: 2147483647 >> 48.1 === 32767. Actual: ' + (2147483647 >> 48.1)); 
} 

//CHECK#50
if (2147483647 >> 49.1 !== 16383) { 
  $ERROR('#50: 2147483647 >> 49.1 === 16383. Actual: ' + (2147483647 >> 49.1)); 
} 

//CHECK#51
if (2147483647 >> 50.1 !== 8191) { 
  $ERROR('#51: 2147483647 >> 50.1 === 8191. Actual: ' + (2147483647 >> 50.1)); 
} 

//CHECK#52
if (2147483647 >> 51.1 !== 4095) { 
  $ERROR('#52: 2147483647 >> 51.1 === 4095. Actual: ' + (2147483647 >> 51.1)); 
} 

//CHECK#53
if (2147483647 >> 52.1 !== 2047) { 
  $ERROR('#53: 2147483647 >> 52.1 === 2047. Actual: ' + (2147483647 >> 52.1)); 
} 

//CHECK#54
if (2147483647 >> 53.1 !== 1023) { 
  $ERROR('#54: 2147483647 >> 53.1 === 1023. Actual: ' + (2147483647 >> 53.1)); 
} 

//CHECK#55
if (2147483647 >> 54.1 !== 511) { 
  $ERROR('#55: 2147483647 >> 54.1 === 511. Actual: ' + (2147483647 >> 54.1)); 
} 

//CHECK#56
if (2147483647 >> 55.1 !== 255) { 
  $ERROR('#56: 2147483647 >> 55.1 === 255. Actual: ' + (2147483647 >> 55.1)); 
} 

//CHECK#57
if (2147483647 >> 56.1 !== 127) { 
  $ERROR('#57: 2147483647 >> 56.1 === 127. Actual: ' + (2147483647 >> 56.1)); 
} 

//CHECK#58
if (2147483647 >> 57.1 !== 63) { 
  $ERROR('#58: 2147483647 >> 57.1 === 63. Actual: ' + (2147483647 >> 57.1)); 
} 

//CHECK#59
if (2147483647 >> 58.1 !== 31) { 
  $ERROR('#59: 2147483647 >> 58.1 === 31. Actual: ' + (2147483647 >> 58.1)); 
} 

//CHECK#60
if (2147483647 >> 59.1 !== 15) { 
  $ERROR('#60: 2147483647 >> 59.1 === 15. Actual: ' + (2147483647 >> 59.1)); 
} 

//CHECK#61
if (2147483647 >> 60.1 !== 7) { 
  $ERROR('#61: 2147483647 >> 60.1 === 7. Actual: ' + (2147483647 >> 60.1)); 
} 

//CHECK#62
if (2147483647 >> 61.1 !== 3) { 
  $ERROR('#62: 2147483647 >> 61.1 === 3. Actual: ' + (2147483647 >> 61.1)); 
} 

//CHECK#63
if (2147483647 >> 62.1 !== 1) { 
  $ERROR('#63: 2147483647 >> 62.1 === 1. Actual: ' + (2147483647 >> 62.1)); 
} 

//CHECK#64
if (2147483647 >> 63.1 !== 0) { 
  $ERROR('#64: 2147483647 >> 63.1 === 0. Actual: ' + (2147483647 >> 63.1)); 
} 

