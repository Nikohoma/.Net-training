using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.WebRequestMethods;


//| Field                 | Rule                                                               | Regex / Logic       | Example Input              | Output                    |           |         |
//| --------------------- | ------------------------------------------------------------------ | ------------------- | -------------------------- | ------------------------- | --------- | ------- |
//| **Transaction ID**    | Must start with `TXN-` followed by **6 digits**, first digit not 0 | `TXN-[1-9][0-9]{5}` | `TXN-123456`               | ✅ Valid                   |           |         |
//|                       |                                                                    |                     | `TXN-023456`               | ❌ Invalid (starts with 0) |           |         |
//| **Date (YYYY-MM-DD)** | Year: 2000–2999                                                    | `2[0-9]{3}`         | `2024`                     | ✅ Valid                   |           |         |
//|                       | Month: 01–12                                                       | `(0[1-9]            | 1[0-2])`                   | `02`                      | ✅ Valid   |         |
//|                       | Day: 01–31                                                         | `(0[1-9]            | [12][0-9]                  | 3[01])`                   | `09`      | ✅ Valid |
//|                       |                                                                    |                     | `32`                       | ❌ Invalid (day > 31)      |           |         |
//| **Currency**          | Must be one of `USD`, `INR`, `GBP`                                 | `(USD               | INR                        | GBP)`                     | `USD`     | ✅ Valid |
//|                       |                                                                    |                     | `EUR`                      | ❌ Invalid                 |           |         |
//| **Amount**            | Numeric with exactly 2 decimals, max `999999.99`                   | `(0                 | [1-9][0-9]{0,5}).[0-9]{2}` | `5000.50`                 | ✅ Valid   |         |
//|                       | Leading zeros not allowed except 0                                 |                     | `0123.45`                  | ❌ Invalid                 |           |         |
//|                       |                                                                    |                     | `1000000.00`               | ❌ Invalid (too large)     |           |         |
//| **Status**            | Must be one of `SUCCESS`, `FAILED`, `PENDING`                      | `(SUCCESS           | FAILED                     | PENDING)`                 | `SUCCESS` | ✅ Valid |
//|                       |                                                                    |                     | `DONE`                     | ❌ Invalid                 |           |         |
//| Field                 | Rule                                                               | Regex / Logic       | Example Input              | Output                    |           |         |
//| --------------------- | ------------------------------------------------------------------ | ------------------- | -------------------------- | ------------------------- | --------- | ------- |
//| **Transaction ID**    | Must start with `TXN-` followed by **6 digits**, first digit not 0 | `TXN-[1-9][0-9]{5}` | `TXN-123456`               | ✅ Valid                   |           |         |
//|                       |                                                                    |                     | `TXN-023456`               | ❌ Invalid (starts with 0) |           |         |
//| **Date (YYYY-MM-DD)** | Year: 2000–2999                                                    | `2[0-9]{3}`         | `2024`                     | ✅ Valid                   |           |         |
//|                       | Month: 01–12                                                       | `(0[1-9]            | 1[0-2])`                   | `02`                      | ✅ Valid   |         |
//|                       | Day: 01–31                                                         | `(0[1-9]            | [12][0-9]                  | 3[01])`                   | `09`      | ✅ Valid |
//|                       |                                                                    |                     | `32`                       | ❌ Invalid (day > 31)      |           |         |
//| **Currency**          | Must be one of `USD`, `INR`, `GBP`                                 | `(USD               | INR                        | GBP)`                     | `USD`     | ✅ Valid |
//|                       |                                                                    |                     | `EUR`                      | ❌ Invalid                 |           |         |
//| **Amount**            | Numeric with exactly 2 decimals, max `999999.99`                   | `(0                 | [1-9][0-9]{0,5}).[0-9]{2}` | `5000.50`                 | ✅ Valid   |         |
//|                       | Leading zeros not allowed except 0                                 |                     | `0123.45`                  | ❌ Invalid                 |           |         |
//|                       |                                                                    |                     | `1000000.00`               | ❌ Invalid (too large)     |           |         |
//| **Status**            | Must be one of `SUCCESS`, `FAILED`, `PENDING`                      | `(SUCCESS           | FAILED                     | PENDING)`                 | `SUCCESS` | ✅ Valid |
//|                       |                                                                    |                     | `DONE`                     | ❌ Invalid                 |           |         |

// Test Cases: 
// Input
//3
//TXN - 123456 | 2024 - 02 - 09 | USD | 5000.50 | SUCCESS
//TXN - 654321 | 2025 - 12 - 31 | INR | 0.01 | PENDING
//TXN - 999999 | 2999 - 01 - 01 | GBP | 999999.99 | FAILED
// Output
//Valid
//Valid
//Valid

// Input: 
//2
//TXN - 023456 | 2024 - 02 - 09 | USD | 5000.50 | SUCCESS
//TXN - 12345 | 2024 - 02 - 09 | USD | 5000.50 | SUCCESS
// Output:
//Invalid
//Invalid


namespace RegexQuestion
{
    public static class ValidTransactionRegex
    {
        public static string Validater(string input)
        {
            string pattern = @"^TXN-[1-9][0-9]{5}\|2[0-9]{3}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])\|(USD|INR|GBP)\|[0-9]{0,6}\.[0-9]{2}\|(SUCCESS|FAILED|PENDING)$";
            if (Regex.IsMatch(input, pattern))
            {
                return "Valid";
            }
            else
            {
                return "Invalid";
            }
        }
    }

    public class MainClass
    {
        public static void Main()
        {
            Console.WriteLine("Enter n: ");
            int n = int.Parse(Console.ReadLine());
            List<string> inputs = new List<string>();
            for(int i =0; i<n; i++)
            {
                string s = Console.ReadLine();
                inputs.Add(s);
            }

            List<string> result = new List<string>();
            foreach(var i in inputs)
            {
                var output = ValidTransactionRegex.Validater(i);
                result.Add(output);
            }

            foreach(var r in result)
            {
                Console.WriteLine(r);
            }
        }
    }
}
