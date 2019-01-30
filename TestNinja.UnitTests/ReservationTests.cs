using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
        {
            var reservation = new Reservation();
            var result = reservation.CanBeCancelledBy(new User {IsAdmin = true});
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_SameUserCancelling_ReturnTrue()
        {
            var user = new User();
            var reservation = new Reservation {MadeBy = user};

            var result = reservation.CanBeCancelledBy(user);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnFalse()
        {
            var reservation = new Reservation {MadeBy = new User()};

            var result = reservation.CanBeCancelledBy(new User());

            Assert.IsFalse(result);
        }
    }
}
