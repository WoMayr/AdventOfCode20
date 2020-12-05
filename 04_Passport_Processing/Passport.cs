using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04_Passport_Processing
{
    public class Passport
    {
        public static ILogger<Passport> Logger { private get; set; }

        /*
            byr (Birth Year)
            iyr (Issue Year)
            eyr (Expiration Year)
            hgt (Height)
            hcl (Hair Color)
            ecl (Eye Color)
            pid (Passport ID)
            cid (Country ID)
         */
        public int? BirthYear { get; set; }
        public int? IssueYear { get; set; }
        public int? ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportId { get; set; }
        public int? CountryId { get; set; }

        public bool HasRequiredFields =>
            BirthYear != null &&
            IssueYear != null &&
            ExpirationYear != null &&
            Height != null &&
            HairColor != null &&
            EyeColor != null &&
            PassportId != null;
        public bool IsValid
        {
            get
            {
                if (!HasRequiredFields)
                {
                    return false;
                }

                return
                    BirthYearValid(BirthYear.Value) &&
                    IssueYearValid(IssueYear.Value) &&
                    ExpirationYearValid(ExpirationYear.Value) &&
                    HeightValid(Height) &&
                    HairColorValid(HairColor) &&
                    EyeColorValid(EyeColor) &&
                    PassportIdValid(PassportId);
            }
        }

        public static Passport FromInput(string input)
        {
            var passport = new Passport();
            var parts = input
                .Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s =>
                {
                    var keyValueParts = s.Split(':');
                    return (keyValueParts[0], keyValueParts[1]);
                });

            //byr(Birth Year)
            //iyr(Issue Year)
            //eyr(Expiration Year)
            //hgt(Height)
            //hcl(Hair Color)
            //ecl(Eye Color)
            //pid(Passport ID)
            //cid(Country ID)

            foreach (var (key, value) in parts)
            {
                switch (key)
                {
                    case "byr":
                        passport.BirthYear = int.Parse(value);
                        break;
                    case "iyr":
                        passport.IssueYear = int.Parse(value);
                        break;
                    case "eyr":
                        passport.ExpirationYear = int.Parse(value);
                        break;
                    case "hgt":
                        passport.Height = value;
                        break;
                    case "hcl":
                        passport.HairColor = value;
                        break;
                    case "ecl":
                        passport.EyeColor = value;
                        break;
                    case "pid":
                        passport.PassportId = value;
                        break;
                    case "cid":
                        passport.CountryId = int.Parse(value);
                        break;
                    default:
                        throw new Exception($"Unknown passport key: {key} (Value = {value})");
                }
            }

            return passport;
        }

        public static bool BirthYearValid(int v)
        {
            return v is >= 1920 and <= 2002;
        }

        public static bool IssueYearValid(int v)
        {
            return v is >= 2010 and <= 2020;
        }
        public static bool ExpirationYearValid(int v)
        {
            return v is >= 2020 and <= 2030;
        }

        private static readonly Regex heightCheckRegex = new Regex(@"^(\d+)(in|cm)$");
        public static bool HeightValid(string v)
        {
            var match = heightCheckRegex.Match(v);
            if (!match.Success)
            {
                return false;
            }

            var value = int.Parse(match.Groups[1].Value);
            var unit = match.Groups[2].Value;

            switch (unit)
            {
                case "cm": return value is >= 150 and <= 193;
                case "in": return value is >= 59 and <= 76;
                default:
                    Logger.LogWarning("Unknown height unit \"{unit}\"", unit);
                    return false;
            }
        }

        private static readonly Regex colorCheckRegex = new Regex(@"^#[0-9a-f]{6}$");
        public static bool HairColorValid(string v)
        {
            return colorCheckRegex.IsMatch(v);
        }

        private static readonly HashSet<string> validEyeColors = new HashSet<string>
        {
            "amb", 
            "blu", 
            "brn", 
            "gry", 
            "grn", 
            "hzl", 
            "oth",
        };
        public static bool EyeColorValid(string v)
        {
            return validEyeColors.Contains(v.ToLower());
        }

        private static readonly Regex passportCheckRegex = new Regex(@"^\d{9}$");
        public static bool PassportIdValid(string v)
        {
            return passportCheckRegex.IsMatch(v);
        }
    }
}
