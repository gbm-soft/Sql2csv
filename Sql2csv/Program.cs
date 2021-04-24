using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sql2csv
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader fs1 = new StreamReader(args[0]);

            string s = "";
            var list = new List<string> { };
            while (s != null)
            {
                s = fs1.ReadLine();
                if (s != null)
                {
                    if (s.Length < 20) continue;
                    if(s.Substring(0,11)== "INSERT INTO")
                    {
                        var idx = s.Substring(13, 100).IndexOf('`'); ;
                        StreamWriter result = new StreamWriter(args[0] +"."+ s.Substring(13,idx) ,true);

                        string pattern = @"\([^\)]+\)";
                        Regex rgx = new Regex(pattern);
                        var m = rgx.Matches(s);

                        foreach (Match match in m)
                        {
                            result.WriteLine(match.Value.Substring(1,match.Value.Length-2));
                        };

                        result.Close();

                    }

                }
            }

        }
    }
}
