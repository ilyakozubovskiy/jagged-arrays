using System;
using System.Collections.Generic;
using NUnit.Framework;

#pragma warning disable CA1707

namespace JaggedArrays.Tests
{
    [TestFixture]
    public class ArrayExtensionTests
    {
        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(
                    new[] { new[] { 2, -40, 55 }, new[] { 1 }, new[] { 1, 1 }, null, null },
                    new[] { null, null, new[] { 1 }, new[] { 1, 1 }, new[] { 2, -40, 55 } });
                yield return new TestCaseData(
                    new[] { new[] { 1, 2, 3 }, null, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 1, 3 }, new[] { 1 } },
                    new[] { null, new[] { 1 }, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 3 }, new[] { 1, 2, 1, 3 } });
                yield return new TestCaseData(
                    new[] { new[] { 1, 2, 3 }, null, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 1, 3 }, new[] { 1 }, new[] { 10, 10, 1, 90, 1 } },
                    new[] { null, new[] { 1 }, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 3 }, new[] { 1, 2, 1, 3 }, new[] { 10, 10, 1, 90, 1 } });
                yield return new TestCaseData(
                    new[] { new[] { 1, 2, 3 }, new[] { 10987, 2, 3 }, null, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 1, 3 }, new[] { 1 }, new[] { 10, 10, 1, 90, 1 }, null },
                    new[] { null, null, new[] { 1 }, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 3 }, new[] { 1, 2, 1, 3 }, new[] { 10, 10, 1, 90, 1 }, new[] { 10987, 2, 3 } });
                yield return new TestCaseData(
                    new[] { new[] { 2, -40, 55 }, new[] { 1 }, new[] { 1, 1 }, null, null },
                    new[] { new[] { 2, -40, 55 }, new[] { 1, 1 }, new[] { 1 }, null, null });
                yield return new TestCaseData(
                    new[] { new[] { 1, 2, 3 }, null, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 1, 3 }, new[] { 1 } },
                    new[] { new[] { 1, 2, 1, 3 }, new[] { 1, 2, 3 }, new[] { 1, 1, 1, 1, 1 }, new[] { 1 }, null });
                yield return new TestCaseData(
                    new[] { new[] { 1, 2, 3 }, null, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 1, 3 }, new[] { 1 }, new[] { 10, 10, 1, 90, 1 } },
                    new[] { new[] { 10, 10, 1, 90, 1 }, new[] { 1, 2, 1, 3 }, new[] { 1, 2, 3 }, new[] { 1, 1, 1, 1, 1 }, new[] { 1 }, null });
                yield return new TestCaseData(
                    new[] { new[] { 1, 2, 3 }, new[] { 10987, 2, 3 }, null, new[] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 1, 3 }, new[] { 1 }, new[] { 10, 10, 1, 90, 1 }, null },
                    new[] { new[] { 10987, 2, 3 }, new[] { 10, 10, 1, 90, 1 }, new[] { 1, 2, 1, 3 }, new[] { 1, 2, 3 }, new[] { 1, 1, 1, 1, 1 }, new[] { 1 }, null, null });
            }
        }

        [TestCaseSource(nameof(TestCases))]
        public void OrderByAscendingBySum_Tests(int[][] source, int[][] expected)
        {
            source.OrderByAscendingBySum();
            Assert.AreEqual(expected, source);
        }

        [Test]
        public void OrderByAscendingBySum_SourceIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.OrderByAscendingBySum(null));
        
        [TestCaseSource(nameof(TestCases))]
        public void OrderByDescendingBySum_Tests(int[][] source, int[][] expected)
        {
            source.OrderByDescendingBySum();
            Assert.AreEqual(expected, source);
        }

        [Test]
        public void OrderByDescendingBySum_SourceIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.OrderByDescendingBySum(null));
    }
}
