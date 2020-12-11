using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;
using Xunit.Abstractions;

namespace _10_Adapter_Array
{
    public class Day10Test : BaseTest<Day10>
    {
        public Day10Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Part1_Example1()
        {
            subject.Input = @"16
10
15
5
1
11
7
19
6
12
4";


            subject.Run1();

            subject.DeviceJoltage.Should().Be(22);
            subject.JoltDifferenceCount[1].Should().Be(7);
            subject.JoltDifferenceCount[3].Should().Be(5);
        }

        [Fact]
        public void Part1_Example2()
        {
            subject.Input = @"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";


            subject.Run1();

            subject.JoltDifferenceCount[1].Should().Be(22);
            subject.JoltDifferenceCount[3].Should().Be(10);
        }

        [Fact]
        public void Part2_Example1()
        {
            subject.Input = @"16
10
15
5
1
11
7
19
6
12
4";

            subject.TrackPossibilities = true;
            subject.Run2();

            subject.PossibilityCount.Should().Be(8);
            subject.PossibleAdapterConfigurations.Should().BeEquivalentTo(
                new[] {
                    new [] { 1, 4, 5, 6, 7, 10, 11, 12, 15, 16, 19 },
                    new [] { 1, 4, 5, 6, 7, 10, 12, 15, 16, 19 },
                    new [] { 1, 4, 5, 7, 10, 11, 12, 15, 16, 19 },
                    new [] { 1, 4, 5, 7, 10, 12, 15, 16, 19 },
                    new [] { 1, 4, 6, 7, 10, 11, 12, 15, 16, 19 },
                    new [] { 1, 4, 6, 7, 10, 12, 15, 16, 19 },
                    new [] { 1, 4, 7, 10, 11, 12, 15, 16, 19 },
                    new [] { 1, 4, 7, 10, 12, 15, 16, 19 },
                }
            );
        }

        [Fact]
        public void Part2_Example1_WithoutPossibilities()
        {
            subject.Input = @"16
10
15
5
1
11
7
19
6
12
4";

            subject.Run2();

            subject.PossibilityCount.Should().Be(8);
        }

        [Fact]
        public void Part2_Example2()
        {
            subject.Input = @"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";


            subject.TrackPossibilities = true;
            subject.Run2();

            subject.PossibilityCount.Should().Be(19208);
            subject.PossibleAdapterConfigurations.Should().HaveCount(19208);
            subject.PossibleAdapterConfigurations.Should().ContainEquivalentOf(new[] { 1, 2, 3, 4, 7, 8, 9, 10, 11, 14, 17, 18, 19, 20, 23, 24, 25, 28, 31, 32, 33, 34, 35, 38, 39, 42, 45, 46, 47, 48, 49 });
            subject.PossibleAdapterConfigurations.Should().ContainEquivalentOf(new[] { 1, 2, 3, 4, 7, 8, 9, 10, 11, 14, 17, 18, 19, 20, 23, 24, 25, 28, 31, 32, 33, 34, 35, 38, 39, 42, 45, 46, 47, 49 });
            subject.PossibleAdapterConfigurations.Should().ContainEquivalentOf(new[] { 1, 2, 3, 4, 7, 8, 9, 10, 11, 14, 17, 18, 19, 20, 23, 24, 25, 28, 31, 32, 33, 34, 35, 38, 39, 42, 45, 46, 48, 49 });
            subject.PossibleAdapterConfigurations.Should().ContainEquivalentOf(new[] { 1, 2, 3, 4, 7, 8, 9, 10, 11, 14, 17, 18, 19, 20, 23, 24, 25, 28, 31, 32, 33, 34, 35, 38, 39, 42, 45, 46, 49, });
            subject.PossibleAdapterConfigurations.Should().ContainEquivalentOf(new[] { 1, 2, 3, 4, 7, 8, 9, 10, 11, 14, 17, 18, 19, 20, 23, 24, 25, 28, 31, 32, 33, 34, 35, 38, 39, 42, 45, 47, 48, 49 });
            //subject.PossibleAdapterConfigurations.Should().ContainEquivalentOf(new[] { 3, 4, 7, 10, 11, 14, 17, 20, 23, 25, 28, 31, 34, 35, 38, 39, 42, 45, 46, 48, 49 });
            //subject.PossibleAdapterConfigurations.Should().ContainEquivalentOf(new[] { 3, 4, 7, 10, 11, 14, 17, 20, 23, 25, 28, 31, 34, 35, 38, 39, 42, 45, 46, 49 });
            //subject.PossibleAdapterConfigurations.Should().ContainEquivalentOf(new[] { 3, 4, 7, 10, 11, 14, 17, 20, 23, 25, 28, 31, 34, 35, 38, 39, 42, 45, 47, 48, 49 });
            //subject.PossibleAdapterConfigurations.Should().ContainEquivalentOf(new[] { 3, 4, 7, 10, 11, 14, 17, 20, 23, 25, 28, 31, 34, 35, 38, 39, 42, 45, 47, 49 });
            //subject.PossibleAdapterConfigurations.Should().ContainEquivalentOf(new[] { 3, 4, 7, 10, 11, 14, 17, 20, 23, 25, 28, 31, 34, 35, 38, 39, 42, 45, 48, 49 });
        }

        [Fact]
        public void Part2_Example2_WithoutPossibilities()
        {
            subject.Input = @"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";


            subject.Run2();

            subject.PossibilityCount.Should().Be(19208);
        }
    }
}
