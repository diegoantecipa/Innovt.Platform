﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Innovt.Cloud.File
{
    public interface IFileSystem
    {  
        Task<bool> CopyObject(string sourceBucket, string sourceKey, string destinationBucket, string destinationKey, CancellationToken cancellationToken = default);
       
        void Download(string bucketName, string fileName, string destination);
      
        Stream DownloadStream(string url);
       
        Stream DownloadStream(string bucketName, string fileName);
       
        Task<Stream> DownloadStreamAsync(string url, CancellationToken cancellationToken = default);
       
        Task<Stream> DownloadStreamAsync(string bucketName, string fileName, CancellationToken cancellationToken = default);
       
        (string bucket, string fileKey) ExtractBucketFromGetUrl(string url);
      
        bool FolderExists(string bucketName, string key);
       
        Task<bool> FolderExistsAsync(string bucketName, string key, string region = null, List<KeyValuePair<string, string>> metadata = null, CancellationToken cancellationToken = default);
        
        string GeneratePreSignedURL(string bucketName, string key, DateTime expiration, IDictionary<string, object> additionalProperties);
       
        string GetPreSignedURL(string bucketName, string key, DateTime expires);

        string GetObjectContent(string url, Encoding encoding);
       
        Task<string> GetObjectContentAsync(string url, Encoding encoding, CancellationToken cancellationToken = default);
        
        string PutObject(string bucketName, Stream stream, string fileName,string contentType = null);
       
        string PutObject(string bucketName, string filePath, string contentType = null);
       
        Task<string> PutObjectAsync(string bucketName, Stream stream, string fileName, string contentType = null, CancellationToken cancellationToken = default);
        
        Task<string> PutObjectAsync(string bucketName, string filePath, string contentType = null, CancellationToken cancellationToken = default);
      
        string Upload(string bucketName, Stream stream, string fileName, string region = null, List<KeyValuePair<string, string>> metadata = null);
       
        string Upload(string bucketName, string filePath, string region = null, List<KeyValuePair<string, string>> metadata = null);
       
        Task<string> UploadAsync(string bucketName, Stream stream, string fileName, string region = null, List<KeyValuePair<string, string>> metadata = null, CancellationToken cancellationToken = default);
       
        Task<string> UploadAsync(string bucketName, string filePath, string region = null, List<KeyValuePair<string, string>> metadata = null, CancellationToken cancellationToken = default);
      
        Task UploadDirectoryAsync(string bucketName, string directory, CancellationToken cancellationToken = default);

        Task<bool> DeleteObjectAsync(string bucketName, string key, CancellationToken cancellationToken = default);

        bool DeleteObject(string bucketName, string key);
    }
}