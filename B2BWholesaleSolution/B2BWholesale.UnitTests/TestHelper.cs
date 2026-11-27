using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using AgentPortalWeb.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace B2BWholesale.UnitTests
{
    public static class TestHelper
    {
        // Tạo DbContext chạy độc lập trên RAM cho mỗi Test Case
        public static AppDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                // Bỏ qua cảnh báo Transaction vì InMemory DB không dùng transaction vật lý
                .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            return new AppDbContext(options);
        }

        // Gắn HttpContext, Session và TempData giả lập vào Controller
        public static void SetupControllerContext(Controller controller, int? userId = null, string? userName = null)
        {
            var httpContext = new DefaultHttpContext();
            var session = new MockHttpSession();

            if (userId.HasValue)
                session.SetInt32("UserID", userId.Value);
            if (!string.IsNullOrEmpty(userName))
                session.SetString("UserName", userName);

            httpContext.Session = session;

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };
            controller.TempData = new TempDataDictionary(httpContext, new MockTempDataProvider());
        }
    }

    public class MockHttpSession : ISession
    {
        private readonly Dictionary<string, byte[]> _sessionStorage = new();
        public string Id => Guid.NewGuid().ToString();
        public bool IsAvailable => true;
        public IEnumerable<string> Keys => _sessionStorage.Keys;
        public void Clear() => _sessionStorage.Clear();
        public Task CommitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
        public Task LoadAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
        public void Remove(string key) => _sessionStorage.Remove(key);
        public void Set(string key, byte[] value) => _sessionStorage[key] = value;
        public bool TryGetValue(string key, [NotNullWhen(true)] out byte[]? value) => _sessionStorage.TryGetValue(key, out value);
    }

    public class MockTempDataProvider : ITempDataProvider
    {
        public IDictionary<string, object> LoadTempData(HttpContext context) => new Dictionary<string, object>();
        public void SaveTempData(HttpContext context, IDictionary<string, object> values) { }
    }
}