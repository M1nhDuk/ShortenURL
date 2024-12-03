using Microsoft.EntityFrameworkCore;

namespace ShortenURL.Service
{
    public class UrlShorteningService
    {
        public const int NumberOfCharInShortLink = 7;
        private const string Alphabet = " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private readonly Random _random = new ();
        private readonly ApplicationDbContext _dbcontext;

        public UrlShorteningService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<string> GenerateUniqueCode()
        {
            //Array store shorten link name
            var codeChars = new char[NumberOfCharInShortLink];

            while (true)
            {
                //Loop to genrate short Url
                for (var i = 0; i < NumberOfCharInShortLink; i++)
                {
                    var RandomIndex = _random.Next(Alphabet.Length);

                    codeChars[i] = Alphabet[RandomIndex];
                }

                var code = new string(codeChars);

                if (!await _dbcontext.ShortenedUrls.AnyAsync(s => s.Code == code))
                {
                    return code;
                }
            }

            
        }
    }
}
