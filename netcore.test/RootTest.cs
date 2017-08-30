using System;
using Xunit;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Skeleton.Controllers;
using Skeleton.Data;

namespace Skeleton.test
{
    public class RootTest
    {
        [Fact]
        public void Test1()
        {
            var builder = new DbContextOptionsBuilder<SkeletonContext>();
            var cache = Moq.Mock.Of<IMemoryCache>();
            builder.UseMemoryCache(cache);

            var context = new Moq.Mock<SkeletonContext>(builder.Options);
            var logger = new Moq.Mock<ILogger<Root>>();
            var root = new Root(context.Object, logger.Object);
            var ret = root.Index() as ViewResult;
            Assert.NotNull(ret);
        }
    }
}
