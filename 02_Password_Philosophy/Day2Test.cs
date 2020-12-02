using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;
using Xunit.Abstractions;

namespace _02_Password_Philosophy
{
    public class Day2Test
    {
        private Day2 subject;

        public Day2Test(ITestOutputHelper output)
        {
            var services = Setup.SetupDependencyInjection<Day2>(output);
            subject = services.GetRequiredService<Day2>();
        }

        [Fact]
        public void Part1_Example()
        {
            subject.Input = @"1-3 a: abcde
1-3 b: cdefg
2-9 c: ccccccccc";

            subject.Run1();

            subject.ValidPasswords.Should().Be(2);
        }


        [Fact]
        public void Part1_Custom1()
        {
            subject.Input = "1-3 a: aaaa";

            subject.Run1();

            subject.ValidPasswords.Should().Be(0);
        }


        [Fact]
        public void Part2_Example_abcde()
        {
            subject.Input = "1-3 a: abcde";

            subject.Run2();

            subject.ValidPasswords.Should().Be(1);
        }

        [Fact]
        public void Part2_Example_cdefg()
        {
            subject.Input = "1-3 b: cdefg";

            subject.Run2();

            subject.ValidPasswords.Should().Be(0);
        }

        [Fact]
        public void Part2_Example_ccccccccc()
        {
            subject.Input = "2-9 c: ccccccccc";

            subject.Run2();

            subject.ValidPasswords.Should().Be(0);
        }
    }
}
