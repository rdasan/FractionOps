using System;
using System.Collections.Generic;
using System.Text;

namespace fractionops.Models
{
    public class Fraction
    {
        public long Numerator { get; set; }
        public long Denominator { get; set; }

        public Fraction(string fractionText)
        {
            var parts = fractionText.Split('/');
            if (long.TryParse(parts[0], out long numerator))
                Numerator = numerator;
            if (long.TryParse(parts[1], out long denominator))
                Denominator = denominator;
            ReduceFraction();
        }

        private void ReduceFraction()
        {
            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }


        }
    }
}
