# Point In Elliptical Arc Sector Tests

Determines whether a point is in an Elliptical Arc Sector.

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

../../InstrumentedLibrary/Geometry/Contains/EllipticalArcSectorContainsPointTests.cs

The required method signature for this API is as follows:

```CSharp
public static Inclusion EllipticalArcSectorContainsPoint(double cX, double cY, double r1, double r2, double angle, double startAngle, double sweepAngle, double pX, double pY, double epsilon = Epsilon)
```

## Test Case Index

- [Test Case: (0, 0, 2, 2, 0, 0, 0.785398163397448, 0.5, 0.5, 5.6843418860808E-12)](#0,-0,-2,-2,-0,-0,-0.785398163397448,-0.5,-0.5,-5.6843418860808E-12)

### (0, 0, 2, 2, 0, 0, 0.785398163397448, 0.5, 0.5, 5.6843418860808E-12)

| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |
|---|---|---|---|
| [EllipticalArcContainsPoint1(0, 0, 2, 2, 0, 0, 0.785398163397448, 0.5, 0.5, 5.6843418860808E-12)](#Point-In-Ellipse-Tests) | Inside != True | 10000 in 32 ms. 0.0032 ms. average |  |
| [EllipticalArcContainsPoint2(0, 0, 2, 2, 0, 0, 0.785398163397448, 0.5, 0.5, 5.6843418860808E-12)](#Point-In-Ellipse-Tests) | Inside != True | 10000 in 59 ms. 0.0059 ms. average |  |
| [EllipticalArcSectorContainsPoint0(0, 0, 2, 2, 0, 0, 0.785398163397448, 0.5, 0.5, 5.6843418860808E-12)](#Point-In-Ellipse-Tests) | Outside != True | 10000 in 37 ms. 0.0037 ms. average |  |
| [EllipticalArcSectorContainsPointSC(0, 0, 2, 2, 0, 0, 0.785398163397448, 0.5, 0.5, 5.6843418860808E-12)](#Point-In-Ellipse-Tests) | Inside != True | 10000 in 31 ms. 0.0031 ms. average |  |

## The Code

The code for the methods tested follows below.

### Point In Ellipse Tests

Determines whether a point is in an Ellipse.  
- [http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm](http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion EllipticalArcContainsPoint1(
            double cX, double cY,
            double r1, double r2,
            double angle,
            double startAngle,
            double sweepAngle,
            double pX, double pY,
            double epsilon = Epsilon)
        {
            return EllipticalArcContainsPoint1(cX, cY, r1, r2, Cos(angle), Sin(angle), Cos(startAngle), Sin(startAngle), Cos(sweepAngle), Sin(sweepAngle), pX, pY, epsilon);
        }
```

### Point In Ellipse Tests

Determines whether a point is in an Ellipse.  
- [http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm](http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion EllipticalArcContainsPoint2(
            double cX, double cY,
            double r1, double r2,
            double angle,
            double startAngle,
            double sweepAngle,
            double pX, double pY,
            double epsilon = Epsilon)
        {
            return EllipticalArcContainsPoint2(cX, cY, r1, r2, Cos(angle), Sin(angle), Cos(startAngle), Sin(startAngle), Cos(sweepAngle), Sin(sweepAngle), pX, pY, epsilon);
        }
```

### Point In Ellipse Tests

Determines whether a point is in an Ellipse.  
- [http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm](http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion EllipticalArcSectorContainsPoint0(
            double cX, double cY,
            double r1, double r2,
            double angle,
            double startAngle,
            double sweepAngle,
            double pX, double pY,
            double epsilon = Epsilon)
        {
            return EllipticalArcSectorContainsPoint0(cX, cY, r1, r2, Cos(angle), Sin(angle), startAngle, sweepAngle, pX, pY, epsilon);
        }
```

### Point In Ellipse Tests

Determines whether a point is in an Ellipse.  
- [http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm](http://stackoverflow.com/questions/7946187/point-and-ellipse-rotated-position-test-algorithm)

```CSharp
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Inclusion EllipticalArcSectorContainsPointSC(
            double cX, double cY,
            double r1, double r2,
            double angle,
            double startAngle,
            double sweepAngle,
            double pX, double pY,
            double epsilon = Epsilon)
        {
            return EllipticalArcSectorContainsPointSC(cX, cY, r1, r2, Cos(angle), Sin(angle), Cos(startAngle), Sin(startAngle), Cos(sweepAngle), Sin(sweepAngle), pX, pY, epsilon);
        }
```

