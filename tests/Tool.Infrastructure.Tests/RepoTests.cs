using Tool.Core.Domain.Devices;
using Tool.Infrastructure.Persistence.Sqlite;
using Xunit;

namespace Tool.Infrastructure.Tests;

public class RepoTests
{
    [Fact]
    public async Task Repo_Add_And_GetAll_Works()
    {
        var repo = new SqliteDeviceRepository();
        await repo.AddAsync(new Device("1", "REG-D"));
        var all = await repo.GetAllAsync();
        Assert.Single(all);
    }
}
