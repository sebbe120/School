using System;
using System.Diagnostics;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using static FluentAssertions.FluentActions;

namespace Exercises
{
    public class Ex08_ExceptionTests
    {
        [Fact]
        public void DoesThrow_WrappedInAction_ThrowInvalidOperationException()
        {
            // Arrange
            var subject = new Thrower();

            // Act
            Action act = () => subject.DoesThrow();

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void DoesThrow_ThrowInvalidOperationAdvanced()
        {
            // * Throw InvalidOperationException,
            //   * which exception message contains "foobar"
            //   * and an InnerException of exactly DivideByZeroException,
            //     * which exception message contains "Dark Side"

            // Arrange
            var subject = new Thrower();

            // Act
            Action act = () => subject.DoesThrow();

            // Assert
            using (new AssertionScope())
            {
                act.Should().Throw<InvalidOperationException>().Which.Message.Contains("foobar");
                act.Should().Throw<InvalidOperationException>().WithInnerException<DivideByZeroException>().Which.Message.Contains("Dark Side");
            }
        }

        #region Helpers
        private class Thrower
        {
            [DebuggerNonUserCode]
            public void DoesThrow() =>
                throw new InvalidOperationException("Yada Yada foobar Yada Yada",
                    new DivideByZeroException("Something, Something, Something, Dark Side"));

            public int DoesNotThrow() => 42;

            public Task DoesThrowAsync()
            {
                DoesThrow();
                return Task.CompletedTask;
            }

            public Task<int> DoesNotThrowAsync() => Task.FromResult(DoesNotThrow());
        }
        #endregion
    }
}
