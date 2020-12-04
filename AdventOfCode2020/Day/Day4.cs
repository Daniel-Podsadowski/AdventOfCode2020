using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day4
    {
        public static void Main()
        {
            var lines = File.ReadAllLines(@"..\..\..\Data\day4.txt"); //make sure 2 new lines at end of file

            var numValid = 0;
            var numPresentandValid = 0;
            var passport = "";
            foreach (var line in lines)
            {
                line.Trim();
                if (line == "")
                {
                    var hasbyr = passport.Contains("byr:");
                    var hasiyr = passport.Contains("iyr:");
                    var haseyr = passport.Contains("eyr:");
                    var hashgt = passport.Contains("hgt:");
                    var hashcl = passport.Contains("hcl:");
                    var hasecl = passport.Contains("ecl:");
                    var haspid = passport.Contains("pid:");
                    if (hasbyr && hasiyr && haseyr && hashgt && hashcl && hasecl && haspid)
                    {
                        numValid++;
                        var passportArray = passport.Split(" ");
                        int byr = 0, iyr = 0, eyr = 0;
                        bool isCm = false;
                        string hgt = "", hcl = "", ecl = "", pid = "";
                        foreach (var constraint in passportArray)
                        {
                            if (constraint.Contains("byr:"))       { byr = int.Parse(constraint.Split(":")[1]); }
                            else if (constraint.Contains("iyr:"))  { iyr = int.Parse(constraint.Split(":")[1]); }
                            else if (constraint.Contains("eyr:"))  { eyr = int.Parse(constraint.Split(":")[1]); }
                            else if (constraint.Contains("hgt:"))  { hgt = constraint.Split(":")[1]; }
                            else if (constraint.Contains("hcl:"))  { hcl = constraint.Split(":")[1]; }
                            else if (constraint.Contains("ecl:"))  { ecl = constraint.Split(":")[1]; }
                            else if (constraint.Contains("pid:"))  { pid = constraint.Split(":")[1]; }
                        }

                        if (byr >= 1920 && byr <= 2002 && iyr >= 2010 && iyr <= 2020 && eyr >= 2020 && eyr <= 2030 && (hgt.Contains("cm") || hgt.Contains("in")))
                        {
                            if (hgt.Contains("cm")) { isCm = true; }
                            hgt = hgt.Substring(0, hgt.Length - 2);
                            int hgtInt = int.Parse(hgt);
                            if ((isCm && hgtInt >= 150 && hgtInt <= 193) || (!isCm && hgtInt >= 59 && hgtInt <= 76))
                            {
                                var isValidHcl = true;
                                char[] validChar = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
                                if (hcl[0] == '#')
                                {
                                    hcl = hcl.Substring(1, hcl.Length - 1);
                                    foreach (var ch in hcl) { if (!validChar.Contains(ch)) { isValidHcl = false; } }
                                    if (isValidHcl && hcl.Length == 6)
                                    {
                                        string[] validEcl = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                                        if (validEcl.Contains(ecl))
                                        {
                                            if (pid.All(char.IsDigit) && pid.Length == 9) { numPresentandValid++; }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    passport = "";
                }
                else
                {
                    if (passport == "") { passport = line; }
                    else { passport = passport + " " + line; }
                }
            }
            Console.WriteLine("Number of Valid Passports: " + numValid);
            Console.WriteLine("Number of Valid and Present Passports: " + numPresentandValid);
        }
    }
}
