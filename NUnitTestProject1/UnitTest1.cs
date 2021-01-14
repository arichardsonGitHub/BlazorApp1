using EmployeeManagement.Web.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace NUnitTestProject1.Tests
{
    [SetUpFixture]
    public class Config
    {
        public static DbContextOptions<AndrewSandboxContext> DBContextOptions { get; set; }

        public static int NumberOfUsersToCreateInContext { get; set; } = 2;

        [OneTimeSetUp]  // [OneTimeSetUp] for NUnit 3.0 and up; see http://bartwullems.blogspot.com/2015/12/upgrading-to-nunit-30-onetimesetup.html
        public void SetUp()
        {
            SetupContext();
        }

        [OneTimeTearDown]  // [OneTimeTearDown] for NUnit 3.0 and up
        public void TearDown()
        {
        }

        private void SetupContext()
        {
            DBContextOptions = new DbContextOptionsBuilder<AndrewSandboxContext>()
            .UseInMemoryDatabase(databaseName: "database")
            .Options;

            using (var context = new AndrewSandboxContext(DBContextOptions))
            {
                for (int x = 0; x < NumberOfUsersToCreateInContext; x++)
                {
                    context.Users.Add(new EmployeeManagement.Web.Models.User { Id = x, GenderId = 1, FirstName = $"User{x}", AddressId = 1 });
                }

                context.Addresses.Add(new EmployeeManagement.Web.Models.Address { Id = 1, City = "City1" });

                context.Genders.Add(new Gender { Id = 1, Name = "Female" });
                context.Genders.Add(new Gender { Id = 2, Name = "Male" });

                context.SaveChanges();
            }
        }
    }

    [TestFixture]
    public class UserRepositoryTests
    {
        [Test]
        public void KnownNumberOfUsersAreReturned()
        {
            using (var context = new AndrewSandboxContext(Config.DBContextOptions))
            {
                var mockUserRepository = new UserRepository(context);

                var returnedUsers = mockUserRepository.GetAllAsync().Result;

                Assert.AreEqual(Config.NumberOfUsersToCreateInContext, returnedUsers.Count);
            }
        }

        [Test]
        public void KnownUserIsReturned()
        {
            using (var context = new AndrewSandboxContext(Config.DBContextOptions))
            {
                var mockUserRepository = new UserRepository(context);

                var returnedUser0 = mockUserRepository.GetByIDAsync(0).Result;
                var returnedUser1 = mockUserRepository.GetByIDAsync(1).Result;

                Assert.NotNull(returnedUser0);
                Assert.NotNull(returnedUser1);

                Assert.AreEqual(0, returnedUser0.Id);
                Assert.AreEqual(1, returnedUser1.Id);
            }
        }

        [Test]
        public void UknownUserReturnsNull()
        {
            using (var context = new AndrewSandboxContext(Config.DBContextOptions))
            {
                var mockUserRepository = new UserRepository(context);

                var returnedUserShouldBeNull = mockUserRepository.GetByIDAsync(5150).Result;

                Assert.IsNull(returnedUserShouldBeNull);
            }
        }
    }
}
