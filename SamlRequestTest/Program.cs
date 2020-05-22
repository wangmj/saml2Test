using SamlComposer;
using System;
using System.Diagnostics;

namespace SamlRequestTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var ss= DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss:msZ");
            //ss= DateTime.Now.ToUniversalTime().ToString("u");
            //ss = string.Format("{0:u}", DateTime.Now);
            Console.WriteLine(ss);
            Console.WriteLine();

            Console.WriteLine("compose samlrequest test:");
            string res = Composer.GenerateSamlRequest("stress1.0", "https://sts.omr.boc.com/adfs/ls", Guid.NewGuid(), DateTime.Now);
            //string res = Composer.GenerateSamlRequest("https://sts.omr.boc.com", "https://sts.omr.boc.com/adfs/ls",Guid.NewGuid(), DateTime.Now);
            Console.WriteLine(res); 
            Console.WriteLine();

            Console.WriteLine("Decode SamlRequest test:");
            var samlRequest = Composer.EncodeSamlRequest(res);
            Console.WriteLine(samlRequest);
            Console.WriteLine();
            var xmlRequest = Composer.DecodeSamlRequest(samlRequest);
            Console.WriteLine(xmlRequest);

            Debug.Assert(res == xmlRequest);
            Console.WriteLine();

            //Console.WriteLine("Decode SamlResponse test:");
            ////SamlResponse为adfs服务返回的html中的samlResponse的值，示例中用到的字符串是adfs返回的一个错误值，这里仅为验证DecodeSamlResponse方法
            var samlResponse = "PHNhbWxwOlJlc3BvbnNlIElEPSJfZWM1OTdjNzktMWJhZi00NGRkLWJkNTItMmJlMTBkNTZmM2UxIiBWZXJzaW9uPSIyLjAiIElzc3VlSW5zdGFudD0iMjAyMC0wNS0yMlQxMjo0Nzo1OC4yMzVaIiBEZXN0aW5hdGlvbj0iaHR0cHM6Ly9iYWlkdTExMS5jb20vbG9naW4iIENvbnNlbnQ9InVybjpvYXNpczpuYW1lczp0YzpTQU1MOjIuMDpjb25zZW50OnVuc3BlY2lmaWVkIiBJblJlc3BvbnNlVG89Il8wNzJlYTU4M2IwZjQ0YWE3YmZmYjgwZjI3ZGMyNGRiZiIgeG1sbnM6c2FtbHA9InVybjpvYXNpczpuYW1lczp0YzpTQU1MOjIuMDpwcm90b2NvbCI+PElzc3VlciB4bWxucz0idXJuOm9hc2lzOm5hbWVzOnRjOlNBTUw6Mi4wOmFzc2VydGlvbiI+aHR0cDovL3N0cy5vbXIuYm9jLmNvbS9hZGZzL3NlcnZpY2VzL3RydXN0PC9Jc3N1ZXI+PHNhbWxwOlN0YXR1cz48c2FtbHA6U3RhdHVzQ29kZSBWYWx1ZT0idXJuOm9hc2lzOm5hbWVzOnRjOlNBTUw6Mi4wOnN0YXR1czpTdWNjZXNzIiAvPjwvc2FtbHA6U3RhdHVzPjxBc3NlcnRpb24gSUQ9Il9iNWJmOWExNC0zMTBkLTQ3OTItODkxNS1hNTQ1Mjc4YTkyZDAiIElzc3VlSW5zdGFudD0iMjAyMC0wNS0yMlQxMjo0Nzo1OC4yMzVaIiBWZXJzaW9uPSIyLjAiIHhtbG5zPSJ1cm46b2FzaXM6bmFtZXM6dGM6U0FNTDoyLjA6YXNzZXJ0aW9uIj48SXNzdWVyPmh0dHA6Ly9zdHMub21yLmJvYy5jb20vYWRmcy9zZXJ2aWNlcy90cnVzdDwvSXNzdWVyPjxkczpTaWduYXR1cmUgeG1sbnM6ZHM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvMDkveG1sZHNpZyMiPjxkczpTaWduZWRJbmZvPjxkczpDYW5vbmljYWxpemF0aW9uTWV0aG9kIEFsZ29yaXRobT0iaHR0cDovL3d3dy53My5vcmcvMjAwMS8xMC94bWwtZXhjLWMxNG4jIiAvPjxkczpTaWduYXR1cmVNZXRob2QgQWxnb3JpdGhtPSJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNyc2Etc2hhMjU2IiAvPjxkczpSZWZlcmVuY2UgVVJJPSIjX2I1YmY5YTE0LTMxMGQtNDc5Mi04OTE1LWE1NDUyNzhhOTJkMCI+PGRzOlRyYW5zZm9ybXM+PGRzOlRyYW5zZm9ybSBBbGdvcml0aG09Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvMDkveG1sZHNpZyNlbnZlbG9wZWQtc2lnbmF0dXJlIiAvPjxkczpUcmFuc2Zvcm0gQWxnb3JpdGhtPSJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzEwL3htbC1leGMtYzE0biMiIC8+PC9kczpUcmFuc2Zvcm1zPjxkczpEaWdlc3RNZXRob2QgQWxnb3JpdGhtPSJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGVuYyNzaGEyNTYiIC8+PGRzOkRpZ2VzdFZhbHVlPit1VHRKaDFQY2R6MW14bGdJbUVsYUVYV3VIa05jSTgrTEZjOUR3VmdCTm89PC9kczpEaWdlc3RWYWx1ZT48L2RzOlJlZmVyZW5jZT48L2RzOlNpZ25lZEluZm8+PGRzOlNpZ25hdHVyZVZhbHVlPllsQlFyMEdmTkRxRGMyUXJLUHVleHAvVkNWRFNYRXF5RDFzVW1Pd3E5TGlLUVdnTGUwSlFWM3ArdE96VlR2WHE5dUI0WDl0YUlXa2tFcGZ2OG1XY0FVa0R2ZjREQzZEQ3lZUGNmblMyaVZPZ2toUFAvMmFEdk9uL0h6V0YzY1FZd0RLRmQ4ZjNIQVJyS2p1dzNrVHVwYUNWL2xhVlBtZmtpd2ZScUVrUENpNUY5RzBNN2RFZ2thVzBkK2tMRUFmWkthQ1NiSHA5dXUwaGRVemxxY0htNzZZcC9tTnFydjJnMy9jTlkrRWM5cFIvWGp4NlRleitjTHVBZnA5ZUlqOUxxeGNGSXhkK09QWXNFRTVpSVFtSlowcVU2SDd6Q1lDYWtHRnBhQVljM2NuR3RWWkM1djE0c0tvL3I4aGt0czVlZ1E5SEhwUUZOem8xQUZ4Vk02TmdXZz09PC9kczpTaWduYXR1cmVWYWx1ZT48S2V5SW5mbyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC8wOS94bWxkc2lnIyI+PGRzOlg1MDlEYXRhPjxkczpYNTA5Q2VydGlmaWNhdGU+TUlJQzJqQ0NBY0tnQXdJQkFnSVFNTWZRVURmcjFZbEV3MWk2c1AybUt6QU5CZ2txaGtpRzl3MEJBUXNGQURBcE1TY3dKUVlEVlFRREV4NUJSRVpUSUZOcFoyNXBibWNnTFNCemRITXViMjF5TG1Kdll5NWpiMjB3SGhjTk1qQXdOVEl5TURNMU5URTBXaGNOTWpFd05USXlNRE0xTlRFMFdqQXBNU2N3SlFZRFZRUURFeDVCUkVaVElGTnBaMjVwYm1jZ0xTQnpkSE11YjIxeUxtSnZZeTVqYjIwd2dnRWlNQTBHQ1NxR1NJYjNEUUVCQVFVQUE0SUJEd0F3Z2dFS0FvSUJBUUM3aUxmeERPL0NISytNZUo0R0cxUGlFOS9XYW0wUUNYTCtKSDV2VlVIdVhBU2hIQ25lWGljdW9sb1IvTHo0OSt0YnVMZHFVNTNEUXhLdVE0ZjlXYUdCVm1vSUVOY2VLOUZ2QlIvTjc2aEh2dUIzTFUrYk0vK2FnNEdHZWgrRitibk1rVThYL2pvUGVmbUtySVpVM2pNa2FkSFZ1QTZiWW1sOTArWWhTZU1jT1ZGNS9sRTVQRHM0bHRDc1dDeDlQOTNFeXdXRDNkbW1VdW40Mm0xQ092Y3dwU2lCbUpaczQ1MGFBWHpOZUtrbWpWazhSa1hnYkFtQTNJbUkvZWlnR1ZEeXlTMnByUG1MdWlzbnpEWE9wMld0ck5DaS9kZlV5d29DZk9CbWx2T2lHN2ZFOTkwWFNET0tTMCszVlE2eEo2d0RJTzhjVW9aaEFWblVlZk1aalBQRkFnTUJBQUV3RFFZSktvWklodmNOQVFFTEJRQURnZ0VCQUZ2Q1ZpT3MxcVQ0Zk9udzBleDlrR1Bjb0c3U1JJTlNqdzhsTWZlWndBUkQwYVdpdUxvdDlYLzhBR1Z0YWZZNkNRMCtIMWdQcW1jRXJ2RlRsWkJjeUVZM1U2RWtXbG1ZYi8yTVdYRFFYM0ZnbXhLV3RsUi9vc0JvcTlPWlIvNVdNdDNIU2sxWFhId3BDVU1GMEFEaVl4ZGQxYXBmdThxcWh3MVJDeHdIV0pMSmcwbXhmVTg4amhXTTB4YUdzUUVuaGZkUXRuTExWWjNZRjdxc1k0MXNVTWQxZURySVppK3FCRVJkR3d2bDl2US9wSjg3ZmZoWFd0Sy9tMEtFN0tIZ002Vng0cmJRNmZsZllIaFRRMVN3Y0ZaRk1aRHlzNHBLdlpHdCtuVmREN3ZuVFZYZHhncVNXVFFmTU5oM3R5NHk0UjBvSFYvWVlXL2w1aHVSenNmc0VMUT08L2RzOlg1MDlDZXJ0aWZpY2F0ZT48L2RzOlg1MDlEYXRhPjwvS2V5SW5mbz48L2RzOlNpZ25hdHVyZT48U3ViamVjdD48U3ViamVjdENvbmZpcm1hdGlvbiBNZXRob2Q9InVybjpvYXNpczpuYW1lczp0YzpTQU1MOjIuMDpjbTpiZWFyZXIiPjxTdWJqZWN0Q29uZmlybWF0aW9uRGF0YSBJblJlc3BvbnNlVG89Il8wNzJlYTU4M2IwZjQ0YWE3YmZmYjgwZjI3ZGMyNGRiZiIgTm90T25PckFmdGVyPSIyMDIwLTA1LTIyVDEyOjUyOjU4LjIzNVoiIFJlY2lwaWVudD0iaHR0cHM6Ly9iYWlkdTExMS5jb20vbG9naW4iIC8+PC9TdWJqZWN0Q29uZmlybWF0aW9uPjwvU3ViamVjdD48Q29uZGl0aW9ucyBOb3RCZWZvcmU9IjIwMjAtMDUtMjJUMTI6NDc6NTguMjM0WiIgTm90T25PckFmdGVyPSIyMDIwLTA1LTIyVDEzOjQ3OjU4LjIzNFoiPjxBdWRpZW5jZVJlc3RyaWN0aW9uPjxBdWRpZW5jZT5zdHJlc3MxLjA8L0F1ZGllbmNlPjwvQXVkaWVuY2VSZXN0cmljdGlvbj48L0NvbmRpdGlvbnM+PEF0dHJpYnV0ZVN0YXRlbWVudD48QXR0cmlidXRlIE5hbWU9Imh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3VwbiI+PEF0dHJpYnV0ZVZhbHVlPnRlc3RlckBvbXIuYm9jLmNvbTwvQXR0cmlidXRlVmFsdWU+PC9BdHRyaWJ1dGU+PC9BdHRyaWJ1dGVTdGF0ZW1lbnQ+PEF1dGhuU3RhdGVtZW50IEF1dGhuSW5zdGFudD0iMjAyMC0wNS0yMlQxMjo0Nzo1OC4yMzFaIj48QXV0aG5Db250ZXh0PjxBdXRobkNvbnRleHRDbGFzc1JlZj51cm46ZmVkZXJhdGlvbjphdXRoZW50aWNhdGlvbjp3aW5kb3dzPC9BdXRobkNvbnRleHRDbGFzc1JlZj48L0F1dGhuQ29udGV4dD48L0F1dGhuU3RhdGVtZW50PjwvQXNzZXJ0aW9uPjwvc2FtbHA6UmVzcG9uc2U+";
            var decodedResponse = Composer.DecodeSamlResponse(samlResponse);
            Console.WriteLine(decodedResponse);
            Console.WriteLine();

            Console.WriteLine("*********end*********");
            Console.Read();
        }
    }
}
