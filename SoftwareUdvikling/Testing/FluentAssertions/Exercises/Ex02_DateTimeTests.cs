using FluentAssertions;
using FluentAssertions.Common;
using FluentAssertions.Extensions;
using System;
using Xunit;

namespace Exercises
{
    public class Ex02_DateTimeTests
    {
        [Fact]
        public void In_2023_Easter_Sunday_Falls_On_April_9th()
        {
            // Arrange
            var expected = 9.April(2023);

            // Act
            DateTime date = EasterSunday();

            // Assert
            date.Should().Be(expected);
        }

        [Fact]
        public void The_start_of_this_presentation_is_within_5_minutes_of_the_scheduled_time()
        {
            // Arrange
            var expectedStartOfLecture = 13.March(2023).At(08.Hours(30.Minutes()));

            // Act
            DateTime date = StartOfThisPresentation();

            // Assert
            date.Should().BeCloseTo(expectedStartOfLecture, 5.Minutes());
        }

        [Fact]
        public void In_2023_Danish_daylight_saving_time_ends_29th_of_October_at_0300_GMT_Plus2()
        {
            // Express expectedEndOfDst using the Fluent API from FluentAssertions.Extensions
            // See https://fluentassertions.com/datetimespans/ for examples

            // Arrange
            DateTimeOffset expectedEndOfDst = 29.October(2023).At(3, 0).WithOffset(2.Hours());

            // Act
            DateTimeOffset date = DaylightSavingTimeEnd();

            // Assert
            date.Should().Be(expectedEndOfDst);
        }

        #region Helpers
        private static DateTime EasterSunday() => new(2023, 04, 09);

        private static DateTime StartOfThisPresentation() => new DateTime(2023, 03, 13, 08, 30, 00).AddMinutes(new Random().Next(-5, 5));

        private static DateTimeOffset DaylightSavingTimeEnd() => new(2023, 10, 29, 03, 00, 00, TimeSpan.FromHours(2));
        #endregion
    }
}
