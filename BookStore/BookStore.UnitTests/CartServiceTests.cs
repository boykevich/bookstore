using System.Security.Claims;
using BookStore.Components.Models;
using BookStore.Components.Pages;
using BookStore.Data;
using Bunit;
using Bunit.TestDoubles;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.UnitTests;

public class CartPageTests : TestContext
{
    private const string UserId = "test-user";

    public CartPageTests()
    {
        // 1) Set up a fake auth provider that always returns our test user
        Services.AddSingleton<AuthenticationStateProvider>(
            new TestAuthStateProvider(UserId));
    
        // 2) Set up an in-memory DbContext and seed it per-test
        var ctx = TestDbContextFactory.Create();
        Services.AddScoped<ApplicationDbContext>(_ => ctx);
        
        var nav = Services.GetRequiredService<FakeNavigationManager>();
        nav.NavigateTo("/cartpage");
    }

    [Fact]
    public async Task ShowsEmptyMessage_WhenCartIsEmpty()
    {
        // no seeding of items → cart.Items is empty
        var cut = RenderComponent<CartPage>();
        // wait for OnInitializedAsync to complete
        await cut.InvokeAsync(() => Task.CompletedTask);

        // should find the .alert-info with our empty-cart message
        var alert = cut.Find("div.alert-info");
        Assert.Contains("Your cart is empty", alert.TextContent);
    }

    [Fact]
    public async Task ShowsItemsAndTotal_WhenCartHasItems()
    {
        SeedCartWithBooks((1, "Alpha", 5m), (2, "Beta", 7m));
    
        var cut = RenderComponent<CartPage>();
        await cut.InvokeAsync(() => Task.CompletedTask);
    
        // expect two rows in the tbody
        var rows = cut.FindAll("tbody tr");
        Assert.Equal(2, rows.Count);
    
        // check book names and prices appear
        Assert.Contains("Alpha", rows[0].TextContent);
        Assert.Contains("$5.00", rows[0].TextContent);
        Assert.Contains("Beta", rows[1].TextContent);
        Assert.Contains("$7.00", rows[1].TextContent);
    
        // total should be €12.00
        var total = cut.Find("h4").TextContent;
        Assert.Contains("$12.00", total);
    }

    [Fact]
    public async Task RemoveItem_RemovesSingleRow()
    {
        SeedCartWithBooks((1, "One", 3m), (2, "Two", 4m));

        var cut = RenderComponent<CartPage>();
        await cut.InvokeAsync(() => Task.CompletedTask);

        // click the first "Remove" button
        var removeButtons = cut.FindAll("button")
                               .Where(b => b.TextContent.Contains("Remove"))
                               .ToArray();
        removeButtons[0].Click();
        await cut.InvokeAsync(() => Task.CompletedTask);

        // now only one row should remain
        var rowsAfter = cut.FindAll("tbody tr");
        Assert.Single(rowsAfter);
        Assert.DoesNotContain("One", rowsAfter[0].TextContent);
        Assert.Contains("Two", rowsAfter[0].TextContent);
    }

    [Fact]
    public async Task ClearCart_RemovesAllRows()
    {
        SeedCartWithBooks((1, "X", 2m), (2, "Y", 8m));

        var cut = RenderComponent<CartPage>();
        await cut.InvokeAsync(() => Task.CompletedTask);

        // click "Clear Cart" (btn-warning)
        cut.Find("button.btn-warning").Click();
        await cut.InvokeAsync(() => Task.CompletedTask);

        // should show empty-cart alert
        var alert = cut.Find("div.alert-info");
        Assert.Contains("Your cart is empty", alert.TextContent);
    }

    // helper to seed two or more books & cart items
    private void SeedCartWithBooks(params (int Id, string Name, decimal Price)[] books)
    {
        var ctx = Services.GetRequiredService<ApplicationDbContext>();

        var cart = new Cart { UserId = UserId };
        ctx.Carts.Add(cart);

        foreach (var (id, name, price) in books)
        {
            var book = new Book { Id = id, BookName = name, Price = price };
            ctx.Books.Add(book);
            ctx.CartItems.Add(new CartItem { Cart = cart, Book = book });
        }
        ctx.SaveChanges();
    }

    // a minimal AuthenticationStateProvider stub
    private class TestAuthStateProvider : AuthenticationStateProvider
    {
        private readonly string _userId;
        public TestAuthStateProvider(string userId) => _userId = userId;

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity(
                new[] { new Claim(ClaimTypes.NameIdentifier, _userId) },
                authenticationType: "test"
            );
            var user = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(user));
        }
    }
}