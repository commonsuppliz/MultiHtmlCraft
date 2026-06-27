
using System;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using MultiHtmlCraft.Core;
using System.Threading.Tasks;
using System.Net.Mime;

namespace MultiHtmlCraft.Core
{
    public class ContentBuilder
    {
        public static async Task<CHttpContentDownload> GetCHtttpContentAsync(HttpClient client, string requestUri, string destinationPath, CHttpContentDownload contentDownload, IProgress<(string, CHttpContentDownload)> progress = null, CancellationToken cancellationToken = default)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("enter GetCHtttpContentAsync {0} {1}  ManagedThreadID: {2}", requestUri, destinationPath, System.Threading.Thread.CurrentThread.ManagedThreadId);
            }
            var totalRead = 0L;
            bool hasContentLength = false;
            int ___contentBytesLength= 0;
            int totalBytes = -1;
            try 
            {
                var response = await client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead);

                response.EnsureSuccessStatusCode();
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("GetCHtttpContentAsync  {0} StatusCode {1}  ManagedThreadID: {2}", requestUri, response.StatusCode, System.Threading.Thread.CurrentThread.ManagedThreadId);
                }
                if (response.Content.Headers.ContentLength.HasValue)
                {
                    hasContentLength = true;
                    ___contentBytesLength = (int)response.Content.Headers.ContentLength.Value;
                }
                else
                {
                    hasContentLength = false;
                }
        
          
                var canReportProgress = totalBytes != -1 && progress != null;
                contentDownload.Url = requestUri;
              
                contentDownload.ContentType = string.Format("{0}", response.Content.Headers.ContentType);
                if (response.Content.Headers.LastModified != null)
                {
                    contentDownload.LastModified = response.Content.Headers.LastModified;
                }
             
                /*
                using (var contentHttpDocumentStream = stream, documentFileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                */

                using (var contentHttpDocumentStream = await response.Content.ReadAsStreamAsync(cancellationToken))
                {
                    using (var documentFileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite, 8192, true))
                    {


                        var buffer = new byte[8192];
                        var isMoreToRead = true;
                        var memoryDocumentStream = new MemoryStream();
                        do
                        {
                            //

                            var read = await contentHttpDocumentStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false);
                            if (read == 0)
                            {
                                isMoreToRead = false;

                                if (progress != null && canReportProgress)

                                {
                                    var progressPercentage = (float)totalRead / (float)totalBytes * 100;
                                    contentDownload.Progress = progressPercentage;
                                    if (canReportProgress)
                                    {
                                        progress.Report((requestUri, contentDownload));
                                    }
                                }

                            }
                            else
                            {
                                totalRead += read;
                                if (progress != null && canReportProgress)
                                {
                                    var progressPercentage = (float)totalRead / (float)totalBytes * 100;
                                    contentDownload.Progress = progressPercentage;
                                    if (canReportProgress)
                                    {
                                        progress.Report((requestUri, contentDownload));
                                    }

                                }




                                //  contentDownload.__documentMemStream


                                await documentFileStream.WriteAsync(buffer, 0, read, cancellationToken);




                            }
                        }
                        while (isMoreToRead);
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("GetCHtttpContentAsync  error {0} {1}  ", requestUri, ex.Message);
                }
            }

            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("exit GetCHtttpContentAsync  {0} Total Read : {1}  ", requestUri, totalRead);
            }
            if(!hasContentLength)
            {
                contentDownload.ContentLength = (int)totalRead; 
            }
            else
            {
                contentDownload.ContentLength = ___contentBytesLength;
            }
       
            return contentDownload;


        }

    }
     public class CancellationToken<T1, T2> : IProgress<(string, CHttpContentDownload)>
    {
        public void Report((string, CHttpContentDownload) value)
        {
            System.Diagnostics.Debug.WriteLine($"{value.Item1}  {value.Item2.ContentLength} {value.Item2.Progress}%");
        }
    }
}
