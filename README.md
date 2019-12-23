# FractionOps
---

This a .Net Core 3.1 Console App for performing the basic Arithmatic operations on Fractions.
All the different mathematical operations and string conversions are thoroughly **Unit Tested** using **XUnit.Net**.

This Application takes operations on fractions as an input and produce a fractional result.

- Legal operators shall be *, /, +, - (multiply, divide, add, subtract)
- Operands and operators shall be separated by one or more spaces
- Mixed numbers will be represented by whole_numerator/denominator. e.g. "3_1/4"
- Improper fractions and whole numbers are also allowed as operands 
- The result can be a whole number, fraction or mixed fraction

### Example run:

? 1/2 / 3/4
= 2/3


? 2_3/8 + 9/8
= 3_1/2

### What's supported:

- Single operation on 2 operands
- 4 operations (add, subtract, multiply, divide)
- Negative numbers
- Basic Exception Handling (Eg: DivideByZero Error, Aruthmatic Overflow Exception etc)
- Global Exception Handling for unhandled exceptions if thrown.

### What's not supported:

- Multi operand operations
- Decimals



