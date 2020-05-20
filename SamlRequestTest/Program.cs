﻿using SamlComposer;
using System;
using System.Diagnostics;

namespace SamlRequestTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("compose samlrequest test:");
            string res = Composer.GenerateSamlRequest("urn:bocsso:bops_boms_kbm", Guid.NewGuid(), DateTime.Now);
            Console.WriteLine(res); 
            Console.WriteLine();

            Console.WriteLine("Decode SamlRequest test:");
            var samlRequest = Composer.EncodeSamlRequest(res);
            var xmlRequest = Composer.DecodeSamlRequest(samlRequest);
            Console.WriteLine(xmlRequest);

            Debug.Assert(res == xmlRequest);
            Console.WriteLine();

            Console.WriteLine("Decode SamlResponse test:");
            //SamlResponse为adfs服务返回的html中的samlResponse的值，示例中用到的字符串是adfs返回的一个错误值，这里仅为验证DecodeSamlResponse方法
            var samlResponse = "PHNhbWxwOlJlc3BvbnNlIElEPSJfZTA2MGIxYzItM2E3NC00NDU0LTk2MGYtNmFlZjA1OGM4NWUwIiBWZXJzaW9uPSIyLjAiIElzc3VlSW5zdGFudD0iMjAyMC0wNC0yOVQwODoyNjoyMy41NzhaIiBEZXN0aW5hdGlvbj0iaHR0cHM6Ly8yMi4xODguNTMuMTg0OjI1MDA3L2JvY3ZvbE1hbmFnZXIvdmVyaWZ5IiBDb25zZW50PSJ1cm46b2FzaXM6bmFtZXM6dGM6U0FNTDoyLjA6Y29uc2VudDp1bnNwZWNpZmllZCIgSW5SZXNwb25zZVRvPSJfYWRkYjVmNzEyNmRhOTIwMTk2Nzc2OTE1ZTY0YTllNDUiIHhtbG5zOnNhbWxwPSJ1cm46b2FzaXM6bmFtZXM6dGM6U0FNTDoyLjA6cHJvdG9jb2wiPjxJc3N1ZXIgeG1sbnM9InVybjpvYXNpczpuYW1lczp0YzpTQU1MOjIuMDphc3NlcnRpb24iPmh0dHA6Ly9mcy5zLmJvY3N5cy5jbi9hZGZzL3NlcnZpY2VzL3RydXN0PC9Jc3N1ZXI+PGRzOlNpZ25hdHVyZSB4bWxuczpkcz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC8wOS94bWxkc2lnIyI+PGRzOlNpZ25lZEluZm8+PGRzOkNhbm9uaWNhbGl6YXRpb25NZXRob2QgQWxnb3JpdGhtPSJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzEwL3htbC1leGMtYzE0biMiIC8+PGRzOlNpZ25hdHVyZU1ldGhvZCBBbGdvcml0aG09Imh0dHA6Ly93d3cudzMub3JnLzIwMDEvMDQveG1sZHNpZy1tb3JlI3JzYS1zaGEyNTYiIC8+PGRzOlJlZmVyZW5jZSBVUkk9IiNfZTA2MGIxYzItM2E3NC00NDU0LTk2MGYtNmFlZjA1OGM4NWUwIj48ZHM6VHJhbnNmb3Jtcz48ZHM6VHJhbnNmb3JtIEFsZ29yaXRobT0iaHR0cDovL3d3dy53My5vcmcvMjAwMC8wOS94bWxkc2lnI2VudmVsb3BlZC1zaWduYXR1cmUiIC8+PGRzOlRyYW5zZm9ybSBBbGdvcml0aG09Imh0dHA6Ly93d3cudzMub3JnLzIwMDEvMTAveG1sLWV4Yy1jMTRuIyIgLz48L2RzOlRyYW5zZm9ybXM+PGRzOkRpZ2VzdE1ldGhvZCBBbGdvcml0aG09Imh0dHA6Ly93d3cudzMub3JnLzIwMDEvMDQveG1sZW5jI3NoYTI1NiIgLz48ZHM6RGlnZXN0VmFsdWU+VkxPMkRyS0wwd25taDZsQXdkckVraUVURGI3aWdadG0xUldPUDl5WUxRcz08L2RzOkRpZ2VzdFZhbHVlPjwvZHM6UmVmZXJlbmNlPjwvZHM6U2lnbmVkSW5mbz48ZHM6U2lnbmF0dXJlVmFsdWU+RnFPaklIOG8wazdlelIwcXIxQlRKZlNxYVc1S1BZZjVoZm1KUkUwWnNFTXFGSGJUR0xaSjhnYkdKY2ZOVklmWjJ0Z2xOQU5xQ1d0TGtNWVhIWjAzeTB5aHRuOEdZTVZRdE1iaVNvR2QxQy8ydFJRNldmMS85V25lb1Z0bmJFR05xRmkxYzM5TDVvT3Y5N2VsZGJNL3crSy94S0NPa3NvbndSNEQ4VnMrbXIwN0wybEgwWXdYbktiQllXdnVOWjQvVllKenNpeFY0T0JYazYyMi9lcE0rNVE2VzEwWkR5UlpMeFF1TmtGSks5N21ZSVRiVDljeDNXalFlbmlLQmp3d0tCeVpCbjJMZWJzaWZSRFdtMnlqN0JFalNCb2oydloyY1hZQnFnc3BpaXVmeXRZRG54RXpjbXJJTUN6MWtsUVY5bVdoUEM2WVJRQnJYQld1dkNFNFd3PT08L2RzOlNpZ25hdHVyZVZhbHVlPjxLZXlJbmZvIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwLzA5L3htbGRzaWcjIj48ZHM6WDUwOURhdGE+PGRzOlg1MDlDZXJ0aWZpY2F0ZT5NSUlEV2pDQ0FrS2dBd0lCQWdJQ0IwTXdEUVlKS29aSWh2Y05BUUVGQlFBd1NERUxNQWtHQTFVRUJoTUNRMDR4RGpBTUJnTlZCQW9UQlVKUFEwbERNU2t3SndZRFZRUUxFeUJDVDBOSlF5QlNiMjkwSUVObGNuUnBabWxqWVhSbElFRjFkR2h2Y21sMGVUQWVGdzB4TlRFd01UUXdOREF3TURCYUZ3MHpNREV3TVRBd016VTVOVGxhTUZReEN6QUpCZ05WQkFZVEFrTk9NUll3RkFZRFZRUUtFdzFDWVc1cklHOW1JRU5vYVc1aE1RNHdEQVlEVlFRTEV3VkNUME5KUXpFZE1Cc0dBMVVFQXhNVVFVUkdVMU5KUjA0dVV5NUNUME5UV1ZNdVEwNHdnZ0VpTUEwR0NTcUdTSWIzRFFFQkFRVUFBNElCRHdBd2dnRUtBb0lCQVFDLzJZTlNkRVUwSmc0Y3k4bXYzb01HbllQcEp2TGVNV3lHSmVHTjRLTmpMMU5XLzRIcU54WlE1cWpiTVQwNEltNnpjTHBUNWhRZDdBUTZOSFdVaGx0cDUwMkFjMnd3K3RvVFRoRW5wdTlPSWdONFI5dXdaQi9WS3hwbnpLRlZPc0dlMDREU3RDanBnQnJTZ2EzYTZtWERDdUdkK282ZHM2KzZWeVhoKzAwTm1vSG9pUVhNekZ1SG1wbUZjQjdMRWVDZlByUGQzdVQyYVZuUlMzR3lvQ053Y3FSM05oNDlyK1VIVU01MWxaU0tLcVZpRmJISVh5ZXlhaXd4Y2tWTEJKcGc2eW92aEx6T2VkYUdLSEpzNVc3TVdtR0dmVGhPQnlWVXhBelRBZUhZVDlER2VEcEVJdkVxR1UrZmR2ZFRkVzMyU3JIRlBCZDFJWnBzYzBIT0hZMkRBZ01CQUFHalFqQkFNQjBHQTFVZERnUVdCQlRIc0JVSkZBejRFVFNLdlYxOGJxcE5OVzFKc0RBZkJnTlZIU01FR0RBV2dCU2x2OXJ4M2FITDJ3V3B2WnVOZ052M1QzWHQrekFOQmdrcWhraUc5dzBCQVFVRkFBT0NBUUVBZFRHV0VjRnFNaWhLdmNiTk1RbGlPYXJrK2NIdzlnUWJyK0JGdkluaXpkQjVaRXYvNytQMHVicSswQ3k5MWs2aDhFYVNRck85MDRyL2hKRC9QZzJCMDlJSVQxY2dVMDhyRTFmZjFvVCtWdTVOdVFoUjN2aFljWnpKWTlCQU91N1FObEdQSlJsdXJKTTNCNnhOWTBiQjhvMTdMdjlFTVZSU2IyY1hPK0FNb2ZsUEJGQWVDeDB5alJRMnVtZXBwS3VyNjVSaHJrSGg4QjgzT1pHV0cvd1R5VTdRWm5KSU83TWQwUUJYd0ZSRFhFVDJKQzRKOFR4SUxGTVZCVG52TE53V2dnS0MxeGVydWZ5NkdINmRITHZUU0h0UDg2RFlSK25OVHVHT0NVcG8zM2k2VEFMK3BSWnFaOHJvK3o1Mmt6azFMV2RETkhkdW5rNUtCeXc4NE4zV3dBPT08L2RzOlg1MDlDZXJ0aWZpY2F0ZT48L2RzOlg1MDlEYXRhPjwvS2V5SW5mbz48L2RzOlNpZ25hdHVyZT48c2FtbHA6U3RhdHVzPjxzYW1scDpTdGF0dXNDb2RlIFZhbHVlPSJ1cm46b2FzaXM6bmFtZXM6dGM6U0FNTDoyLjA6c3RhdHVzOlJlc3BvbmRlciIgLz48L3NhbWxwOlN0YXR1cz48L3NhbWxwOlJlc3BvbnNlPg==";
            var decodedResponse = Composer.DecodeSamlResponse(samlResponse);
            Console.WriteLine(decodedResponse);
            Console.WriteLine();

            Console.WriteLine("*********end*********");
            Console.Read();
        }
    }
}
