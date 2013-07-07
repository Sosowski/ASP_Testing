namespace MvcFriendcode.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MvcFriendcode.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcFriendcode.Models.FriendCodeDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcFriendcode.Models.FriendCodeDBContext context)
        {
            context.FriendCodes.AddOrUpdate(i => i.User,
                new FriendCode
            {
                User = "Montblanc",
                Code = "4968-7974-8979",
                DateAdded = DateTime.Parse("2013-7-2"),
                Rating = 10
            },
                new FriendCode
            {
                User = "BobFrank",
                Code = "7978-7948-6589",
                DateAdded = DateTime.Parse("2013-7-4"),
                Rating = 5
            }

            );
        }
    }
}
