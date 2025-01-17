// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using Axe.Windows.Core.Bases;
using Axe.Windows.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Axe.Windows.RulesTests.Conditions
{
    [TestClass]
    public class PatternConditionTests
    {
        [TestMethod]
        public void TestMatchingPatternIDs()
        {
            using (var e = new MockA11yElement())
            {
                e.Patterns.Add(new A11yPattern(e, PatternIDs.Invoke));
                var test = new PatternCondition(PatternIDs.Invoke);
                Assert.IsTrue(test.Matches(e));
            } // using
        }

        [TestMethod]
        public void TestNonMatchingPatternIDs()
        {
            using (var e = new MockA11yElement())
            {
                e.Patterns.Add(new A11yPattern(e, PatternIDs.Invoke));
                var test = new PatternCondition(PatternIDs.ExpandCollapse);
                Assert.IsFalse(test.Matches(e));
            } // using
        }

        [TestMethod]
        public void TestNoPatterns()
        {
            using (var e = new MockA11yElement())
            {
                var test = new PatternCondition(PatternIDs.Toggle);
                Assert.IsFalse(test.Matches(e));
            } // using
        }

        [TestMethod]
        public void TestNullElementArgumentException()
        {
            Action action = () => new PatternCondition(0).Matches(null);
            Assert.ThrowsException<ArgumentNullException>(action);
        }
    } // class
} // namespace
