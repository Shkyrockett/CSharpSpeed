# Ellipse Perimeter Length Tests

Estimations on the length of the Perimeter of an ellipse.

> ## Machine Specs for this Runs Results
> The test cases below were run on a system with the following hardware specifications. Results will vary on the same system depending on current processing work load. So, take the numbers in the tables with a grain of salt.  
> **Processor:**  
> Name: Intel(R) Core(TM) i5-7200U CPU @ 2.50GHz  
  > **Physical Memory:**  
> Capacity: 8 GB  
> Speed: 1600 nanoseconds  
  > **Library Compiled as:**  
> Release  

## Results

../../InstrumentedLibrary/Geometry/Length/EllipsePerimeterLengthTests.cs

The required method signature for this API is as follows:

```CSharp
public static double EllipsePerimeterLength(double a, double b)
```

## Test Case Index

- [Test Case: (1, 1)](#1,-1)
- [Test Case: (1, 2)](#1,-2)
- [Test Case: (1, 3)](#1,-3)
- [Test Case: (2, 4)](#2,-4)
- [Test Case: (0, 4)](#0,-4)

### (1, 1)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [_ExactEllipsePerimeter(1, 1)](#Ellipse-Perimeter-Length-1) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 5 ms. 0.0005 ms. average | Circle test case. |
| [EllipsePerimeter1(1, 1)](#Ellipse-Perimeter-Length-1) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 6 ms. 0.0006 ms. average | Circle test case. |
| [EllipsePerimeter2(1, 1)](#Ellipse-Perimeter-Length-2) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 7 ms. 0.0007 ms. average | Circle test case. |
| [EllipsePerimeter2_3JacobsenWaadeland(1, 1)](#Ellipse-Perimeter-Length-17) | 7.9993540567265446 != 6.2831853071795862 | 10000 in 8 ms. 0.0008 ms. average | Circle test case. |
| [EllipsePerimeter3_3_3_2(1, 1)](#Ellipse-Perimeter-Length-18) | 7.9992322711594959 != 6.2831853071795862 | 10000 in 10 ms. 0.001 ms. average | Circle test case. |
| [EllipsePerimeterAhmadi2006(1, 1)](#Ellipse-Perimeter-Length-47) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 6 ms. 0.0006 ms. average | Circle test case. |
| [EllipsePerimeterAlmkvist(1, 1)](#Ellipse-Perimeter-Length-8) | 12.566370614359172 != 6.2831853071795862 | 10000 in 8 ms. 0.0008 ms. average | Circle test case. |
| [EllipsePerimeterBartolomeu(1, 1)](#Ellipse-Perimeter-Length-37) | NaN != 6.2831853071795862 | 10000 in 11 ms. 0.0011 ms. average | Circle test case. |
| [EllipsePerimeterBartolomeuMichon(1, 1)](#Ellipse-Perimeter-Length-33) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 8 ms. 0.0008 ms. average | Circle test case. |
| [EllipsePerimeterBessel(1, 1)](#Ellipse-Perimeter-Length-Bessel) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 9 ms. 0.0009 ms. average | Circle test case. |
| [EllipsePerimeterCantrell(1, 1)](#Ellipse-Perimeter-Length-40) | 7.2631368276289869 != 6.2831853071795862 | 10000 in 9 ms. 0.0009 ms. average | Circle test case. |
| [EllipsePerimeterCantrell2(1, 1)](#Ellipse-Perimeter-Length-34) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 6 ms. 0.0006 ms. average | Circle test case. |
| [EllipsePerimeterCantrell2006(1, 1)](#Ellipse-Perimeter-Length-46) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 7 ms. 0.0007 ms. average | Circle test case. |
| [EllipsePerimeterCantrellRamanujan(1, 1)](#Ellipse-Perimeter-Length-42) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 13 ms. 0.0013 ms. average | Circle test case. |
| [EllipsePerimeterCombinedPadé(1, 1)](#Ellipse-Perimeter-Length-14) | 7.9999999999999991 != 6.2831853071795862 | 10000 in 6 ms. 0.0006 ms. average | Circle test case. |
| [EllipsePerimeterCombinedPadéHudsonLipkaMichon(1, 1)](#Ellipse-Perimeter-Length-25) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 7 ms. 0.0007 ms. average | Circle test case. |
| [EllipsePerimeterEuler(1, 1)](#Ellipse-Perimeter-Length-7) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 10 ms. 0.001 ms. average | Circle test case. |
| [EllipsePerimeterJacobsenWaadelandHudsonLipka(1, 1)](#Ellipse-Perimeter-Length-16) | 7.9999999999999991 != 6.2831853071795862 | 10000 in 5 ms. 0.0005 ms. average | Circle test case. |
| [EllipsePerimeterK13(1, 1)](#Ellipse-Perimeter-Length-43) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 6 ms. 0.0006 ms. average | Circle test case. |
| [EllipsePerimeterKepler(1, 1)](#Ellipse-Perimeter-Length-3) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 5 ms. 0.0005 ms. average | Circle test case. |
| [EllipsePerimeterLindner(1, 1)](#Ellipse-Perimeter-Length-11) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 7 ms. 0.0007 ms. average | Circle test case. |
| [EllipsePerimeterLockwood(1, 1)](#Ellipse-Perimeter-Length-36) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 10 ms. 0.001 ms. average | Circle test case. |
| [EllipsePerimeterMuir(1, 1)](#Ellipse-Perimeter-Length-10) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 6 ms. 0.0006 ms. average | Circle test case. |
| [EllipsePerimeterNaive(1, 1)](#Ellipse-Perimeter-Length-5) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 6 ms. 0.0006 ms. average | Circle test case. |
| [EllipsePerimeterOptimizedPeano(1, 1)](#Ellipse-Perimeter-Length-29) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 6 ms. 0.0006 ms. average | Circle test case. |
| [EllipsePerimeterOptimizedQuadratic1(1, 1)](#Ellipse-Perimeter-Length-30) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 6 ms. 0.0006 ms. average | Circle test case. |
| [EllipsePerimeterOptimizedQuadratic2(1, 1)](#Ellipse-Perimeter-Length-31) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 12 ms. 0.0012 ms. average | Circle test case. |
| [EllipsePerimeterOptimizedRamanujan1(1, 1)](#Ellipse-Perimeter-Length-32) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 13 ms. 0.0013 ms. average | Circle test case. |
| [EllipsePerimeterPadé3_2(1, 1)](#Ellipse-Perimeter-Length-27) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 6 ms. 0.0006 ms. average | Circle test case. |
| [EllipsePerimeterPadé3_3(1, 1)](#Ellipse-Perimeter-Length-28) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 6 ms. 0.0006 ms. average | Circle test case. |
| [EllipsePerimeterPadéHudsonLipkaBronshtein(1, 1)](#Ellipse-Perimeter-Length-24) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 12 ms. 0.0012 ms. average | Circle test case. |
| [EllipsePerimeterPadéJacobsenWaadeland(1, 1)](#Ellipse-Perimeter-Length-26) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 12 ms. 0.0012 ms. average | Circle test case. |
| [EllipsePerimeterPadéMichon(1, 1)](#Ellipse-Perimeter-Length-23) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 9 ms. 0.0009 ms. average | Circle test case. |
| [EllipsePerimeterPadéSelmer(1, 1)](#Ellipse-Perimeter-Length-22) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 9 ms. 0.0009 ms. average | Circle test case. |
| [EllipsePerimeterPeano(1, 1)](#Ellipse-Perimeter-Length-6) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 7 ms. 0.0007 ms. average | Circle test case. |
| [EllipsePerimeterQuadratic(1, 1)](#Ellipse-Perimeter-Length-9) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 11 ms. 0.0011 ms. average | Circle test case. |
| [EllipsePerimeterRamanujan(1, 1)](#Ellipse-Perimeter-Length-19) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 6 ms. 0.0006 ms. average | Circle test case. |
| [EllipsePerimeterRamanujan2(1, 1)](#Ellipse-Perimeter-Length-21) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 6 ms. 0.0006 ms. average | Circle test case. |
| [EllipsePerimeterRivera1(1, 1)](#Ellipse-Perimeter-Length-38) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 9 ms. 0.0009 ms. average | Circle test case. |
| [EllipsePerimeterRivera2(1, 1)](#Ellipse-Perimeter-Length-39) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 6 ms. 0.0006 ms. average | Circle test case. |
| [EllipsePerimeterSelmer(1, 1)](#Ellipse-Perimeter-Length-20) | 6.941130894320354 != 6.2831853071795862 | 10000 in 8 ms. 0.0008 ms. average | Circle test case. |
| [EllipsePerimeterSipos(1, 1)](#Ellipse-Perimeter-Length-4) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 6 ms. 0.0006 ms. average | Circle test case. |
| [EllipsePerimeterSykora(1, 1)](#Ellipse-Perimeter-Length-41) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 6 ms. 0.0006 ms. average | Circle test case. |
| [EllipsePerimeterSykoraRiveraCantrellsParticularlyFruitful(1, 1)](#Ellipse-Perimeter-Length-12) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 6 ms. 0.0006 ms. average | Circle test case. |
| [EllipsePerimeterTakakazuSeki(1, 1)](#Ellipse-Perimeter-Length-35) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 12 ms. 0.0012 ms. average | Circle test case. |
| [EllipsePerimeterThomasBlankenhorn1(1, 1)](#Ellipse-Perimeter-Length-44) | 6.2831851335599787 != 6.2831853071795862 | 10000 in 8 ms. 0.0008 ms. average | Circle test case. |
| [EllipsePerimeterThomasBlankenhorn8(1, 1)](#Ellipse-Perimeter-Length-45) | 6.2831853071795853 != 6.2831853071795862 | 10000 in 7 ms. 0.0007 ms. average | Circle test case. |
| [EllipsePerimeterYNOT(1, 1)](#Ellipse-Perimeter-Length-13) | 6.2831853071795862 == 6.2831853071795862 | 10000 in 8 ms. 0.0008 ms. average | Circle test case. |

### (1, 2)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [_ExactEllipsePerimeter(1, 2)](#Ellipse-Perimeter-Length-1) | 9.6884482205476754 == 9.6884482205476754 | 10000 in 6 ms. 0.0006 ms. average | One to two test case. |
| [EllipsePerimeter1(1, 2)](#Ellipse-Perimeter-Length-1) | 9.9345882657961013 != 9.6884482205476754 | 10000 in 5 ms. 0.0005 ms. average | One to two test case. |
| [EllipsePerimeter2(1, 2)](#Ellipse-Perimeter-Length-2) | 9.688448217268153 != 9.6884482205476754 | 10000 in 7 ms. 0.0007 ms. average | One to two test case. |
| [EllipsePerimeter2_3JacobsenWaadeland(1, 2)](#Ellipse-Perimeter-Length-17) | 11.999031085089817 != 9.6884482205476754 | 10000 in 8 ms. 0.0008 ms. average | One to two test case. |
| [EllipsePerimeter3_3_3_2(1, 2)](#Ellipse-Perimeter-Length-18) | 11.998848406739244 != 9.6884482205476754 | 10000 in 8 ms. 0.0008 ms. average | One to two test case. |
| [EllipsePerimeterAhmadi2006(1, 2)](#Ellipse-Perimeter-Length-47) | 9.6884440077706628 != 9.6884482205476754 | 10000 in 6 ms. 0.0006 ms. average | One to two test case. |
| [EllipsePerimeterAlmkvist(1, 2)](#Ellipse-Perimeter-Length-8) | 18.826654899615804 != 9.6884482205476754 | 10000 in 9 ms. 0.0009 ms. average | One to two test case. |
| [EllipsePerimeterBartolomeu(1, 2)](#Ellipse-Perimeter-Length-37) | 9.6812101526774423 != 9.6884482205476754 | 10000 in 9 ms. 0.0009 ms. average | One to two test case. |
| [EllipsePerimeterBartolomeuMichon(1, 2)](#Ellipse-Perimeter-Length-33) | 9.7640629073072365 != 9.6884482205476754 | 10000 in 7 ms. 0.0007 ms. average | One to two test case. |
| [EllipsePerimeterBessel(1, 2)](#Ellipse-Perimeter-Length-Bessel) | 9.6884482205474214 != 9.6884482205476754 | 10000 in 18 ms. 0.0018 ms. average | One to two test case. |
| [EllipsePerimeterCantrell(1, 2)](#Ellipse-Perimeter-Length-40) | 11.007320795030857 != 9.6884482205476754 | 10000 in 7 ms. 0.0007 ms. average | One to two test case. |
| [EllipsePerimeterCantrell2(1, 2)](#Ellipse-Perimeter-Length-34) | 9.6884349608047167 != 9.6884482205476754 | 10000 in 6 ms. 0.0006 ms. average | One to two test case. |
| [EllipsePerimeterCantrell2006(1, 2)](#Ellipse-Perimeter-Length-46) | 9.6884211087479 != 9.6884482205476754 | 10000 in 14 ms. 0.0014 ms. average | One to two test case. |
| [EllipsePerimeterCantrellRamanujan(1, 2)](#Ellipse-Perimeter-Length-42) | 9.6884482161301015 != 9.6884482205476754 | 10000 in 12 ms. 0.0012 ms. average | One to two test case. |
| [EllipsePerimeterCombinedPadé(1, 2)](#Ellipse-Perimeter-Length-14) | 11.999999999999998 != 9.6884482205476754 | 10000 in 5 ms. 0.0005 ms. average | One to two test case. |
| [EllipsePerimeterCombinedPadéHudsonLipkaMichon(1, 2)](#Ellipse-Perimeter-Length-25) | 9.6996673179584878 != 9.6884482205476754 | 10000 in 8 ms. 0.0008 ms. average | One to two test case. |
| [EllipsePerimeterEuler(1, 2)](#Ellipse-Perimeter-Length-7) | 9.9345882657961013 != 9.6884482205476754 | 10000 in 8 ms. 0.0008 ms. average | One to two test case. |
| [EllipsePerimeterJacobsenWaadelandHudsonLipka(1, 2)](#Ellipse-Perimeter-Length-16) | 11.999999999999998 != 9.6884482205476754 | 10000 in 5 ms. 0.0005 ms. average | One to two test case. |
| [EllipsePerimeterK13(1, 2)](#Ellipse-Perimeter-Length-43) | 9.67968311328274 != 9.6884482205476754 | 10000 in 6 ms. 0.0006 ms. average | One to two test case. |
| [EllipsePerimeterKepler(1, 2)](#Ellipse-Perimeter-Length-3) | 8.8857658763167322 != 9.6884482205476754 | 10000 in 6 ms. 0.0006 ms. average | One to two test case. |
| [EllipsePerimeterLindner(1, 2)](#Ellipse-Perimeter-Length-11) | 9.4900021159081085 != 9.6884482205476754 | 10000 in 5 ms. 0.0005 ms. average | One to two test case. |
| [EllipsePerimeterLockwood(1, 2)](#Ellipse-Perimeter-Length-36) | 9.6326591796010774 != 9.6884482205476754 | 10000 in 6 ms. 0.0006 ms. average | One to two test case. |
| [EllipsePerimeterMuir(1, 2)](#Ellipse-Perimeter-Length-10) | 9.6866467205267526 != 9.6884482205476754 | 10000 in 8 ms. 0.0008 ms. average | One to two test case. |
| [EllipsePerimeterNaive(1, 2)](#Ellipse-Perimeter-Length-5) | 9.42477796076938 != 9.6884482205476754 | 10000 in 5 ms. 0.0005 ms. average | One to two test case. |
| [EllipsePerimeterOptimizedPeano(1, 2)](#Ellipse-Perimeter-Length-29) | 9.5972618277942257 != 9.6884482205476754 | 10000 in 6 ms. 0.0006 ms. average | One to two test case. |
| [EllipsePerimeterOptimizedQuadratic1(1, 2)](#Ellipse-Perimeter-Length-30) | 9.7304315513826882 != 9.6884482205476754 | 10000 in 7 ms. 0.0007 ms. average | One to two test case. |
| [EllipsePerimeterOptimizedQuadratic2(1, 2)](#Ellipse-Perimeter-Length-31) | 10.134633230774856 != 9.6884482205476754 | 10000 in 6 ms. 0.0006 ms. average | One to two test case. |
| [EllipsePerimeterOptimizedRamanujan1(1, 2)](#Ellipse-Perimeter-Length-32) | 9.6920198264899966 != 9.6884482205476754 | 10000 in 6 ms. 0.0006 ms. average | One to two test case. |
| [EllipsePerimeterPadé3_2(1, 2)](#Ellipse-Perimeter-Length-27) | 9.6884482199503 != 9.6884482205476754 | 10000 in 8 ms. 0.0008 ms. average | One to two test case. |
| [EllipsePerimeterPadé3_3(1, 2)](#Ellipse-Perimeter-Length-28) | 9.6884482205308338 != 9.6884482205476754 | 10000 in 6 ms. 0.0006 ms. average | One to two test case. |
| [EllipsePerimeterPadéHudsonLipkaBronshtein(1, 2)](#Ellipse-Perimeter-Length-24) | 9.6996673179584878 != 9.6884482205476754 | 10000 in 7 ms. 0.0007 ms. average | One to two test case. |
| [EllipsePerimeterPadéJacobsenWaadeland(1, 2)](#Ellipse-Perimeter-Length-26) | 9.68844819716615 != 9.6884482205476754 | 10000 in 6 ms. 0.0006 ms. average | One to two test case. |
| [EllipsePerimeterPadéMichon(1, 2)](#Ellipse-Perimeter-Length-23) | 9.6884462618134766 != 9.6884482205476754 | 10000 in 6 ms. 0.0006 ms. average | One to two test case. |
| [EllipsePerimeterPadéSelmer(1, 2)](#Ellipse-Perimeter-Length-22) | 9.6884081135181734 != 9.6884482205476754 | 10000 in 5 ms. 0.0005 ms. average | One to two test case. |
| [EllipsePerimeterPeano(1, 2)](#Ellipse-Perimeter-Length-6) | 9.6942840029957029 != 9.6884482205476754 | 10000 in 7 ms. 0.0007 ms. average | One to two test case. |
| [EllipsePerimeterQuadratic(1, 2)](#Ellipse-Perimeter-Length-9) | 9.6830388727066925 != 9.6884482205476754 | 10000 in 11 ms. 0.0011 ms. average | One to two test case. |
| [EllipsePerimeterRamanujan(1, 2)](#Ellipse-Perimeter-Length-19) | 9.6884210976712879 != 9.6884482205476754 | 10000 in 6 ms. 0.0006 ms. average | One to two test case. |
| [EllipsePerimeterRamanujan2(1, 2)](#Ellipse-Perimeter-Length-21) | 9.6884482161300856 != 9.6884482205476754 | 10000 in 5 ms. 0.0005 ms. average | One to two test case. |
| [EllipsePerimeterRivera1(1, 2)](#Ellipse-Perimeter-Length-38) | 10.263842579758375 != 9.6884482205476754 | 10000 in 6 ms. 0.0006 ms. average | One to two test case. |
| [EllipsePerimeterRivera2(1, 2)](#Ellipse-Perimeter-Length-39) | 9.6876717552385525 != 9.6884482205476754 | 10000 in 8 ms. 0.0008 ms. average | One to two test case. |
| [EllipsePerimeterSelmer(1, 2)](#Ellipse-Perimeter-Length-20) | 11.631420262914473 != 9.6884482205476754 | 10000 in 9 ms. 0.0009 ms. average | One to two test case. |
| [EllipsePerimeterSipos(1, 2)](#Ellipse-Perimeter-Length-4) | 9.9964866108563228 != 9.6884482205476754 | 10000 in 6 ms. 0.0006 ms. average | One to two test case. |
| [EllipsePerimeterSykora(1, 2)](#Ellipse-Perimeter-Length-41) | 9.6891032808438151 != 9.6884482205476754 | 10000 in 5 ms. 0.0005 ms. average | One to two test case. |
| [EllipsePerimeterSykoraRiveraCantrellsParticularlyFruitful(1, 2)](#Ellipse-Perimeter-Length-12) | 9.710913742906115 != 9.6884482205476754 | 10000 in 5 ms. 0.0005 ms. average | One to two test case. |
| [EllipsePerimeterTakakazuSeki(1, 2)](#Ellipse-Perimeter-Length-35) | 9.7445797861536789 != 9.6884482205476754 | 10000 in 8 ms. 0.0008 ms. average | One to two test case. |
| [EllipsePerimeterThomasBlankenhorn1(1, 2)](#Ellipse-Perimeter-Length-44) | 9.688448146555233 != 9.6884482205476754 | 10000 in 12 ms. 0.0012 ms. average | One to two test case. |
| [EllipsePerimeterThomasBlankenhorn8(1, 2)](#Ellipse-Perimeter-Length-45) | 9.6884482133005871 != 9.6884482205476754 | 10000 in 14 ms. 0.0014 ms. average | One to two test case. |
| [EllipsePerimeterYNOT(1, 2)](#Ellipse-Perimeter-Length-13) | 9.7044816306435138 != 9.6884482205476754 | 10000 in 7 ms. 0.0007 ms. average | One to two test case. |

### (1, 3)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [_ExactEllipsePerimeter(1, 3)](#Ellipse-Perimeter-Length-1) | 13.364893220555258 == 13.364893220555258 | 10000 in 10 ms. 0.001 ms. average | One to three test case. |
| [EllipsePerimeter1(1, 3)](#Ellipse-Perimeter-Length-1) | 14.049629462081453 != 13.364893220555258 | 10000 in 5 ms. 0.0005 ms. average | One to three test case. |
| [EllipsePerimeter2(1, 3)](#Ellipse-Perimeter-Length-2) | 13.364893009593915 != 13.364893220555258 | 10000 in 12 ms. 0.0012 ms. average | One to three test case. |
| [EllipsePerimeter2_3JacobsenWaadeland(1, 3)](#Ellipse-Perimeter-Length-17) | 15.998708113453089 != 13.364893220555258 | 10000 in 8 ms. 0.0008 ms. average | One to three test case. |
| [EllipsePerimeter3_3_3_2(1, 3)](#Ellipse-Perimeter-Length-18) | 15.998464542318992 != 13.364893220555258 | 10000 in 6 ms. 0.0006 ms. average | One to three test case. |
| [EllipsePerimeterAhmadi2006(1, 3)](#Ellipse-Perimeter-Length-47) | 13.364901392478366 != 13.364893220555258 | 10000 in 10 ms. 0.001 ms. average | One to three test case. |
| [EllipsePerimeterAlmkvist(1, 3)](#Ellipse-Perimeter-Length-8) | 24.967302363384821 != 13.364893220555258 | 10000 in 11 ms. 0.0011 ms. average | One to three test case. |
| [EllipsePerimeterBartolomeu(1, 3)](#Ellipse-Perimeter-Length-37) | 13.416407864998739 != 13.364893220555258 | 10000 in 16 ms. 0.0016 ms. average | One to three test case. |
| [EllipsePerimeterBartolomeuMichon(1, 3)](#Ellipse-Perimeter-Length-33) | 13.551639618546297 != 13.364893220555258 | 10000 in 10 ms. 0.001 ms. average | One to three test case. |
| [EllipsePerimeterBessel(1, 3)](#Ellipse-Perimeter-Length-Bessel) | 13.364893219286676 != 13.364893220555258 | 10000 in 12 ms. 0.0012 ms. average | One to three test case. |
| [EllipsePerimeterCantrell(1, 3)](#Ellipse-Perimeter-Length-40) | 14.867666954589119 != 13.364893220555258 | 10000 in 7 ms. 0.0007 ms. average | One to three test case. |
| [EllipsePerimeterCantrell2(1, 3)](#Ellipse-Perimeter-Length-34) | 13.364896216299904 != 13.364893220555258 | 10000 in 9 ms. 0.0009 ms. average | One to three test case. |
| [EllipsePerimeterCantrell2006(1, 3)](#Ellipse-Perimeter-Length-46) | 13.364824481736408 != 13.364893220555258 | 10000 in 11 ms. 0.0011 ms. average | One to three test case. |
| [EllipsePerimeterCantrellRamanujan(1, 3)](#Ellipse-Perimeter-Length-42) | 13.364892780210418 != 13.364893220555258 | 10000 in 7 ms. 0.0007 ms. average | One to three test case. |
| [EllipsePerimeterCombinedPadé(1, 3)](#Ellipse-Perimeter-Length-14) | 15.999999999999998 != 13.364893220555258 | 10000 in 7 ms. 0.0007 ms. average | One to three test case. |
| [EllipsePerimeterCombinedPadéHudsonLipkaMichon(1, 3)](#Ellipse-Perimeter-Length-25) | 13.443398563486323 != 13.364893220555258 | 10000 in 14 ms. 0.0014 ms. average | One to three test case. |
| [EllipsePerimeterEuler(1, 3)](#Ellipse-Perimeter-Length-7) | 14.049629462081453 != 13.364893220555258 | 10000 in 8 ms. 0.0008 ms. average | One to three test case. |
| [EllipsePerimeterJacobsenWaadelandHudsonLipka(1, 3)](#Ellipse-Perimeter-Length-16) | 15.999999999999998 != 13.364893220555258 | 10000 in 9 ms. 0.0009 ms. average | One to three test case. |
| [EllipsePerimeterK13(1, 3)](#Ellipse-Perimeter-Length-43) | 13.308000038220312 != 13.364893220555258 | 10000 in 6 ms. 0.0006 ms. average | One to three test case. |
| [EllipsePerimeterKepler(1, 3)](#Ellipse-Perimeter-Length-3) | 10.882796185405306 != 13.364893220555258 | 10000 in 5 ms. 0.0005 ms. average | One to three test case. |
| [EllipsePerimeterLindner(1, 3)](#Ellipse-Perimeter-Length-11) | 12.761209684742839 != 13.364893220555258 | 10000 in 10 ms. 0.001 ms. average | One to three test case. |
| [EllipsePerimeterLockwood(1, 3)](#Ellipse-Perimeter-Length-36) | 13.24841432147679 != 13.364893220555258 | 10000 in 10 ms. 0.001 ms. average | One to three test case. |
| [EllipsePerimeterMuir(1, 3)](#Ellipse-Perimeter-Length-10) | 13.352869349830646 != 13.364893220555258 | 10000 in 8 ms. 0.0008 ms. average | One to three test case. |
| [EllipsePerimeterNaive(1, 3)](#Ellipse-Perimeter-Length-5) | 12.566370614359172 != 13.364893220555258 | 10000 in 10 ms. 0.001 ms. average | One to three test case. |
| [EllipsePerimeterOptimizedPeano(1, 3)](#Ellipse-Perimeter-Length-29) | 13.105114431624409 != 13.364893220555258 | 10000 in 5 ms. 0.0005 ms. average | One to three test case. |
| [EllipsePerimeterOptimizedQuadratic1(1, 3)](#Ellipse-Perimeter-Length-30) | 13.4659980945635 != 13.364893220555258 | 10000 in 6 ms. 0.0006 ms. average | One to three test case. |
| [EllipsePerimeterOptimizedQuadratic2(1, 3)](#Ellipse-Perimeter-Length-31) | 14.609964916710679 != 13.364893220555258 | 10000 in 9 ms. 0.0009 ms. average | One to three test case. |
| [EllipsePerimeterOptimizedRamanujan1(1, 3)](#Ellipse-Perimeter-Length-32) | 13.375333431445613 != 13.364893220555258 | 10000 in 6 ms. 0.0006 ms. average | One to three test case. |
| [EllipsePerimeterPadé3_2(1, 3)](#Ellipse-Perimeter-Length-27) | 13.364893083994293 != 13.364893220555258 | 10000 in 8 ms. 0.0008 ms. average | One to three test case. |
| [EllipsePerimeterPadé3_3(1, 3)](#Ellipse-Perimeter-Length-28) | 13.364893211253367 != 13.364893220555258 | 10000 in 7 ms. 0.0007 ms. average | One to three test case. |
| [EllipsePerimeterPadéHudsonLipkaBronshtein(1, 3)](#Ellipse-Perimeter-Length-24) | 13.443398563486323 != 13.364893220555258 | 10000 in 15 ms. 0.0015 ms. average | One to three test case. |
| [EllipsePerimeterPadéJacobsenWaadeland(1, 3)](#Ellipse-Perimeter-Length-26) | 13.364891014942938 != 13.364893220555258 | 10000 in 5 ms. 0.0005 ms. average | One to three test case. |
| [EllipsePerimeterPadéMichon(1, 3)](#Ellipse-Perimeter-Length-23) | 13.36482036013957 != 13.364893220555258 | 10000 in 7 ms. 0.0007 ms. average | One to three test case. |
| [EllipsePerimeterPadéSelmer(1, 3)](#Ellipse-Perimeter-Length-22) | 13.364235415270866 != 13.364893220555258 | 10000 in 6 ms. 0.0006 ms. average | One to three test case. |
| [EllipsePerimeterPeano(1, 3)](#Ellipse-Perimeter-Length-6) | 13.408157828836107 != 13.364893220555258 | 10000 in 8 ms. 0.0008 ms. average | One to three test case. |
| [EllipsePerimeterQuadratic(1, 3)](#Ellipse-Perimeter-Length-9) | 13.328648814475097 != 13.364893220555258 | 10000 in 10 ms. 0.001 ms. average | One to three test case. |
| [EllipsePerimeterRamanujan(1, 3)](#Ellipse-Perimeter-Length-19) | 13.364439787235845 != 13.364893220555258 | 10000 in 6 ms. 0.0006 ms. average | One to three test case. |
| [EllipsePerimeterRamanujan2(1, 3)](#Ellipse-Perimeter-Length-21) | 13.36489277982672 != 13.364893220555258 | 10000 in 6 ms. 0.0006 ms. average | One to three test case. |
| [EllipsePerimeterRivera1(1, 3)](#Ellipse-Perimeter-Length-38) | 15.303936465488505 != 13.364893220555258 | 10000 in 6 ms. 0.0006 ms. average | One to three test case. |
| [EllipsePerimeterRivera2(1, 3)](#Ellipse-Perimeter-Length-39) | 13.36352587654069 != 13.364893220555258 | 10000 in 6 ms. 0.0006 ms. average | One to three test case. |
| [EllipsePerimeterSelmer(1, 3)](#Ellipse-Perimeter-Length-20) | 39.140777713903759 != 13.364893220555258 | 10000 in 16 ms. 0.0016 ms. average | One to three test case. |
| [EllipsePerimeterSipos(1, 3)](#Ellipse-Perimeter-Length-4) | 14.510394913873744 != 13.364893220555258 | 10000 in 5 ms. 0.0005 ms. average | One to three test case. |
| [EllipsePerimeterSykora(1, 3)](#Ellipse-Perimeter-Length-41) | 13.365780395389869 != 13.364893220555258 | 10000 in 5 ms. 0.0005 ms. average | One to three test case. |
| [EllipsePerimeterSykoraRiveraCantrellsParticularlyFruitful(1, 3)](#Ellipse-Perimeter-Length-12) | 13.424777960769379 != 13.364893220555258 | 10000 in 7 ms. 0.0007 ms. average | One to three test case. |
| [EllipsePerimeterTakakazuSeki(1, 3)](#Ellipse-Perimeter-Length-35) | 13.506859472618803 != 13.364893220555258 | 10000 in 6 ms. 0.0006 ms. average | One to three test case. |
| [EllipsePerimeterThomasBlankenhorn1(1, 3)](#Ellipse-Perimeter-Length-44) | 13.364893564992762 != 13.364893220555258 | 10000 in 12 ms. 0.0012 ms. average | One to three test case. |
| [EllipsePerimeterThomasBlankenhorn8(1, 3)](#Ellipse-Perimeter-Length-45) | 13.364893270368384 != 13.364893220555258 | 10000 in 11 ms. 0.0011 ms. average | One to three test case. |
| [EllipsePerimeterYNOT(1, 3)](#Ellipse-Perimeter-Length-13) | 13.404710414370236 != 13.364893220555258 | 10000 in 8 ms. 0.0008 ms. average | One to three test case. |

### (2, 4)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [_ExactEllipsePerimeter(2, 4)](#Ellipse-Perimeter-Length-1) | 19.376896441095351 == 19.376896441095351 | 10000 in 6 ms. 0.0006 ms. average | Two to four test case. |
| [EllipsePerimeter1(2, 4)](#Ellipse-Perimeter-Length-1) | 19.869176531592203 != 19.376896441095351 | 10000 in 8 ms. 0.0008 ms. average | Two to four test case. |
| [EllipsePerimeter2(2, 4)](#Ellipse-Perimeter-Length-2) | 19.376896434536306 != 19.376896441095351 | 10000 in 7 ms. 0.0007 ms. average | Two to four test case. |
| [EllipsePerimeter2_3JacobsenWaadeland(2, 4)](#Ellipse-Perimeter-Length-17) | 23.998062170179633 != 19.376896441095351 | 10000 in 18 ms. 0.0018 ms. average | Two to four test case. |
| [EllipsePerimeter3_3_3_2(2, 4)](#Ellipse-Perimeter-Length-18) | 23.997696813478488 != 19.376896441095351 | 10000 in 5 ms. 0.0005 ms. average | Two to four test case. |
| [EllipsePerimeterAhmadi2006(2, 4)](#Ellipse-Perimeter-Length-47) | 19.376888015541326 != 19.376896441095351 | 10000 in 6 ms. 0.0006 ms. average | Two to four test case. |
| [EllipsePerimeterAlmkvist(2, 4)](#Ellipse-Perimeter-Length-8) | 37.653309799231607 != 19.376896441095351 | 10000 in 12 ms. 0.0012 ms. average | Two to four test case. |
| [EllipsePerimeterBartolomeu(2, 4)](#Ellipse-Perimeter-Length-37) | 19.362420305354885 != 19.376896441095351 | 10000 in 8 ms. 0.0008 ms. average | Two to four test case. |
| [EllipsePerimeterBartolomeuMichon(2, 4)](#Ellipse-Perimeter-Length-33) | 19.528125814614473 != 19.376896441095351 | 10000 in 5 ms. 0.0005 ms. average | Two to four test case. |
| [EllipsePerimeterBessel(2, 4)](#Ellipse-Perimeter-Length-Bessel) | 19.376896441094843 != 19.376896441095351 | 10000 in 12 ms. 0.0012 ms. average | Two to four test case. |
| [EllipsePerimeterCantrell(2, 4)](#Ellipse-Perimeter-Length-40) | 22.014641590061714 != 19.376896441095351 | 10000 in 9 ms. 0.0009 ms. average | Two to four test case. |
| [EllipsePerimeterCantrell2(2, 4)](#Ellipse-Perimeter-Length-34) | 19.376869921609433 != 19.376896441095351 | 10000 in 17 ms. 0.0017 ms. average | Two to four test case. |
| [EllipsePerimeterCantrell2006(2, 4)](#Ellipse-Perimeter-Length-46) | 19.3768422174958 != 19.376896441095351 | 10000 in 8 ms. 0.0008 ms. average | Two to four test case. |
| [EllipsePerimeterCantrellRamanujan(2, 4)](#Ellipse-Perimeter-Length-42) | 19.376896432260203 != 19.376896441095351 | 10000 in 12 ms. 0.0012 ms. average | Two to four test case. |
| [EllipsePerimeterCombinedPadé(2, 4)](#Ellipse-Perimeter-Length-14) | 23.999999999999996 != 19.376896441095351 | 10000 in 5 ms. 0.0005 ms. average | Two to four test case. |
| [EllipsePerimeterCombinedPadéHudsonLipkaMichon(2, 4)](#Ellipse-Perimeter-Length-25) | 19.399334635916976 != 19.376896441095351 | 10000 in 6 ms. 0.0006 ms. average | Two to four test case. |
| [EllipsePerimeterEuler(2, 4)](#Ellipse-Perimeter-Length-7) | 19.869176531592203 != 19.376896441095351 | 10000 in 5 ms. 0.0005 ms. average | Two to four test case. |
| [EllipsePerimeterJacobsenWaadelandHudsonLipka(2, 4)](#Ellipse-Perimeter-Length-16) | 23.999999999999996 != 19.376896441095351 | 10000 in 5 ms. 0.0005 ms. average | Two to four test case. |
| [EllipsePerimeterK13(2, 4)](#Ellipse-Perimeter-Length-43) | 19.359366226565481 != 19.376896441095351 | 10000 in 5 ms. 0.0005 ms. average | Two to four test case. |
| [EllipsePerimeterKepler(2, 4)](#Ellipse-Perimeter-Length-3) | 17.771531752633464 != 19.376896441095351 | 10000 in 5 ms. 0.0005 ms. average | Two to four test case. |
| [EllipsePerimeterLindner(2, 4)](#Ellipse-Perimeter-Length-11) | 18.980004231816217 != 19.376896441095351 | 10000 in 10 ms. 0.001 ms. average | Two to four test case. |
| [EllipsePerimeterLockwood(2, 4)](#Ellipse-Perimeter-Length-36) | 19.265318359202155 != 19.376896441095351 | 10000 in 5 ms. 0.0005 ms. average | Two to four test case. |
| [EllipsePerimeterMuir(2, 4)](#Ellipse-Perimeter-Length-10) | 19.373293441053505 != 19.376896441095351 | 10000 in 11 ms. 0.0011 ms. average | Two to four test case. |
| [EllipsePerimeterNaive(2, 4)](#Ellipse-Perimeter-Length-5) | 18.849555921538759 != 19.376896441095351 | 10000 in 5 ms. 0.0005 ms. average | Two to four test case. |
| [EllipsePerimeterOptimizedPeano(2, 4)](#Ellipse-Perimeter-Length-29) | 19.194523655588451 != 19.376896441095351 | 10000 in 5 ms. 0.0005 ms. average | Two to four test case. |
| [EllipsePerimeterOptimizedQuadratic1(2, 4)](#Ellipse-Perimeter-Length-30) | 19.460863102765376 != 19.376896441095351 | 10000 in 10 ms. 0.001 ms. average | Two to four test case. |
| [EllipsePerimeterOptimizedQuadratic2(2, 4)](#Ellipse-Perimeter-Length-31) | 20.269266461549712 != 19.376896441095351 | 10000 in 11 ms. 0.0011 ms. average | Two to four test case. |
| [EllipsePerimeterOptimizedRamanujan1(2, 4)](#Ellipse-Perimeter-Length-32) | 19.384039652979993 != 19.376896441095351 | 10000 in 5 ms. 0.0005 ms. average | Two to four test case. |
| [EllipsePerimeterPadé3_2(2, 4)](#Ellipse-Perimeter-Length-27) | 19.3768964399006 != 19.376896441095351 | 10000 in 5 ms. 0.0005 ms. average | Two to four test case. |
| [EllipsePerimeterPadé3_3(2, 4)](#Ellipse-Perimeter-Length-28) | 19.376896441061668 != 19.376896441095351 | 10000 in 6 ms. 0.0006 ms. average | Two to four test case. |
| [EllipsePerimeterPadéHudsonLipkaBronshtein(2, 4)](#Ellipse-Perimeter-Length-24) | 19.399334635916976 != 19.376896441095351 | 10000 in 11 ms. 0.0011 ms. average | Two to four test case. |
| [EllipsePerimeterPadéJacobsenWaadeland(2, 4)](#Ellipse-Perimeter-Length-26) | 19.3768963943323 != 19.376896441095351 | 10000 in 7 ms. 0.0007 ms. average | Two to four test case. |
| [EllipsePerimeterPadéMichon(2, 4)](#Ellipse-Perimeter-Length-23) | 19.376892523626953 != 19.376896441095351 | 10000 in 5 ms. 0.0005 ms. average | Two to four test case. |
| [EllipsePerimeterPadéSelmer(2, 4)](#Ellipse-Perimeter-Length-22) | 19.376816227036347 != 19.376896441095351 | 10000 in 8 ms. 0.0008 ms. average | Two to four test case. |
| [EllipsePerimeterPeano(2, 4)](#Ellipse-Perimeter-Length-6) | 19.388568005991406 != 19.376896441095351 | 10000 in 5 ms. 0.0005 ms. average | Two to four test case. |
| [EllipsePerimeterQuadratic(2, 4)](#Ellipse-Perimeter-Length-9) | 19.366077745413385 != 19.376896441095351 | 10000 in 7 ms. 0.0007 ms. average | Two to four test case. |
| [EllipsePerimeterRamanujan(2, 4)](#Ellipse-Perimeter-Length-19) | 19.376842195342576 != 19.376896441095351 | 10000 in 9 ms. 0.0009 ms. average | Two to four test case. |
| [EllipsePerimeterRamanujan2(2, 4)](#Ellipse-Perimeter-Length-21) | 19.376896432260171 != 19.376896441095351 | 10000 in 5 ms. 0.0005 ms. average | Two to four test case. |
| [EllipsePerimeterRivera1(2, 4)](#Ellipse-Perimeter-Length-38) | 20.52768515951675 != 19.376896441095351 | 10000 in 6 ms. 0.0006 ms. average | Two to four test case. |
| [EllipsePerimeterRivera2(2, 4)](#Ellipse-Perimeter-Length-39) | 19.375343510477105 != 19.376896441095351 | 10000 in 7 ms. 0.0007 ms. average | Two to four test case. |
| [EllipsePerimeterSelmer(2, 4)](#Ellipse-Perimeter-Length-20) | 58.605757878714115 != 19.376896441095351 | 10000 in 8 ms. 0.0008 ms. average | Two to four test case. |
| [EllipsePerimeterSipos(2, 4)](#Ellipse-Perimeter-Length-4) | 19.992973221712646 != 19.376896441095351 | 10000 in 8 ms. 0.0008 ms. average | Two to four test case. |
| [EllipsePerimeterSykora(2, 4)](#Ellipse-Perimeter-Length-41) | 19.37820656168763 != 19.376896441095351 | 10000 in 8 ms. 0.0008 ms. average | Two to four test case. |
| [EllipsePerimeterSykoraRiveraCantrellsParticularlyFruitful(2, 4)](#Ellipse-Perimeter-Length-12) | 19.42182748581223 != 19.376896441095351 | 10000 in 5 ms. 0.0005 ms. average | Two to four test case. |
| [EllipsePerimeterTakakazuSeki(2, 4)](#Ellipse-Perimeter-Length-35) | 19.489159572307358 != 19.376896441095351 | 10000 in 12 ms. 0.0012 ms. average | Two to four test case. |
| [EllipsePerimeterThomasBlankenhorn1(2, 4)](#Ellipse-Perimeter-Length-44) | 19.376896293110466 != 19.376896441095351 | 10000 in 13 ms. 0.0013 ms. average | Two to four test case. |
| [EllipsePerimeterThomasBlankenhorn8(2, 4)](#Ellipse-Perimeter-Length-45) | 19.376896426601174 != 19.376896441095351 | 10000 in 10 ms. 0.001 ms. average | Two to four test case. |
| [EllipsePerimeterYNOT(2, 4)](#Ellipse-Perimeter-Length-13) | 19.408963261287024 != 19.376896441095351 | 10000 in 8 ms. 0.0008 ms. average | Two to four test case. |

### (0, 4)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [_ExactEllipsePerimeter(0, 4)](#Ellipse-Perimeter-Length-1) | 16 == 16 | 10000 in 6 ms. 0.0006 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeter1(0, 4)](#Ellipse-Perimeter-Length-1) | 17.771531752633464 != 16 | 10000 in 10 ms. 0.001 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeter2(0, 4)](#Ellipse-Perimeter-Length-2) | 16 == 16 | 10000 in 6 ms. 0.0006 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeter2_3JacobsenWaadeland(0, 4)](#Ellipse-Perimeter-Length-17) | 15.998708113453089 != 16 | 10000 in 10 ms. 0.001 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeter3_3_3_2(0, 4)](#Ellipse-Perimeter-Length-18) | 15.998464542318992 != 16 | 10000 in 6 ms. 0.0006 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterAhmadi2006(0, 4)](#Ellipse-Perimeter-Length-47) | 16 == 16 | 10000 in 9 ms. 0.0009 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterAlmkvist(0, 4)](#Ellipse-Perimeter-Length-8) | 25.132741228718345 != 16 | 10000 in 14 ms. 0.0014 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterBartolomeu(0, 4)](#Ellipse-Perimeter-Length-37) | 16 == 16 | 10000 in 7 ms. 0.0007 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterBartolomeuMichon(0, 4)](#Ellipse-Perimeter-Length-33) | 16 == 16 | 10000 in 6 ms. 0.0006 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterBessel(0, 4)](#Ellipse-Perimeter-Length-Bessel) | 15.994167990438742 != 16 | 10000 in 9 ms. 0.0009 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterCantrell(0, 4)](#Ellipse-Perimeter-Length-40) | 16 == 16 | 10000 in 7 ms. 0.0007 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterCantrell2(0, 4)](#Ellipse-Perimeter-Length-34) | 16 == 16 | 10000 in 13 ms. 0.0013 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterCantrell2006(0, 4)](#Ellipse-Perimeter-Length-46) | 16 == 16 | 10000 in 9 ms. 0.0009 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterCantrellRamanujan(0, 4)](#Ellipse-Perimeter-Length-42) | 16 == 16 | 10000 in 8 ms. 0.0008 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterCombinedPadé(0, 4)](#Ellipse-Perimeter-Length-14) | 15.999999999999998 != 16 | 10000 in 9 ms. 0.0009 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterCombinedPadéHudsonLipkaMichon(0, 4)](#Ellipse-Perimeter-Length-25) | 17.540558982543011 != 16 | 10000 in 10 ms. 0.001 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterEuler(0, 4)](#Ellipse-Perimeter-Length-7) | 17.771531752633464 != 16 | 10000 in 5 ms. 0.0005 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterJacobsenWaadelandHudsonLipka(0, 4)](#Ellipse-Perimeter-Length-16) | 15.999999999999998 != 16 | 10000 in 7 ms. 0.0007 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterK13(0, 4)](#Ellipse-Perimeter-Length-43) | 15.168951183496318 != 16 | 10000 in 9 ms. 0.0009 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterKepler(0, 4)](#Ellipse-Perimeter-Length-3) | 0 != 16 | 10000 in 10 ms. 0.001 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterLindner(0, 4)](#Ellipse-Perimeter-Length-11) | 13.328648814475097 != 16 | 10000 in 13 ms. 0.0013 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterLockwood(0, 4)](#Ellipse-Perimeter-Length-36) | NaN != 16 | 10000 in 6 ms. 0.0006 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterMuir(0, 4)](#Ellipse-Perimeter-Length-10) | 15.832634857811492 != 16 | 10000 in 6 ms. 0.0006 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterNaive(0, 4)](#Ellipse-Perimeter-Length-5) | 12.566370614359172 != 16 | 10000 in 7 ms. 0.0007 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterOptimizedPeano(0, 4)](#Ellipse-Perimeter-Length-29) | 16.58760921095411 != 16 | 10000 in 8 ms. 0.0008 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterOptimizedQuadratic1(0, 4)](#Ellipse-Perimeter-Length-30) | 15.861633190780255 != 16 | 10000 in 16 ms. 0.0016 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterOptimizedQuadratic2(0, 4)](#Ellipse-Perimeter-Length-31) | 19.495211930568445 != 16 | 10000 in 6 ms. 0.0006 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterOptimizedRamanujan1(0, 4)](#Ellipse-Perimeter-Length-32) | 15.979481054177345 != 16 | 10000 in 5 ms. 0.0005 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterPadé3_2(0, 4)](#Ellipse-Perimeter-Length-27) | 15.992638330410177 != 16 | 10000 in 7 ms. 0.0007 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterPadé3_3(0, 4)](#Ellipse-Perimeter-Length-28) | 15.995726750960086 != 16 | 10000 in 8 ms. 0.0008 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterPadéHudsonLipkaBronshtein(0, 4)](#Ellipse-Perimeter-Length-24) | 17.540558982543011 != 16 | 10000 in 7 ms. 0.0007 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterPadéJacobsenWaadeland(0, 4)](#Ellipse-Perimeter-Length-26) | 15.985791189695004 != 16 | 10000 in 6 ms. 0.0006 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterPadéMichon(0, 4)](#Ellipse-Perimeter-Length-23) | 15.957296018233869 != 16 | 10000 in 5 ms. 0.0005 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterPadéSelmer(0, 4)](#Ellipse-Perimeter-Length-22) | 15.917402778188285 != 16 | 10000 in 8 ms. 0.0008 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterPeano(0, 4)](#Ellipse-Perimeter-Length-6) | 18.849555921538759 != 16 | 10000 in 10 ms. 0.001 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterQuadratic(0, 4)](#Ellipse-Perimeter-Length-9) | 15.390597961942367 != 16 | 10000 in 9 ms. 0.0009 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterRamanujan(0, 4)](#Ellipse-Perimeter-Length-19) | 15.933519472266905 != 16 | 10000 in 7 ms. 0.0007 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterRamanujan2(0, 4)](#Ellipse-Perimeter-Length-21) | 15.993562600093492 != 16 | 10000 in 6 ms. 0.0006 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterRivera1(0, 4)](#Ellipse-Perimeter-Length-38) | NaN != 16 | 10000 in 8 ms. 0.0008 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterRivera2(0, 4)](#Ellipse-Perimeter-Length-39) | 16 == 16 | 10000 in 13 ms. 0.0013 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterSelmer(0, 4)](#Ellipse-Perimeter-Length-20) | 416.53053264287388 != 16 | 10000 in 7 ms. 0.0007 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterSipos(0, 4)](#Ellipse-Perimeter-Length-4) | ∞ != 16 | 10000 in 5 ms. 0.0005 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterSykora(0, 4)](#Ellipse-Perimeter-Length-41) | 16 == 16 | 10000 in 8 ms. 0.0008 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterSykoraRiveraCantrellsParticularlyFruitful(0, 4)](#Ellipse-Perimeter-Length-12) | 16 == 16 | 10000 in 6 ms. 0.0006 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterTakakazuSeki(0, 4)](#Ellipse-Perimeter-Length-35) | 16 == 16 | 10000 in 5 ms. 0.0005 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterThomasBlankenhorn1(0, 4)](#Ellipse-Perimeter-Length-44) | 16 == 16 | 10000 in 9 ms. 0.0009 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterThomasBlankenhorn8(0, 4)](#Ellipse-Perimeter-Length-45) | 16 == 16 | 10000 in 6 ms. 0.0006 ms. average | Zero height, or double sided line segment test case. |
| [EllipsePerimeterYNOT(0, 4)](#Ellipse-Perimeter-Length-13) | 15.999999999999998 != 16 | 10000 in 13 ms. 0.0013 ms. average | Zero height, or double sided line segment test case. |

## The Code

The code for the methods tested follows below.

### Ellipse Perimeter Length 1

Find the length of the Perimeter of an ellipse.  
- [http://www.paulbourke.net/geometry/ellipsecirc/](http://www.paulbourke.net/geometry/ellipsecirc/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double _ExactEllipsePerimeter(double a, double b)
        {
            // If a or b are 0 then the ellipse is a set of two line segments.
            if (a == 0 || b == 0)
            {
                return a > b ? a * 4d : b * 4d;
            }

            var tol = DoubleEpsilon;// Pow(0.5d, 27d);
            var s = 0d;
            var m = 1d;
            var x = a > b ? a : b;
            var y = a < b ? a : b;
            while (x - y > tol * y)
            {
                var t = (x + y) / 2d;
                y = Sqrt(x * y);
                x = t;
                m *= 2d;
                s += m * (x - y) * (x - y);
            }

            return PI * (((a + b) * (a + b)) - s) / (x + y);
        }
```

### Ellipse Perimeter Length 1

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeter1(double a, double b)
        {
            return 2d * PI * Sqrt(0.5d * ((b * b) + (a * a)));
        }
```

### Ellipse Perimeter Length 2

Find the length of the Perimeter of an ellipse.  
- [http://ellipse-circumference.blogspot.com/](http://ellipse-circumference.blogspot.com/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeter2(double a, double b)
        {
            var h = (b - a) * (b - a) / ((b + a) * (b + a));
            var H2 = 4d - (3d * h);
            var d = (11d * PI / (44d - (14d * PI))) + 24100d - (24100d * h);
            return PI * (b + a) * (1d + (3d * h / (10d + Pow(H2, 0.5d))) + (((1.5d * Pow(h, 6)) - (0.5d * Pow(h, 12d))) / d));
        }
```

### Ellipse Perimeter Length 17

Find the length of the Perimeter of an ellipse.  
- [http://www.ebyte.it/library/docs/math07/EllipsePerimeterApprox07add.html](http://www.ebyte.it/library/docs/math07/EllipsePerimeterApprox07add.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeter2_3JacobsenWaadeland(double a, double b)
        {
            const double d1 = (PI / 4d * (61d / 48d)) - 1d;
            const double d2 = (PI / 4d * (187d / 147d)) - 1d;
            const double p = d1 / (d1 - d2);
            const double h = 1d;
            return PI * (a + b) * ((p * ((3072d - (1280d * h) - (252d * h * h) + (33d * h * h * h)) / (3072d - (2048d * h) + (212d * h * h)))) + ((1d - p) * ((256d - (48d * h) - (21d * h * h)) / (256d - (112d * h) + (3d * h * h)))));
        }
```

### Ellipse Perimeter Length 18

Find the length of the Perimeter of an ellipse.  
- [http://www.ebyte.it/library/docs/math07/EllipsePerimeterApprox07add.html](http://www.ebyte.it/library/docs/math07/EllipsePerimeterApprox07add.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeter3_3_3_2(double a, double b)
        {
            const double d1 = (PI / 4d * (61d / 48d)) - 1d;
            const double d2 = (PI / 4d * (187d / 147d)) - 1d;
            const double p = d1 / (d1 - d2);
            const double h = 1d;
            return PI * (a + b) * ((p * ((135168d - (85760d * h) - (5568d * h * h) + (3867d * h * h * h)) / (135168d - (119552d * h) + (22208d * h * h) - (345d * h * h * h)))) + ((1d - p) * ((3072d - (1280d * h) - (252d * h * h) + (33d * h * h * h)) / (3072d - (2048d * h) + (212d * h * h)))));
        }
```

### Ellipse Perimeter Length 47

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterAhmadi2006(double a, double b)
        {
            const double c1 = PI - 3d;
            const double c2 = PI;
            const double c3 = 0.5d;
            const double c4 = (PI + 1d) / 2d;
            const double c5 = 4d;
            var k = 1d - (c1 * a * b / ((a * a) + (b * b) + (c2 * Sqrt((c3 * a * b * a * b) + (a * b * Sqrt(a * b * ((c4 * ((a * a) + (b * b))) + (c5 * a * b))))))));
            return 4d * (((PI * a * b) + (k * (a - b) * (a - b))) / (a + b));
        }
```

### Ellipse Perimeter Length 8

Find the length of the Perimeter of an ellipse.  
- [http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html](http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterAlmkvist(double a, double b)
        {
            return 2d * PI
                * (((2d * Pow(a + b, 2d)) - Pow(Sqrt(a) - Sqrt(b), 4d))
                / (Pow(Sqrt(a) - Sqrt(b), 2d) + (2d * Sqrt(2d * (a + b)) * Pow(a * b, 1d / 4d))));
        }
```

### Ellipse Perimeter Length 37

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterBartolomeu(double a, double b)
        {
            var t = PI / 4d * ((a - b) / b);
            return PI * Sqrt(2d * ((a * a) + (b * b))) * (Sin(t) / t);
        }
```

### Ellipse Perimeter Length 33

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterBartolomeuMichon(double a, double b)
        {
            return Abs(a - b) < DoubleEpsilon ? 2d * PI * a : PI * ((a - b) / Atan((a - b) / (a + b)));
        }
```

### Ellipse Perimeter Length Bessel

Find the length of the Perimeter of an ellipse using the Bessel formula.  
- [http://www.paulbourke.net/geometry/ellipsecirc/](http://www.paulbourke.net/geometry/ellipsecirc/)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterBessel(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            var n = 10;

            var len = 1d;
            double sum;
            for (var i = 1; i < n; i++)
            {
                sum = 1d;
                for (var j = i; j > 0; j--)
                {
                    if (j > 1)
                    {
                        sum *= (2d * (j - 1)) - 1;
                    }
                    sum /= 2d * j;
                }
                len += Pow(h, i) * sum * sum;
            }
            len *= PI * (a + b);

            return len;
        }
```

### Ellipse Perimeter Length 40

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterCantrell(double a, double b)
        {
            var s = Log(2d) / Log(2d / (4d - PI));
            return (4d * (a + b)) - (2d * (4d - PI) * a * b / Pow(Pow(a, s) + Pow(b, s), 1d / s));
        }
```

### Ellipse Perimeter Length 34

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterCantrell2(double a, double b)
        {
            const double p = 0.410117d;
            const double w = 74d;
            return (4d * (a + b)) - ((8d - (2d * PI)) * a * b / ((p * (a + b)) + ((1d - (2d * p)) * (Sqrt((a + (w * b)) * ((w * a) + b)) / (1d + w)))));
        }
```

### Ellipse Perimeter Length 46

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterCantrell2006(double a, double b)
        {
            const double p = 3.982901d;
            const double q = 66.71674d;
            const double s = 18.31287d;
            const double t = 23.39728d;
            const double r = 4d * (((4d - PI) * ((4d * s) + t + 16d)) - ((4d * p) + q));
            return (4d * (a + b))
                - (a * b / (a + b)
                * (((p * (a + b) * (a + b)) + (q * a * b) + (r * (a * b / (a + b)) * (a * b / (a + b))))
                / (((a + b) * (a + b)) + (s * a * b) + (t * (a * b / (a + b)) * (a * b / (a + b))))));
        }
```

### Ellipse Perimeter Length 42

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterCantrellRamanujan(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            return PI * (a + b) * (1d + (3d * h / (10d + Sqrt(4d - (3d * h)))) + (((4d / PI) - (14d / 11d)) * Pow(h, 12d)));
        }
```

### Ellipse Perimeter Length 14

Find the length of the Perimeter of an ellipse.  
- [http://www.ebyte.it/library/docs/math07/EllipsePerimeterApprox07add.html](http://www.ebyte.it/library/docs/math07/EllipsePerimeterApprox07add.html)
- [http://www.numericana.com/answer/ellipse.htm#elliptic](http://www.numericana.com/answer/ellipse.htm#elliptic)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterCombinedPadé(double a, double b)
        {
            const double d1 = (PI / 4d * (19d / 15d)) - 1d;
            const double d2 = (PI / 4d * (80d / 63d)) - 1d;
            const double p = d1 / (d1 - d2);
            const double h = 1d;
            return PI * (a + b) * ((p * ((64d + (16d * h)) / (64d - (h * h)))) + ((1d - p) * ((16d + (3d * h)) / (16d - h))));
        }
```

### Ellipse Perimeter Length 25

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterCombinedPadéHudsonLipkaMichon(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            return PI * (a + b) * ((64d + (3d * h * h)) / (64d - (16d * h)));
        }
```

### Ellipse Perimeter Length 7

Find the length of the Perimeter of an ellipse.  
- [http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html](http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterEuler(double a, double b)
        {
            return 2d * PI * Sqrt(((a * a) + (b * b)) / 2d);
        }
```

### Ellipse Perimeter Length 16

Find the length of the Perimeter of an ellipse.  
- [http://www.ebyte.it/library/docs/math07/EllipsePerimeterApprox07add.html](http://www.ebyte.it/library/docs/math07/EllipsePerimeterApprox07add.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterJacobsenWaadelandHudsonLipka(double a, double b)
        {
            const double d1 = (PI / 4d * (61d / 48d)) - 1d;
            const double d2 = (PI / 4d * (187d / 147d)) - 1d;
            const double p = d1 / (d1 - d2);
            const double h = 1d;
            return PI * (a + b) * ((p * ((256d - (48d * h) - (21d * h * h)) / (256d - (112d * h) + (3d * h * h)))) + ((1d - p) * ((64d - (3d * h * h)) / (64d - (16d * h)))));
        }
```

### Ellipse Perimeter Length 43

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterK13(double a, double b)
        {
            return PI * (((a + b) / 2d) + Sqrt(((a * a) + (b * b)) / 2d));
        }
```

### Ellipse Perimeter Length 3

Find the length of the Perimeter of an ellipse.  
- [http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html](http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterKepler(double a, double b)
        {
            return 2d * PI * Sqrt(a * b);
        }
```

### Ellipse Perimeter Length 11

Find the length of the Perimeter of an ellipse.  
- [http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html](http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterLindner(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            return PI * (a + b) * Sqrt(1d + (h / 8d));
        }
```

### Ellipse Perimeter Length 36

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterLockwood(double a, double b)
        {
            return 4d * ((b * b / a * Atan(a / b)) + (a * a / b * Atan(b / a)));
        }
```

### Ellipse Perimeter Length 10

Find the length of the Perimeter of an ellipse.  
- [http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html](http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterMuir(double a, double b)
        {
            return 2d * PI * Pow((Pow(a, 3d / 2d) + Pow(b, 3d / 2d)) / 2d, 2d / 3d);
        }
```

### Ellipse Perimeter Length 5

Find the length of the Perimeter of an ellipse.  
- [http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html](http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterNaive(double a, double b)
        {
            return PI * (a + b);
        }
```

### Ellipse Perimeter Length 29

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterOptimizedPeano(double a, double b)
        {
            const double p = 1.32d;
            return 2d * PI * ((p * ((a + b) / 2d)) + ((1d - p) * Sqrt(a * b)));
        }
```

### Ellipse Perimeter Length 30

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterOptimizedQuadratic1(double a, double b)
        {
            const double w = 0.7966106d;
            return 2d * PI * Sqrt((w * (((a * a) + (b * b)) / 2d)) + ((1d - w) * a * b));
        }
```

### Ellipse Perimeter Length 31

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterOptimizedQuadratic2(double a, double b)
        {
            return PI * Sqrt((2d * ((a * a) + (b * b))) + ((a - b) * (a - b) / 2.458338d));
        }
```

### Ellipse Perimeter Length 32

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterOptimizedRamanujan1(double a, double b)
        {
            const double p = 3.0273d;
            const double w = 3d;
            return 2d * PI * ((p * ((a + b) / 2d)) + ((1d - p) * Sqrt((a + (w * b)) * ((w * a) + b)) / (1d + w)));
        }
```

### Ellipse Perimeter Length 27

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterPadé3_2(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            return PI * (a + b) * ((3072d - (1280d * h) - (252d * h * h) + (33d * h * h * h)) / (3072d - (2048d * h) + (212d * h * h)));
        }
```

### Ellipse Perimeter Length 28

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterPadé3_3(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            return PI * (a + b)
                * ((135168d - (85760d * h) - (5568d * h * h) + (3867d * h * h * h))
                / (135168d - (119552d * h) + (22208d * h * h) - (345d * h * h * h)));
        }
```

### Ellipse Perimeter Length 24

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterPadéHudsonLipkaBronshtein(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            return PI * (a + b) * ((64d + (3d * h * h)) / (64d - (16d * h)));
        }
```

### Ellipse Perimeter Length 26

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterPadéJacobsenWaadeland(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            return PI * (a + b) * ((256d - (48d * h) - (21d * h * h)) / (256d - (112d * h) + (3d * h * h)));
        }
```

### Ellipse Perimeter Length 23

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterPadéMichon(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            return PI * (a + b) * ((64d + (16d * h)) / (64d - (h * h)));
        }
```

### Ellipse Perimeter Length 22

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterPadéSelmer(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            return PI * (a + b) * ((16d + (3d * h)) / (16d - h));
        }
```

### Ellipse Perimeter Length 6

Find the length of the Perimeter of an ellipse.  
- [http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html](http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterPeano(double a, double b)
        {
            return PI * ((3d * (a + b) / 2d) - Sqrt(a * b));
        }
```

### Ellipse Perimeter Length 9

Find the length of the Perimeter of an ellipse.  
- [http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html](http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterQuadratic(double a, double b)
        {
            return PI / 2d * Sqrt((6d * ((a * a) + (b * b))) + (4d * a * b));
        }
```

### Ellipse Perimeter Length 19

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterRamanujan(double a, double b)
        {
            return PI * ((3d * (a + b)) - Sqrt(((3d * a) + b) * (a + (3d * b))));
        }
```

### Ellipse Perimeter Length 21

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterRamanujan2(double a, double b)
        {
            var h = (a - b) * (a - b) / ((a + b) * (a + b));
            return PI * (a + b) * (1d + (3d * h / (10d + Sqrt(4 - (3d * h)))));
        }
```

### Ellipse Perimeter Length 38

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterRivera1(double a, double b)
        {
            return (4d * a) + (2d * (PI - 2d) * a * Pow(b / a, 1.456d));
        }
```

### Ellipse Perimeter Length 39

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterRivera2(double a, double b)
        {
            return (4d * (((PI * a * b) + ((a - b) * (a - b))) / (a + b))) - (89d / 146d * Pow(((b * Sqrt(a)) - (a * Sqrt(b))) / (a + b), 2d));
        }
```

### Ellipse Perimeter Length 20

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterSelmer(double a, double b)
        {
            return PI / 4d * (((6 + (0.5d * (Pow(a - b, 2d) * Pow(a - b, 2d) / Pow(a + b, 2d) * Pow(a + b, 2d)))) * (a + b)) - Sqrt(2d * ((a * a) + (3d * a * b) + (b * b))));
        }
```

### Ellipse Perimeter Length 4

Find the length of the Perimeter of an ellipse.  
- [http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html](http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterSipos(double a, double b)
        {
            return 2d * PI * ((a + b) * (a + b) / ((Sqrt(a) + Sqrt(a)) * (Sqrt(b) + Sqrt(b))));
        }
```

### Ellipse Perimeter Length 41

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterSykora(double a, double b)
        {
            return (4d * (((PI * a * b) + ((a - b) * (a - b))) / (a + b))) - (0.5d * (a * b / (a + b)) * ((a - b) * (a - b) / ((PI * a * b) + ((a + b) * (a + b)))));
        }
```

### Ellipse Perimeter Length 12

Find the length of the Perimeter of an ellipse.  
- [http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html](http://www.ebyte.it/library/docs/math05a/EllipsePerimeterApprox05.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterSykoraRiveraCantrellsParticularlyFruitful(double a, double b)
        {
            return 4d * ((PI * a * b) + ((a - b) * (a - b))) / (a + b);
        }
```

### Ellipse Perimeter Length 35

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterTakakazuSeki(double a, double b)
        {
            return 2d * Sqrt((PI * PI * a * b) + (4d * (a - b) * (a - b)));
        }
```

### Ellipse Perimeter Length 44

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterThomasBlankenhorn1(double a, double b)
        {
            var X1 = a;
            var X2 = b;
            var HMX = Max(X1, X2);
            var HMN = Min(X1, X2);
            var H1 = HMN / HMX;
            return 2d * PI * HMX * ((2d / PI) + (0.0000122d * Pow(H1, 0.6125d)) - (0.0021973d * Pow(H1, 1.225d)) + (0.919315d * Pow(H1, 1.8375d)) - (1.0359227d * Pow(H1, 2.45d)) + (0.861913d * Pow(H1, 3.0625d)) - (0.7274398d * Pow(H1, 3.675d)) + (0.6352295d * Pow(H1, 4.2875d)) - (0.436051d * Pow(H1, 4.9d)) + (0.1818904d * Pow(H1, 5.5125d)) - (0.0333691d * Pow(H1, 6.125d)));
        }
```

### Ellipse Perimeter Length 45

Find the length of the Perimeter of an ellipse.  
- [http://www.mathsisfun.com/geometry/ellipse-perimeter.html](http://www.mathsisfun.com/geometry/ellipse-perimeter.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterThomasBlankenhorn8(double a, double b)
        {
            var X1 = a;
            var X2 = b;
            var HMX = Max(X1, X2);
            var HMN = Min(X1, X2);
            var H1 = HMN / HMX;
            return HMX * (4d + (((3929d * Pow(H1, 1.5d)) + (1639157d * Pow(H1, 2d)) + (19407215d * Pow(H1, 2.5d)) + (24302653d * Pow(H1, 3d)) + (12892432d * Pow(H1, 3.5d))) / (86251d + (1924742d * Pow(H1, 0.5d)) + (6612384 * Pow(H1, 1d)) + (7291509d * Pow(H1, 1.5d)) + (6436977 * Pow(H1, 2d)) + (3158719d * Pow(H1, 2.5d)))));
        }
```

### Ellipse Perimeter Length 13

Find the length of the Perimeter of an ellipse.  
- [http://www.ebyte.it/library/docs/math07/EllipsePerimeterApprox07add.html](http://www.ebyte.it/library/docs/math07/EllipsePerimeterApprox07add.html)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double EllipsePerimeterYNOT(double a, double b)
        {
            var s = Log(2d, E) / Log(PI / 2d, E);
            return 4d * Pow(Pow(a, s) + Pow(b, s), 1d / s);
        }
```

