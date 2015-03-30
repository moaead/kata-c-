using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestProject1
{
    class Calculator
    {
        public int Add(string input)
        {
            var negatives = new List<int>();
            if (input.StartsWith("//"))
            {
                if (input.StartsWith("//["))
                {
                    List<String> delems = new List<String>();
                    int pos1 = input.IndexOf("[");
                    while (pos1 >= 2)
                    {

                        int pos2 = input.IndexOf("]", pos1);
                        String delem = input.Substring(pos1 + 1, pos2 - pos1);
                        delems.Add(delem);
                        pos1 = input.IndexOf("[", pos1 + 1);
                    }

                    input = input.Substring(input.IndexOf("\n") + 1);
                    foreach (String delem in delems)
                    {

                        input = input.Replace(delem.Replace("]", ""), ",");
                    }
                }
                else
                {
                    int pos1 = 2;
                    int newLinePos = input.IndexOf("\n");
                    String delim = input.Substring(pos1, newLinePos - pos1);
                    input = input.Substring(newLinePos + 1).Replace(delim, ",");
                }

            }



            input = input.Replace("\n", ",");

            var split = input.Split(',');
            int result = 0;
            if (input.Contains(','))
                foreach (var a in split)
                {
                    int num = int.Parse(a);
                    if (num >= 1000)
                        num %= 1000;
                    result += num;
                    if (num < 0)
                        negatives.Add(num);

                }
            else
            {
                int.TryParse(input, out result);
                if (result < 0)
                {
                    throw new Exception("negatives not allowed - " + result);
                }
                else if (result >= 1000)
                    result %= 1000;



            }
            if (negatives.Count() > 0)
            {

                throw new Exception("negatives not allowed - " + String.Join(",", negatives.ToArray()));
            }


            return result;
        }
    }
}
