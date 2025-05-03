using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Amazon.S3;
using Amazon.S3.Model;
using BookStore.Data;

[Authorize]
[Route("pdf")]
public class PdfController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IAmazonS3 _s3;
    private const string BucketName = "bookstore-media228";

    public PdfController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IAmazonS3 s3)
    {
        _context = context;
        _userManager = userManager;
        _s3 = s3;
    }

    [HttpGet("{bookId:int}")]
    public async Task<IActionResult> GetPdf(int bookId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Unauthorized();

        var hasPurchased = await _context.PurchasedBooks
            .AnyAsync(p => p.BookId == bookId && p.UserId == user.Id);

        if (!hasPurchased) return Forbid();

        var pdf = await _context.PdfBooks.FirstOrDefaultAsync(pb => pb.BookId == bookId);
        if (pdf == null) return NotFound();

        var key = pdf.FilePath.TrimStart('/');
        var request = new GetPreSignedUrlRequest
        {
            BucketName = BucketName,
            Key = key,
            Expires = DateTime.UtcNow.AddSeconds(20)
        };

        var url = _s3.GetPreSignedURL(request);
        return Redirect(url);
    }
}
