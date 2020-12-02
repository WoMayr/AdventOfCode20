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
        public void Example()
        {
            subject.Input = @"1-3 a: abcde
1-3 b: cdefg
2-9 c: ccccccccc";

            subject.Run();

            subject.ValidPasswords.Should().Be(2);
        }


        [Fact]
        public void Custom1()
        {
            subject.Input = "1-3 a: aaaa";

            subject.Run();

            subject.ValidPasswords.Should().Be(0);
        }
    }
}
