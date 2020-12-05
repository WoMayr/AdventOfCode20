using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;
using Xunit.Abstractions;

namespace _04_Passport_Processing
{
    public class Day4Test : BaseTest<Day4>
    {
        public Day4Test(ITestOutputHelper output) : base(output)
        {
            Passport.Logger = services.GetRequiredService<ILogger<Passport>>();
        }

        [Fact]
        public void Part1_Example_Pass1()
        {
            var input = @"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm";
            var passport = Passport.FromInput(input);

            passport.HasRequiredFields.Should().BeTrue();
        }

        [Fact]
        public void Part1_Example_Pass2()
        {
            var input = @"iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929";
            var passport = Passport.FromInput(input);

            passport.HasRequiredFields.Should().BeFalse();
        }

        [Fact]
        public void Part1_Example_Pass3()
        {
            var input = @"hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm";
            var passport = Passport.FromInput(input);

            passport.HasRequiredFields.Should().BeTrue();
        }

        [Fact]
        public void Part1_Example_Pass4()
        {
            var input = @"hcl:#cfa07d eyr:2025 pid:166559648
iyr:2011 ecl:brn hgt:59in";
            var passport = Passport.FromInput(input);

            passport.HasRequiredFields.Should().BeFalse();
        }

        [Fact]
        public void Part1_Example_Run()
        {
            var input = @"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm

iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929

hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm

hcl:#cfa07d eyr:2025 pid:166559648
iyr:2011 ecl:brn hgt:59in";
            subject.Input = input;
            subject.Run1();

            subject.ValidPassports.Should().Be(2);
        }

        [Fact]
        public void Part2_Example_Passport_Byr()
        {
            Passport.BirthYearValid(2002).Should().BeTrue();
            Passport.BirthYearValid(2003).Should().BeFalse();
        }

        [Fact]
        public void Part2_Example_Passport_Hgt()
        {
            Passport.HeightValid("60in").Should().BeTrue();
            Passport.HeightValid("190cm").Should().BeTrue();
            Passport.HeightValid("190in").Should().BeFalse();
            Passport.HeightValid("190").Should().BeFalse();
        }

        [Fact]
        public void Part2_Example_Passport_Hcl()
        {
            Passport.HairColorValid("#123abc").Should().BeTrue();
            Passport.HairColorValid("#123abz").Should().BeFalse();
            Passport.HairColorValid("123abc").Should().BeFalse();
        }

        [Fact]
        public void Part2_Example_Passport_Ecl()
        {
            Passport.EyeColorValid("brn").Should().BeTrue();
            Passport.EyeColorValid("wat").Should().BeFalse();
        }

        [Fact]
        public void Part2_Example_Passport_Pid()
        {
            Passport.PassportIdValid("000000001").Should().BeTrue();
            Passport.PassportIdValid("0123456789").Should().BeFalse();
        }

        [Fact]
        public void Part2_Example_Invalid_Pass1()
        {
            var input = @"eyr:1972 cid:100
hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926";
            var passport = Passport.FromInput(input);

            passport.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Part2_Example_Invalid_Pass2()
        {
            var input = @"iyr:2019
hcl:#602927 eyr:1967 hgt:170cm
ecl:grn pid:012533040 byr:1946";
            var passport = Passport.FromInput(input);

            passport.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Part2_Example_Invalid_Pass3()
        {
            var input = @"hcl:dab227 iyr:2012
ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277";
            var passport = Passport.FromInput(input);

            passport.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Part2_Example_Invalid_Pass4()
        {
            var input = @"hgt:59cm ecl:zzz
eyr:2038 hcl:74454a iyr:2023
pid:3556412378 byr:2007";
            var passport = Passport.FromInput(input);

            passport.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Part2_Example_Valid_Pass1()
        {
            var input = @"pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980
hcl:#623a2f";
            var passport = Passport.FromInput(input);

            passport.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Part2_Example_Valid_Pass2()
        {
            var input = @"eyr:2029 ecl:blu cid:129 byr:1989
iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm";
            var passport = Passport.FromInput(input);

            passport.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Part2_Example_Valid_Pass3()
        {
            var input = @"hcl:#888785
hgt:164cm byr:2001 iyr:2015 cid:88
pid:545766238 ecl:hzl
eyr:2022";
            var passport = Passport.FromInput(input);

            passport.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Part2_Example_Valid_Pass4()
        {
            var input = @"iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719";
            var passport = Passport.FromInput(input);

            passport.IsValid.Should().BeTrue();
        }
    }
}
